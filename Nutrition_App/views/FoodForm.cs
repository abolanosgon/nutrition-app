using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    /// <summary>
    /// Formulario para la gestión de alimentos del sistema.
    /// Permite visualizar la lista de alimentos, registrar nuevos alimentos,
    /// editar alimentos existentes y eliminar registros seleccionados.
    /// </summary>
    public partial class FoodForm : Form
    {
        private FoodController foodController = new FoodController();
        private int selectedFoodId = -1;

        /// <summary>
        /// Inicializa una nueva instancia del formulario de alimentos.
        /// </summary>
        /// <param name="user">Usuario que accede al módulo de alimentos.</param>
        public FoodForm(User user)
        {
            InitializeComponent();
            LoadFoods();
        }

        /// <summary>
        /// Carga la lista de alimentos en la grilla y ajusta los encabezados visibles.
        /// </summary>
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

        /// <summary>
        /// Valida la información ingresada y registra un nuevo alimento en el sistema.
        /// </summary>
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

        /// <summary>
        /// Captura el identificador del alimento seleccionado en la grilla.
        /// </summary>
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

        /// <summary>
        /// Elimina el alimento seleccionado previa confirmación del usuario.
        /// </summary>
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
                LoadFoods();
                selectedFoodId = -1;

                MessageBox.Show("Alimento eliminado correctamente.");
            }
        }

        /// <summary>
        /// Limpia los controles del formulario de alimentos y devuelve el foco al campo de nombre.
        /// </summary>
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

        /// <summary>
        /// Abre el formulario de edición para el alimento seleccionado y recarga la lista al finalizar.
        /// </summary>
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (selectedFoodId == -1)
            {
                MessageBox.Show("Debe seleccionar un alimento.");
                return;
            }

            Food? selectedFood = foodController.GetFoodById(selectedFoodId);

            if (selectedFood == null)
            {
                MessageBox.Show("No se encontró el alimento seleccionado.");
                return;
            }

            EditFoodForm editFoodForm = new EditFoodForm(selectedFood);
            editFoodForm.ShowDialog();

            LoadFoods();
        }

        /// <summary>
        /// Evento reservado para futuras inicializaciones del formulario.
        /// </summary>
        private void FoodForm_Load(object sender, EventArgs e)
        {

        }
    }
}