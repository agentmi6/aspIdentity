﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppIdentity.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Approved { get; set; }             
    }
}