using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;
using System.Threading.Tasks;

namespace Railroad.BLL.Services
{
    public class TrainRouteService : ITrainRouteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainRouteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(TrainRouteWriteDTO trainRouteWriteDTO)
        {
            var routePoints = await _unitOfWork.RoutePointRepository.GetAllWithDetailsAsync();
            var train = await _unitOfWork.TrainRepository.GetByIdAsync(trainRouteWriteDTO.TrainId);

            if (train != null)
            {
                var entity = new TrainRoute
                {
                    Name = trainRouteWriteDTO.Name,
                    Train = train,
                    RoutePoints = routePoints.Where(x => trainRouteWriteDTO.RoutePointsIds.Contains(x.Id)).ToList()
                };
                await _unitOfWork.TrainRouteRepository.AddAsync(entity);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TrainRouteRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TrainRouteReadDTO>> GetAllAsync()
        {
            var trainRoutes = await _unitOfWork.TrainRouteRepository.GetAllWithDetailsAsync();
            return trainRoutes.Select(route => MapToTrainRouteReadDTO(route));
        }

        public async Task<TrainRouteReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.TrainRouteRepository.GetByIdWithDetailsAsync(id);
                if (entity != null)
                {
                    return MapToTrainRouteReadDTO(entity);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int id, TrainRouteWriteDTO trainRouteWriteDTO)
        {
            var trainRoute = await _unitOfWork.TrainRouteRepository.GetByIdWithDetailsAsync(id);
            var train = await _unitOfWork.TrainRepository.GetByIdAsync(trainRouteWriteDTO.TrainId);
            var routePoints = await _unitOfWork.RoutePointRepository.GetAllWithDetailsAsync();
            if (train != null)
            {
                trainRoute.Name = trainRouteWriteDTO.Name;
                trainRoute.TrainId = trainRouteWriteDTO.TrainId;
                trainRoute.RoutePoints = routePoints.Where(x => trainRouteWriteDTO.RoutePointsIds.Contains(x.Id)).ToList();

                await _unitOfWork.SaveAsync();
            }
        }

        private TrainRouteReadDTO MapToTrainRouteReadDTO(TrainRoute trainRoute) => new TrainRouteReadDTO
        {
            TrainRouteId = trainRoute.Id,
            TrainId = trainRoute.Id,
            Name = trainRoute.Name,
            RoutePointsIds = trainRoute.RoutePoints.Select(t => t.Id).ToList()
        };
    }
}
