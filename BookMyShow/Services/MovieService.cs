using BookMyShow.Data;
using BookMyShow.DTOs;
using BookMyShow.Models;
using BookMyShow.Services.Interfaces;

namespace BookMyShow.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public void Add(MovieDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Language = dto.Language,
                Duration = dto.Duration,
                ReleaseDate = dto.ReleaseDate
            };

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(int id, MovieDto dto)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                throw new Exception("Movie not found");

            movie.Title = dto.Title;
            movie.Language = dto.Language;
            movie.Duration = dto.Duration;
            movie.ReleaseDate = dto.ReleaseDate;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
                throw new Exception("Movie not found");

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.Find(id);
        }
    }
}
