using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition_App.Models
{
    // Representa un registro de consumo de un alimento por parte de un usuario
    public class MealRecord
    {
        public int Id { get; set; }               // Identificador único del registro
        public int UserId { get; set; }           // Usuario al que pertenece el consumo
        public int FoodId { get; set; }           // Alimento consumido
        public DateTime RecordDate { get; set; }  // Fecha del consumo
        public string MealType { get; set; }      // Tipo de comida: desayuno, almuerzo, cena, snack
        public double Quantity { get; set; }      // Cantidad consumida
    }
}
