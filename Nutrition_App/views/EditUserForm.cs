using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class EditUserForm : Form
    {
        private User selectedUser;
        private UserController userController = new UserController();

        public EditUserForm()
        {
            InitializeComponent();
        }

        public EditUserForm(User user)
        {
            InitializeComponent();
            selectedUser = user;
            LoadUserData();
        }

        private void LoadUserData()
        {
            if (selectedUser == null)
            {
                return;
            }

            txtName.Text = selectedUser.Name;
            txtAge.Text = selectedUser.Age.ToString();
            txtWeight.Text = selectedUser.Weight.ToString();
            txtHeight.Text = selectedUser.Height.ToString();

            cmbGender.SelectedItem = selectedUser.Gender == "Male" ? "Hombre" : "Mujer";

            switch (selectedUser.Goal)
            {
                case "Maintain":
                    cmbGoal.SelectedItem = "Mantener peso";
                    break;
                case "LoseFat":
                    cmbGoal.SelectedItem = "Perder grasa";
                    break;
                case "GainMuscle":
                    cmbGoal.SelectedItem = "Ganar masa muscular";
                    break;
            }

            switch (selectedUser.ActivityLevel)
            {
                case "Sedentary":
                    cmbActivityLevel.SelectedItem = "Sedentario";
                    break;
                case "Light":
                    cmbActivityLevel.SelectedItem = "Ligero";
                    break;
                case "Moderate":
                    cmbActivityLevel.SelectedItem = "Moderado";
                    break;
                case "Active":
                    cmbActivityLevel.SelectedItem = "Activo";
                    break;
            }

            switch (selectedUser.DietType)
            {
                case "Standard":
                    cmbDietType.SelectedItem = "Estándar";
                    break;
                case "Keto":
                    cmbDietType.SelectedItem = "Keto";
                    break;
                case "Vegetarian":
                    cmbDietType.SelectedItem = "Vegetariana";
                    break;
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age <= 0)
            {
                MessageBox.Show("Debe ingresar una edad válida.");
                return;
            }

            if (!double.TryParse(txtWeight.Text, out double weight) || weight <= 0)
            {
                MessageBox.Show("Debe ingresar un peso válido.");
                return;
            }

            if (!double.TryParse(txtHeight.Text, out double height) || height <= 0)
            {
                MessageBox.Show("Debe ingresar una altura válida.");
                return;
            }

            if (cmbGender.SelectedItem == null || cmbGoal.SelectedItem == null ||
                cmbActivityLevel.SelectedItem == null || cmbDietType.SelectedItem == null)
            {
                MessageBox.Show("Debe completar todos los campos.");
                return;
            }

            selectedUser.Name = txtName.Text;
            selectedUser.Age = age;
            selectedUser.Weight = weight;
            selectedUser.Height = height;
            selectedUser.Gender = cmbGender.SelectedItem.ToString() == "Hombre" ? "Male" : "Female";

            switch (cmbGoal.SelectedItem.ToString())
            {
                case "Mantener peso":
                    selectedUser.Goal = "Maintain";
                    break;
                case "Perder grasa":
                    selectedUser.Goal = "LoseFat";
                    break;
                case "Ganar masa muscular":
                    selectedUser.Goal = "GainMuscle";
                    break;
            }

            switch (cmbActivityLevel.SelectedItem.ToString())
            {
                case "Sedentario":
                    selectedUser.ActivityLevel = "Sedentary";
                    break;
                case "Ligero":
                    selectedUser.ActivityLevel = "Light";
                    break;
                case "Moderado":
                    selectedUser.ActivityLevel = "Moderate";
                    break;
                case "Activo":
                    selectedUser.ActivityLevel = "Active";
                    break;
            }

            switch (cmbDietType.SelectedItem.ToString())
            {
                case "Estándar":
                    selectedUser.DietType = "Standard";
                    break;
                case "Keto":
                    selectedUser.DietType = "Keto";
                    break;
                case "Vegetariana":
                    selectedUser.DietType = "Vegetarian";
                    break;
            }

            userController.UpdateUser(selectedUser);

            MessageBox.Show("Usuario actualizado correctamente.");
            this.Close();
        }

        private void EditUserForm_Load(object sender, EventArgs e)
        {

        }
    }
}