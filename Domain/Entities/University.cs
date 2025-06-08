namespace Domain.Entities
{
    public class University
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; } // Düzeltildi


        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<MealMenu> MealMenus { get; set; } = new List<MealMenu>();
    }
}
