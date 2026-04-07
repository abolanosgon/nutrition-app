using System;

namespace Nutrition_App.Models
{
    // Modelo que representa estadísticas diarias de consumo calórico.
    // Se utiliza para mostrar el total de calorías y cantidad de comidas por día.
    public class DailyCaloriesStat
    {
        // Fecha del registro (día específico)
        public DateTime Date { get; set; }

        // Total de calorías consumidas en ese día
        public double TotalCalories { get; set; }

        // Cantidad total de comidas registradas en ese día
        public int TotalMeals { get; set; }
    }
}