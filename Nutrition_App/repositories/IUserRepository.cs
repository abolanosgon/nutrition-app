using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrition_App.Models;


namespace Nutrition_App.Repositories
{
    // Define las operaciones básicas para almacenar y recuperar usuarios
    public interface IUserRepository
    {
        void Add(User user);
        List<User> GetAll();
    }
}