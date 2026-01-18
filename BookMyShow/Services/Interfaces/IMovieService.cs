using BookMyShow.DTOs;
using BookMyShow.Models;

namespace BookMyShow.Services.Interfaces
{
    public interface IMovieService
    {
        void Add(MovieDto dto);
        void Update(int id, MovieDto dto);
        void Delete(int id);
        List<Movie> GetAll();
        Movie GetById(int id);
    }
}
