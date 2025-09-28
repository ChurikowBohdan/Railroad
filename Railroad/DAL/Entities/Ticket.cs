using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class Ticket : BaseEntity
    {
        public int TrainRouteId { get; set; }
        public int PriceId { get; set; }
        public int PersonId { get; set; }

        public int DepartureStationId { get; set; }
        public int DestinationStationId { get; set; }

        [Range(0, 100)]
        public double CarriageWeight { get; set; }

        [Range(0, 100)]
        public int Seat { get; set; }

        [Range(0, 1000)]
        public decimal CarriagePrice { get; set; }

        [Range(0, 1000)]
        public decimal RoadPrice { get; set; }

        [Range(0, 1000)]
        public decimal FinalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public TrainRoute TrainRoute { get; set; }

        public Price Price { get; set; }
        public Person Person { get; set; }

    }
}
