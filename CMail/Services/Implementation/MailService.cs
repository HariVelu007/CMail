using CMail.Config;
using CMail.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMail.Services.Interfaces;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using MailLibrary.DomainModel;

namespace CMail.Services.Implementation
{
    public class MailService : IMailService
    {
        private readonly MailContext _context;
        private readonly HttpContext _httpContext;
        private string Userid => _httpContext.User.FindFirstValue(ClaimTypes.Email);
        public MailService(MailContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public Task<int> ComposeMail(ViewMaildto mail)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMail(int Id)
        {
            throw new NotImplementedException();
        }
        public Task<int> ForwardMail(ViewMaildto mail)
        {
            throw new NotImplementedException();
        }
        public Task<int> SaveAsDraft(ViewMaildto mail)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Maildto>> ViewlMails()
        {
            List<Maildto> maildtos = new List<Maildto>();
             await _context.UserMails.Join(
                _context.MailViewers.Where(v => v.MailReceiverID == Userid),
                mail => mail.MailUniqueID,
                viewer => viewer.MailUniqueID,
                (mail, viewer) => mail).ToListAsync();
            return null;
        }
        public async Task<Maildto> ViewMail(int id)
        {
            var mail =await _context.UserMails.Include("MailViewer")
                .Include("MailAttachment")
                .Where(u => u.ID == id).FirstOrDefaultAsync();
            throw new NotImplementedException();

        }
    }
}
