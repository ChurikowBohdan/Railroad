using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class Customer : BaseEntity
    {
        [Range(0, int.MaxValue)]
        public int PersonId { get; set; }

        [Range(0, 100)]
        public int DiscountValue { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Role { get; set; } = "Customer";

        public Person Person { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
