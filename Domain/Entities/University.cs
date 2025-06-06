namespace Domain.Entities
{
    public class University
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }



        public ICollection<User> Users { get; set; }
        public ICollection<MealMenu> MealMenus { get; set; }
    }
}
