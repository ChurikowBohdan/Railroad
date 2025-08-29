using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class PriceWriteDTO
    {
        public decimal PriceForKGOfCarriageWeight { get; set; }
        public decimal PriceForKilometer { get; set; }
    }
}
