using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class RoutePoint : BaseEntity
    {
        public int TrainRouteId { get; set; }
        public int StationId { get; set; }

        public DateTime? ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        [Range(0,100)]
        public int Platform { get; set; }

        [Range(1, 100)]
        public int Order { get; set; }

        [Range(0, 10000)]
        public double DistanceFromPreviousStation { get; set; }

        public TrainRoute TrainRoute { get; set; }
        public Station Station { get; set; }
    }
}
