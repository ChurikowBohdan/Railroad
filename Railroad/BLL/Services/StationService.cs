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
                StationCityName = stationDTO.StationCityName,
                StationDistrictName = stationDTO.StationDistrictName,
                NuberOfPlatforms = stationDTO.NuberOfPlatforms
            };

            await _unitOfWork.StationRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.StationRepository.DeleteByIdAsync(id);
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

        public async Task UpdateAsync(int stationId, StationWriteDTO stationWriteDTO)
        {
            var station = await _unitOfWork.StationRepository.GetByIdAsync(stationId);
            var entity = new Station
            {
                Id = station.Id,
                Name = stationWriteDTO.Name,
                StationCityName = stationWriteDTO.StationCityName,
                StationDistrictName = stationWriteDTO.StationDistrictName,
                NuberOfPlatforms = stationWriteDTO.NuberOfPlatforms
            };

            _unitOfWork.StationRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        private StationReadDTO MapToStationReadDTO(Station station) => new StationReadDTO
        {
            StationId = station.Id,
            Name = station.Name,
            StationCityName = station.StationCityName,
            StationDistrictName = station.StationDistrictName,
            NuberOfPlatforms = station.NuberOfPlatforms
        };
    }
}
