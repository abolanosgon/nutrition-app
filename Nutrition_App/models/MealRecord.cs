namespace Nutrition_App.Models
{
    public class MealRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public DateTime RecordDate { get; set; }
        public string MealType { get; set; } = "";
        public double Quantity { get; set; }
    }
}