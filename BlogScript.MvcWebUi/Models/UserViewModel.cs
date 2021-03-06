﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogScript.MvcWebUi.Models
{
    public class UserViewModel
    {
        [Display(Name = "Kullanıcı Adı: ")]
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Parola: ")]
        [StringLength(20,MinimumLength =4)]
        [Required(ErrorMessage ="Lütfen Parolanızı giriniz")]
        public string Password { get; set; }
    }
}
