﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingLab.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Email Id is required!")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "First Name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Contact No is required!")]
        public decimal ContactNo { get; set; }
    }
}
