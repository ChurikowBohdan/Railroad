using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class TrainWriteDTO
    {
        public string Name { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
