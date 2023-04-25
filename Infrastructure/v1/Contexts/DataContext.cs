using Microsoft.EntityFrameworkCore;
// using Domain.v1.Entities;

namespace Infrastructure.v1.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options: options)
        {

        }

        // public DbSet<Cast> Casts { get; set; }
    }
}