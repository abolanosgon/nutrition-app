using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    // Formulario para editar un alimento existente.
    // Permite modificar sus datos nutricionales y guardarlos.
    public partial class EditFoodForm : Form
    {
        // Alimento seleccionado que se va a editar
        private Food? selectedFood;

        // Controlador para manejar operaciones de alimentos
        private FoodController foodController = new FoodController();

        // Constructor por defecto
        public EditFoodForm()
        {
            InitializeComponent();
        }

        // Constructor que recibe el alimento a editar
        public EditFoodForm(Food food)
        {
            InitializeComponent();
            selectedFood = food;
            LoadFoodData();
        }

        // Carga los datos del alimento en los campos del formulario
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

        // Evento del botón para guardar los cambios realizados
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Validación: debe existir un alimento seleccionado
            if (selectedFood == null)
            {
                MessageBox.Show("No se encontró el alimento.");
                return;
            }

            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(txtFoodName.Text) ||
                string.IsNullOrWhiteSpace(txtCategory.Text) ||
                string.IsNullOrWhiteSpace(txtPortionSize.Text))
            {
                MessageBox.Show("Debe completar nombre, categoría y porción.");
                return;
            }

            // Validación de valores numéricos
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

            // Asignación de los nuevos valores al objeto
            selectedFood.Name = txtFoodName.Text;
            selectedFood.Category = txtCategory.Text;
            selectedFood.Calories = calories;
            selectedFood.Protein = protein;
            selectedFood.Carbohydrates = carbohydrates;
            selectedFood.Fat = fat;
            selectedFood.PortionSize = txtPortionSize.Text;

            // Llamada al controlador para actualizar el alimento en el repositorio
            foodController.UpdateFood(selectedFood);

            MessageBox.Show("Alimento actualizado correctamente.");

            // Cierra el formulario después de guardar
            this.Close();
        }
    }
}