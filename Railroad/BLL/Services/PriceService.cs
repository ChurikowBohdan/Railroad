using Railroad.BLL.DTOs;
using Railroad.BLL.ServiceIntefaces;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;

namespace Railroad.BLL.Services
{
    public class PriceService : IPriceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PriceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(PriceWriteDTO priceWriteDTO)
        {
            var entity = new Price
            {
                PriceForKGOfCarriageWeight = priceWriteDTO.PriceForKGOfCarriageWeight,
                PriceForKilometer = priceWriteDTO.PriceForKilometer
            };

            await _unitOfWork.PriceRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.PriceRepository.DeleteByIdAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PriceReadDTO>> GetAllAsync()
        {
            var prices = await _unitOfWork.PriceRepository.GetAllAsync();
            return prices.Select(price => MapToPriceReadDTO(price));
        }

        public async Task<PriceReadDTO?> GetByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await _unitOfWork.PriceRepository.GetByIdAsync(id);
                if (entity != null)
                {
                    return MapToPriceReadDTO(entity);
                }
            }
            return null;
        }

        public async Task UpdateAsync(int id, PriceWriteDTO priceWriteDTO)
        {
            var price = await _unitOfWork.PriceRepository.GetByIdAsync(id);
            price.PriceForKGOfCarriageWeight = priceWriteDTO.PriceForKGOfCarriageWeight;
            price.PriceForKilometer = priceWriteDTO.PriceForKilometer;

            await _unitOfWork.SaveAsync();
        }

        private PriceReadDTO MapToPriceReadDTO(Price price) => new PriceReadDTO
        {
            PriceId = price.Id,
            PriceForKGOfCarriageWeight = price.PriceForKGOfCarriageWeight,
            PriceForKilometer = price.PriceForKilometer,
        };
    }
}
