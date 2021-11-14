using Core.Models;
using Entities.Dtos;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuthenticationService
    {
        Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<Response<NoContent>> RevokeRefreshToken(string refreshToken);
    }
}
