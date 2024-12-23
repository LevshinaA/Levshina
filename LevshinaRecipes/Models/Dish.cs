namespace LevshinaRecipes.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int CookingTime { get; set; } // Время в минутах
        public string Complexity { get; set; }
        public string Ingredients { get; set; }
        public string Description { get; set; }

        // Метод для бизнес-логики
        public bool IsQuickDish() => CookingTime <= 30; // Быстрое блюдо
    }
}
