using System;
using Nutrition_App.Models;

namespace Nutrition_App.Services
{
    public class NutritionService
    {
        public NutritionInfo CalculateNutritionInfo(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            double bmi = CalculateBMI(user.Weight, user.Height);
            double maintenanceCalories = CalculateMaintenanceCalories(user);
            double targetCalories = CalculateTargetCalories(maintenanceCalories, user.Goal);

            double proteinGrams = 0;
            double carbsGrams = 0;
            double fatsGrams = 0;

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

        private double CalculateBMI(double weight, double heightInCm)
        {
            double heightInMeters = heightInCm / 100.0;
            return weight / (heightInMeters * heightInMeters);
        }

        private double CalculateMaintenanceCalories(User user)
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

        private double GetActivityMultiplier(string activityLevel)
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

        private double CalculateTargetCalories(double maintenanceCalories, string goal)
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

        private void CalculateMacros(
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

                case "Standard":
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