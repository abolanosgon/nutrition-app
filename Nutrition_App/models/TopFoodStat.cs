namespace Nutrition_App.Models
{
    // Modelo que representa estadísticas de los alimentos más consumidos.
    // Se utiliza para mostrar rankings o "top" de consumo.
    public class TopFoodStat
    {
        // Nombre del alimento
        public string FoodName { get; set; } = "";

        // Cantidad de veces que el alimento fue consumido
        public int TimesConsumed { get; set; }

        // Cantidad total consumida del alimento
        public double TotalQuantity { get; set; }

        // Total de calorías aportadas por ese alimento
        public double TotalCalories { get; set; }
    }
}