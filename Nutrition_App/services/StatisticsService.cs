using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;

namespace Nutrition_App.Services
{
    public class StatisticsService
    {
        private readonly List<MealRecord> _mealRecords;
        private readonly List<Food> _foods;

        public StatisticsService(List<MealRecord> mealRecords, List<Food> foods)
        {
            _mealRecords = mealRecords ?? new List<MealRecord>();
            _foods = foods ?? new List<Food>();
        }

        // =========================
        // ESTADÍSTICAS GENERALES
        // =========================
        public NutritionStatsSummary GetSummary()
        {
            int totalMealRecords = _mealRecords.Count;

            int totalUsersWithRecords = _mealRecords
                .Select(m => m.UserId)
                .Distinct()
                .Count();

            double totalCalories = 0;
            double totalProtein = 0;
            double totalCarbs = 0;
            double totalFat = 0;

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
                .OrderByDescending(stat => stat.TimesConsumed)
                .Take(top)
                .ToList();

            return topFoods;
        }

        // =========================
        // ESTADÍSTICAS POR USUARIO
        // =========================
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
                .OrderByDescending(stat => stat.TimesConsumed)
                .Take(top)
                .ToList();

            return topFoods;
        }
    }
}