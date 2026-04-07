using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar las estadísticas del sistema.
    // Obtiene datos desde los repositorios y delega los cálculos al servicio.
    public class StatisticsController
    {
        // Repositorio de registros de comidas
        private readonly MealRecordJsonRepository _mealRecordRepository;

        // Repositorio de alimentos
        private readonly FoodJsonRepository _foodRepository;

        public StatisticsController()
        {
            _mealRecordRepository = new MealRecordJsonRepository();
            _foodRepository = new FoodJsonRepository();
        }

        // Construye una instancia del servicio de estadísticas con los datos actuales
        private StatisticsService BuildService()
        {
            var mealRecords = _mealRecordRepository.GetAll();
            var foods = _foodRepository.GetAll();

            return new StatisticsService(mealRecords, foods);
        }

        // Obtiene un resumen general de estadísticas
        public NutritionStatsSummary GetSummary()
        {
            return BuildService().GetSummary();
        }

        // Obtiene estadísticas diarias de calorías (todos los usuarios)
        public List<DailyCaloriesStat> GetDailyCaloriesStats()
        {
            return BuildService().GetDailyCaloriesStats();
        }

        // Obtiene los alimentos más consumidos (top N)
        public List<TopFoodStat> GetTopFoods(int top = 5)
        {
            return BuildService().GetTopFoods(top);
        }

        // Obtiene un resumen de estadísticas para un usuario específico
        public NutritionStatsSummary GetSummaryByUser(int userId)
        {
            return BuildService().GetSummaryByUser(userId);
        }

        // Obtiene estadísticas diarias de calorías para un usuario específico
        public List<DailyCaloriesStat> GetDailyCaloriesStatsByUser(int userId)
        {
            return BuildService().GetDailyCaloriesStatsByUser(userId);
        }

        // Obtiene los alimentos más consumidos por un usuario específico
        public List<TopFoodStat> GetTopFoodsByUser(int userId, int top = 5)
        {
            return BuildService().GetTopFoodsByUser(userId, top);
        }
    }
}