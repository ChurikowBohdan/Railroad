using Railroad.BLL.DTOs;
using Railroad.DAL.Entities;

namespace Railroad.BLL.ServiceIntefaces
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(LoginWriteDTO request);
        Task<TokenResponseDTO?> LoginAsync(LoginDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO request);
    }
}
