using Flunt.Notifications;
using Flunt.Validations;
using System.ComponentModel.DataAnnotations;


namespace ProjectMarket.Application.Models
{
    
    public class UserModel : Notifiable<Notification>
    {
        [Key]
        public int SystemId { get; set; }
        public string UserName { get; set; }        
        public string UserAddress { get; set; }
        public int UserPhone { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public UserModel(int systemId, string userName, string userAddress, int userPhone, int userId, string userEmail, string userPassword)
        {
            SystemId = systemId;
            UserName = userName;
            UserAddress = userAddress;
            UserPhone = userPhone;
            UserId = userId;
            UserEmail = userEmail;
            UserPassword = userPassword;

            AddNotifications(new Contract<Notification>()
                .IsGreaterThan(UserName, 2, "UserName", "User Name is too short")
                .IsLowerThan(UserName, 50, "UserName", "User Name is too long")
            );

            AddNotifications(new Contract<Notification>()
                .IsGreaterThan(UserAddress, 2, "UserAddress", "User Address is too short")
                .IsLowerThan(UserAddress, 80, "UserAddress", "User Address is too long")
            );

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserPhone.ToString(), "UserPhone", "User phone cannot be empty") // Add a better validation for phone number
            );

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserId.ToString(), "UserId", "User ID cannot be empty")
            );

            AddNotifications(new Contract<Notification>()
                .IsEmail(UserEmail, "Please enter a valid e-mail adress")
                //.IsLowerThan(UserEmail, 30, "UserEmail", "User e-mail is too long") // Just IsEmail should be enough
            );

            AddNotifications(new Contract<Notification>()
                .IsGreaterThan(UserPassword, 7, "UserPassword", "User Password is too short") // Min of 8 chars for secure password. Consider hashing before saving to db
            );

        }
    }

   
    
}
