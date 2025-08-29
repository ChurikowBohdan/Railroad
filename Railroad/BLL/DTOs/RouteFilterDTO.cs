namespace Railroad.BLL.DTOs
{
    public class RouteFilterDTO
    {
        public int DepartureStationId { get; set; }
        public DateTime DepartureDate { get; set; }
        public int DestinationStation { get; set; }
        public DateTime DestinationDate { get; set; }
    }
}
