using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition_App.Models
{
    // Representa un alimento incluido dentro de un menú
    public class MenuItem
    {
        public int Id { get; set; }            // Identificador del item
        public int FoodId { get; set; }        // Alimento asociado
        public string MealType { get; set; }   // Tipo de comida: desayuno, almuerzo, cena, snack
        public double Quantity { get; set; }   // Cantidad del alimento dentro del menú
    }
}