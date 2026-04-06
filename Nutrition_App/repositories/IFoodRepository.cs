using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    public interface IFoodRepository
    {
        void Add(Food food);
        List<Food> GetAll();
        void Delete(int foodId);
        void Update(Food food);
    }
}