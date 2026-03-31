using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    public interface IMealRecordRepository
    {
        void Add(MealRecord record);
        List<MealRecord> GetAll();
        void Delete(int recordId);
        void Update(MealRecord record);
    }
}