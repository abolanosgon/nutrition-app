using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition_App.Models
{
    // Representa un alimento o producto disponible en el sistema
    public class Food
    {
        public int Id { get; set; }                // Identificador único
        public string Name { get; set; }           // Nombre del alimento
        public string Category { get; set; }       // Categoría: proteína, carbohidrato, grasa, etc.
        public double Calories { get; set; }       // Calorías por porción
        public double Protein { get; set; }        // Proteína en gramos
        public double Carbohydrates { get; set; }  // Carbohidratos en gramos
        public double Fat { get; set; }            // Grasas en gramos
        public string PortionSize { get; set; }    // Tamaño o medida de porción
    }
}