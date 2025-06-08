namespace Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Guid UniversityId { get; set; }
        public University University { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
