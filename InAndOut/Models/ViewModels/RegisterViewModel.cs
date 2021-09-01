using InAndOut.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailValide",controller:"Account")]
        [ValidEmailDomain(ErrorMessage = "Email must be one of the popular email websites like: gmail.com")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare(nameof(Password),ErrorMessage ="Make sure that password fields are the same")]
        public string ConfirmPassword { get; set; }


    }
}
