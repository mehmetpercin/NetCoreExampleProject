using Entities.Concrete;
using Entities.Dtos;

namespace Business.Interfaces
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
    }
}
