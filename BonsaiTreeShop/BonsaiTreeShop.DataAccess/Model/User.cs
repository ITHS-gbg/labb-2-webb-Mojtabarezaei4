using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BonsaiTreeShop.DataAccess.Model
{
    public class User : IdentityUser
    {
        [StringLength(30)]
        [Required]
        public string FirstName { get; set; } = null!;

        [StringLength(30)]
        [Required]
        public string LastName { get; set; } = null!;

        [StringLength(30)]
        public string Role { get; set; } = "Customer";
        
        [StringLength(30)]
        public string Address { get; set; } = String.Empty;

        public List<Order> Orders { get; } = new List<Order>();
    }
}