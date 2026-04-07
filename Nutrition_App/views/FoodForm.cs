using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    // Formulario para la gestión de alimentos.
    // Permite crear, visualizar, editar y eliminar alimentos.
    public partial class FoodForm : Form
    {
        // Controlador para manejar operaciones de alimentos
        private FoodController foodController = new FoodController();

        // Id del alimento seleccionado en el DataGridView
        private int selectedFoodId = -1;

        // Usuario logueado (no se usa directamente aquí, pero se mantiene por contexto)
        private User? loggedUser;

        // Constructor que recibe el usuario logueado
        public FoodForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadFoods();
        }

        // Carga todos los alimentos en el DataGridView
        private void LoadFoods()
        {
            dgvFoods.DataSource = null;
            dgvFoods.DataSource = foodController.GetFoods();

            // Configuración de encabezados de columnas
            dgvFoods.Columns["Id"].HeaderText = "ID";
            dgvFoods.Columns["Name"].HeaderText = "Nombre";
            dgvFoods.Columns["Category"].HeaderText = "Categoría";
            dgvFoods.Columns["Calories"].HeaderText = "Calorías";
            dgvFoods.Columns["Protein"].HeaderText = "Proteína";
            dgvFoods.Columns["Carbohydrates"].HeaderText = "Carbohidratos";
            dgvFoods.Columns["Fat"].HeaderText = "Grasa";
            dgvFoods.Columns["PortionSize"].HeaderText = "Porción";
        }

        // Botón para agregar un nuevo alimento
        private void btnAddFood_Click(object sender, EventArgs e)
        {
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

            // Creación del objeto Food con los datos ingresados
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

            // Registro del alimento en el sistema
            foodController.RegisterFood(food);

            MessageBox.Show("Alimento agregado correctamente.");

            // Limpia formulario y recarga datos
            ClearFoodForm();
            LoadFoods();
        }

        // Evento al hacer clic en una fila del DataGridView
        // Guarda el Id del alimento seleccionado
        private void dgvFoods_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvFoods.Rows[e.RowIndex];
                object? idValue = row.Cells["Id"].Value;

                if (idValue != null && int.TryParse(idValue.ToString(), out int id))
                {
                    selectedFoodId = id;
                }
            }
        }

        // Botón para eliminar alimento seleccionado
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            // Validación: debe haber selección
            if (selectedFoodId == -1)
            {
                MessageBox.Show("Debe seleccionar un alimento.");
                return;
            }

            // Confirmación antes de eliminar
            DialogResult result = MessageBox.Show(
                "¿Está seguro de eliminar este alimento?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            // Eliminación
            if (result == DialogResult.Yes)
            {
                foodController.DeleteFood(selectedFoodId);
                LoadFoods();
                selectedFoodId = -1;

                MessageBox.Show("Alimento eliminado correctamente.");
            }
        }

        // Limpia los campos del formulario
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

        // Botón para editar alimento seleccionado
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            // Validación: debe haber selección
            if (selectedFoodId == -1)
            {
                MessageBox.Show("Debe seleccionar un alimento.");
                return;
            }

            // Obtiene el alimento desde el controlador
            Food? selectedFood = foodController.GetFoodById(selectedFoodId);

            if (selectedFood == null)
            {
                MessageBox.Show("No se encontró el alimento seleccionado.");
                return;
            }

            // Abre formulario de edición
            EditFoodForm editFoodForm = new EditFoodForm(selectedFood);
            editFoodForm.ShowDialog();

            // Refresca lista después de editar
            LoadFoods();
        }
    }
}