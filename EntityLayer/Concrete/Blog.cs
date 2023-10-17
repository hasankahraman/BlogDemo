using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string ImageThumbnail { get; set; }
        public bool Status { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.Now.ToShortDateString());

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int? WriterId { get; set; }
        public Writer? Writer { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
