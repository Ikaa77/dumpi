using Microsoft.EntityFrameworkCore;
using MoviaCatalogiAPI.Models;

namespace MoviaCatalogiAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}


