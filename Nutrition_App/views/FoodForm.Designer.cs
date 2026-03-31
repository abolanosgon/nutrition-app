namespace Nutrition_App.Views
{
    partial class FoodForm
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
            dgvFoods = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtFoodName = new TextBox();
            txtCategory = new TextBox();
            txtCalories = new TextBox();
            txtProtein = new TextBox();
            txtCarbohydrates = new TextBox();
            txtFat = new TextBox();
            txtPortionSize = new TextBox();
            btnAddFood = new Button();
            btnDeleteFood = new Button();
            btnEditFood = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFoods).BeginInit();
            SuspendLayout();
            // 
            // dgvFoods
            // 
            dgvFoods.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFoods.Location = new Point(12, 12);
            dgvFoods.Name = "dgvFoods";
            dgvFoods.Size = new Size(445, 426);
            dgvFoods.TabIndex = 0;
            dgvFoods.CellClick += dgvFoods_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(495, 24);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 1;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(495, 53);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "Categoria";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(495, 82);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 3;
            label3.Text = "Calorias";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(495, 111);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 4;
            label4.Text = "Proteina";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(495, 140);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 5;
            label5.Text = "Carbohidratos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(495, 169);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 6;
            label6.Text = "Grasa";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(495, 198);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 7;
            label7.Text = "Porcion";
            // 
            // txtFoodName
            // 
            txtFoodName.Location = new Point(594, 21);
            txtFoodName.Name = "txtFoodName";
            txtFoodName.Size = new Size(100, 23);
            txtFoodName.TabIndex = 8;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(594, 50);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(100, 23);
            txtCategory.TabIndex = 9;
            // 
            // txtCalories
            // 
            txtCalories.Location = new Point(594, 79);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(100, 23);
            txtCalories.TabIndex = 10;
            // 
            // txtProtein
            // 
            txtProtein.Location = new Point(594, 108);
            txtProtein.Name = "txtProtein";
            txtProtein.Size = new Size(100, 23);
            txtProtein.TabIndex = 11;
            // 
            // txtCarbohydrates
            // 
            txtCarbohydrates.Location = new Point(594, 137);
            txtCarbohydrates.Name = "txtCarbohydrates";
            txtCarbohydrates.Size = new Size(100, 23);
            txtCarbohydrates.TabIndex = 12;
            // 
            // txtFat
            // 
            txtFat.Location = new Point(594, 166);
            txtFat.Name = "txtFat";
            txtFat.Size = new Size(100, 23);
            txtFat.TabIndex = 13;
            // 
            // txtPortionSize
            // 
            txtPortionSize.Location = new Point(594, 195);
            txtPortionSize.Name = "txtPortionSize";
            txtPortionSize.Size = new Size(100, 23);
            txtPortionSize.TabIndex = 14;
            // 
            // btnAddFood
            // 
            btnAddFood.Location = new Point(529, 301);
            btnAddFood.Name = "btnAddFood";
            btnAddFood.Size = new Size(144, 30);
            btnAddFood.TabIndex = 16;
            btnAddFood.Text = "Agregar alimento";
            btnAddFood.UseVisualStyleBackColor = true;
            btnAddFood.Click += btnAddFood_Click;
            // 
            // btnDeleteFood
            // 
            btnDeleteFood.Location = new Point(532, 337);
            btnDeleteFood.Name = "btnDeleteFood";
            btnDeleteFood.Size = new Size(141, 29);
            btnDeleteFood.TabIndex = 17;
            btnDeleteFood.Text = "Eliminar alimento";
            btnDeleteFood.UseVisualStyleBackColor = true;
            btnDeleteFood.Click += btnDeleteFood_Click;
            // 
            // btnEditFood
            // 
            btnEditFood.Location = new Point(532, 372);
            btnEditFood.Name = "btnEditFood";
            btnEditFood.Size = new Size(141, 27);
            btnEditFood.TabIndex = 18;
            btnEditFood.Text = "Editar Alimento";
            btnEditFood.UseVisualStyleBackColor = true;
            btnEditFood.Click += btnEditFood_Click;
            // 
            // FoodForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(721, 450);
            Controls.Add(btnEditFood);
            Controls.Add(btnDeleteFood);
            Controls.Add(btnAddFood);
            Controls.Add(txtPortionSize);
            Controls.Add(txtFat);
            Controls.Add(txtCarbohydrates);
            Controls.Add(txtProtein);
            Controls.Add(txtCalories);
            Controls.Add(txtCategory);
            Controls.Add(txtFoodName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvFoods);
            Name = "FoodForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvFoods).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFoods;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtFoodName;
        private TextBox txtCategory;
        private TextBox txtCalories;
        private TextBox txtProtein;
        private TextBox txtCarbohydrates;
        private TextBox txtFat;
        private TextBox txtPortionSize;
        private Button btnAddFood;
        private Button btnDeleteFood;
        private Button btnEditFood;
    }
}