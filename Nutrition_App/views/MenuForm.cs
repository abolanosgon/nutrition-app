using System;
using System.Linq;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;
using Nutrition_App.Repositories;

namespace Nutrition_App.Views
{
    public partial class MenuForm : Form
    {
        private readonly User _loggedUser;
        private readonly MenuController _menuController;
        private readonly FoodJsonRepository _foodRepository;

        public MenuForm(User loggedUser)
        {
            InitializeComponent();
            _loggedUser = loggedUser;
            _menuController = new MenuController();
            _foodRepository = new FoodJsonRepository();

            LoadAssignedMenu();
        }

        private void LoadAssignedMenu()
        {
            var menu = _menuController.GetAssignedMenu(_loggedUser);

            if (menu == null)
            {
                MessageBox.Show("No se encontró un menú asignado para este usuario.");
                lblMenuName.Text = "Sin menú asignado";
                lblGoal.Text = "Objetivo: ---";
                lblDietType.Text = "Tipo de dieta: ---";
                dgvMenu.DataSource = null;
                return;
            }

            lblMenuName.Text = menu.Name;
            lblGoal.Text = $"Objetivo: {menu.Goal}";
            lblDietType.Text = $"Tipo de dieta: {menu.DietType}";

            var foods = _foodRepository.GetAll();

            var menuDetails = menu.Items.Select(item =>
            {
                var food = foods.FirstOrDefault(f => f.Id == item.FoodId);

                return new
                {
                    TiempoDeComida = item.MealType,
                    Alimento = food?.Name ?? "No encontrado",
                    Cantidad = item.Quantity,
                    Calorias = food != null ? food.Calories * item.Quantity : 0,
                    Proteina = food != null ? food.Protein * item.Quantity : 0,
                    Carbohidratos = food != null ? food.Carbohydrates * item.Quantity : 0,
                    Grasas = food != null ? food.Fat * item.Quantity : 0
                };
            }).ToList();

            dgvMenu.DataSource = null;
            dgvMenu.DataSource = menuDetails;
        }
    }
}