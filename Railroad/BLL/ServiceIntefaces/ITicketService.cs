using Railroad.BLL.DTOs;

namespace Railroad.BLL.ServiceIntefaces
{
    public interface ITicketService : ICrud<TicketReadDTO, TicketWriteDTO>
    {
    }
}
