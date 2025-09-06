using Azure.Identity;

namespace Railroad.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Customer? Customer { get; set; }
        public Admin? Admin { get; set; }
        public string? RefrestToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
