namespace Railroad.BLL.DTOs
{
    public class TrainRouteWriteDTO
    {
        public int TrainId { get; set; }
        public string Name { get; set; }
        public ICollection<int> RoutePoints { get; set; }
    }
}
