namespace WinFormsApp1
{
    partial class FormAluno
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
            lblBemVindo = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // lblBemVindo
            // 
            lblBemVindo.AutoSize = true;
            lblBemVindo.Location = new Point(359, 9);
            lblBemVindo.Name = "lblBemVindo";
            lblBemVindo.Size = new Size(38, 15);
            lblBemVindo.TabIndex = 0;
            lblBemVindo.Text = "label1";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(685, 12);
            button1.Name = "button1";
            button1.Size = new Size(103, 65);
            button1.TabIndex = 1;
            button1.Text = "Justificar Falta(s)";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(lblBemVindo);
            Name = "FormAluno";
            Text = "FormAluno";
            Load += FormAluno_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBemVindo;
        private Button button1;
    }
}