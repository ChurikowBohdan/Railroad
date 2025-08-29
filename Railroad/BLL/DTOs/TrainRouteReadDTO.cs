using Railroad.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class TrainRouteReadDTO
    {
        public int Id { get; set; }
        public int TrainId { get; set; }
        public string Name { get; set; }
        public ICollection<int> RoutePoints { get; set; }
    }
}
