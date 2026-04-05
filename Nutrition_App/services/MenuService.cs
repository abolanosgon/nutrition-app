using Nutrition_App.Models;
using Nutrition_App.Repositories;
using System.Windows.Forms;

namespace Nutrition_App.Services
{
    public class MenuService
    {
        private readonly MenuJsonRepository _menuRepository;

        public MenuService()
        {
            _menuRepository = new MenuJsonRepository();
        }

        public Menu? GetMenuForUser(User user)
        {
            var menus = _menuRepository.GetAllMenus();

            string userGoal = NormalizeGoal(user.Goal);
            string userDietType = NormalizeDietType(user.DietType);

            return menus.FirstOrDefault(m =>
                NormalizeGoal(m.Goal) == userGoal &&
                NormalizeDietType(m.DietType) == userDietType);
        }

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