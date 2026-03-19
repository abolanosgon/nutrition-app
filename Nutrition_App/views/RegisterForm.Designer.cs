namespace Nutrition_App.Views

{
    partial class RegisterForm
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
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 40);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Location = new Point(161, 40);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // btnSaveUser
            // 
            btnSaveUser.Location = new Point(93, 358);
            btnSaveUser.Name = "btnSaveUser";
            btnSaveUser.Size = new Size(148, 30);
            btnSaveUser.TabIndex = 2;
            btnSaveUser.Text = "Guardar usuario";
            btnSaveUser.UseVisualStyleBackColor = true;
            btnSaveUser.Click += btnSaveUser_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 72);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 3;
            label2.Text = "Edad";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(161, 69);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 4;
            txtAge.TextChanged += txtAge_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 105);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 5;
            label3.Text = "Peso";
            label3.Click += label3_Click;
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(161, 105);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(100, 23);
            txtWeight.TabIndex = 6;
            // 
            // lablel
            // 
            lablel.AutoSize = true;
            lablel.Location = new Point(35, 137);
            lablel.Name = "lablel";
            lablel.Size = new Size(39, 15);
            lablel.TabIndex = 7;
            lablel.Text = "Altura";
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(161, 137);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(100, 23);
            txtHeight.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 171);
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
            cmbGender.Location = new Point(161, 168);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 23);
            cmbGender.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(35, 200);
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
            cmbGoal.Location = new Point(161, 197);
            cmbGoal.Name = "cmbGoal";
            cmbGoal.Size = new Size(121, 23);
            cmbGoal.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(35, 229);
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
            cmbActivityLevel.Location = new Point(161, 229);
            cmbActivityLevel.Name = "cmbActivityLevel";
            cmbActivityLevel.Size = new Size(121, 23);
            cmbActivityLevel.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(35, 265);
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
            cmbDietType.Location = new Point(161, 258);
            cmbDietType.Name = "cmbDietType";
            cmbDietType.Size = new Size(121, 23);
            cmbDietType.TabIndex = 16;
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(336, 40);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(335, 288);
            dgvUsers.TabIndex = 17;
            dgvUsers.CellClick += dgvUsers_CellClick;
            
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(35, 296);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 18;
            label8.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(161, 288);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(100, 23);
            txtPassword.TabIndex = 19;
            // 
            // lblSelectedUser
            // 
            lblSelectedUser.AutoSize = true;
            lblSelectedUser.Location = new Point(35, 325);
            lblSelectedUser.Name = "lblSelectedUser";
            lblSelectedUser.Size = new Size(121, 15);
            lblSelectedUser.TabIndex = 20;
            lblSelectedUser.Text = "Usuario generado: ---";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 438);
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
            Name = "RegisterForm";
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
    }
}
