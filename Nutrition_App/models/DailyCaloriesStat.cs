using System;

namespace Nutrition_App.Models
{
    public class DailyCaloriesStat
    {
        public DateTime Date { get; set; }
        public double TotalCalories { get; set; }
        public int TotalMeals { get; set; }
    }
}