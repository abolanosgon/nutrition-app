namespace Nutrition_App.Views
{
    partial class UserMealForm
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
            dgvMealRecords = new DataGridView();
            label2 = new Label();
            cmbMealType = new ComboBox();
            label3 = new Label();
            txtQuantity = new TextBox();
            label4 = new Label();
            cmbFoods = new ComboBox();
            btnRegisterMeal = new Button();
            btnDeleteMealRecord = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMealRecords).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(247, 27);
            label1.Name = "label1";
            label1.Size = new Size(170, 15);
            label1.TabIndex = 0;
            label1.Text = "Mi menu / registro de comidas";
            // 
            // dgvMealRecords
            // 
            dgvMealRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMealRecords.Location = new Point(36, 66);
            dgvMealRecords.Name = "dgvMealRecords";
            dgvMealRecords.Size = new Size(580, 210);
            dgvMealRecords.TabIndex = 1;
            dgvMealRecords.CellClick += dgvMealRecords_CellClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(197, 297);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 2;
            label2.Text = "Tipo de comida";
            // 
            // cmbMealType
            // 
            cmbMealType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMealType.FormattingEnabled = true;
            cmbMealType.Items.AddRange(new object[] { "Desayuno", "Almuerzo", "Cena", "Snack" });
            cmbMealType.Location = new Point(336, 294);
            cmbMealType.Name = "cmbMealType";
            cmbMealType.Size = new Size(121, 23);
            cmbMealType.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(197, 326);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 4;
            label3.Text = "Cantidad";
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(336, 323);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(100, 23);
            txtQuantity.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(197, 355);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 6;
            label4.Text = "Alimento";
            // 
            // cmbFoods
            // 
            cmbFoods.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFoods.FormattingEnabled = true;
            cmbFoods.Location = new Point(336, 352);
            cmbFoods.Name = "cmbFoods";
            cmbFoods.Size = new Size(121, 23);
            cmbFoods.TabIndex = 7;
            // 
            // btnRegisterMeal
            // 
            btnRegisterMeal.Location = new Point(47, 386);
            btnRegisterMeal.Name = "btnRegisterMeal";
            btnRegisterMeal.Size = new Size(164, 35);
            btnRegisterMeal.TabIndex = 8;
            btnRegisterMeal.Text = "Registrar Comida";
            btnRegisterMeal.UseVisualStyleBackColor = true;
            btnRegisterMeal.Click += btnRegisterMeal_Click;
            // 
            // btnDeleteMealRecord
            // 
            btnDeleteMealRecord.Location = new Point(232, 386);
            btnDeleteMealRecord.Name = "btnDeleteMealRecord";
            btnDeleteMealRecord.Size = new Size(164, 35);
            btnDeleteMealRecord.TabIndex = 9;
            btnDeleteMealRecord.Text = "Eliminar  Comida";
            btnDeleteMealRecord.UseVisualStyleBackColor = true;
            btnDeleteMealRecord.Click += btnDeleteMealRecord_Click;
            // 
            // UserMealForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 450);
            Controls.Add(btnDeleteMealRecord);
            Controls.Add(btnRegisterMeal);
            Controls.Add(cmbFoods);
            Controls.Add(label4);
            Controls.Add(txtQuantity);
            Controls.Add(label3);
            Controls.Add(cmbMealType);
            Controls.Add(label2);
            Controls.Add(dgvMealRecords);
            Controls.Add(label1);
            Name = "UserMealForm";
            Text = "Form1";
            Load += UserMealForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMealRecords).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvMealRecords;
        private Label label2;
        private ComboBox cmbMealType;
        private Label label3;
        private TextBox txtQuantity;
        private Label label4;
        private ComboBox cmbFoods;
        private Button btnRegisterMeal;
        private Button btnDeleteMealRecord;
    }
}