using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Define las operaciones básicas para almacenar y recuperar alimentos
    public interface IFoodRepository
    {
        void Add(Food food);
        List<Food> GetAll();
        void Delete(int foodId);
        void Update(Food food);
    }
}