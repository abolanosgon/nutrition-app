using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    // Servicio encargado de la lógica básica de alimentos.
    // Funciona como intermediario entre el controlador y el repositorio.
    public class FoodService
    {
        // Repositorio utilizado para acceder a los datos de alimentos
        private readonly IFoodRepository foodRepository;

        // Constructor que recibe la implementación del repositorio
        public FoodService(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        // Agrega un nuevo alimento al repositorio
        public void AddFood(Food food)
        {
            foodRepository.Add(food);
        }

        // Obtiene la lista completa de alimentos
        public List<Food> GetFoods()
        {
            return foodRepository.GetAll();
        }

        // Elimina un alimento según su Id
        public void DeleteFood(int foodId)
        {
            foodRepository.Delete(foodId);
        }

        // Actualiza la información de un alimento existente
        public void UpdateFood(Food food)
        {
            foodRepository.Update(food);
        }
    }
}