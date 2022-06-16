using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBookv1.Shared.Models
{
    internal class AuthenticationUserModel
    {
        //NOT USED YET
        //FOR AUTHENTICATION FOR ENTERING THE "ADMIN PORTAL"

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
