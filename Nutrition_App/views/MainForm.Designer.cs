namespace Nutrition_App.Views

{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            btnSaveUser = new Button();
            label2 = new Label();
            txtAge = new TextBox();
            label3 = new Label();
            txtWeight = new TextBox();
            lablel = new Label();
            txtHeight = new TextBox();
            label4 = new Label();
            cmbGender = new ComboBox();
            label5 = new Label();
            cmbGoal = new ComboBox();
            label6 = new Label();
            cmbActivityLevel = new ComboBox();
            label7 = new Label();
            cmbDietType = new ComboBox();
            dgvUsers = new DataGridView();
            label8 = new Label();
            txtPassword = new TextBox();
            lblSelectedUser = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtLoginUsername = new TextBox();
            txtLoginPassword = new TextBox();
            btnLogin = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 18);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Location = new Point(155, 18);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // btnSaveUser
            // 
            btnSaveUser.Location = new Point(87, 336);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(138, 23);
            btnSaveUser.TabIndex = 2;
            btnSaveUser.Text = "Guardar usuario";
            btnSaveUser.UseVisualStyleBackColor = true;
            btnSaveUser.Click += btnSaveUser_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 50);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 3;
            label2.Text = "Edad";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(155, 47);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 4;
            txtAge.TextChanged += txtAge_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 83);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 5;
            label3.Text = "Peso";
            label3.Click += label3_Click;
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(155, 83);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(100, 23);
            txtWeight.TabIndex = 6;
            // 
            // lablel
            // 
            lablel.AutoSize = true;
            lablel.Location = new Point(29, 115);
            lablel.Name = "lablel";
            lablel.Size = new Size(39, 15);
            lablel.TabIndex = 7;
            lablel.Text = "Altura";
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(155, 115);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(100, 23);
            txtHeight.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 149);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 9;
            label4.Text = "Genero";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Hombre", "Mujer" });
            cmbGender.Location = new Point(155, 146);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 23);
            cmbGender.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 178);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 11;
            label5.Text = "Objetivo";
            // 
            // cmbGoal
            // 
            cmbGoal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGoal.FlatStyle = FlatStyle.System;
            cmbGoal.FormattingEnabled = true;
            cmbGoal.Items.AddRange(new object[] { "Mantener peso", "Perder grasa", "Ganar masa muscular" });
            cmbGoal.Location = new Point(155, 175);
            cmbGoal.Name = "cmbGoal";
            cmbGoal.Size = new Size(121, 23);
            cmbGoal.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 207);
            label6.Name = "label6";
            label6.Size = new Size(101, 15);
            label6.TabIndex = 13;
            label6.Text = "Nivel de actividad";
            // 
            // cmbActivityLevel
            // 
            cmbActivityLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActivityLevel.FlatStyle = FlatStyle.System;
            cmbActivityLevel.FormattingEnabled = true;
            cmbActivityLevel.Items.AddRange(new object[] { "Sedentario", "Ligero", "Moderado", "Activo" });
            cmbActivityLevel.Location = new Point(155, 207);
            cmbActivityLevel.Name = "cmbActivityLevel";
            cmbActivityLevel.Size = new Size(121, 23);
            cmbActivityLevel.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(29, 243);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 15;
            label7.Text = "Tipo de dieta";
            // 
            // cmbDietType
            // 
            cmbDietType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDietType.FlatStyle = FlatStyle.System;
            cmbDietType.FormattingEnabled = true;
            cmbDietType.Items.AddRange(new object[] { "Estándar", "Keto", "Vegetariana" });
            cmbDietType.Location = new Point(155, 236);
            cmbDietType.Name = "cmbDietType";
            cmbDietType.Size = new Size(121, 23);
            cmbDietType.TabIndex = 16;
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(338, 12);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(394, 175);
            dgvUsers.TabIndex = 17;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(29, 274);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 18;
            label8.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(155, 266);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 19;
            // 
            // lblSelectedUser
            // 
            lblSelectedUser.AutoSize = true;
            lblSelectedUser.Location = new Point(29, 303);
            lblSelectedUser.Name = "lblSelectedUser";
            lblSelectedUser.Size = new Size(121, 15);
            lblSelectedUser.TabIndex = 20;
            lblSelectedUser.Text = "Usuario generado: ---";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(483, 215);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 21;
            label9.Text = "Log In";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(407, 244);
            label10.Name = "label10";
            label10.Size = new Size(47, 15);
            label10.TabIndex = 22;
            label10.Text = "Usuario";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(407, 284);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 23;
            label11.Text = "Contraseña";
            // 
            // txtLoginUsername
            // 
            txtLoginUsername.Location = new Point(550, 241);
            txtLoginUsername.Name = "txtLoginUsername";
            txtLoginUsername.Size = new Size(100, 23);
            txtLoginUsername.TabIndex = 24;
            // 
            // txtLoginPassword
            // 
            txtLoginPassword.Location = new Point(550, 281);
            txtLoginPassword.Name = "txtLoginPassword";
            txtLoginPassword.Size = new Size(100, 23);
            txtLoginPassword.TabIndex = 25;
            txtLoginPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(453, 336);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(129, 23);
            btnLogin.TabIndex = 26;
            btnLogin.Text = "Iniciar sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(763, 443);
            Controls.Add(btnLogin);
            Controls.Add(txtLoginPassword);
            Controls.Add(txtLoginUsername);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(lblSelectedUser);
            Controls.Add(txtPassword);
            Controls.Add(label8);
            Controls.Add(dgvUsers);
            Controls.Add(cmbDietType);
            Controls.Add(label7);
            Controls.Add(cmbActivityLevel);
            Controls.Add(label6);
            Controls.Add(cmbGoal);
            Controls.Add(label5);
            Controls.Add(cmbGender);
            Controls.Add(label4);
            Controls.Add(txtHeight);
            Controls.Add(lablel);
            Controls.Add(txtWeight);
            Controls.Add(label3);
            Controls.Add(txtAge);
            Controls.Add(label2);
            Controls.Add(btnSaveUser);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Button btnSaveUser;
        private Label label2;
        private TextBox txtAge;
        private Label label3;
        private TextBox txtWeight;
        private Label lablel;
        private TextBox txtHeight;
        private Label label4;
        private ComboBox cmbGender;
        private Label label5;
        private ComboBox cmbGoal;
        private Label label6;
        private ComboBox cmbActivityLevel;
        private Label label7;
        private ComboBox cmbDietType;
        private DataGridView dgvUsers;
        private Label label8;
        private TextBox txtPassword;
        private Label lblSelectedUser;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtLoginUsername;
        private TextBox txtLoginPassword;
        private Button btnLogin;
        private Button btnSeedData;
    }
}
