namespace Nutrition_App.Models
{
    // Representa un resumen general de estadísticas nutricionales
    public class NutritionStatsSummary
    {
        // Total de registros de comidas
        public int TotalMealRecords { get; set; }

        // Total de usuarios que tienen registros de comidas
        public int TotalUsersWithRecords { get; set; }

        // Total de calorías consumidas
        public double TotalCalories { get; set; }

        // Promedio de calorías por registro de comida
        public double AverageCaloriesPerRecord { get; set; }

        // Promedio de calorías por usuario
        public double AverageCaloriesPerUser { get; set; }

        // Total de proteína consumida
        public double TotalProtein { get; set; }

        // Total de carbohidratos consumidos
        public double TotalCarbs { get; set; }

        // Total de grasas consumidas
        public double TotalFat { get; set; }
    }
}