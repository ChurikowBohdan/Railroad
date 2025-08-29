using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class Train : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, 1000)]
        public int NumberOfSeats { get; set; }
    }
}
