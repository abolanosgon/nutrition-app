using System.Linq;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Services
{
    // Servicio encargado de asignar un menú a un usuario.
    // Compara el objetivo y tipo de dieta del usuario con los menús disponibles.
    public class MenuService
    {
        // Repositorio que contiene los menús almacenados en JSON
        private readonly MenuJsonRepository _menuRepository;

        public MenuService()
        {
            _menuRepository = new MenuJsonRepository();
        }

        // Obtiene el menú correspondiente a un usuario según su objetivo y tipo de dieta
        public Menu? GetMenuForUser(User user)
        {
            var menus = _menuRepository.GetAllMenus();

            // Normaliza valores del usuario para evitar problemas de comparación
            string userGoal = NormalizeGoal(user.Goal);
            string userDietType = NormalizeDietType(user.DietType);

            // Busca el primer menú que coincida con ambas condiciones
            return menus.FirstOrDefault(m =>
                NormalizeGoal(m.Goal) == userGoal &&
                NormalizeDietType(m.DietType) == userDietType);
        }

        // Normaliza el objetivo del usuario (inglés/español, variaciones)
        private string NormalizeGoal(string goal)
        {
            string value = NormalizeText(goal);

            switch (value)
            {
                case "maintain":
                case "mantener":
                case "mantener peso":
                case "maintain weight":
                    return "maintain";

                case "losefat":
                case "lose fat":
                case "perder grasa":
                case "perdergrasa":
                case "perder peso":
                case "bajar grasa":
                case "lose weight":
                    return "losefat";

                case "gainmuscle":
                case "gain muscle":
                case "ganar masa":
                case "ganar masa muscular":
                case "ganarmasa":
                case "ganar peso":
                case "aumentar peso":
                case "aumentar de peso":
                case "gain weight":
                    return "gainmuscle";

                default:
                    return value;
            }
        }

        // Normaliza el tipo de dieta del usuario
        private string NormalizeDietType(string dietType)
        {
            string value = NormalizeText(dietType);

            switch (value)
            {
                case "standard":
                case "estandar":
                case "estándar":
                case "estadanr":
                    return "standard";

                case "keto":
                    return "keto";

                case "vegetarian":
                case "vegetariano":
                case "vegetariana":
                    return "vegetarian";

                default:
                    return value;
            }
        }

        // Limpia texto: elimina espacios, convierte a minúsculas y quita tildes
        private string NormalizeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            return text.Trim().ToLower()
                .Replace("á", "a")
                .Replace("é", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ú", "u");
        }
    }
}