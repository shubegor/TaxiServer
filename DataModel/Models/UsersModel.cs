﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataModel.Models
{
    public class UsersModel
    {
        [Key]
        
        public string Phone { get; set; }

        
        public string FIO { get; set; }

        public string Email { get; set; }

        public string Auto { get; set; }

        public string AutoNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }
    }
}