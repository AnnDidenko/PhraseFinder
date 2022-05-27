using Phrase_Finder.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Phrase_Finder.Application.Infrastructure
{
    public interface IAuthService
    {
        bool DoesUserNameExist(string userName);
        Task<TokenResponseDto> Register(RegistrationRequestDto data);
        TokenResponseDto Authenticate(RegistrationRequestDto data);
        List<UserDto> AllUsers();
        UserDto UserById(int id);
    }
}
