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
        public string UserPhone { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public UserModel(int systemId, string userName, string userAddress, string userPhone, string userId, string userEmail, string userPassword)
        {
            SystemId = systemId;
            UserName = userName;
            UserAddress = userAddress;
            UserPhone = userPhone;
            UserId = userId;
            UserEmail = userEmail;
            UserPassword = userPassword;

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserName, "UserName")
                .IsGreaterThan(UserName, 2, "UserName", "User Name is too short")
                .IsLowerThan(UserName, 50, "UserName", "User Name is too long")
            );

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserAddress, "UserAddress")
                .IsGreaterThan(UserAddress, 2, "UserAddress", "User Address is too short")
                .IsLowerThan(UserAddress, 80, "UserAddress", "User Address is too long")
            );

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserPhone, "UserPhone")
                .IsGreaterThan(UserPhone, 2, "UserPhone", "User Phone is too short")
                .IsLowerThan(UserPhone, 80, "UserPhone", "User Phone is too long")
            );

            AddNotifications(new Contract<Notification>()
                .IsNotNullOrEmpty(UserId, "UserId")
            );

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
