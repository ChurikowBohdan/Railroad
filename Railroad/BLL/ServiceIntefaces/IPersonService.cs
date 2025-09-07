using Railroad.BLL.DTOs;

namespace Railroad.BLL.ServiceIntefaces
{
    public interface IPersonService : ICrud<PersonReadDTO, PersonWriteDTO>
    {
    }
}
