using Nutrition_App.Models;
using Nutrition_App.Services;

namespace Nutrition_App.Controllers
{
    public class MenuController
    {
        private readonly MenuService _menuService;

        public MenuController()
        {
            _menuService = new MenuService();
        }

        public Menu? GetAssignedMenu(User user)
        {
            return _menuService.GetMenuForUser(user);
        }
    }
}