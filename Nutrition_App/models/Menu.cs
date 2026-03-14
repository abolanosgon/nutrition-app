using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition_App.Models
{
    // Representa un menú planificado para un usuario en una fecha específica
    public class Menu
    {
        public int Id { get; set; }                 // Identificador del menú
        public int UserId { get; set; }             // Usuario al que pertenece el menú
        public DateTime Date { get; set; }          // Fecha para la cual se planifica el menú

        // Lista de alimentos que forman parte del menú
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
}