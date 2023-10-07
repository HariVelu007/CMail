using CMail.Services.Interfaces;
using CMail.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace CMail.Security
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MailAuthentication
    {
        private readonly RequestDelegate _next;
        public MailAuthentication(RequestDelegate next)
        {
            _next = next;          
        }

        public Task Invoke(HttpContext httpContext, ITokenService tokenService)
        {

            if (httpContext.GetRouteValue("Controller").ToString() == "Account")
                return _next(httpContext);

            string enctoken= httpContext.Request.Headers["Authorization"];   
            if(enctoken==null || !enctoken.StartsWith("Bearer"))
            {
                httpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
            TokenViewModel model= tokenService.GetUserByToken(enctoken.ToString());           
            if (model==null)
            {
                httpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return Task.CompletedTask;
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email, model.user.UserMailID),
                new Claim(ClaimTypes.Name, model.user.UserName),
                new Claim(ClaimTypes.Gender, model.user.Gender)                
            };
            ClaimsIdentity idendity = new ClaimsIdentity(claims,"BearerAuth");
            ClaimsPrincipal principle = new ClaimsPrincipal(idendity);
            Thread.CurrentPrincipal = principle;
            httpContext.User = principle;            
            
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MailAuthenticationExtensions
    {
        public static IApplicationBuilder UseMailAuthentication(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MailAuthentication>();
        }
    }
}
