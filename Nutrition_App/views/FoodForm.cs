using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class FoodForm : Form
    {
        private FoodController foodController = new FoodController();
        private int selectedFoodId = -1;
        private User loggedUser;

        public FoodForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadFoods();
        }

        private void LoadFoods()
        {
            dgvFoods.DataSource = null;
            dgvFoods.DataSource = foodController.GetFoods();

            dgvFoods.Columns["Id"].HeaderText = "ID";
            dgvFoods.Columns["Name"].HeaderText = "Nombre";
            dgvFoods.Columns["Category"].HeaderText = "Categoría";
            dgvFoods.Columns["Calories"].HeaderText = "Calorías";
            dgvFoods.Columns["Protein"].HeaderText = "Proteína";
            dgvFoods.Columns["Carbohydrates"].HeaderText = "Carbohidratos";
            dgvFoods.Columns["Fat"].HeaderText = "Grasa";
            dgvFoods.Columns["PortionSize"].HeaderText = "Porción";
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtPortionSize.Text))
            {
                MessageBox.Show("Debe completar nombre, categoría y porción.");
                return;
            }

            if (!double.TryParse(txtCalories.Text, out double calories) || calories < 0)
            {
                MessageBox.Show("Debe ingresar calorías válidas.");
                return;
            }

            if (!double.TryParse(txtProtein.Text, out double protein) || protein < 0)
            {
                MessageBox.Show("Debe ingresar proteína válida.");
                return;
            }

            if (!double.TryParse(txtCarbohydrates.Text, out double carbohydrates) || carbohydrates < 0)
            {
                MessageBox.Show("Debe ingresar carbohidratos válidos.");
                return;
            }

            if (!double.TryParse(txtFat.Text, out double fat) || fat < 0)
            {
                MessageBox.Show("Debe ingresar grasa válida.");
                return;
            }

            Food food = new Food
            {
                Name = txtFoodName.Text,
                Category = txtCategory.Text,
                Calories = calories,
                Protein = protein,
                Carbohydrates = carbohydrates,
                Fat = fat,
                PortionSize = txtPortionSize.Text
            };

            foodController.RegisterFood(food);

            MessageBox.Show("Alimento agregado correctamente.");

            ClearFoodForm();
            LoadFoods();
        }

        private void dgvFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvFoods.Rows[e.RowIndex];
                selectedFoodId = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (selectedFoodId == -1)
            {
                MessageBox.Show("Debe seleccionar un alimento.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar este alimento?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                foodController.DeleteFood(selectedFoodId);

                LoadFoods(); // refresca el grid
                selectedFoodId = -1;

                MessageBox.Show("Alimento eliminado correctamente.");
            }
        }

        private void ClearFoodForm()
        {
            txtFoodName.Clear();
            txtCategory.Clear();
            txtCalories.Clear();
            txtProtein.Clear();
            txtCarbohydrates.Clear();
            txtFat.Clear();
            txtPortionSize.Clear();
            txtFoodName.Focus();
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (selectedFoodId == -1)
            {
                MessageBox.Show("Debe seleccionar un alimento.");
                return;
            }

            Food selectedFood = foodController.GetFoodById(selectedFoodId);

            if (selectedFood == null)
            {
                MessageBox.Show("No se encontró el alimento seleccionado.");
                return;
            }

            EditFoodForm editFoodForm = new EditFoodForm(selectedFood);
            editFoodForm.ShowDialog();

            LoadFoods();
        }
    }
}