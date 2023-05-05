using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyFirstAzureWebApp.Models
{
    public partial class User
    {
        public User()
        {

        }
        public User(string userLogin, string userPassword)
        {
            UserLogin = userLogin;
            UserPassword = userPassword;
        }
        //[Key]
        public int UserId { get; set; }
        public string UserLogin { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
    }
}
