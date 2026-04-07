using System.Collections.Generic;

namespace Nutrition_App.Models
{
    // Representa un menú compuesto por varios alimentos según objetivo y tipo de dieta
    public class Menu
    {
        // Identificador único del menú
        public int Id { get; set; }

        // Nombre del menú
        public string Name { get; set; } = "";

        // Objetivo del menú (ej: perder peso, ganar masa, mantenimiento)
        public string Goal { get; set; } = "";

        // Tipo de dieta (ej: keto, vegetariana, etc.)
        public string DietType { get; set; } = "";

        // Lista de elementos que componen el menú
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}