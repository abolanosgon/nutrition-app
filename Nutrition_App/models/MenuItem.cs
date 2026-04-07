namespace Nutrition_App.Models
{
    // Representa un elemento dentro de un menú
    public class MenuItem
    {
        // Identificador único del elemento del menú
        public int Id { get; set; }

        // Id del alimento asociado a este elemento
        public int FoodId { get; set; }

        // Tipo de comida (ej: desayuno, almuerzo, cena)
        public string MealType { get; set; } = "";

        // Cantidad del alimento dentro del menú
        public double Quantity { get; set; }
    }
}