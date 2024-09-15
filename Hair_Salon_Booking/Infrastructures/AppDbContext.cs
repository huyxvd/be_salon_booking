using Microsoft.EntityFrameworkCore;

namespace Infrastructures;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    #region DbSet
    #endregion
}