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
            SuspendLayout();
            // 
            // lblBemVindo
            // 
            lblBemVindo.AutoSize = true;
            lblBemVindo.Location = new Point(337, 60);
            lblBemVindo.Name = "lblBemVindo";
            lblBemVindo.Size = new Size(38, 15);
            lblBemVindo.TabIndex = 0;
            lblBemVindo.Text = "label1";
            // 
            // FormAluno
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblBemVindo);
            Name = "FormAluno";
            Text = "FormAluno";
            Load += FormAluno_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBemVindo;
    }
}