using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrition_App.Models;
using System.IO;
using System.Text.Json;


namespace Nutrition_App.Repositories
{
    // Repositorio que guarda y recupera usuarios desde un archivo JSON
    public class UserJsonRepository : IUserRepository
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.json");

        public void Add(User user)
        {
            List<User> users = GetAll();

            users.Add(user);

            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            File.WriteAllText(filePath, json);
        }

        public List<User> GetAll()
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(json);
        }

        public void Delete(int userId)
        {
            List<User> users = GetAll();

            User userToRemove = users.FirstOrDefault(u => u.Id == userId);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);

                string json = JsonSerializer.Serialize(users, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
            }
        }

        public void Update(User user)
        {
            List<User> users = GetAll();

            User existingUser = users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.Age = user.Age;
                existingUser.Weight = user.Weight;
                existingUser.Height = user.Height;
                existingUser.Gender = user.Gender;
                existingUser.Goal = user.Goal;
                existingUser.ActivityLevel = user.ActivityLevel;
                existingUser.DietType = user.DietType;
                existingUser.Role = user.Role;

                string json = JsonSerializer.Serialize(users, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                File.WriteAllText(filePath, json);
            }
        }
    }
}