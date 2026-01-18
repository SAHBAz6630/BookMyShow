namespace BookMyShow.DTOs
{
    public class MovieDto
    {
        public string Title { get; set; }
        public string Language { get; set; }
        public int Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IFormFile? Image { get; set; }
    }
}
