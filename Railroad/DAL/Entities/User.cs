using Azure.Identity;
using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(100)]
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        [MaxLength(100)]
        public string Role { get; set; }
        [Range(0, 100)]
        public int DiscountValue { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
