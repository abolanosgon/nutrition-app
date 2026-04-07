using System;
using Nutrition_App.Models;

namespace Nutrition_App.Services
{
    // Servicio encargado de calcular la información nutricional del usuario.
    // Calcula IMC, calorías de mantenimiento, calorías objetivo y macronutrientes.
    public class NutritionService
    {
        // Calcula toda la información nutricional a partir de los datos del usuario
        public NutritionInfo CalculateNutritionInfo(User user)
        {
            // Valida que el usuario exista
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            double bmi = CalculateBMI(user.Weight, user.Height);
            double maintenanceCalories = CalculateMaintenanceCalories(user);
            double targetCalories = CalculateTargetCalories(maintenanceCalories, user.Goal);

            double proteinGrams;
            double carbsGrams;
            double fatsGrams;

            // Calcula la distribución de macronutrientes según calorías objetivo y tipo de dieta
            CalculateMacros(
                targetCalories,
                user.DietType,
                out proteinGrams,
                out carbsGrams,
                out fatsGrams
            );

            // Devuelve el resultado redondeado
            return new NutritionInfo
            {
                BMI = Math.Round(bmi, 2),
                MaintenanceCalories = Math.Round(maintenanceCalories, 2),
                TargetCalories = Math.Round(targetCalories, 2),
                ProteinGrams = Math.Round(proteinGrams, 2),
                CarbsGrams = Math.Round(carbsGrams, 2),
                FatsGrams = Math.Round(fatsGrams, 2)
            };
        }

        // Calcula el índice de masa corporal
        private static double CalculateBMI(double weight, double heightInCm)
        {
            double heightInMeters = heightInCm / 100.0;
            return weight / (heightInMeters * heightInMeters);
        }

        // Calcula las calorías de mantenimiento usando metabolismo basal y nivel de actividad
        private static double CalculateMaintenanceCalories(User user)
        {
            double bmr;

            // Fórmula distinta según género
            if (user.Gender == "Male")
            {
                bmr = 10 * user.Weight + 6.25 * user.Height - 5 * user.Age + 5;
            }
            else
            {
                bmr = 10 * user.Weight + 6.25 * user.Height - 5 * user.Age - 161;
            }

            double activityMultiplier = GetActivityMultiplier(user.ActivityLevel);

            return bmr * activityMultiplier;
        }

        // Devuelve el multiplicador correspondiente al nivel de actividad
        private static double GetActivityMultiplier(string activityLevel)
        {
            switch (activityLevel)
            {
                case "Sedentary":
                    return 1.2;
                case "Light":
                    return 1.375;
                case "Moderate":
                    return 1.55;
                case "Active":
                    return 1.725;
                default:
                    return 1.2;
            }
        }

        // Calcula las calorías objetivo según el objetivo del usuario
        private static double CalculateTargetCalories(double maintenanceCalories, string goal)
        {
            switch (goal)
            {
                case "LoseFat":
                    return maintenanceCalories - 500;
                case "GainMuscle":
                    return maintenanceCalories + 300;
                case "Maintain":
                default:
                    return maintenanceCalories;
            }
        }

        // Calcula gramos de proteína, carbohidratos y grasas según dieta y calorías objetivo
        private static void CalculateMacros(
            double targetCalories,
            string dietType,
            out double proteinGrams,
            out double carbsGrams,
            out double fatsGrams)
        {
            double proteinPercentage;
            double carbsPercentage;
            double fatsPercentage;

            // Distribución de macronutrientes según el tipo de dieta
            switch (dietType)
            {
                case "Keto":
                    proteinPercentage = 0.25;
                    carbsPercentage = 0.10;
                    fatsPercentage = 0.65;
                    break;

                case "Vegetarian":
                    proteinPercentage = 0.25;
                    carbsPercentage = 0.50;
                    fatsPercentage = 0.25;
                    break;

                default:
                    proteinPercentage = 0.30;
                    carbsPercentage = 0.40;
                    fatsPercentage = 0.30;
                    break;
            }

            // Conversión de calorías a gramos
            proteinGrams = (targetCalories * proteinPercentage) / 4;
            carbsGrams = (targetCalories * carbsPercentage) / 4;
            fatsGrams = (targetCalories * fatsPercentage) / 9;
        }
    }
}