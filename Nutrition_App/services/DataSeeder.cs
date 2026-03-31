using Nutrition_App.Models;
using Nutrition_App.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Nutrition_App.Services
{
    public class DataSeeder
    {
        private readonly FoodJsonRepository foodRepository;

        private readonly string usersFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.json");

        private readonly string mealRecordsFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "mealRecords.json");

        public DataSeeder()
        {
            foodRepository = new FoodJsonRepository();
        }

        public void SeedAllData()
        {
            List<Food> foods = foodRepository.GetAll();

            if (foods == null || foods.Count == 0)
            {
                throw new Exception("No hay alimentos en foods.json. No se pueden generar registros.");
            }

            List<User> users = GenerateUsers();
            List<MealRecord> mealRecords = GenerateMealRecords(users, foods);

            SaveUsers(users);
            SaveMealRecords(mealRecords);
        }

        private void SaveUsers(List<User> users)
        {
            EnsureDirectoryExists(usersFilePath);

            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(usersFilePath, json);
        }

        private void SaveMealRecords(List<MealRecord> mealRecords)
        {
            EnsureDirectoryExists(mealRecordsFilePath);

            string json = JsonSerializer.Serialize(mealRecords, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(mealRecordsFilePath, json);
        }

        private void EnsureDirectoryExists(string filePath)
        {
            string directory = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private List<User> GenerateUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Name = "Carlos Ramirez", Username = "carlos1", Password = "1234", Age = 28, Weight = 78, Height = 175, Gender = "Male", Goal = "Maintain", ActivityLevel = "Moderate", DietType = "Standard", Role = "User" },
                new User { Id = 2, Name = "Maria Gonzalez", Username = "maria2", Password = "1234", Age = 32, Weight = 62, Height = 165, Gender = "Female", Goal = "LoseFat", ActivityLevel = "Light", DietType = "Vegetarian", Role = "User" },
                new User { Id = 3, Name = "Jose Fernandez", Username = "jose3", Password = "1234", Age = 24, Weight = 70, Height = 172, Gender = "Male", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Standard", Role = "User" },
                new User { Id = 4, Name = "Ana Morales", Username = "ana4", Password = "1234", Age = 29, Weight = 58, Height = 160, Gender = "Female", Goal = "Maintain", ActivityLevel = "Moderate", DietType = "Keto", Role = "User" },
                new User { Id = 5, Name = "Luis Rojas", Username = "luis5", Password = "1234", Age = 35, Weight = 85, Height = 180, Gender = "Male", Goal = "LoseFat", ActivityLevel = "Sedentary", DietType = "Standard", Role = "User" },
                new User { Id = 6, Name = "Sofia Herrera", Username = "sofia6", Password = "1234", Age = 27, Weight = 55, Height = 158, Gender = "Female", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Vegetarian", Role = "User" },
                new User { Id = 7, Name = "Daniel Castro", Username = "daniel7", Password = "1234", Age = 31, Weight = 74, Height = 177, Gender = "Male", Goal = "Maintain", ActivityLevel = "Light", DietType = "Standard", Role = "User" },
                new User { Id = 8, Name = "Valeria Jimenez", Username = "valeria8", Password = "1234", Age = 26, Weight = 61, Height = 168, Gender = "Female", Goal = "LoseFat", ActivityLevel = "Moderate", DietType = "Keto", Role = "User" },
                new User { Id = 9, Name = "Andres Vega", Username = "andres9", Password = "1234", Age = 30, Weight = 82, Height = 178, Gender = "Male", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Standard", Role = "User" },
                new User { Id = 10, Name = "Paula Navarro", Username = "paula10", Password = "1234", Age = 33, Weight = 64, Height = 164, Gender = "Female", Goal = "Maintain", ActivityLevel = "Light", DietType = "Vegetarian", Role = "User" },
                new User { Id = 11, Name = "Ricardo Solis", Username = "ricardo11", Password = "1234", Age = 36, Weight = 88, Height = 182, Gender = "Male", Goal = "LoseFat", ActivityLevel = "Moderate", DietType = "Keto", Role = "User" },
                new User { Id = 12, Name = "Laura Mendez", Username = "laura12", Password = "1234", Age = 25, Weight = 57, Height = 162, Gender = "Female", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Standard", Role = "User" },
                new User { Id = 13, Name = "Fernando Arias", Username = "fernando13", Password = "1234", Age = 29, Weight = 76, Height = 174, Gender = "Male", Goal = "Maintain", ActivityLevel = "Sedentary", DietType = "Standard", Role = "User" },
                new User { Id = 14, Name = "Gabriela Ruiz", Username = "gabriela14", Password = "1234", Age = 28, Weight = 60, Height = 166, Gender = "Female", Goal = "LoseFat", ActivityLevel = "Light", DietType = "Vegetarian", Role = "User" },
                new User { Id = 15, Name = "Kevin Chaves", Username = "kevin15", Password = "1234", Age = 23, Weight = 79, Height = 179, Gender = "Male", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Keto", Role = "User" },
                new User { Id = 16, Name = "Monica Quesada", Username = "monica16", Password = "1234", Age = 34, Weight = 63, Height = 163, Gender = "Female", Goal = "Maintain", ActivityLevel = "Moderate", DietType = "Standard", Role = "User" },
                new User { Id = 17, Name = "Javier Campos", Username = "javier17", Password = "1234", Age = 37, Weight = 90, Height = 183, Gender = "Male", Goal = "LoseFat", ActivityLevel = "Light", DietType = "Standard", Role = "User" },
                new User { Id = 18, Name = "Natalia Porras", Username = "natalia18", Password = "1234", Age = 27, Weight = 56, Height = 159, Gender = "Female", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Vegetarian", Role = "User" },
                new User { Id = 19, Name = "Esteban Molina", Username = "esteban19", Password = "1234", Age = 31, Weight = 81, Height = 176, Gender = "Male", Goal = "Maintain", ActivityLevel = "Moderate", DietType = "Keto", Role = "User" },
                new User { Id = 20, Name = "Carolina Brenes", Username = "carolina20", Password = "1234", Age = 30, Weight = 59, Height = 161, Gender = "Female", Goal = "LoseFat", ActivityLevel = "Sedentary", DietType = "Standard", Role = "User" },
                new User { Id = 21, Name = "Miguel Salazar", Username = "miguel21", Password = "1234", Age = 26, Weight = 77, Height = 181, Gender = "Male", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Standard", Role = "User" },
                new User { Id = 22, Name = "Daniela Ulate", Username = "daniela22", Password = "1234", Age = 24, Weight = 54, Height = 157, Gender = "Female", Goal = "Maintain", ActivityLevel = "Light", DietType = "Vegetarian", Role = "User" },
                new User { Id = 23, Name = "Pablo Aguilar", Username = "pablo23", Password = "1234", Age = 35, Weight = 86, Height = 184, Gender = "Male", Goal = "LoseFat", ActivityLevel = "Moderate", DietType = "Keto", Role = "User" },
                new User { Id = 24, Name = "Elena Cordero", Username = "elena24", Password = "1234", Age = 29, Weight = 62, Height = 167, Gender = "Female", Goal = "GainMuscle", ActivityLevel = "Active", DietType = "Standard", Role = "User" },
                new User { Id = 25, Name = "Oscar Villalobos", Username = "oscar25", Password = "1234", Age = 38, Weight = 92, Height = 185, Gender = "Male", Goal = "Maintain", ActivityLevel = "Light", DietType = "Standard", Role = "Admin" }
            };
        }

        private List<MealRecord> GenerateMealRecords(List<User> users, List<Food> foods)
        {
            List<MealRecord> mealRecords = new List<MealRecord>();
            Random random = new Random();
            int recordId = 1;

            DateTime startDate = DateTime.Today.AddDays(-14);

            List<string> mealTypes = new List<string>
            {
                "Breakfast",
                "Lunch",
                "Dinner",
                "Snack"
            };

            foreach (User user in users)
            {
                for (int day = 0; day < 15; day++)
                {
                    DateTime currentDate = startDate.AddDays(day);

                    foreach (string mealType in mealTypes)
                    {
                        Food selectedFood = SelectFoodByMealType(foods, mealType, random);

                        MealRecord record = new MealRecord
                        {
                            Id = recordId++,
                            UserId = user.Id,
                            FoodId = selectedFood.Id,
                            RecordDate = GetDateWithMealHour(currentDate, mealType),
                            MealType = mealType,
                            Quantity = GetRandomQuantity(random)
                        };

                        mealRecords.Add(record);
                    }
                }
            }

            return mealRecords;
        }

        private Food SelectFoodByMealType(List<Food> foods, string mealType, Random random)
        {
            List<Food> filteredFoods;

            switch (mealType)
            {
                case "Breakfast":
                    filteredFoods = foods.Where(f =>
                        f.Category == "Carbohidrato" ||
                        f.Category == "Fruta" ||
                        f.Category == "Lácteo" ||
                        f.Category == "Snack" ||
                        f.Category == "Bebida").ToList();
                    break;

                case "Lunch":
                case "Dinner":
                    filteredFoods = foods.Where(f =>
                        f.Category == "Proteína" ||
                        f.Category == "Carbohidrato" ||
                        f.Category == "Legumbre" ||
                        f.Category == "Vegetal" ||
                        f.Category == "Grasa saludable").ToList();
                    break;

                case "Snack":
                    filteredFoods = foods.Where(f =>
                        f.Category == "Fruta" ||
                        f.Category == "Snack" ||
                        f.Category == "Lácteo" ||
                        f.Category == "Grasa saludable" ||
                        f.Category == "Bebida" ||
                        f.Category == "Suplemento").ToList();
                    break;

                default:
                    filteredFoods = foods;
                    break;
            }

            if (filteredFoods.Count == 0)
            {
                filteredFoods = foods;
            }

            int randomIndex = random.Next(filteredFoods.Count);
            return filteredFoods[randomIndex];
        }

        private DateTime GetDateWithMealHour(DateTime date, string mealType)
        {
            switch (mealType)
            {
                case "Breakfast":
                    return date.Date.AddHours(7);
                case "Lunch":
                    return date.Date.AddHours(12);
                case "Dinner":
                    return date.Date.AddHours(19);
                case "Snack":
                    return date.Date.AddHours(15);
                default:
                    return date.Date.AddHours(12);
            }
        }

        private double GetRandomQuantity(Random random)
        {
            double[] quantities = { 0.5, 1.0, 1.5, 2.0 };
            int randomIndex = random.Next(quantities.Length);
            return quantities[randomIndex];
        }
    }
}