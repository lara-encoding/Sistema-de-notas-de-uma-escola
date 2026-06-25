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
            btnAdicionar = new Button();
            txtNotaTrabalho = new TextBox();
            txtNome = new TextBox();
            txtNotaTeste = new TextBox();
            txtNotaParticipacao = new TextBox();
            label1 = new Label();
            label2 = new Label();
            dgvAlunos = new DataGridView();
            groupBox1 = new GroupBox();
            lblTotalRetidos = new Label();
            lblTotalAprovados = new Label();
            lblMelhorAluno = new Label();
            lblMediaTurma = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtTurma = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.BackColor = Color.ForestGreen;
            btnAdicionar.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdicionar.Location = new Point(889, 42);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(103, 97);
            btnAdicionar.TabIndex = 0;
            btnAdicionar.Text = "Adicionar Aluno";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += button1_Click;
            // 
            // txtNotaTrabalho
            // 
            txtNotaTrabalho.Location = new Point(648, 116);
            txtNotaTrabalho.Name = "txtNotaTrabalho";
            txtNotaTrabalho.Size = new Size(225, 23);
            txtNotaTrabalho.TabIndex = 2;
            txtNotaTrabalho.TextChanged += textBox1_TextChanged;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(648, 29);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(225, 23);
            txtNome.TabIndex = 4;
            // 
            // txtNotaTeste
            // 
            txtNotaTeste.Location = new Point(648, 87);
            txtNotaTeste.Name = "txtNotaTeste";
            txtNotaTeste.Size = new Size(225, 23);
            txtNotaTeste.TabIndex = 5;
            // 
            // txtNotaParticipacao
            // 
            txtNotaParticipacao.Location = new Point(648, 145);
            txtNotaParticipacao.Name = "txtNotaParticipacao";
            txtNotaParticipacao.Size = new Size(225, 23);
            txtNotaParticipacao.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(552, 32);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome do aluno";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(561, 119);
            label2.Name = "label2";
            label2.Size = new Size(81, 15);
            label2.TabIndex = 8;
            label2.Text = "Nota Trabalho";
            label2.Click += label2_Click;
            // 
            // dgvAlunos
            // 
            dgvAlunos.BackgroundColor = SystemColors.ActiveBorder;
            dgvAlunos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlunos.Location = new Point(-1, -3);
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.RowTemplate.Height = 25;
            dgvAlunos.Size = new Size(493, 453);
            dgvAlunos.TabIndex = 9;
            dgvAlunos.CellValueChanged += dgvAlunos_CellValueChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblTotalRetidos);
            groupBox1.Controls.Add(lblTotalAprovados);
            groupBox1.Controls.Add(lblMelhorAluno);
            groupBox1.Controls.Add(lblMediaTurma);
            groupBox1.Location = new Point(521, 189);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(471, 115);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Estatísticas da Escola";
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
            label3.Location = new Point(580, 90);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 11;
            label3.Text = "Nota Teste";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(541, 148);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 12;
            label4.Text = "Nota Participação";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(601, 61);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 13;
            label5.Text = "Turma";
            label5.Click += label5_Click_1;
            // 
            // txtTurma
            // 
            txtTurma.CharacterCasing = CharacterCasing.Upper;
            txtTurma.Location = new Point(648, 58);
            txtTurma.Name = "txtTurma";
            txtTurma.Size = new Size(225, 23);
            txtTurma.TabIndex = 14;
            // 
            // button1
            // 
            button1.BackColor = Color.Transparent;
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(694, 340);
            button1.Name = "button1";
            button1.Size = new Size(123, 75);
            button1.TabIndex = 16;
            button1.Text = "Apagar Aluno";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(847, 340);
            button2.Name = "button2";
            button2.Size = new Size(123, 75);
            button2.TabIndex = 19;
            button2.Text = "Apagar Tabela";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(541, 342);
            button3.Name = "button3";
            button3.Size = new Size(123, 75);
            button3.TabIndex = 20;
            button3.Text = "Ver Turmas";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1004, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtTurma);
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
        private TextBox txtTurma;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}