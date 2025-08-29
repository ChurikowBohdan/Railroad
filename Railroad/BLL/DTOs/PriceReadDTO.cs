using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class PriceReadDTO
    {
        public int PriceId { get; set; }
        public decimal PriceForKGOfCarriageWeight { get; set; }
        public decimal PriceForKilometer { get; set; }
    }
}
