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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Credit>().HasNoKey();
            builder.Entity<MovieKeywords>().HasNoKey();
            builder.Entity<MovieLinks>().HasNoKey();
            builder.Entity<ProductionCountry>().HasNoKey();

            builder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    j => j.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            builder.Entity<Movie>()
                .HasMany(m => m.ProductionCompanies)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MovieProductionCompany",
                    j => j.HasOne<ProductionCompany>().WithMany().HasForeignKey("ProductionCompanyId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            builder.Entity<Movie>()
                .HasMany(m => m.ProductionCountries)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MovieProductionCountry",
                    j => j.HasOne<ProductionCountry>().WithMany().HasForeignKey("ProductionCountryId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            builder.Entity<Movie>()
                .HasMany(m => m.SpokenLanguages)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "MovieSpokenLanguage",
                    j => j.HasOne<SpokenLanguage>().WithMany().HasForeignKey("SpokenLanguageId"),
                    j => j.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

            // builder.Entity<AppUser>()
            //     .HasMany(ur => ur.UserRoles)
            //     .WithOne(u => u.User)
            //     .HasForeignKey(ur => ur.UserId)
            //     .IsRequired();

            // builder.Entity<AppRole>()
            //     .HasMany(ur => ur.UserRoles)
            //     .WithOne(u => u.Role)
            //     .HasForeignKey(ur => ur.RoleId)
            //     .IsRequired();
        }

    }
}