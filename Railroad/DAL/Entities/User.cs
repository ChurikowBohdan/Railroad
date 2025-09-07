using Azure.Identity;

namespace Railroad.DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string Role { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
