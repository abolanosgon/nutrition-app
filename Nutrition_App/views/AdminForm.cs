using System;
using System.Windows.Forms;
using Nutrition_App.Controllers;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class AdminForm : Form
    {
        private User loggedUser;
        private UserController userController = new UserController();
        private int selectedUserId = -1;

        public AdminForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        public AdminForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = userController.GetUsers();
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvUsers.Rows[e.RowIndex];
                selectedUserId = Convert.ToInt32(row.Cells["Id"].Value);
            }
        }
    }
}