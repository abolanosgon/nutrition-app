using System;
using System.Linq;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class UserMealForm : Form
    {
        private User loggedUser;
        private FoodController foodController = new FoodController();
        private MealRecordController mealRecordController = new MealRecordController();
        private int selectedMealRecordId = -1;

        public UserMealForm()
        {
            InitializeComponent();
        }

        public UserMealForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadFoods();
            LoadMealRecords();
        }

        private void LoadFoods()
        {
            cmbFoods.DataSource = null;
            cmbFoods.DataSource = foodController.GetFoods();
            cmbFoods.DisplayMember = "Name";
            cmbFoods.ValueMember = "Id";
            cmbFoods.SelectedIndex = -1;
        }

        private void LoadMealRecords()
        {
            if (loggedUser == null)
            {
                return;
            }

            var allRecords = mealRecordController.GetRecords();
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

        private string TranslateMealType(string mealType)
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

        private void btnRegisterMeal_Click(object sender, EventArgs e)
        {
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

            string mealType = "";

            switch (cmbMealType.SelectedItem.ToString())
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

            MealRecord record = new MealRecord
            {
                UserId = loggedUser.Id,
                FoodId = Convert.ToInt32(cmbFoods.SelectedValue),
                RecordDate = DateTime.Now,
                MealType = mealType,
                Quantity = quantity
            };

            mealRecordController.RegisterRecord(record);

            MessageBox.Show("Comida registrada correctamente.");

            cmbFoods.SelectedIndex = -1;
            cmbMealType.SelectedIndex = -1;
            txtQuantity.Clear();

            LoadMealRecords();
        }

        private void UserMealForm_Load(object sender, EventArgs e)
        {

        }


        private void dgvMealRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMealRecords.Rows[e.RowIndex];

                if (row.Cells["Id"].Value != null)
                {
                    selectedMealRecordId = Convert.ToInt32(row.Cells["Id"].Value);
                }
            }
        }

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