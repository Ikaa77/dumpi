using Microsoft.EntityFrameworkCore;
using MoviaCatalogiAPI.Data;
using MoviaCatalogiAPI.Models;
using MovieCatalogWebService.Repositories;  // Ensure this is included
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviaCatalogiAPI.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly LibraryDbContext _context;

        public RatingRepository(LibraryDbContext context)
        {
            _context = context;
        }

        // Get all ratings for a specific movie
        public async Task<IEnumerable<Rating>> GetRatingsByMovieIdAsync(int movieId)
        {
            return await _context.Ratings
                .Where(r => r.MovieId == movieId)
                .ToListAsync();
        }

        // Add a new rating
        public async Task AddRatingAsync(Rating rating)
        {
            await _context.Ratings.AddAsync(rating);
        }
    }
}
