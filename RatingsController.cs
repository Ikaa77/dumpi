using Microsoft.AspNetCore.Mvc;
using MoviaCatalogiAPI.Models;
using MoviaCatalogiAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviaCatalogiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ratings/movie/{movieId}
        [HttpGet("movie/{movieId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetRatingsByMovie(int movieId)
        {
            var ratings = await _unitOfWork.RatingRepository.GetRatingsByMovieIdAsync(movieId);
            if (ratings == null)
            {
                return NotFound(new { message = "No ratings found for this movie" });
            }
            return Ok(ratings);
        }

        // POST: api/ratings
        [HttpPost]
        public async Task<ActionResult<Rating>> AddRating(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the associated movie exists
            var movie = await _unitOfWork.MovieRepository.GetMovieByIdAsync(rating.MovieId);
            if (movie == null)
            {
                return BadRequest(new { message = "Invalid Movie ID" });
            }

            await _unitOfWork.RatingRepository.AddRatingAsync(rating);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction(nameof(GetRatingsByMovie), new { movieId = rating.MovieId }, rating);
        }
    }
}
