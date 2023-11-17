using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please write your username. It is mandatory")]
        public string Username { get; set; }
        [Display(Name = "Name & Surname")]
        [Required(ErrorMessage = "Please write your name and surname. It is mandatory")]
        public string NameSurname { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please write your password. It is mandatory")]
        public string Password { get; set; }
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Please write your password again. It is mandatory")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "E Mail Address")]
        [Required(ErrorMessage = "Please write your email. It is mandatory")]
        public string Email { get; set; }

    }
}
