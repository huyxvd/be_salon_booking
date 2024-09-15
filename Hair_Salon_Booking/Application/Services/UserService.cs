using Application.Commons;
using Application.Interfaces;
using Application.Utils;
using Application.ViewModels.UserDTO;
using AutoMapper;
using Domain.Entities;
using System.Security.Cryptography;

namespace Application.Services;
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ICurrentTime _currentTime;
    private readonly AppConfiguration _configuration;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, ICurrentTime currentTime, AppConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _currentTime = currentTime;
        _configuration = configuration;
    }

    public async Task<Result<object>> Register(RegisterUserDTO userDTO)
    {
        var isExist = await _unitOfWork.UserRepository.GetUserByEmail(userDTO.Email);

        if (isExist != null)
        {
            return new Result<object>
            {
                Error = 1,
                Message = "Email is exist, please change email.",
                Data = null
            };
        }

        CreatePasswordHash(userDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);

        var user = new User
        {
            Email = userDTO.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            VerificationToken = CreateRandomToken()
        };

        await _unitOfWork.UserRepository.AddAsync(user);
        await _unitOfWork.SaveChangeAsync();

        return new Result<object>
        {
            Error= 0,
            Message = "Register successfully.",
            Data = user
        };
    }

    //Hash password
    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }

    //Create Token
    private string CreateRandomToken()
    {
        return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
    }
}