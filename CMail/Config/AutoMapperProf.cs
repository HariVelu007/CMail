using AutoMapper;
using CMail.ViewModel;
using MailLibrary.DomainModel;

namespace CMail.Config
{
    public class AutoMapperProf: Profile
    {
        public AutoMapperProf()
        {
            //CreateMap<Maildto, UserMail>()
            //    .ForMember(dest=> dest.MailSubject,opt=>opt.MapFrom(src=>src.Subject))
            //    .ForMember(dest => dest.MailContent, opt => opt.MapFrom(src => src.MailBody))
            //    .ForMember(dest => dest.Viewers, opt => opt.MapFrom(src => src.To));
        }
    }
}
