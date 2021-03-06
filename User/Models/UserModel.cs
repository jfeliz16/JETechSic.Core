﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.SIC.Core.User.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }              
        public string Password { get; set; }    
        public string PasswordConfirm { get; set; }
    }
}
