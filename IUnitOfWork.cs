using MovieCatalogWebService.Repositories;
using System.Threading.Tasks;

namespace MoviaCatalogiAPI.Repositories
{
    public interface IUnitOfWork
    {
        IMovieRepository MovieRepository { get; }
        IRatingRepository RatingRepository { get; }
        Task SaveAsync();
    }
}

