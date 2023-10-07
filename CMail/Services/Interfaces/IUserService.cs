using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMail.ViewModel;
using MailLibrary.DomainModel;

namespace CMail.Services.Interfaces
{
    public interface IUserService 
    {
        Task<IList<User>> GetUsers(int? id);

        Task<User> Login(LoginViewModel login);

        Task<int> AddUser(User user);

        Task<int> UpdateUser(RegisterViewModel register, int id);
    }
}
