using Railroad.DAL.Entities;

namespace Railroad.BLL.DTOs
{
    public class UserWriteDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
