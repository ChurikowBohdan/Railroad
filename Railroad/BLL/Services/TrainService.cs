using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class TrainService : ITrainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TrainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(TrainWriteDTO trainDTO)
        {
            var entity = new Train
            {
                Name = trainDTO.Name,
                NumberOfSeats = trainDTO.NumberOfSeats
            };

            await _unitOfWork.TrainRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TrainRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<TrainReadDTO>> GetAllAsync()
        {
            var trains = await _unitOfWork.TrainRepository.GetAllAsync();
            return trains.Select(train => MapToTrainReadDTO(train));
        }

        public async Task<TrainReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.TrainRepository.GetByIdAsync(id);
                if (entity != null)
                {
                    return MapToTrainReadDTO(entity);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int trainId, TrainWriteDTO trainWriteDTO)
        {
            var train = await _unitOfWork.TrainRepository.GetByIdAsync(trainId);
            var entity = new Train
            {
                Id = train.Id,
                Name= trainWriteDTO.Name,
                NumberOfSeats = trainWriteDTO.NumberOfSeats,
            };

            _unitOfWork.TrainRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        private TrainReadDTO MapToTrainReadDTO(Train train) => new TrainReadDTO
        {
            TrainId = train.Id,
            Name = train.Name,
            NumberOfSeats = train.NumberOfSeats
        };
    }
}
