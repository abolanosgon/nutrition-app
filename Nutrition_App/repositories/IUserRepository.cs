using System.Collections.Generic;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void Add(User user);
        void Delete(int userId);
        void Update(User user);
    }
}