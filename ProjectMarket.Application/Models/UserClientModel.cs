using System.ComponentModel.DataAnnotations;


namespace ProjectMarket.Application.Models
{
    public class UserClientModel
    {
        [Key]
        public int SystemId { get; private set; }
        public string UserName { get; private set; }        
        public string UserAddress { get; private set; }
        public int UserPhone { get; private set; }
        public int UserId { get; private set; }
        public string UserEmail { get; private set; }
        public string UserPassword { get; private set; }
    }
}
