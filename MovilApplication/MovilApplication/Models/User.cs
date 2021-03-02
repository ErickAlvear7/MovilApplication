using System;
using System.Collections.Generic;
using System.Text;

namespace MovilApplication.Models
{
     public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Password { get; set; }
        public string ImagenPath { get; set; }
    }
}
