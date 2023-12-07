using System.ComponentModel.DataAnnotations;

namespace BlogDemo.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Role Name is required")]
        public string Name { get; set; }
    }
}
