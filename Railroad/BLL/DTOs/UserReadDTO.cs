using Railroad.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class UserReadDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public string Role { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
