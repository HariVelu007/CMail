using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMail.ViewModel
{
    public class MailID
    {
        [EmailAddress(ErrorMessage = "InValid UserID")]
        [StringLength(50, ErrorMessage = "Mail ID must not exceed 50 character")]
        public string UserID { get; set; }
    }
    public class ViewMaildto
    {        

        [Required(ErrorMessage ="Enter sender ID")]
        [EmailAddress(ErrorMessage = "InValid UserID")]
        [StringLength(50, ErrorMessage = "Mail ID must not exceed 50 character")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Enter Receiver ID")]
        public List<MailID> To { get; set; }
        public List<MailID> Cc { get; set; }
        public List<MailID> Bcc { get; set; }
        public List<byte[]> Attachment { get; set; }

        [StringLength(100, ErrorMessage = "Subject must not exceed 100 character")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Enter Body ")]        
        public string MailBody { get; set; }
        public string Type { get; set; }
    }

    public class Maildto : ViewMaildto
    {
        [Required(ErrorMessage ="Mail ID missing")]
        public string MailID { get; set; }
    }

    

    
}
