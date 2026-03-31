namespace Nutrition_App.Views
{
    partial class AdminForm
    {
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
            dgvUsers = new DataGridView();
            btnDeleteUser = new Button();
            btnEditUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // dgvUsers
            // 
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(12, 12);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(480, 583);
            dgvUsers.TabIndex = 0;
            dgvUsers.CellClick += dgvUsers_CellClick;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Location = new Point(536, 57);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(163, 33);
            btnDeleteUser.TabIndex = 1;
            btnDeleteUser.Text = "Eliminar Usuario";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(536, 105);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(163, 33);
            btnEditUser.TabIndex = 2;
            btnEditUser.Text = "Editar Usuario";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(750, 607);
            Controls.Add(btnEditUser);
            Controls.Add(btnDeleteUser);
            Controls.Add(dgvUsers);
            Name = "AdminForm";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvUsers;
        private Button btnDeleteUser;
        private Button btnEditUser;
    }
}