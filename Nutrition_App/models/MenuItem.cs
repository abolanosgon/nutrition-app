namespace Nutrition_App.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string MealType { get; set; } = "";
        public double Quantity { get; set; }
    }
}