using System.Collections.Generic;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    /// <summary>
    /// Servicio encargado de gestionar las operaciones relacionadas con los alimentos.
    /// Actúa como intermediario entre los controladores y el repositorio de alimentos.
    /// </summary>
    public class FoodService
    {
        private readonly IFoodRepository foodRepository;

        /// <summary>
        /// Inicializa una nueva instancia del servicio de alimentos.
        /// </summary>
        /// <param name="foodRepository">Repositorio utilizado para acceder a los datos de alimentos.</param>
        public FoodService(IFoodRepository foodRepository)
        {
            this.foodRepository = foodRepository;
        }

        /// <summary>
        /// Agrega un nuevo alimento al repositorio.
        /// </summary>
        /// <param name="food">Alimento que se desea registrar.</param>
        public void AddFood(Food food)
        {
            foodRepository.Add(food);
        }

        /// <summary>
        /// Obtiene la lista completa de alimentos registrados.
        /// </summary>
        /// <returns>Lista de alimentos disponibles en el sistema.</returns>
        public List<Food> GetFoods()
        {
            return foodRepository.GetAll();
        }

        /// <summary>
        /// Elimina un alimento del repositorio según su identificador.
        /// </summary>
        /// <param name="foodId">Identificador del alimento a eliminar.</param>
        public void DeleteFood(int foodId)
        {
            foodRepository.Delete(foodId);
        }

        /// <summary>
        /// Actualiza la información de un alimento existente.
        /// </summary>
        /// <param name="food">Alimento con los datos actualizados.</param>
        public void UpdateFood(Food food)
        {
            foodRepository.Update(food);
        }
    }
}