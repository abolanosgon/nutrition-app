using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    public class StatisticsController
    {
        private readonly MealRecordJsonRepository _mealRecordRepository;
        private readonly FoodJsonRepository _foodRepository;

        public StatisticsController()
        {
            _mealRecordRepository = new MealRecordJsonRepository();
            _foodRepository = new FoodJsonRepository();
        }

        private StatisticsService BuildService()
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            return new StatisticsService(mealRecords, foods);
        }

        public NutritionStatsSummary GetSummary()
        {
            return BuildService().GetSummary();
        }

        public List<DailyCaloriesStat> GetDailyCaloriesStats()
        {
            return BuildService().GetDailyCaloriesStats();
        }

        public List<TopFoodStat> GetTopFoods(int top = 5)
        {
            return BuildService().GetTopFoods(top);
        }

        public NutritionStatsSummary GetSummaryByUser(int userId)
        {
            return BuildService().GetSummaryByUser(userId);
        }

        public List<DailyCaloriesStat> GetDailyCaloriesStatsByUser(int userId)
        {
            return BuildService().GetDailyCaloriesStatsByUser(userId);
        }

        public List<TopFoodStat> GetTopFoodsByUser(int userId, int top = 5)
        {
            return BuildService().GetTopFoodsByUser(userId, top);
        }
    }
}