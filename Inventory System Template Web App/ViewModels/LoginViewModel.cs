﻿using System.ComponentModel.DataAnnotations;

namespace Inventory_System_Template_Web_App.ViewModels
{
    public class LoginViewModel
    {       
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
        public string? ReturnUrl { get; set; }        
    }
}

