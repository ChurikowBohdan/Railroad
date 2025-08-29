namespace Railroad.BLL.ServiceIntefaces
{
    public interface ICrud<TDTORead, TDTOWrite>
    {
        Task<IEnumerable<TDTORead>> GetAllAsync();
        Task<TDTORead?> GetByIdAsync(int id);
        Task AddAsync(TDTOWrite data);
        Task UpdateAsync(int Id, TDTOWrite data);
        Task DeleteAsync(int id);
    }
}
