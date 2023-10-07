using CMail.Config;
using CMail.Services.Interfaces;
using CMail.ViewModel;
using MailLibrary.DomainModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CMail.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly MailContext _context;

        public TokenService(MailContext context)
        {
            _context = context;
        }

        public  string CreateToken(string userid)
        {
            var token = Guid.NewGuid().ToString();
            var encodedToken = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(token));

            UserToken userToken = new UserToken
            {
                UserID=userid,
                Token= token
            };
            _context.userTokens.Add(userToken);
            return _context.SaveChanges()>0? "Bearer "+encodedToken: "";
        }

        public TokenViewModel GetUserByToken(string token)
        {
            TokenViewModel tokenView = new TokenViewModel();
            if (token == "")
            {
                tokenView.Status = false;
                tokenView.Message = "Token Empty";
                return tokenView;
            }
            if (!token.Contains("Bearer"))
            {
                tokenView.Status = false;
                tokenView.Message = "Invalid Token";
                return tokenView;
            }
            var encToken = token.Replace("Bearer ", "");
            var userToken= System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(encToken));

            UserToken uToken= _context.userTokens.Where(t => t.Token == userToken).FirstOrDefault();
            if(uToken.ExpiryDate< DateTime.Now)
            {
                tokenView.Status = false;
                tokenView.Message = "Token Expired";
                return tokenView;
            }
            User user = _context.Users.Where(u => u.UserMailID == uToken.UserID).FirstOrDefault();
            if(user==null)
            {
                tokenView.Status = false;
                tokenView.Message = "User not found";
                return tokenView;
            }
            tokenView.user = user;
            return tokenView;
            
        }
    }
}
