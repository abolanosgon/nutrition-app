using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de gestionar las operaciones relacionadas con alimentos
    public class FoodController
    {
        private readonly FoodService foodService;

        public FoodController()
        {
            // Inicializa el servicio utilizando el repositorio de alimentos en JSON
            IFoodRepository foodRepository = new FoodJsonRepository();
            foodService = new FoodService(foodRepository);
        }

        // Registra un nuevo alimento
        public void RegisterFood(Food food)
        {
            foodService.AddFood(food);
        }

        // Obtiene la lista de todos los alimentos
        public List<Food> GetFoods()
        {
            return foodService.GetFoods();
        }

        // Elimina un alimento por su Id
        public void DeleteFood(int foodId)
        {
            foodService.DeleteFood(foodId);
        }

        // Actualiza la información de un alimento
        public void UpdateFood(Food food)
        {
            foodService.UpdateFood(food);
        }

        // Obtiene un alimento específico por su Id
        public Food? GetFoodById(int foodId)
        {
            List<Food> foods = foodService.GetFoods();
            return foods.FirstOrDefault(f => f.Id == foodId);
        }
    }
}