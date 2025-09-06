namespace Railroad.DAL.Entities
{
    public class Admin : BaseEntity
    {
        public string Position { get; set; }
        public string Role { get; set; } = "Admin";

        public Person Person { get; set; }
    }
}
