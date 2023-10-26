using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BlogRating
    {
        [Key]
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int TotalScore { get; set; }
        public int NumberOfRates { get; set; }
        public double AverageRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; } = true;
    }
}
