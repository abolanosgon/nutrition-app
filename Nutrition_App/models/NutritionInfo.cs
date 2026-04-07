namespace Nutrition_App.Models
{
    // Modelo que representa la información nutricional calculada para un usuario.
    // Incluye indicadores físicos y distribución de macronutrientes.
    public class NutritionInfo
    {
        // Índice de Masa Corporal del usuario
        public double BMI { get; set; }

        // Calorías necesarias para mantener el peso actual
        public double MaintenanceCalories { get; set; }

        // Calorías objetivo según el objetivo del usuario (déficit o superávit)
        public double TargetCalories { get; set; }

        // Cantidad de proteína recomendada en gramos
        public double ProteinGrams { get; set; }

        // Cantidad de carbohidratos recomendada en gramos
        public double CarbsGrams { get; set; }

        // Cantidad de grasas recomendada en gramos
        public double FatsGrams { get; set; }
    }
}