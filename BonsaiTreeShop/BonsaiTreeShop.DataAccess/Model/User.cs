using Microsoft.AspNetCore.Identity;

namespace BonsaiTreeShop.DataAccess.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;

        public string Address { get; set; } = string.Empty;

        public List<Order> Orders { get; } = new List<Order>();
    }
}