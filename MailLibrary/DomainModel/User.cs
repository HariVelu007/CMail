using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailLibrary.DomainModel
{
    public class User
    {                
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Key]
        [Required]
        [MaxLength(50)]
        public string UserMailID { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public byte[] Password { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }
        [Required]
        [MaxLength(20)]
        public string Country { get; set; }
        [Required]
        [MaxLength(10)]
        public string Mobile { get; set; }        
        public int NoOfFailedAttempt { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
    }
}
