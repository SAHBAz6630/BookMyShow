using BookMyShow.DTOs;
using BookMyShow.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // ------------------ Add Movie ------------------
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add([FromBody] MovieDto dto)
        {
            try
            {
                _movieService.Add(dto);
                return Ok(new { message = "Movie added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ------------------ Update Movie ------------------
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MovieDto dto)
        {
            try
            {
                _movieService.Update(id, dto);
                return Ok(new { message = "Movie updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ------------------ Delete Movie ------------------
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _movieService.Delete(id);
                return Ok(new { message = "Movie deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ------------------ Get All Movies ------------------
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var movies = _movieService.GetAll();
                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // ------------------ Get Movie By ID ------------------
        [Authorize(Roles = "Admin,User")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var movie = _movieService.GetById(id);
                if (movie == null)
                    return NotFound(new { message = "Movie not found" });

                return Ok(movie);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
