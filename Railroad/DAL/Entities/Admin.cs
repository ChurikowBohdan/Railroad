namespace Railroad.DAL.Entities
{
    public class Admin : BaseEntity
    {
        public int DiscountValue { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
