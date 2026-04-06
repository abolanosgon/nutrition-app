namespace Nutrition_App.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public int Age { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Gender { get; set; } = "";
        public string Goal { get; set; } = "";
        public string ActivityLevel { get; set; } = "";
        public string DietType { get; set; } = "";
        public string Role { get; set; } = "";
    }
}