using Application.Utils;
using Application.ViewModels.UserDTO;

namespace Application.Interfaces;
public interface IUserService
{
    Task<Result<object>> Register(RegisterUserDTO userDTO);
}