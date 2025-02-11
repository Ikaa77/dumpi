using Microsoft.EntityFrameworkCore;
using MoviaCatalogiAPI.Data;
using MoviaCatalogiAPI.Models;
using MovieCatalogWebService.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviaCatalogiAPI.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly LibraryDbContext _context;

        public MovieRepository(LibraryDbContext context)
        {
            _context = context;
        }

        // Get all movies
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        // Get a single movie by ID
        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);
        }

        // Add a new movie
        public async Task AddMovieAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
        }

        // Update an existing movie
        public async Task UpdateMovieAsync(Movie movie)
        {
            _context.Movies.Update(movie);
        }

        // Delete a movie by ID
        public async Task DeleteMovieAsync(int id)
        {
            var movie = await GetMovieByIdAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
        }
    }
}
