using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    #region DbSet
    public DbSet<User> Users { get; set; }
    #endregion
}