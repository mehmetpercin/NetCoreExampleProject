using Core.Models;
using Entities.Dtos;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> CreateUserAsync(AppUserCreateDto userCreateDto);
    }
}
