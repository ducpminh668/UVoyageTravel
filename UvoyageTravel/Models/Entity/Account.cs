using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UvoyageTravel.Models.Entity
{
    public class Account
    {
        public string username { get; set; }
        public string password { get; set; }
        public List<string> Roles { get; set; }
    }
}