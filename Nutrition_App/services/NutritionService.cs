using System;
using Nutrition_App.Models;

namespace Nutrition_App.Services
{
    /// <summary>
    /// Servicio encargado de calcular información nutricional basada en los datos del usuario.
    /// Incluye cálculos de IMC, calorías de mantenimiento, calorías objetivo y macronutrientes.
    /// </summary>
    public class NutritionService
    {
        /// <summary>
        /// Calcula toda la información nutricional del usuario.
        /// </summary>
        /// <param name="user">Usuario del cual se calcularán los valores nutricionales.</param>
        /// <returns>Objeto con los valores calculados.</returns>
        public NutritionInfo CalculateNutritionInfo(User user)
        {
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

            CalculateMacros(
                targetCalories,
                user.DietType,
                out proteinGrams,
                out carbsGrams,
                out fatsGrams
            );

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

        /// <summary>
        /// Calcula el Índice de Masa Corporal (IMC).
        /// </summary>
        /// <param name="weight">Peso en kilogramos.</param>
        /// <param name="heightInCm">Altura en centímetros.</param>
        /// <returns>Valor del IMC.</returns>
        private static double CalculateBMI(double weight, double heightInCm)
        {
            double heightInMeters = heightInCm / 100.0;
            return weight / (heightInMeters * heightInMeters);
        }

        /// <summary>
        /// Calcula las calorías de mantenimiento del usuario usando la fórmula de Harris-Benedict modificada.
        /// </summary>
        /// <param name="user">Usuario con los datos necesarios para el cálculo.</param>
        /// <returns>Calorías de mantenimiento estimadas.</returns>
        private static double CalculateMaintenanceCalories(User user)
        {
            double bmr;

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

        /// <summary>
        /// Obtiene el multiplicador de actividad según el nivel de actividad del usuario.
        /// </summary>
        /// <param name="activityLevel">Nivel de actividad del usuario.</param>
        /// <returns>Factor multiplicador de actividad.</returns>
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

        /// <summary>
        /// Calcula las calorías objetivo según el objetivo del usuario.
        /// </summary>
        /// <param name="maintenanceCalories">Calorías de mantenimiento.</param>
        /// <param name="goal">Objetivo del usuario.</param>
        /// <returns>Calorías objetivo ajustadas.</returns>
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

        /// <summary>
        /// Calcula la distribución de macronutrientes (proteínas, carbohidratos y grasas)
        /// según el tipo de dieta del usuario.
        /// </summary>
        /// <param name="targetCalories">Calorías objetivo.</param>
        /// <param name="dietType">Tipo de dieta.</param>
        /// <param name="proteinGrams">Salida de gramos de proteína.</param>
        /// <param name="carbsGrams">Salida de gramos de carbohidratos.</param>
        /// <param name="fatsGrams">Salida de gramos de grasa.</param>
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

            proteinGrams = (targetCalories * proteinPercentage) / 4;
            carbsGrams = (targetCalories * carbsPercentage) / 4;
            fatsGrams = (targetCalories * fatsPercentage) / 9;
        }
    }
}