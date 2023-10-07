using MailLibrary.DomainModel;

namespace CMail.ViewModel
{
    public class TokenViewModel
    {
        public bool Status { get; set; } = true;
        public string Message { get; set; } = "";
        public User user { get; set; } = null;
    }
}
