﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ENB.Students.Registration.Blazor.DTO.AppUser
{
    public class UserLoginModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
