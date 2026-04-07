using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;

namespace Nutrition_App.Services
{
    // Servicio encargado de calcular estadísticas nutricionales.
    // Procesa registros de comidas y alimentos para generar métricas agregadas.
    public class StatisticsService
    {
        // Lista de registros de comidas
        private readonly List<MealRecord> _mealRecords;

        // Lista de alimentos disponibles
        private readonly List<Food> _foods;

        // Constructor que recibe los datos necesarios para calcular estadísticas
        public StatisticsService(List<MealRecord> mealRecords, List<Food> foods)
        {
            _mealRecords = mealRecords ?? new List<MealRecord>();
            _foods = foods ?? new List<Food>();
        }

        // Obtiene un resumen general de estadísticas
        public NutritionStatsSummary GetSummary()
        {
            int totalMealRecords = _mealRecords.Count;

            // Cantidad de usuarios únicos con registros
            int totalUsersWithRecords = _mealRecords
                .Select(m => m.UserId)
                .Distinct()
                .Count();

            double totalCalories = 0;
            double totalProtein = 0;
            double totalCarbs = 0;
            double totalFat = 0;

            // Recorre todos los registros para acumular valores nutricionales
            foreach (var record in _mealRecords)
            {
                var food = _foods.FirstOrDefault(f => f.Id == record.FoodId);

                if (food == null)
                    continue;

                totalCalories += food.Calories * record.Quantity;
                totalProtein += food.Protein * record.Quantity;
                totalCarbs += food.Carbohydrates * record.Quantity;
                totalFat += food.Fat * record.Quantity;
            }

            // Promedios
            double averageCaloriesPerRecord = totalMealRecords > 0
                ? totalCalories / totalMealRecords
                : 0;

            double averageCaloriesPerUser = totalUsersWithRecords > 0
                ? totalCalories / totalUsersWithRecords
                : 0;

            return new NutritionStatsSummary
            {
                TotalMealRecords = totalMealRecords,
                TotalUsersWithRecords = totalUsersWithRecords,
                TotalCalories = totalCalories,
                AverageCaloriesPerRecord = averageCaloriesPerRecord,
                AverageCaloriesPerUser = averageCaloriesPerUser,
                TotalProtein = totalProtein,
                TotalCarbs = totalCarbs,
                TotalFat = totalFat
            };
        }

        // Obtiene estadísticas diarias de calorías
        public List<DailyCaloriesStat> GetDailyCaloriesStats()
        {
            var dailyStats = _mealRecords
                .GroupBy(r => r.RecordDate.Date)
                .Select(group =>
                {
                    double totalCalories = 0;

                    foreach (var record in group)
                    {
                        var food = _foods.FirstOrDefault(f => f.Id == record.FoodId);

                        if (food == null)
                            continue;

                        totalCalories += food.Calories * record.Quantity;
                    }

                    return new DailyCaloriesStat
                    {
                        Date = group.Key,
                        TotalCalories = totalCalories,
                        TotalMeals = group.Count()
                    };
                })
                .OrderBy(stat => stat.Date)
                .ToList();

            return dailyStats;
        }

        // Obtiene los alimentos más consumidos (top N)
        public List<TopFoodStat> GetTopFoods(int top = 5)
        {
            var topFoods = _mealRecords
                .GroupBy(r => r.FoodId)
                .Select(group =>
                {
                    var food = _foods.FirstOrDefault(f => f.Id == group.Key);

                    if (food == null)
                        return null;

                    double totalQuantity = group.Sum(r => r.Quantity);
                    double totalCalories = group.Sum(r => food.Calories * r.Quantity);

                    return new TopFoodStat
                    {
                        FoodName = food.Name,
                        TimesConsumed = group.Count(),
                        TotalQuantity = totalQuantity,
                        TotalCalories = totalCalories
                    };
                })
                .Where(stat => stat != null)
                .Select(stat => stat!)
                .OrderByDescending(stat => stat.TimesConsumed)
                .Take(top)
                .ToList();

            return topFoods;
        }

        // Obtiene resumen filtrado por usuario
        public NutritionStatsSummary GetSummaryByUser(int userId)
        {
            var userRecords = _mealRecords
                .Where(r => r.UserId == userId)
                .ToList();

            int totalMealRecords = userRecords.Count;
            int totalUsersWithRecords = totalMealRecords > 0 ? 1 : 0;

            double totalCalories = 0;
            double totalProtein = 0;
            double totalCarbs = 0;
            double totalFat = 0;

            foreach (var record in userRecords)
            {
                var food = _foods.FirstOrDefault(f => f.Id == record.FoodId);

                if (food == null)
                    continue;

                totalCalories += food.Calories * record.Quantity;
                totalProtein += food.Protein * record.Quantity;
                totalCarbs += food.Carbohydrates * record.Quantity;
                totalFat += food.Fat * record.Quantity;
            }

            double averageCaloriesPerRecord = totalMealRecords > 0
                ? totalCalories / totalMealRecords
                : 0;

            return new NutritionStatsSummary
            {
                TotalMealRecords = totalMealRecords,
                TotalUsersWithRecords = totalUsersWithRecords,
                TotalCalories = totalCalories,
                AverageCaloriesPerRecord = averageCaloriesPerRecord,
                AverageCaloriesPerUser = totalCalories,
                TotalProtein = totalProtein,
                TotalCarbs = totalCarbs,
                TotalFat = totalFat
            };
        }

        // Obtiene estadísticas diarias filtradas por usuario
        public List<DailyCaloriesStat> GetDailyCaloriesStatsByUser(int userId)
        {
            var dailyStats = _mealRecords
                .Where(r => r.UserId == userId)
                .GroupBy(r => r.RecordDate.Date)
                .Select(group =>
                {
                    double totalCalories = 0;

                    foreach (var record in group)
                    {
                        var food = _foods.FirstOrDefault(f => f.Id == record.FoodId);

                        if (food == null)
                            continue;

                        totalCalories += food.Calories * record.Quantity;
                    }

                    return new DailyCaloriesStat
                    {
                        Date = group.Key,
                        TotalCalories = totalCalories,
                        TotalMeals = group.Count()
                    };
                })
                .OrderBy(stat => stat.Date)
                .ToList();

            return dailyStats;
        }

        // Obtiene top alimentos consumidos por un usuario
        public List<TopFoodStat> GetTopFoodsByUser(int userId, int top = 5)
        {
            var topFoods = _mealRecords
                .Where(r => r.UserId == userId)
                .GroupBy(r => r.FoodId)
                .Select(group =>
                {
                    var food = _foods.FirstOrDefault(f => f.Id == group.Key);

                    if (food == null)
                        return null;

                    double totalQuantity = group.Sum(r => r.Quantity);
                    double totalCalories = group.Sum(r => food.Calories * r.Quantity);

                    return new TopFoodStat
                    {
                        FoodName = food.Name,
                        TimesConsumed = group.Count(),
                        TotalQuantity = totalQuantity,
                        TotalCalories = totalCalories
                    };
                })
                .Where(stat => stat != null)
                .Select(stat => stat!)
                .OrderByDescending(stat => stat.TimesConsumed)
                .Take(top)
                .ToList();

            return topFoods;
        }
    }
}