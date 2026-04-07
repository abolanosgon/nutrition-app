using System;
using System.Linq;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    // Formulario para registrar y visualizar las comidas del usuario.
    // Permite agregar registros de alimentos consumidos y eliminarlos.
    public partial class UserMealForm : Form
    {
        // Usuario logueado
        private User? loggedUser;

        // Controladores para alimentos y registros de comidas
        private FoodController foodController = new FoodController();
        private MealRecordController mealRecordController = new MealRecordController();

        // Id del registro seleccionado en la tabla
        private int selectedMealRecordId = -1;

        // Constructor por defecto
        public UserMealForm()
        {
            InitializeComponent();
        }

        // Constructor con usuario logueado
        public UserMealForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadFoods();
            LoadMealRecords();
        }

        // Carga los alimentos en el ComboBox
        private void LoadFoods()
        {
            cmbFoods.DataSource = null;
            cmbFoods.DataSource = foodController.GetFoods();
            cmbFoods.DisplayMember = "Name";
            cmbFoods.ValueMember = "Id";
            cmbFoods.SelectedIndex = -1;
        }

        // Carga los registros de comida del usuario en el DataGridView
        private void LoadMealRecords()
        {
            if (loggedUser == null)
            {
                return;
            }

            var allRecords = mealRecordController.GetRecords();

            // Filtra solo los registros del usuario logueado
            var userRecords = allRecords
                .Where(r => r.UserId == loggedUser.Id)
                .Select(r => new
                {
                    Id = r.Id,
                    FoodName = foodController.GetFoodById(r.FoodId)?.Name,
                    MealType = TranslateMealType(r.MealType),
                    RecordDate = r.RecordDate,
                    Quantity = r.Quantity
                })
                .ToList();

            dgvMealRecords.DataSource = null;
            dgvMealRecords.DataSource = userRecords;

            // Configuración de encabezados
            if (dgvMealRecords.Columns["Id"] != null)
                dgvMealRecords.Columns["Id"].HeaderText = "ID";

            if (dgvMealRecords.Columns["FoodName"] != null)
                dgvMealRecords.Columns["FoodName"].HeaderText = "Alimento";

            if (dgvMealRecords.Columns["MealType"] != null)
                dgvMealRecords.Columns["MealType"].HeaderText = "Tipo de comida";

            if (dgvMealRecords.Columns["RecordDate"] != null)
                dgvMealRecords.Columns["RecordDate"].HeaderText = "Fecha";

            if (dgvMealRecords.Columns["Quantity"] != null)
                dgvMealRecords.Columns["Quantity"].HeaderText = "Cantidad";
        }

        // Traduce tipo de comida a español para mostrar en la UI
        private static string TranslateMealType(string mealType)
        {
            switch (mealType)
            {
                case "Breakfast":
                    return "Desayuno";
                case "Lunch":
                    return "Almuerzo";
                case "Dinner":
                    return "Cena";
                case "Snack":
                    return "Snack";
                default:
                    return mealType;
            }
        }

        // Botón para registrar una nueva comida
        private void btnRegisterMeal_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (loggedUser == null)
            {
                MessageBox.Show("No se encontró el usuario.");
                return;
            }

            if (cmbFoods.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un alimento.");
                return;
            }

            if (cmbMealType.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de comida.");
                return;
            }

            if (!double.TryParse(txtQuantity.Text, out double quantity) || quantity <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida.");
                return;
            }

            // Conversión del tipo de comida de UI a formato interno
            string mealType = "";

            switch (cmbMealType.SelectedItem?.ToString() ?? "")
            {
                case "Desayuno":
                    mealType = "Breakfast";
                    break;
                case "Almuerzo":
                    mealType = "Lunch";
                    break;
                case "Cena":
                    mealType = "Dinner";
                    break;
                case "Snack":
                    mealType = "Snack";
                    break;
            }

            if (string.IsNullOrWhiteSpace(mealType))
            {
                MessageBox.Show("El tipo de comida seleccionado no es válido.");
                return;
            }

            // Obtiene el Id del alimento seleccionado
            if (cmbFoods.SelectedValue == null || !int.TryParse(cmbFoods.SelectedValue.ToString(), out int foodId))
            {
                MessageBox.Show("No se pudo obtener el alimento seleccionado.");
                return;
            }

            // Crea el registro de comida
            MealRecord record = new MealRecord
            {
                UserId = loggedUser.Id,
                FoodId = foodId,
                RecordDate = DateTime.Now,
                MealType = mealType,
                Quantity = quantity
            };

            // Guarda el registro
            mealRecordController.RegisterRecord(record);

            MessageBox.Show("Comida registrada correctamente.");

            // Limpia los campos
            cmbFoods.SelectedIndex = -1;
            cmbMealType.SelectedIndex = -1;
            txtQuantity.Clear();

            // Recarga la tabla
            LoadMealRecords();
        }

        // Evento al seleccionar un registro en la tabla
        private void dgvMealRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMealRecords.Rows[e.RowIndex];
                object? idValue = row.Cells["Id"].Value;

                if (idValue != null && int.TryParse(idValue.ToString(), out int id))
                {
                    selectedMealRecordId = id;
                }
            }
        }

        // Botón para eliminar un registro de comida
        private void btnDeleteMealRecord_Click(object sender, EventArgs e)
        {
            if (selectedMealRecordId == -1)
            {
                MessageBox.Show("Debe seleccionar un registro.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "¿Está seguro que desea eliminar este registro?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                mealRecordController.DeleteRecord(selectedMealRecordId);

                MessageBox.Show("Registro eliminado correctamente.");

                selectedMealRecordId = -1;

                LoadMealRecords();
            }
        }
    }
}