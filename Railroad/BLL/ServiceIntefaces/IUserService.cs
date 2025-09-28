using Railroad.BLL.DTOs;

namespace Railroad.BLL.ServiceIntefaces
{
    public interface IUserService : ICrud<UserReadDTO, UserWriteDTO>
    {
    }
}
