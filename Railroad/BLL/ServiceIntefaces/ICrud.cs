namespace Railroad.BLL.ServiceIntefaces
{
    public interface ICrud<TDTORead, TDTOWrite>
    {
        Task<IEnumerable<TDTORead>> GetAllAsync();
        Task<TDTORead?> GetByIdAsync(int id);
        Task AddAsync(TDTOWrite data);
        Task UpdateAsync(int id, TDTOWrite data);
        Task DeleteAsync(int id);
    }
}
