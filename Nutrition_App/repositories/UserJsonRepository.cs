using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using Nutrition_App.Models;

namespace Nutrition_App.Repositories
{
    // Repository que gestiona la persistencia de usuarios en un archivo JSON
    public class UserJsonRepository : IUserRepository
    {
        private readonly string filePath;

        public UserJsonRepository()
        {
            // Construye la ruta hacia /data/users.json desde el directorio del ejecutable
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            filePath = Path.Combine(projectDir, "data", "users.json");
        }

        // Agrega un nuevo usuario con Id incremental
        public void Add(User user)
        {
            List<User> users = GetAll();

            user.Id = users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;
            users.Add(user);

            SaveAll(users);
        }

        // Obtiene todos los usuarios desde el archivo JSON
        public List<User> GetAll()
        {
            EnsureFileExists();

            string json = File.ReadAllText(filePath);

            // Si el archivo está vacío, retorna lista vacía
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<User>();
            }

            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }

        // Elimina un usuario por su Id
        public void Delete(int userId)
        {
            List<User> users = GetAll();

            User? userToRemove = users.FirstOrDefault(u => u.Id == userId);

            if (userToRemove != null)
            {
                users.Remove(userToRemove);
                SaveAll(users);
            }
        }

        // Actualiza los datos de un usuario existente
        public void Update(User user)
        {
            List<User> users = GetAll();

            User? existingUser = users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser != null)
            {
                // Se actualizan las propiedades del usuario encontrado
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

        // Guarda todos los usuarios sobrescribiendo el archivo JSON
        private void SaveAll(List<User> users)
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        // Crea el archivo si no existe, inicializándolo como lista vacía
        private void EnsureFileExists()
        {
            string? directory = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }
    }
}