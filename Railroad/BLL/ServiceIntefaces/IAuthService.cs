using Railroad.BLL.DTOs;
using Railroad.DAL.Entities;

namespace Railroad.BLL.ServiceIntefaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<TokenResponseDTO?> LoginAsync(UserDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO request);
    }
}
