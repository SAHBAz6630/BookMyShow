namespace BookMyShow.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime ShowDate { get; set; }
        public int Tickets { get; set; }

        public Movie Movie { get; set; }
        public User User { get; set; }
    }
}
