using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RERERE.Data
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        
        public string AuthorEmail { get; set; }
        
        public string Content { get; set; }
        
        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }

    }
}
