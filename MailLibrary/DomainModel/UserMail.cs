using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.DomainModel
{
    public class UserMail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]   
        public string MailUniqueID { get; set; }
     
        [MaxLength(100)]
        public string MailSubject { get; set; }
        public string MailContent { get; set; }
        public bool IsDrafted { get; set; }

        public bool IsScheduled { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<MailViewer> Viewers { get; set; }
        public virtual ICollection<MailAttachment> Attachments { get; set; }
    }
}
