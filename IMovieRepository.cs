using MoviaCatalogiAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieCatalogWebService.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task AddMovieAsync(Movie movie);  // Added method for adding movie
        Task UpdateMovieAsync(Movie movie);
        Task DeleteMovieAsync(int id);
    }
}
