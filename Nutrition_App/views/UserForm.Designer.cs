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
            lbl = new Label();
            lblWelcomeUser = new Label();
            btnEditProfile = new Button();
            btnDeleteAccount = new Button();
            dgvUserData = new DataGridView();
            btnlogout = new Button();
            btnOpenFoods = new Button();
            btnViewNutritionInfo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUserData).BeginInit();
            SuspendLayout();
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Location = new Point(190, 149);
            lbl.Name = "lbl";
            lbl.Size = new Size(66, 15);
            lbl.TabIndex = 0;
            lbl.Text = "Bienvenido";
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.Location = new Point(312, 149);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(38, 15);
            lblWelcomeUser.TabIndex = 1;
            lblWelcomeUser.Text = "label1";
            // 
            // btnEditProfile
            // 
            btnEditProfile.Location = new Point(223, 201);
            btnEditProfile.Name = "btnEditProfile";
            btnEditProfile.Size = new Size(117, 23);
            btnEditProfile.TabIndex = 2;
            btnEditProfile.Text = "Editar mi perfil";
            btnEditProfile.UseVisualStyleBackColor = true;
            btnEditProfile.Click += btnEditProfile_Click;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.Location = new Point(213, 230);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(137, 23);
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
            btnlogout.Location = new Point(213, 332);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(137, 23);
            btnlogout.TabIndex = 5;
            btnlogout.Text = "Cerrar Sesion";
            btnlogout.UseVisualStyleBackColor = true;
            btnlogout.Click += btnLogout_Click;
            // 
            // btnOpenFoods
            // 
            btnOpenFoods.Location = new Point(215, 261);
            btnOpenFoods.Name = "btnOpenFoods";
            btnOpenFoods.Size = new Size(135, 27);
            btnOpenFoods.TabIndex = 6;
            btnOpenFoods.Text = "Ver Alimentos";
            btnOpenFoods.UseVisualStyleBackColor = true;
            btnOpenFoods.Click += btnOpenFoods_Click;
            // 
            // btnViewNutritionInfo
            // 
            btnViewNutritionInfo.Location = new Point(190, 294);
            btnViewNutritionInfo.Name = "btnViewNutritionInfo";
            btnViewNutritionInfo.Size = new Size(172, 32);
            btnViewNutritionInfo.TabIndex = 7;
            btnViewNutritionInfo.Text = "Informacion Nutricional";
            btnViewNutritionInfo.UseVisualStyleBackColor = true;
            btnViewNutritionInfo.Click += btnViewNutritionInfo_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(562, 388);
            Controls.Add(btnViewNutritionInfo);
            Controls.Add(btnOpenFoods);
            Controls.Add(btnlogout);
            Controls.Add(dgvUserData);
            Controls.Add(btnDeleteAccount);
            Controls.Add(btnEditProfile);
            Controls.Add(lblWelcomeUser);
            Controls.Add(lbl);
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUserData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private Label lbl;
        private Label lblWelcomeUser;
        private Button btnEditProfile;
        private Button btnDeleteAccount;
        private DataGridView dgvUserData;
        private Button btnlogout;
        private Button btnOpenFoods;
        private Button btnViewNutritionInfo;
    }
}