using System.ComponentModel.DataAnnotations;


namespace ProjectMarket.Application.Models
{
    public class UserModel
    {
        [Key]
        public int SystemId { get; set; }
        public string UserName { get; set; }        
        public string UserAddress { get; set; }
        public int UserPhone { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
       
    }
}
