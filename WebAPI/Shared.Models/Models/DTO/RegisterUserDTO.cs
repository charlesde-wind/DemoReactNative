﻿using System.ComponentModel.DataAnnotations;

namespace AuthProvider.Models.DTO
{
    public class RegisterUserDTO
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}