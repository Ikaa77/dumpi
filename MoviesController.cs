using Microsoft.AspNetCore.Mvc;
using MoviaCatalogiAPI.Models;
using MoviaCatalogiAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviaCatalogiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            var movies = await _unitOfWork.MovieRepository.GetAllMoviesAsync();
            return Ok(movies);
        }

        // GET: api/movies/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound(new { message = "Movie not found" });
            }
            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> AddMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _unitOfWork.MovieRepository.AddMovieAsync(movie);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        // PUT: api/movies/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest(new { message = "ID mismatch" });
            }

            var existingMovie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);
            if (existingMovie == null)
            {
                return NotFound(new { message = "Movie not found" });
            }

            await _unitOfWork.MovieRepository.UpdateMovieAsync(movie);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        // DELETE: api/movies/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return NotFound(new { message = "Movie not found" });
            }

            await _unitOfWork.MovieRepository.DeleteMovieAsync(id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}
