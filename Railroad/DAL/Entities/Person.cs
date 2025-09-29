using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class Person : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [MaxLength(60)]
        public string Country { get; set; }

        [MaxLength(170)]
        public string City { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
