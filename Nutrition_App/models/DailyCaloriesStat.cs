using System;

namespace Nutrition_App.Models
{
    // Representa las estadísticas diarias de consumo calórico de un usuario
    public class DailyCaloriesStat
    {
        // Fecha correspondiente al registro de estadísticas
        public DateTime Date { get; set; }

        // Total de calorías consumidas en el día
        public double TotalCalories { get; set; }

        // Cantidad total de comidas registradas en el día
        public int TotalMeals { get; set; }
    }
}