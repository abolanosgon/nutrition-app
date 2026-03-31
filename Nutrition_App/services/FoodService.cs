using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    // Maneja la lógica relacionada con los alimentos
    public class FoodService
    {
        private readonly IFoodRepository foodRepository;

        public FoodService(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        public void AddFood(Food food)
        {
            foodRepository.Add(food);
        }

        public List<Food> GetFoods()
        {
            return foodRepository.GetAll();
        }

        public void DeleteFood(int foodId)
        {
            foodRepository.Delete(foodId);
        }

        public void UpdateFood(Food food)
        {
            foodRepository.Update(food);
        }
    }
}