﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalCalendar.Models
{
    public class RegisterModel
    {
        [DisplayName("Name")]
        [Required]
        public string FullName { get; set; }

        [DisplayName("Email Address")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


    }
}
