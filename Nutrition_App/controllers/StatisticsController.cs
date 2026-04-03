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

        public NutritionStatsSummary GetSummary()
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            var statisticsService = new StatisticsService(mealRecords, foods);

            return statisticsService.GetSummary();
        }

        public List<DailyCaloriesStat> GetDailyCaloriesStats()
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            var statisticsService = new StatisticsService(mealRecords, foods);

            return statisticsService.GetDailyCaloriesStats();
        }

        public List<TopFoodStat> GetTopFoods(int top = 5)
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            var statisticsService = new StatisticsService(mealRecords, foods);

            return statisticsService.GetTopFoods(top);
        }

        public NutritionStatsSummary GetSummaryByUser(int userId)
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            var statisticsService = new StatisticsService(mealRecords, foods);

            return statisticsService.GetSummaryByUser(userId);
        }

        public List<DailyCaloriesStat> GetDailyCaloriesStatsByUser(int userId)
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            var statisticsService = new StatisticsService(mealRecords, foods);

            return statisticsService.GetDailyCaloriesStatsByUser(userId);
        }

        public List<TopFoodStat> GetTopFoodsByUser(int userId, int top = 5)
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            var statisticsService = new StatisticsService(mealRecords, foods);

            return statisticsService.GetTopFoodsByUser(userId, top);
        }
    }
}