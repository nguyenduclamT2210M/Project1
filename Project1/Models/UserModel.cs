﻿using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
        public string Tel { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
