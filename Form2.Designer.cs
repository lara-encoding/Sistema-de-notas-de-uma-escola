namespace WinFormsApp1
{
    partial class Form2
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
            dgvTurmas = new DataGridView();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTurmas).BeginInit();
            SuspendLayout();
            // 
            // dgvTurmas
            // 
            dgvTurmas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTurmas.Location = new Point(0, 0);
            dgvTurmas.Name = "dgvTurmas";
            dgvTurmas.RowTemplate.Height = 25;
            dgvTurmas.Size = new Size(432, 450);
            dgvTurmas.TabIndex = 2;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardar.Location = new Point(539, 342);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(162, 58);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar Alterações";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardar);
            Controls.Add(dgvTurmas);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)dgvTurmas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTurmas;
        private Button btnGuardar;
    }
}