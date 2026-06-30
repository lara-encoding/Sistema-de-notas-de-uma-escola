namespace WinFormsApp1
{
    partial class Form1
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnAdicionar = new Button();
            txtNotaTrabalho = new TextBox();
            txtNome = new TextBox();
            txtNotaTeste = new TextBox();
            txtNotaParticipacao = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dgvAlunos = new DataGridView();
            groupBox1 = new GroupBox();
            label6 = new Label();
            lblTotalRetidos = new Label();
            comboBox1 = new ComboBox();
            lblTotalAprovados = new Label();
            lblMelhorAluno = new Label();
            lblMediaTurma = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            cmbTurmas = new ComboBox();
            numFaltas = new NumericUpDown();
            label7 = new Label();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFaltas).BeginInit();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.ForestGreen;
            btnAdicionar.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdicionar.Location = new Point(890, 55);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(103, 97);
            btnAdicionar.TabIndex = 0;
            btnAdicionar.Text = "Adicionar Aluno";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += button1_Click;
            // 
            // txtNotaTrabalho
            // 
            txtNotaTrabalho.Location = new Point(650, 118);
            txtNotaTrabalho.Name = "txtNotaTrabalho";
            txtNotaTrabalho.Size = new Size(225, 23);
            txtNotaTrabalho.TabIndex = 2;
            txtNotaTrabalho.TextChanged += textBox1_TextChanged;
            txtNotaTrabalho.KeyDown += txtNotaTrabalho_KeyDown;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(650, 31);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(225, 23);
            txtNome.TabIndex = 4;
            txtNome.KeyDown += txtNome_KeyDown;
            // 
            // txtNotaTeste
            // 
            txtNotaTeste.Location = new Point(650, 89);
            txtNotaTeste.Name = "txtNotaTeste";
            txtNotaTeste.Size = new Size(225, 23);
            txtNotaTeste.TabIndex = 5;
            txtNotaTeste.KeyDown += txtNotaTeste_KeyDown;
            // 
            // txtNotaParticipacao
            // 
            txtNotaParticipacao.Location = new Point(650, 147);
            txtNotaParticipacao.Name = "txtNotaParticipacao";
            txtNotaParticipacao.Size = new Size(225, 23);
            txtNotaParticipacao.TabIndex = 6;
            txtNotaParticipacao.KeyDown += txtNotaParticipacao_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(554, 34);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome do aluno";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(563, 121);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 8;
            label2.Text = "Nota Trabalho";
            label2.Click += label2_Click;
            // 
            // dgvAlunos
            // 
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dgvAlunos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAlunos.BackgroundColor = Color.White;
            dgvAlunos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAlunos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAlunos.Location = new Point(-1, -3);
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.RowTemplate.Height = 25;
            dgvAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunos.Size = new Size(493, 453);
            dgvAlunos.TabIndex = 9;
            dgvAlunos.CellContentClick += dgvAlunos_CellContentClick;
            dgvAlunos.CellValueChanged += dgvAlunos_CellValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblTotalRetidos);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(lblTotalAprovados);
            groupBox1.Controls.Add(lblMelhorAluno);
            groupBox1.Controls.Add(lblMediaTurma);
            groupBox1.Location = new Point(521, 211);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(471, 115);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estatísticas da Escola";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(340, 13);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 22;
            label6.Text = "Filtrar por Situação";
            label6.Click += label6_Click;
            // 
            // lblTotalRetidos
            // 
            lblTotalRetidos.AutoSize = true;
            lblTotalRetidos.Location = new Point(9, 76);
            lblTotalRetidos.Name = "lblTotalRetidos";
            lblTotalRetidos.Size = new Size(154, 15);
            lblTotalRetidos.TabIndex = 3;
            lblTotalRetidos.Text = "Recuperação/Reprovados: 0";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Todos", "Aprovado", "Reprovado", "Recuperação" });
            comboBox1.Location = new Point(323, 31);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(137, 23);
            comboBox1.TabIndex = 21;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lblTotalAprovados
            // 
            lblTotalAprovados.AutoSize = true;
            lblTotalAprovados.Location = new Point(9, 61);
            lblTotalAprovados.Name = "lblTotalAprovados";
            lblTotalAprovados.Size = new Size(76, 15);
            lblTotalAprovados.TabIndex = 2;
            lblTotalAprovados.Text = "Aprovados: 0";
            lblTotalAprovados.Click += label5_Click;
            // 
            // lblMelhorAluno
            // 
            lblMelhorAluno.AutoSize = true;
            lblMelhorAluno.Location = new Point(9, 46);
            lblMelhorAluno.Name = "lblMelhorAluno";
            lblMelhorAluno.Size = new Size(91, 15);
            lblMelhorAluno.TabIndex = 1;
            lblMelhorAluno.Text = "Melhor Aluno: -";
            // 
            // lblMediaTurma
            // 
            lblMediaTurma.AutoSize = true;
            lblMediaTurma.Location = new Point(6, 31);
            lblMediaTurma.Name = "lblMediaTurma";
            lblMediaTurma.Size = new Size(103, 15);
            lblMediaTurma.TabIndex = 0;
            lblMediaTurma.Text = "Média da Escola: -";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(582, 92);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 11;
            label3.Text = "Nota Teste";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(543, 150);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 12;
            label4.Text = "Nota Participação";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(603, 63);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 13;
            label5.Text = "Turma";
            label5.Click += label5_Click_1;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(690, 338);
            button1.Name = "button1";
            button1.Size = new Size(132, 61);
            button1.TabIndex = 16;
            button1.Text = "Apagar Aluno";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(844, 338);
            button2.Name = "button2";
            button2.Size = new Size(137, 61);
            button2.TabIndex = 19;
            button2.Text = "Apagar Todos Os Alunos";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(527, 338);
            button3.Name = "button3";
            button3.Size = new Size(141, 61);
            button3.TabIndex = 20;
            button3.Text = "Ver Turmas";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // cmbTurmas
            // 
            cmbTurmas.FormattingEnabled = true;
            cmbTurmas.Items.AddRange(new object[] { "1ºA", "2ºA", "3ºA", "1ºC", "2ºC", "3ºC", "1ºG", "2ºG", "3ºG" });
            cmbTurmas.Location = new Point(650, 60);
            cmbTurmas.Name = "cmbTurmas";
            cmbTurmas.Size = new Size(225, 23);
            cmbTurmas.TabIndex = 21;
            cmbTurmas.KeyDown += cmbTurmas_KeyDown;
            // 
            // numFaltas
            // 
            numFaltas.Location = new Point(650, 176);
            numFaltas.Name = "numFaltas";
            numFaltas.Size = new Size(225, 23);
            numFaltas.TabIndex = 22;
            numFaltas.PreviewKeyDown += numFaltas_PreviewKeyDown_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(603, 178);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 23;
            label7.Text = "Faltas";
            // 
            // button4
            // 
            button4.Location = new Point(630, 405);
            button4.Name = "button4";
            button4.Size = new Size(102, 34);
            button4.TabIndex = 25;
            button4.Text = "Importar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(781, 405);
            button5.Name = "button5";
            button5.Size = new Size(104, 34);
            button5.TabIndex = 26;
            button5.Text = "Exportar";
            button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1004, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label7);
            Controls.Add(numFaltas);
            Controls.Add(cmbTurmas);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(groupBox1);
            Controls.Add(txtNotaTrabalho);
            Controls.Add(label2);
            Controls.Add(txtNotaParticipacao);
            Controls.Add(dgvAlunos);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(txtNotaTeste);
            Controls.Add(txtNome);
            Controls.Add(btnAdicionar);
            Name = "Form1";
            Text = "Sistema de Notas - Escolar";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFaltas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdicionar;
        private TextBox txtNotaTrabalho;
        private TextBox txtNome;
        private TextBox txtNotaTeste;
        private TextBox txtNotaParticipacao;
        private Label label1;
        private Label label2;
        private DataGridView dgvAlunos;
        private GroupBox groupBox1;
        private Label lblTotalRetidos;
        private Label lblTotalAprovados;
        private Label lblMelhorAluno;
        private Label lblMediaTurma;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button2;
        private Button button3;
        private ComboBox comboBox1;
        private Label label6;
        private ComboBox cmbTurmas;
        private NumericUpDown numFaltas;
        private Label label7;
        private Button button4;
        private Button button5;
    }
}