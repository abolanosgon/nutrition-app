using System;
using System.Windows.Forms;
using Nutrition_App.Models;

namespace Nutrition_App.Views
{
    public partial class UserForm : Form
    {
        private User loggedUser;

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(User user)
        {
            InitializeComponent();
            loggedUser = user;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}