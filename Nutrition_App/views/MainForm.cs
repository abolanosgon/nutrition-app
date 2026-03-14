using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class MainForm : Form
    {
        // Controlador que manejará la lógica relacionada con usuarios
        private UserController userController = new UserController();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Debe ingresar un nombre.");
                return;
            }

            User user = new User
            {
                Name = txtName.Text,
                Age = 25,
                Weight = 70,
                Height = 170,
                Gender = "Male",
                Goal = "Maintain",
                ActivityLevel = "Moderate",
                DietType = "Standard"
            };

            // Enviamos el usuario al controlador
            userController.RegisterUser(user);

            // Confirmación al usuario
            MessageBox.Show("Usuario registrado correctamente.");
            txtName.Clear();
            txtName.Focus();




        }
    }
}