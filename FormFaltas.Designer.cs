namespace WinFormsApp1
{
    partial class FormFaltas
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
            lblAluno = new Label();
            label3 = new Label();
            label4 = new Label();
            dtpData = new DateTimePicker();
            nudQuantidade = new NumericUpDown();
            btnRegistrarFalta = new Button();
            dgvFaltas = new DataGridView();
            colData = new DataGridViewTextBoxColumn();
            colQuantidade = new DataGridViewTextBoxColumn();
            colJustificada = new DataGridViewTextBoxColumn();
            colRecuperada = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFaltas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(183, 31);
            label1.Name = "label1";
            label1.Size = new Size(54, 21);
            label1.TabIndex = 0;
            label1.Text = "Aluno:";
            // 
            // lblAluno
            // 
            lblAluno.AutoSize = true;
            lblAluno.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblAluno.Location = new Point(234, 31);
            lblAluno.Name = "lblAluno";
            lblAluno.Size = new Size(115, 21);
            lblAluno.TabIndex = 1;
            lblAluno.Text = "nome do aluno";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(184, 70);
            label3.Name = "label3";
            label3.Size = new Size(102, 21);
            label3.TabIndex = 2;
            label3.Text = "Data da Falta:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(192, 111);
            label4.Name = "label4";
            label4.Size = new Size(94, 21);
            label4.TabIndex = 3;
            label4.Text = "Quantidade:";
            // 
            // dtpData
            // 
            dtpData.Location = new Point(292, 70);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(200, 23);
            dtpData.TabIndex = 4;
            // 
            // nudQuantidade
            // 
            nudQuantidade.Location = new Point(292, 114);
            nudQuantidade.Name = "nudQuantidade";
            nudQuantidade.Size = new Size(120, 23);
            nudQuantidade.TabIndex = 5;
            nudQuantidade.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnRegistrarFalta
            // 
            btnRegistrarFalta.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            btnRegistrarFalta.Location = new Point(377, 157);
            btnRegistrarFalta.Name = "btnRegistrarFalta";
            btnRegistrarFalta.Size = new Size(115, 47);
            btnRegistrarFalta.TabIndex = 6;
            btnRegistrarFalta.Text = "Registar Falta";
            btnRegistrarFalta.UseVisualStyleBackColor = true;
            // 
            // dgvFaltas
            // 
            dgvFaltas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFaltas.Columns.AddRange(new DataGridViewColumn[] { colData, colQuantidade, colJustificada, colRecuperada });
            dgvFaltas.Location = new Point(12, 233);
            dgvFaltas.Name = "dgvFaltas";
            dgvFaltas.RowTemplate.Height = 25;
            dgvFaltas.Size = new Size(647, 205);
            dgvFaltas.TabIndex = 7;
            // 
            // colData
            // 
            colData.DataPropertyName = "DataFalta";
            colData.HeaderText = "Data";
            colData.Name = "colData";
            // 
            // colQuantidade
            // 
            colQuantidade.DataPropertyName = "Quantidade";
            colQuantidade.HeaderText = "Quantidade";
            colQuantidade.Name = "colQuantidade";
            // 
            // colJustificada
            // 
            colJustificada.DataPropertyName = "Justificada";
            colJustificada.HeaderText = "Justificada";
            colJustificada.Name = "colJustificada";
            // 
            // colRecuperada
            // 
            colRecuperada.DataPropertyName = "Recuperada";
            colRecuperada.HeaderText = "Recuperada";
            colRecuperada.Name = "colRecuperada";
            // 
            // FormFaltas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 450);
            Controls.Add(dgvFaltas);
            Controls.Add(btnRegistrarFalta);
            Controls.Add(nudQuantidade);
            Controls.Add(dtpData);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblAluno);
            Controls.Add(label1);
            Name = "FormFaltas";
            Text = "FormFaltas";
            Load += FormFaltas_Load;
            ((System.ComponentModel.ISupportInitialize)nudQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFaltas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblAluno;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpData;
        private NumericUpDown nudQuantidade;
        private Button btnRegistrarFalta;
        private DataGridView dgvFaltas;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewTextBoxColumn colQuantidade;
        private DataGridViewTextBoxColumn colJustificada;
        private DataGridViewTextBoxColumn colRecuperada;
    }
}