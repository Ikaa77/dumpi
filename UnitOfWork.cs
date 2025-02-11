using MoviaCatalogiAPI.Data;
using MovieCatalogWebService.Repositories;  // Add the correct namespace here
using System.Threading.Tasks;

namespace MoviaCatalogiAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;

        public IMovieRepository MovieRepository { get; }
        public IRatingRepository RatingRepository { get; }

        public UnitOfWork(LibraryDbContext context, IMovieRepository movieRepository, IRatingRepository ratingRepository)
        {
            _context = context;
            MovieRepository = movieRepository;
            RatingRepository = ratingRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
