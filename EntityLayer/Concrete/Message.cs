using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Parse(DateTime.Now.ToString());
        public bool Status { get; set; } = true;

        public AppUser FromUser { get; set; }
        public AppUser ToUser { get; set; }
    }
}
