namespace WinFormsApp1
{
    partial class EscolhaTurma
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
            cbTurmas = new ComboBox();
            btnEntrarTurma = new Button();
            lblSemTurmas = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(252, 9);
            label1.Name = "label1";
            label1.Size = new Size(285, 25);
            label1.TabIndex = 0;
            label1.Text = "Selecione a Turma para Aceder";
            label1.Click += label1_Click;
            // 
            // cbTurmas
            // 
            cbTurmas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTurmas.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            cbTurmas.FormattingEnabled = true;
            cbTurmas.Location = new Point(312, 81);
            cbTurmas.Name = "cbTurmas";
            cbTurmas.Size = new Size(133, 28);
            cbTurmas.TabIndex = 1;
            // 
            // btnEntrarTurma
            // 
            btnEntrarTurma.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEntrarTurma.Location = new Point(312, 234);
            btnEntrarTurma.Name = "btnEntrarTurma";
            btnEntrarTurma.Size = new Size(126, 61);
            btnEntrarTurma.TabIndex = 2;
            btnEntrarTurma.Text = "Entrar na Turma";
            btnEntrarTurma.UseVisualStyleBackColor = true;
            btnEntrarTurma.Click += btnEntrarTurma_Click;
            // 
            // lblSemTurmas
            // 
            lblSemTurmas.AutoSize = true;
            lblSemTurmas.ForeColor = Color.DarkRed;
            lblSemTurmas.Location = new Point(194, 123);
            lblSemTurmas.Name = "lblSemTurmas";
            lblSemTurmas.Size = new Size(368, 15);
            lblSemTurmas.TabIndex = 3;
            lblSemTurmas.Text = "Ainda não existem turmas registadas. Crie uma turma para começar.";
            lblSemTurmas.Visible = false;
            // 
            // EscolhaTurma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblSemTurmas);
            Controls.Add(btnEntrarTurma);
            Controls.Add(cbTurmas);
            Controls.Add(label1);
            Name = "EscolhaTurma";
            Text = "EscolhaTurma";
            Load += EscolhaTurma_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbTurmas;
        private Button btnEntrarTurma;
        private Label lblSemTurmas;
    }
}