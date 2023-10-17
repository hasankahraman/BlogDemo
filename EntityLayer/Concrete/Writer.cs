using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.Now.ToShortDateString());
        public List<Blog>? Blogs { get; set; }
    }
}
