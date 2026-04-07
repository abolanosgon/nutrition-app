using System.Collections.Generic;
using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    // Controlador encargado de manejar las operaciones relacionadas con alimentos.
    // Actúa como intermediario entre la vista (UI) y el servicio.
    public class FoodController
    {
        // Servicio que contiene la lógica de negocio de alimentos
        private readonly FoodService foodService;

        public FoodController()
        {
            // Inicializa el repositorio y el servicio
            IFoodRepository foodRepository = new FoodJsonRepository();
            foodService = new FoodService(foodRepository);
        }

        // Registra un nuevo alimento
        public void RegisterFood(Food food)
        {
            foodService.AddFood(food);
        }

        // Obtiene la lista completa de alimentos
        public List<Food> GetFoods()
        {
            return foodService.GetFoods();
        }

        // Elimina un alimento por Id
        public void DeleteFood(int foodId)
        {
            foodService.DeleteFood(foodId);
        }

        // Actualiza un alimento existente
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