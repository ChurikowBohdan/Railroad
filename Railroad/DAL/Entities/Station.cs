using System.ComponentModel.DataAnnotations;

namespace Railroad.DAL.Entities
{
    public class Station : BaseEntity
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(170)]
        public string StationCityName { get; set; }

        [MaxLength(200)]
        public string StationDistrictName { get; set;}

        [Range(0, 100)]
        public int NuberOfPlatforms { get; set; }
    }
}
