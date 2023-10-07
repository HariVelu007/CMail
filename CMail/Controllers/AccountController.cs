using CMail.Services;
using CMail.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using MailLibrary.DomainModel;
using System.Threading.Tasks;
using CMail.ViewModel;
using CMail.Mapper;
using CMail.Services.Interfaces;
using CMail.Security;
using Microsoft.AspNetCore.Authorization;

namespace CMail.Controllers
{  
    
    public class AccountController : BaseController
    {
        private readonly IUserService _user;
        private readonly ITokenService _tokenService;

        public AccountController(IUserService user, ITokenService tokenService)
        {
            _user = user;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ModelResponse<LoginResponseViewModel>> Login(LoginViewModel login)
        {

            ModelResponse<LoginResponseViewModel> response = new ModelResponse<LoginResponseViewModel>();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.Message = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
                    response.Status = false;
                    return response;
                }
                var user =await _user.Login(login);

                if(user==null)
                {
                    response.Status = false;
                    response.Message = "Invalid user";
                    return response;
                }

                var hashedPassword = MailLibrary.Helper.MailSecurity
                    .ComputeHMAC_SHA256(System.Text.Encoding.ASCII.GetBytes(login.Password), user.PasswordSalt);

                response.Status = user.Password != hashedPassword ? false : true;

                response.Message = !response.Status ? "Invalid user" : "Login successfull";

                string token= _tokenService.CreateToken(user.UserMailID);

                response.Data = new LoginResponseViewModel() { UserMailID = user.UserMailID, Token = token };
                
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }

        [HttpPost]
        [Route("Register")]
        public async Task<ModelResponse<User>> Register(RegisterViewModel register)
        {

            ModelResponse<User> response = new ModelResponse<User>();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.Message = ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;
                    response.Status = false;
                    return response;
                }                
                User user = register.ToModel();
                user.PasswordSalt = MailLibrary.Helper.MailSecurity.GenerateSalt();
                user.Password = MailLibrary.Helper.MailSecurity.
                    ComputeHMAC_SHA256(System.Text.Encoding.ASCII.GetBytes(register.Password), user.PasswordSalt);
                int RowsAffected =await _user.AddUser(user);                     
                response.Message = RowsAffected > 0 ? "User Registered successfully" : "User Registration failed";
                response.Status = RowsAffected > 0  ? true : false;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }

        }
    }
}
