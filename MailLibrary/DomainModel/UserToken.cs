using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.DomainModel
{
    public class UserToken
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Token { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public DateTime ExpiryDate { get; set; }= DateTime.Now.AddDays(1);
    }
}
