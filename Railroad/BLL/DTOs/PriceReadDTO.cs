using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class PriceReadDTO
    {
        public int Id { get; set; }
        public decimal PriceForKGOfCarriageWeight { get; set; }

        public decimal PriceForKilometer { get; set; }
    }
}
