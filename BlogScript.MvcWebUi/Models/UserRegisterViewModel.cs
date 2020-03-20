using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.Models
{
    public class UserRegisterViewModel
    {
        [StringLength(30,MinimumLength =2)]
        [Display(Name ="Ad: ")]
        [Required]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 2)]
        [Display(Name = "Soyad: ")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Avatar: ")]
        public IFormFile ProfilePhoto { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola: ")]
        public string Password { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        [Display(Name = "Kullanıcı Adı: ")]
        public string UserName { get; set; }
    }
}
