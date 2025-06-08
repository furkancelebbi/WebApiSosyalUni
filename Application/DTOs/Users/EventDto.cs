namespace Application.DTOs.Users
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public string UniversityName { get; set; }
        public string CreatedBy { get; set; }
    }

}
