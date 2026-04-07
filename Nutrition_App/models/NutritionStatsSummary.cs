namespace Nutrition_App.Models
{
    // Modelo que representa un resumen general de estadísticas nutricionales.
    // Agrupa métricas globales calculadas a partir de los registros de comidas.
    public class NutritionStatsSummary
    {
        // Total de registros de comidas en el sistema
        public int TotalMealRecords { get; set; }

        // Cantidad de usuarios que tienen al menos un registro
        public int TotalUsersWithRecords { get; set; }

        // Total de calorías consumidas
        public double TotalCalories { get; set; }

        // Promedio de calorías por registro de comida
        public double AverageCaloriesPerRecord { get; set; }

        // Promedio de calorías por usuario
        public double AverageCaloriesPerUser { get; set; }

        // Total de proteína consumida (gramos)
        public double TotalProtein { get; set; }

        // Total de carbohidratos consumidos (gramos)
        public double TotalCarbs { get; set; }

        // Total de grasa consumida (gramos)
        public double TotalFat { get; set; }
    }
}