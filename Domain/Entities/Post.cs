namespace Domain.Entities
{
    public class Post
    {
        public enum PostType
        {
            General,
            Note,
            Event
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }



        public User User { get; set; }
    }
}
