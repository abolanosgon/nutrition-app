using Nutrition_App.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Nutrition_App.Repositories
{
    // Repositorio encargado de leer los menús desde un archivo JSON.
    // Actualmente solo permite obtener la lista de menús (lectura).
    public class MenuJsonRepository
    {
        // Ruta del archivo menus.json
        private readonly string _filePath;

        public MenuJsonRepository()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = Directory.GetParent(baseDir)?.Parent?.Parent?.Parent?.FullName ?? baseDir;

            _filePath = Path.Combine(projectDir, "data", "menus.json");

            // Asegura que el archivo exista antes de usarlo
            EnsureMenuFileExists();
        }

        // Obtiene todos los menús almacenados en el archivo JSON
        public List<Menu> GetAllMenus()
        {
            EnsureMenuFileExists();

            string json = File.ReadAllText(_filePath);

            // Si el archivo está vacío, devuelve lista vacía
            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<Menu>();
            }

            // Deserializa el JSON a lista de menús
            return JsonSerializer.Deserialize<List<Menu>>(json) ?? new List<Menu>();
        }

        // Verifica que el archivo menus.json exista
        // Si no existe, lo crea con una lista vacía
        private void EnsureMenuFileExists()
        {
            string? directory = Path.GetDirectoryName(_filePath);

            if (!string.IsNullOrWhiteSpace(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }
    }
}