using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User>Users { get; set; }
        public DbSet<Review>Reviews { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmFavorites> FilmFavorites { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Film>().ToTable("Film");
            modelBuilder.Entity<Favorite>().ToTable("Favorite");
            modelBuilder.Entity<FilmFavorites>().ToTable("Film.Favorite");
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Review>().ToTable("Review");

            var userRoleConverter = new EnumToStringConverter<Role>();
            modelBuilder.Entity<User>()
                        .Property(e => e.Role)
                        .HasConversion(userRoleConverter);

            var userStatusConverter = new EnumToStringConverter<StatusUser>();
            modelBuilder.Entity<User>()
                        .Property(e => e.Status)
                        .HasConversion(userStatusConverter);

            modelBuilder.Entity<Favorite>()
                        .HasOne(u => u.User)
                        .WithMany(su => su.Favorites)
                        .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Review>()
                        .HasOne(u => u.User)
                        .WithMany(su => su.Reviews)
                        .HasForeignKey(u=> u.UserId);

            modelBuilder.Entity<Review>()
                        .HasOne(u => u.Film)
                        .WithMany(su => su.ReviewList)
                        .HasForeignKey(u => u.FilmId);

            modelBuilder.Entity<FilmFavorites>()
                        .HasOne(u=>u.Movie)
                        .WithMany(us=>us.filmFavorites)
                        .HasForeignKey(u=>u.MovieId);

            modelBuilder.Entity<FilmFavorites>()
                        .HasOne(u => u.Favorite)
                        .WithMany(us => us.FilmFavorites)
                        .HasForeignKey(u => u.FavoriteId);

            modelBuilder.Entity<Film>()
                        .HasOne(u=>u.Genre)
                        .WithMany(us=>us.films)
                        .HasForeignKey(u=>u.GenreId);

            modelBuilder.Entity<Film>()
                        .Property(f => f.AverageRaiting)
                        .HasColumnType("decimal(2,1)");

            



        }

    }
}
