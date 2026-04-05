using Nutrition_App.Models;
using System.Text.Json;

namespace Nutrition_App.Repositories
{
    public class MenuJsonRepository
    {
        private readonly string _filePath;

        public MenuJsonRepository()
        {
            _filePath = Path.Combine(
                Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName,
                "data",
                "menus.json"
            );

            EnsureMenuFileExists();
        }

        public List<Menu> GetAllMenus()
        {
            EnsureMenuFileExists();

            string json = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Menu>();
            }

            return JsonSerializer.Deserialize<List<Menu>>(json) ?? new List<Menu>();
        }

        private void EnsureMenuFileExists()
        {
            string directory = Path.GetDirectoryName(_filePath)!;
            Directory.CreateDirectory(directory);

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }
    }
}