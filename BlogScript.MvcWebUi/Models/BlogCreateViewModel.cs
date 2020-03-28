using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.Models
{
    public class BlogCreateViewModel
    {
        [Display(Name ="Başlık")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Etiketler")]
        [Required]
        public string Tags { get; set; }
        [Display(Name = "Icerik")]
        [Required]
        public string Content { get; set; }
        [Display(Name = "Kategori")]
        [Required]
        public int Categoryid { get; set; }

        [Display(Name = "Kısa Özet")]
        [Required]
        public string Discription { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
