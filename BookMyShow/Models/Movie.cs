namespace BookMyShow.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public int Duration { get; set; } // minutes
        public DateTime ReleaseDate { get; set; }

        public string? ImageUrl { get; set; }
    }
}
