using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class Price : BaseEntity
    {
        [Range(0, 1000)]
        public decimal PriceForKGOfCarriageWeight { get; set; }

        [Range(0, 1000)]
        public decimal PriceForKilometer { get; set; }
    }
}
