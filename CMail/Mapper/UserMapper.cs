using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailLibrary.DomainModel;
using CMail.ViewModel;

namespace CMail.Mapper
{
    public static class UserMapper
    {
        public static User ToModel(this RegisterViewModel viewModel)
        {
            User user = new User()
            {
                UserMailID = viewModel.UserMailID,
                UserName = viewModel.UserName,
                Gender = viewModel.Gender,                
                Country = viewModel.Country,
                Mobile = viewModel.Mobile,
                IsActive = viewModel.IsActive,
                IsLocked = viewModel.IsActive,
                NoOfFailedAttempt = viewModel.NoOfFailedAttempt
            };
            return user;
        }
    }
}
