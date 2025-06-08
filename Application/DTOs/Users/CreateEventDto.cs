using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Users
{
    public class CreateEventDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Guid UniversityId { get; set; }
    }
}
