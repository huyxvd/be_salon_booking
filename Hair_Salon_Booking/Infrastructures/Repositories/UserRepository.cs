using Application.Interfaces;
using Application.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Infrastructures.Repositories;
public class UserRepository : GenericRepositories<User>, IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context, ICurrentTime timeService, IClaimsService claimsService) : base (context, timeService, claimsService)
    {
        _context = context;
    }

    public async Task<User> GetUserByEmail(string emai)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Email == emai);
    }
}