using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CMail.ViewModel
{
    public class AccountViewModel
    {
        [EmailAddress(ErrorMessage = "Invalid User ID")]
        [Required(ErrorMessage = "Enter User ID")]
        [StringLength(50, ErrorMessage = "Mail-ID must not exceed 50 character")]
        public string UserMailID { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }
    }

    public class LoginViewModel :AccountViewModel
    {     

    }

    public class RegisterViewModel : AccountViewModel
    {        

        [Required(ErrorMessage = "Enter Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm password not matched")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter User Name")]
        [StringLength(50, ErrorMessage = "User Name must not exceed 50 character")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter User Name")]
        [StringLength(10, ErrorMessage = "Gender must not exceed 10 character")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Enter Country")]
        [StringLength(10, ErrorMessage = "Country must not exceed 10 character")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter Country")]
        [Phone(ErrorMessage = "Invalid Phone number")]
        [StringLength(10, ErrorMessage = "Mobile number must not exceed 10 character")]
        public string Mobile { get; set; }
        public int NoOfFailedAttempt { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }

    public class LoginResponseViewModel
    {
        public string UserMailID { get; set; }
        public string Token { get; set; }
    }

   
}
