namespace Nutrition_App.Models
{
    // Modelo que representa un elemento dentro de un menú.
    // Define qué alimento se consume, en qué momento y en qué cantidad.
    public class MenuItem
    {
        // Identificador único del ítem del menú
        public int Id { get; set; }

        // Id del alimento asociado (relación con Food)
        public int FoodId { get; set; }

        // Tipo de comida (ej: Breakfast, Lunch, Dinner, Snack)
        public string MealType { get; set; } = "";

        // Cantidad del alimento dentro del menú
        public double Quantity { get; set; }
    }
}