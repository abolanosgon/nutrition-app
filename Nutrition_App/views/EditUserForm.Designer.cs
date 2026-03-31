namespace Nutrition_App.Views
{
    partial class EditUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtName = new TextBox();
            txtAge = new TextBox();
            label2 = new Label();
            txtWeight = new TextBox();
            label3 = new Label();
            txtHeight = new TextBox();
            label4 = new Label();
            label5 = new Label();
            cmbGender = new ComboBox();
            cmbGoal = new ComboBox();
            label6 = new Label();
            cmbActivityLevel = new ComboBox();
            label7 = new Label();
            cmbDietType = new ComboBox();
            label8 = new Label();
            btnSaveChanges = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 41);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Nombre";
            // 
            // txtName
            // 
            txtName.Location = new Point(165, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 1;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(165, 67);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(100, 23);
            txtAge.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(58, 70);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 2;
            label2.Text = "Edad";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(165, 96);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(100, 23);
            txtWeight.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(58, 99);
            label3.Name = "label3";
            label3.Size = new Size(32, 15);
            label3.TabIndex = 4;
            label3.Text = "Peso";
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(165, 125);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(100, 23);
            txtHeight.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 128);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 6;
            label4.Text = "Altura";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 160);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 8;
            label5.Text = "Genero";
            // 
            // cmbGender
            // 
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGender.FormattingEnabled = true;
            cmbGender.Items.AddRange(new object[] { "Hombre", "Mujer" });
            cmbGender.Location = new Point(165, 157);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 23);
            cmbGender.TabIndex = 9;
            // 
            // cmbGoal
            // 
            cmbGoal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGoal.FormattingEnabled = true;
            cmbGoal.Items.AddRange(new object[] { "Mantener peso", "Perder grasa", "Ganar masa muscular" });
            cmbGoal.Location = new Point(165, 186);
            cmbGoal.Name = "cmbGoal";
            cmbGoal.Size = new Size(121, 23);
            cmbGoal.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(58, 189);
            label6.Name = "label6";
            label6.Size = new Size(52, 15);
            label6.TabIndex = 10;
            label6.Text = "Objetivo";
            // 
            // cmbActivityLevel
            // 
            cmbActivityLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActivityLevel.FormattingEnabled = true;
            cmbActivityLevel.Items.AddRange(new object[] { "Sedentario", "Ligero", "Moderado", "Activo" });
            cmbActivityLevel.Location = new Point(165, 215);
            cmbActivityLevel.Name = "cmbActivityLevel";
            cmbActivityLevel.Size = new Size(121, 23);
            cmbActivityLevel.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(58, 218);
            label7.Name = "label7";
            label7.Size = new Size(101, 15);
            label7.TabIndex = 12;
            label7.Text = "Nivel de actividad";
            // 
            // cmbDietType
            // 
            cmbDietType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDietType.FormattingEnabled = true;
            cmbDietType.Items.AddRange(new object[] { "Estándar", "Keto", "Vegetariana" });
            cmbDietType.Location = new Point(165, 244);
            cmbDietType.Name = "cmbDietType";
            cmbDietType.Size = new Size(121, 23);
            cmbDietType.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(58, 247);
            label8.Name = "label8";
            label8.Size = new Size(76, 15);
            label8.TabIndex = 14;
            label8.Text = "Tipo de dieta";
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.Location = new Point(115, 294);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(136, 23);
            btnSaveChanges.TabIndex = 16;
            btnSaveChanges.Text = "Guardar cambios";
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Click += btnSaveChanges_Click;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 577);
            Controls.Add(btnSaveChanges);
            Controls.Add(cmbDietType);
            Controls.Add(label8);
            Controls.Add(cmbActivityLevel);
            Controls.Add(label7);
            Controls.Add(cmbGoal);
            Controls.Add(label6);
            Controls.Add(cmbGender);
            Controls.Add(label5);
            Controls.Add(txtHeight);
            Controls.Add(label4);
            Controls.Add(txtWeight);
            Controls.Add(label3);
            Controls.Add(txtAge);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Name = "EditUserForm";
            Text = "Form1";
            Load += EditUserForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private TextBox txtAge;
        private Label label2;
        private TextBox txtWeight;
        private Label label3;
        private TextBox txtHeight;
        private Label label4;
        private Label label5;
        private ComboBox cmbGender;
        private ComboBox cmbGoal;
        private Label label6;
        private ComboBox cmbActivityLevel;
        private Label label7;
        private ComboBox cmbDietType;
        private Label label8;
        private Button btnSaveChanges;
    }
}