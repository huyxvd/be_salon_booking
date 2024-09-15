using Application.Interfaces;
using Application.ViewModels.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IActionResult> Register(RegisterUserDTO request)
    {
        var user =  await _userService.Register(request);
        return Ok(user);
    }
}