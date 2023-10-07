using CMail.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailLibrary.DomainModel;
using Microsoft.EntityFrameworkCore;
using CMail.Mapper;
using CMail.Services.Interfaces;
using CMail.Config;

namespace CMail.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly MailContext _context;

        public UserService(MailContext context)
        {
            _context = context;
        }
        public async Task<IList<User>> GetUsers(int? id)
        {   
            if(id!=null)
                return await _context.Users.Where(u=>u.ID==id).ToListAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Login(LoginViewModel login)
        {
            return await _context.Users
                    .Where(u => u.UserMailID == login.UserMailID)
                    .FirstOrDefaultAsync();
        }

        public async Task<int> AddUser(User user)
        {
            //User user = register.ToModel();
            //user.Password = MailLibrary.Helper.MailSecurity.GenerateSalt(user.Password);
            _context.Users.Add(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateUser(RegisterViewModel register,int id)
        {
            User UserView = register.ToModel();
            User user=await _context.Users.FindAsync(id);
            if(user!=null)
            {
                user.Gender = UserView.Gender;
                user.Country = UserView.Country;
                user.Mobile = UserView.Mobile;
                user.IsActive = UserView.IsActive;
                user.NoOfFailedAttempt = UserView.NoOfFailedAttempt;
                user.Password = UserView.Password;
                user.IsLocked = UserView.IsLocked;
            }           
             _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }
    }
}
