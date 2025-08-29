using System.ComponentModel.DataAnnotations;

namespace Railroad.BLL.DTOs
{
    public class StationReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StationCityName { get; set; }
        public string StationDistrictName { get; set; }
        public int NuberOfPlatforms { get; set; }
    }
}
