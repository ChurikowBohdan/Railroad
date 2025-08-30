using Railroad.DAL.Entities;

namespace Railroad.BLL.DTOs
{
    public class FilteredRouteReadDTO
    {
        public int TrainRouteId { get; set; }
        public int TrainId { get; set; }
        public string RouteName { get; set; }
        public string TrainName { get; set; }

        public string DepartureStationName { get; set; }
        public string DepartureStationCityName { get; set; }
        public string DepartureStationDistrictName { get; set; }
        public DateTime DepatrureTime { get; set; }
        public int DeparturePlatformId { get; set; }

        public string ArrivalStationName { get; set; }
        public string ArrivalStationCityName { get; set; }
        public string ArrivalStationDistrictName { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int ArrivalPlatformId { get; set; }
    }
}
