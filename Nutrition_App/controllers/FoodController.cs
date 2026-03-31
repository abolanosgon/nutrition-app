using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Coordina la comunicación entre la vista y la lógica de alimentos
    public class FoodController
    {
        private readonly FoodService foodService;

        public FoodController()
        {
            IFoodRepository foodRepository = new FoodJsonRepository();
            foodService = new FoodService(foodRepository);
        }

        public void RegisterFood(Food food)
        {
            foodService.AddFood(food);
        }

        public List<Food> GetFoods()
        {
            return foodService.GetFoods();
        }

        public void DeleteFood(int foodId)
        {
            foodService.DeleteFood(foodId);
        }

        public void UpdateFood(Food food)
        {
            foodService.UpdateFood(food);
        }

        public Food GetFoodById(int foodId)
        {
            List<Food> foods = foodService.GetFoods();
            return foods.FirstOrDefault(f => f.Id == foodId);
        }
    }
}