using MoviaCatalogiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCatalogWebService.Repositories
{
    public interface IRatingRepository
    {
        Task<IEnumerable<Rating>> GetRatingsByMovieIdAsync(int movieId);
        Task AddRatingAsync(Rating rating);
    }
}

