using Domain.Entities;

namespace Application.Repositories;
public interface IUserRepository : IGenericRepository<User>
{
    Task<User> GetUserByEmail(string email);
}