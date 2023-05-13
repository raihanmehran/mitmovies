using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.v1.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.v1.Contexts
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, int,
        IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext(DbContextOptions options)
            : base(options: options)
        {
        }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder: builder);

            builder.Entity<AppUser>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<AppRole>()
                .HasMany(ur => ur.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();

            builder.Entity<AppUser>()
                .HasMany(u => u.Photos)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.AppUserId)
                .IsRequired(required: false);

            builder.Entity<AppUser>()
                .HasMany(u => u.FavouriteMovies)
                .WithOne(fm => fm.User)
                .HasForeignKey(fm => fm.AppUserId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(u => u.FavouriteTvShows)
                .WithOne(ft => ft.User)
                .HasForeignKey(ft => ft.AppUserId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(u => u.FavouritePeople)
                .WithOne(fp => fp.User)
                .HasForeignKey(fp => fp.AppUserId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(u => u.WatchedMovies)
                .WithOne(wm => wm.User)
                .HasForeignKey(wm => wm.AppUserId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(u => u.WatchedTvShows)
                .WithOne(wt => wt.User)
                .HasForeignKey(wt => wt.AppUserId)
                .IsRequired(required: false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserGenre>()
                .HasKey(ug => new { ug.AppUserId, ug.GenreId });

            builder.Entity<UserGenre>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGenres)
                .HasForeignKey(ug => ug.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserGenre>()
                .HasOne(ug => ug.Genre)
                .WithMany(g => g.UserGenres)
                .HasForeignKey(ug => ug.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}