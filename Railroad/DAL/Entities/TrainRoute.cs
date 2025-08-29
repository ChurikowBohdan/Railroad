using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class TrainRoute : BaseEntity
    {
        public int TrainId { get; set; }

        [MaxLength(400)]
        public string Name { get; set; }

       
        public Train Train { get; set; }
        public ICollection<RoutePoint> RoutePoints { get; set; }
    }
}
