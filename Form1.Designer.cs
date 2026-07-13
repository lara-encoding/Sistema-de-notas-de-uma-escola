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
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            numFaltas = new NumericUpDown();
            label7 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            lblUsuario = new Label();
            cmbTurmas = new ComboBox();
            label5 = new Label();
            btnTerminarSessao = new Button();
            panel1 = new Panel();
            label6 = new Label();
            lblTotalRetidos = new Label();
            lblTotalAprovados = new Label();
            lblMelhorAluno = new Label();
            lblMediaTurma = new Label();
            cb1 = new GroupBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numFaltas).BeginInit();
            panel1.SuspendLayout();
            cb1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdicionar
            // 
            btnAdicionar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdicionar.BackColor = Color.ForestGreen;
            btnAdicionar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnAdicionar.Location = new Point(879, 85);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(103, 97);
            btnAdicionar.TabIndex = 0;
            btnAdicionar.Text = "Adicionar Aluno";
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.Click += button1_Click;
            // 
            // txtNotaTrabalho
            // 
            txtNotaTrabalho.Location = new Point(125, 119);
            txtNotaTrabalho.Name = "txtNotaTrabalho";
            txtNotaTrabalho.Size = new Size(225, 23);
            txtNotaTrabalho.TabIndex = 2;
            txtNotaTrabalho.TextChanged += textBox1_TextChanged;
            txtNotaTrabalho.KeyDown += txtNotaTrabalho_KeyDown;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(125, 61);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(225, 23);
            txtNome.TabIndex = 4;
            txtNome.KeyDown += txtNome_KeyDown;
            // 
            // txtNotaTeste
            // 
            txtNotaTeste.Location = new Point(125, 90);
            txtNotaTeste.Name = "txtNotaTeste";
            txtNotaTeste.Size = new Size(225, 23);
            txtNotaTeste.TabIndex = 5;
            txtNotaTeste.KeyDown += txtNotaTeste_KeyDown;
            // 
            // txtNotaParticipacao
            // 
            txtNotaParticipacao.Location = new Point(125, 148);
            txtNotaParticipacao.Name = "txtNotaParticipacao";
            txtNotaParticipacao.Size = new Size(225, 23);
            txtNotaParticipacao.TabIndex = 6;
            txtNotaParticipacao.KeyDown += txtNotaParticipacao_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 64);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome do aluno";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 122);
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
            dgvAlunos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvAlunos.Location = new Point(0, 0);
            dgvAlunos.Name = "dgvAlunos";
            dgvAlunos.RowTemplate.Height = 25;
            dgvAlunos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlunos.Size = new Size(505, 450);
            dgvAlunos.TabIndex = 9;
            dgvAlunos.CellContentClick += dgvAlunos_CellContentClick;
            dgvAlunos.CellValueChanged += dgvAlunos_CellValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 93);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 11;
            label3.Text = "Nota Teste";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 151);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 12;
            label4.Text = "Nota Participação";
            label4.Click += label4_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(690, 348);
            button1.Name = "button1";
            button1.Size = new Size(113, 46);
            button1.TabIndex = 16;
            button1.Text = "Apagar Aluno";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button2.BackColor = Color.Transparent;
            button2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button2.Location = new Point(834, 348);
            button2.Name = "button2";
            button2.Size = new Size(111, 46);
            button2.TabIndex = 19;
            button2.Text = "Apagar Todos Os Alunos";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.BackColor = Color.Transparent;
            button3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button3.Location = new Point(549, 348);
            button3.Name = "button3";
            button3.Size = new Size(113, 46);
            button3.TabIndex = 20;
            button3.Text = "Ver Turmas";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // numFaltas
            // 
            numFaltas.Location = new Point(125, 177);
            numFaltas.Name = "numFaltas";
            numFaltas.Size = new Size(225, 23);
            numFaltas.TabIndex = 22;
            numFaltas.PreviewKeyDown += numFaltas_PreviewKeyDown_1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(78, 179);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 23;
            label7.Text = "Faltas";
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button4.Location = new Point(549, 400);
            button4.Name = "button4";
            button4.Size = new Size(113, 42);
            button4.TabIndex = 25;
            button4.Text = "Importar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button5.Location = new Point(690, 400);
            button5.Name = "button5";
            button5.Size = new Size(113, 42);
            button5.TabIndex = 26;
            button5.Text = "Exportar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button6.Location = new Point(834, 400);
            button6.Name = "button6";
            button6.Size = new Size(111, 42);
            button6.TabIndex = 27;
            button6.Text = "Enviar Email";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(131, 3);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(38, 15);
            lblUsuario.TabIndex = 28;
            lblUsuario.Text = "label8";
            // 
            // cmbTurmas
            // 
            cmbTurmas.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTurmas.FormattingEnabled = true;
            cmbTurmas.Location = new Point(229, 32);
            cmbTurmas.Name = "cmbTurmas";
            cmbTurmas.Size = new Size(121, 23);
            cmbTurmas.TabIndex = 29;
            cmbTurmas.SelectedIndexChanged += cmbTurmas_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(131, 35);
            label5.Name = "label5";
            label5.Size = new Size(92, 15);
            label5.TabIndex = 23;
            label5.Text = "Trocar de Turma";
            // 
            // btnTerminarSessao
            // 
            btnTerminarSessao.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTerminarSessao.Location = new Point(918, 9);
            btnTerminarSessao.Name = "btnTerminarSessao";
            btnTerminarSessao.Size = new Size(75, 47);
            btnTerminarSessao.TabIndex = 30;
            btnTerminarSessao.Text = "Terminar Sessão";
            btnTerminarSessao.UseVisualStyleBackColor = true;
            btnTerminarSessao.Click += btnTerminarSessao_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cmbTurmas);
            panel1.Controls.Add(lblUsuario);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(numFaltas);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtNotaTrabalho);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtNotaParticipacao);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtNotaTeste);
            panel1.Controls.Add(txtNome);
            panel1.Location = new Point(511, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 207);
            panel1.TabIndex = 31;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(340, 13);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 22;
            label6.Text = "Filtrar por Situação";
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
            lblMediaTurma.Size = new Size(104, 15);
            lblMediaTurma.TabIndex = 0;
            lblMediaTurma.Text = "Média da Turma: -";
            // 
            // cb1
            // 
            cb1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cb1.Controls.Add(comboBox1);
            cb1.Controls.Add(label6);
            cb1.Controls.Add(lblTotalRetidos);
            cb1.Controls.Add(lblTotalAprovados);
            cb1.Controls.Add(lblMelhorAluno);
            cb1.Controls.Add(lblMediaTurma);
            cb1.Location = new Point(511, 219);
            cb1.Name = "cb1";
            cb1.Size = new Size(471, 115);
            cb1.TabIndex = 12;
            cb1.TabStop = false;
            cb1.Text = "Estatísticas da Turma";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Todos", "Aprovados(as)", "Reprovados(as)", "Recuperação" });
            comboBox1.Location = new Point(344, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 23;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1004, 450);
            Controls.Add(cb1);
            Controls.Add(panel1);
            Controls.Add(btnTerminarSessao);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dgvAlunos);
            Controls.Add(btnAdicionar);
            Name = "Form1";
            Text = "Sistema de Notas - Escolar";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAlunos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numFaltas).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            cb1.ResumeLayout(false);
            cb1.PerformLayout();
            ResumeLayout(false);
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
        private Label label3;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private NumericUpDown numFaltas;
        private Label label7;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label lblUsuario;
        private ComboBox cmbTurmas;
        private Label label5;
        private Button btnTerminarSessao;
        private Panel panel1;
        private Label label6;
        private Label lblTotalRetidos;
        private Label lblTotalAprovados;
        private Label lblMelhorAluno;
        private Label lblMediaTurma;
        private GroupBox cb1;
        private ComboBox comboBox1;
    }
}