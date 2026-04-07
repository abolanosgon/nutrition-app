namespace Nutrition_App.Models
{
    // Representa la información nutricional calculada para un usuario
    public class NutritionInfo
    {
        // Índice de masa corporal (BMI)
        public double BMI { get; set; }

        // Calorías necesarias para mantenimiento
        public double MaintenanceCalories { get; set; }

        // Calorías objetivo según la meta del usuario
        public double TargetCalories { get; set; }

        // Cantidad de proteína recomendada en gramos
        public double ProteinGrams { get; set; }

        // Cantidad de carbohidratos recomendada en gramos
        public double CarbsGrams { get; set; }

        // Cantidad de grasas recomendada en gramos
        public double FatsGrams { get; set; }
    }
}