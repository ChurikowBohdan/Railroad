using Railroad.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class CustomerReadDTO
    {
        public int CustomerId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public DateTime BirthDate { get; set; }
        public int DiscountValue { get; init; }
        public string Email { get; init; }
        public DateTime RegistrationDate { get; init; }
        public ICollection<int> TicketsIds { get; init; }
    }
}
