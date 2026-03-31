using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    public class UserJsonRepository : IUserRepository
    {
        private readonly string filePath = Path.Combine(
            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
            "data",
            "users.json"
        );

        public void Add(User user)
        {
            List<User> users = GetAll();

            user.Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;
            users.Add(user);

            SaveAll(users);
        }

        public List<User> GetAll()
        {
            EnsureFileExists();

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        public void Delete(int userId)
        {
            List<User> users = GetAll();

            User userToRemove = users.FirstOrDefault(u => u.Id == userId);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                SaveAll(users);
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

                SaveAll(users);
            }
        }

        private void SaveAll(List<User> users)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        private void EnsureFileExists()
        {
            string directory = Path.GetDirectoryName(filePath)!;
            Directory.CreateDirectory(directory);

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }
    }
}