using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnimeFlix.Models
{
    public class ManageAnime
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name = "Anime Title")]
        public string titleAnime { get; set; }
        [Required]
        [Display(Name = "Anime Iframe Source")]
        public string src { get; set; }
        [Required]
        [Display(Name = "Anime Studio Name")]
        public string studion { get; set; }
        [Required]
        [Display(Name = "Anime Author Name")]
        public string author { get; set; }
        [Required]
        [Display(Name = "Anime Description")]
        public string descriptionAnime { get; set; }
        [Required]
        [Display(Name = "Anime Rating")]
        public int ratingAnime { get; set; }
        [Required]
        [Display(Name = "Anime Image Url")]
        public string imgAnime { get; set; }
        [Required]
        [Display(Name = "Anime Trailer")]
        public string trailerAnime { get; set; }
        [Required]
        [Display(Name = "Anime Runtime")]
        public string runtime { get; set; }
        [Required]
        [Display(Name = "Anime Category Name")]
        public int categoryid { get; set; }

        [ForeignKey("categoryid")]
        public CategoryAnime categoryAnime { get; set; }
    }
}
