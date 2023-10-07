using CMail.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMail.Services.Interfaces
{
    interface IMailService
    {
        public Task<Maildto> ViewMail(int id);
        public Task<int> ComposeMail(ViewMaildto mail);
        public Task<int> ForwardMail(ViewMaildto mail);
        public Task<int> SaveAsDraft(ViewMaildto mail);
        public Task<int> DeleteMail(int Id);
    }
}
