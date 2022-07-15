using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMarket.Application.Models
{
    public class LoginModel : Notifiable<Notification>
    {

        public string UserEmail { get; set; }
        public string UserPassword { get; set; }



        public LoginModel(string userEmail, string userPassword)
        {
            UserEmail = userEmail;
            UserPassword = userPassword;

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserEmail, "UserEmail")
                .IsEmail(UserEmail, "Please enter a valid e-mail adress")

            );

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserPassword, "UserPassword")
                .IsGreaterThan(UserPassword, 8, "UserPassword", "User Password is too short")
            );
        }

        
    }
}
