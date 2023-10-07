using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.DomainModel
{
    public class MailAttachment
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]       
        public string MailUniqueID { get; set; }
        [Required]
        [MaxLength(100)]
        public string FileName { get; set; }
        [Required]
        [MaxLength(10)]
        public string FileType { get; set; }
        [Required]
        public decimal FileSize { get; set; }
        [Required]
        public byte[] AttchmentFile { get; set; }

        public virtual UserMail UserMail { get; set; }
    }
}
