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
                .IsLowerThan(UserName, 50, "UserName", "User Name is too long")
                .IsGreaterThan(UserName, 2, "UserName", "User Name is too short")
                .IsLowerThan(UserName, 80, "UserAddress", "User Address is too long")
                .IsGreaterThan(UserAddress, 2, "UserAddress", "User Address is too short")
                .IsGreaterThan(UserPhone, 2, "UserPhone", "User Phone is too short")
                .IsGreaterThan(UserId, 2, "UserId", "User ID is too short")
                .IsEmail(UserEmail, "Please enter a valid e-mail adress")
                .IsLowerThan(UserEmail, 30, "UserEmail", "User e-mail is too long")
                .IsGreaterThan(UserPassword, 2, "UserPassword", "User Password is too short")
                .IsLowerThan(UserPassword, 50, "UserPassword", "User Password is too long")
                );         
            
        }
    }

   
    
}
