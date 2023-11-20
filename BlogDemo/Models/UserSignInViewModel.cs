using DocumentFormat.OpenXml.Wordprocessing;
using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class UserSignInViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please write your username. It is mandatory")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please write your password. It is mandatory")]
        public string Password { get; set; }
    }
}
