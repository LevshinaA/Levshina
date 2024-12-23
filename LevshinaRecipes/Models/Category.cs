namespace LevshinaRecipes.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Метод для бизнес-логики
        public string GetCategoryInfo() => $"Категория: {Name} (ID: {Id})";
    }

}
