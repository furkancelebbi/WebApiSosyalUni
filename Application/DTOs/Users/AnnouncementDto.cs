namespace Application.DTOs.Users
{
    public record CreateAnnouncementDto(string Title, string Content);
    public record AnnouncementDto(Guid Id, string Title, string Content, DateTime CreatedAt);
}
