using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    /// <summary>
    /// Formulario para editar la información de un alimento existente.
    /// Permite cargar los datos actuales del alimento, modificarlos y guardar los cambios.
    /// </summary>
    public partial class EditFoodForm : Form
    {
        private Food? selectedFood;
        private FoodController foodController = new FoodController();

        /// <summary>
        /// Inicializa una nueva instancia del formulario de edición de alimentos.
        /// </summary>
        public EditFoodForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Inicializa una nueva instancia del formulario de edición de alimentos
        /// con el alimento seleccionado.
        /// </summary>
        /// <param name="food">Alimento que se desea editar.</param>
        public EditFoodForm(Food food)
        {
            InitializeComponent();
            selectedFood = food;
            LoadFoodData();
        }

        /// <summary>
        /// Carga en los controles del formulario la información del alimento seleccionado.
        /// </summary>
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

        /// <summary>
        /// Valida la información ingresada, actualiza el alimento seleccionado
        /// y guarda los cambios en el repositorio.
        /// </summary>
        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (selectedFood == null)
            {
                MessageBox.Show("No se encontró el alimento.");
                return;
            }

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

        /// <summary>
        /// Evento reservado para futuras inicializaciones del formulario.
        /// </summary>
        private void EditFoodForm_Load(object sender, EventArgs e)
        {
            /// N/A
        }
    }
}