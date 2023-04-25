using Domain.v1.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options: options)
        {
        }

        public DbSet<Cast> Casts { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCollection> MovieCollections { get; set; }
        public DbSet<MovieKeywords> MovieKeywords { get; set; }
        public DbSet<MovieLinks> MovieLinks { get; set; }
        public DbSet<ProductionCompany> ProductionCompanies { get; set; }
        public DbSet<ProductionCountry> ProductionCountries { get; set; }
        public DbSet<UserRating> Ratings { get; set; }
        public DbSet<SpokenLanguage> SpokenLanguages { get; set; }

    }
}