using Nutrition_App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;


namespace Nutrition_App.views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private UserController userController = new UserController();

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Debe ingresar un usuario.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.");
                return;
            }

            User authenticatedUser = userController.AuthenticateUser(txtUsername.Text, txtPassword.Text);

            if (authenticatedUser == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
                return;
            }

            MessageBox.Show("Inicio de sesión exitoso. Bienvenido " + authenticatedUser.Name);

            RegisterForm registerForm = new RegisterForm(authenticatedUser);
            registerForm.Show();
            this.Hide();
        }
    }
}
