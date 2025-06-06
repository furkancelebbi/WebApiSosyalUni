namespace Domain.Entities
{
    public class RankLog
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int OldRank { get; set; }
        public int NewRank { get; set; }

        public DateTime ChangedAt { get; set; }

    }
}
