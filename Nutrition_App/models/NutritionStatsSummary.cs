namespace Nutrition_App.Models
{
    public class NutritionStatsSummary
    {
        public int TotalMealRecords { get; set; }
        public int TotalUsersWithRecords { get; set; }
        public double TotalCalories { get; set; }
        public double AverageCaloriesPerRecord { get; set; }
        public double AverageCaloriesPerUser { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbs { get; set; }
        public double TotalFat { get; set; }
    }
}