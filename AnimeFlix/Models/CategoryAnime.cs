using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AnimeFlix.Models
{
    public class CategoryAnime
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
