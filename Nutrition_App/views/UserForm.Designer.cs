namespace Nutrition_App.Views
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblWelcomeUser = new Label();
            btnEditProfile = new Button();
            btnDeleteAccount = new Button();
            dgvUserData = new DataGridView();
            btnlogout = new Button();
            btnOpenFoods = new Button();
            btnViewNutritionInfo = new Button();
            btnViewMyStats = new Button();
            btnViewMenu = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUserData).BeginInit();
            SuspendLayout();
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.Location = new Point(219, 150);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(38, 15);
            lblWelcomeUser.TabIndex = 1;
            lblWelcomeUser.Text = "label1";
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(196, 209);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(147, 32);
            btnEditProfile.TabIndex = 2;
            btnEditProfile.Text = "Editar mi perfil";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.Location = new Point(68, 323);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(147, 32);
            btnDeleteAccount.TabIndex = 3;
            btnDeleteAccount.Text = "Eliminar mi cuenta";
            btnDeleteAccount.UseVisualStyleBackColor = true;
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // dgvUserData
            // 
            dgvUserData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUserData.Location = new Point(12, 46);
            dgvUserData.Name = "dgvUserData";
            dgvUserData.Size = new Size(538, 88);
            dgvUserData.TabIndex = 4;
            // 
            // btnlogout
            // 
            btnlogout.Location = new Point(321, 323);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(147, 32);
            btnlogout.TabIndex = 5;
            btnlogout.Text = "Cerrar Sesion";
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnLogout_Click;
            // 
            // btnOpenFoods
            // 
            btnOpenFoods.Location = new Point(321, 285);
            btnOpenFoods.Name = "btnOpenFoods";
            btnOpenFoods.Size = new Size(147, 32);
            btnOpenFoods.TabIndex = 6;
            btnOpenFoods.Text = "Ingresar Alimentos";
            btnOpenFoods.UseVisualStyleBackColor = true;
            btnOpenFoods.Click += btnOpenFoods_Click;
            // 
            // btnViewNutritionInfo
            // 
            btnViewNutritionInfo.Location = new Point(68, 247);
            btnViewNutritionInfo.Name = "btnViewNutritionInfo";
            btnViewNutritionInfo.Size = new Size(147, 32);
            btnViewNutritionInfo.TabIndex = 7;
            btnViewNutritionInfo.Text = "Informacion Nutricional";
            btnViewNutritionInfo.UseVisualStyleBackColor = true;
            btnViewNutritionInfo.Click += btnViewNutritionInfo_Click;
            // 
            // btnViewMyStats
            // 
            btnViewMyStats.Location = new Point(68, 285);
            btnViewMyStats.Name = "btnViewMyStats";
            btnViewMyStats.Size = new Size(147, 32);
            btnViewMyStats.TabIndex = 8;
            btnViewMyStats.Text = "Ver mis estadísticas";
            btnViewMyStats.UseVisualStyleBackColor = true;
            btnViewMyStats.Click += btnViewMyStats_Click;
            // 
            // btnViewMenu
            // 
            btnViewMenu.Location = new Point(321, 247);
            btnViewMenu.Name = "btnViewMenu";
            btnViewMenu.Size = new Size(147, 32);
            btnViewMenu.TabIndex = 9;
            btnViewMenu.Text = "Menu Asignado";
            btnViewMenu.UseVisualStyleBackColor = true;
            btnViewMenu.Click += btnViewMenu_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 388);
            Controls.Add(btnViewMenu);
            Controls.Add(btnViewMyStats);
            Controls.Add(btnViewNutritionInfo);
            Controls.Add(btnOpenFoods);
            Controls.Add(btnlogout);
            Controls.Add(dgvUserData);
            Controls.Add(btnDeleteAccount);
            Controls.Add(btnEditProfile);
            Controls.Add(lblWelcomeUser);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUserData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lblWelcomeUser;
        private Button btnEditProfile;
        private Button btnDeleteAccount;
        private DataGridView dgvUserData;
        private Button btnlogout;
        private Button btnOpenFoods;
        private Button btnViewNutritionInfo;
        private Button btnViewMyStats;
        private Button btnViewMenu;
    }
}