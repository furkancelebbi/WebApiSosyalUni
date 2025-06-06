namespace Domain.Entities
{
    public class MealMenu
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public String Meals { get; set; }


        public Guid UniversityId { get; set; }


        public University University { get; set; }
    }
}
