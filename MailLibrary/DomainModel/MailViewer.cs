using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.DomainModel
{
    public class MailViewer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        
        public string MailUniqueID { get; set; }

        [Required]
        [MaxLength(10)]
        public MailType MailType { get; set; }

        [Required]
        [MaxLength(50)]
        public string MailReceiverID { get; set; }

        public bool IsReaded { get; set; }
        public DateTime ReadTime { get; set; }
        public bool IsDeleted { get; set; }

        public virtual UserMail UserMail { get; set; }
    }
}
