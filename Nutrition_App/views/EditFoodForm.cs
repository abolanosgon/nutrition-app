using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class EditFoodForm : Form
    {
        private Food selectedFood;
        private FoodController foodController = new FoodController();

        public EditFoodForm()
        {
            InitializeComponent();
        }

        public EditFoodForm(Food food)
        {
            InitializeComponent();
            selectedFood = food;
            LoadFoodData();
        }

        private void LoadFoodData()
        {
            if (selectedFood == null)
            {
                return;
            }

            txtFoodName.Text = selectedFood.Name;
            txtCategory.Text = selectedFood.Category;
            txtCalories.Text = selectedFood.Calories.ToString();
            txtProtein.Text = selectedFood.Protein.ToString();
            txtCarbohydrates.Text = selectedFood.Carbohydrates.ToString();
            txtFat.Text = selectedFood.Fat.ToString();
            txtPortionSize.Text = selectedFood.PortionSize;
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
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

            selectedFood.Name = txtFoodName.Text;
            selectedFood.Category = txtCategory.Text;
            selectedFood.Calories = calories;
            selectedFood.Protein = protein;
            selectedFood.Carbohydrates = carbohydrates;
            selectedFood.Fat = fat;
            selectedFood.PortionSize = txtPortionSize.Text;

            foodController.UpdateFood(selectedFood);

            MessageBox.Show("Alimento actualizado correctamente.");
            this.Close();
        }
    }
}