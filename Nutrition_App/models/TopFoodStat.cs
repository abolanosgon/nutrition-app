namespace Nutrition_App.Models
{
    // Representa estadísticas de consumo para un alimento específico
    public class TopFoodStat
    {
        // Nombre del alimento
        public string FoodName { get; set; } = "";

        // Cantidad de veces que fue consumido
        public int TimesConsumed { get; set; }

        // Cantidad total consumida del alimento
        public double TotalQuantity { get; set; }

        // Total de calorías consumidas de este alimento
        public double TotalCalories { get; set; }
    }
}