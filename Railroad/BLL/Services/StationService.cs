using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class StationService : IStationService
    {

        private readonly IUnitOfWork _unitOfWork;
        public StationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(StationWriteDTO stationDTO)
        {
            var entity = new Station
            {
                Name = stationDTO.Name,
                CityName = stationDTO.StationCityName,
                DistrictName = stationDTO.StationDistrictName,
                NuberOfPlatforms = stationDTO.NuberOfPlatforms
            };

            await _unitOfWork.StationRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.StationRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<StationReadDTO>> GetAllAsync()
        {
            var stations = await _unitOfWork.StationRepository.GetAllAsync();
            return stations.Select(station => MapToStationReadDTO(station));
        }

        public async Task<StationReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.StationRepository.GetByIdAsync(id);
                if (entity != null)
                {
                    return MapToStationReadDTO(entity);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int id, StationWriteDTO stationWriteDTO)
        {
            var station = await _unitOfWork.StationRepository.GetByIdAsync(id);

            station.Name = stationWriteDTO.Name;
            station.CityName = stationWriteDTO.StationCityName;
            station.DistrictName = stationWriteDTO.StationDistrictName;
            station.NuberOfPlatforms = stationWriteDTO.NuberOfPlatforms;

            await _unitOfWork.SaveAsync();
        }

        private StationReadDTO MapToStationReadDTO(Station station) => new StationReadDTO
        {
            StationId = station.Id,
            Name = station.Name,
            StationCityName = station.CityName,
            StationDistrictName = station.DistrictName,
            NuberOfPlatforms = station.NuberOfPlatforms
        };
    }
}
