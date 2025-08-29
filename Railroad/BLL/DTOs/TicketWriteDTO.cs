namespace Railroad.BLL.DTOs
{
    public class TicketWriteDTO
    {
        public int TrainRouteId { get; set; }
        public int PricesId { get; set; }
        public int CustomerId { get; set; }
        public int DepartureStationId { get; set; }
        public int DestinationStationId { get; set; }
        public double CarriageWeight { get; set; }
        public int Seat { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
