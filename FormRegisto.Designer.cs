namespace WinFormsApp1
{
    partial class FormRegisto
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
            panelRegisto = new Panel();
            checkBox1 = new CheckBox();
            lblConfirmarSenha = new Label();
            lblConfirmarSenhaTexto = new Label();
            txtConfirmarSenha = new TextBox();
            lblEstadoSenha = new Label();
            cbDisciplinas = new ComboBox();
            lblDisciplina = new Label();
            lblNovaSenha = new Label();
            lblUtilizador = new Label();
            label3 = new Label();
            txtNovaSenha = new TextBox();
            txtNovoUtilizador = new TextBox();
            txtNovoNome = new TextBox();
            btnCancelar = new Button();
            btnConfirmarRegisto = new Button();
            rbProfessor = new RadioButton();
            rbAluno = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            panelRegisto.SuspendLayout();
            SuspendLayout();
            // 
            // panelRegisto
            // 
            panelRegisto.Controls.Add(checkBox1);
            panelRegisto.Controls.Add(lblConfirmarSenha);
            panelRegisto.Controls.Add(lblConfirmarSenhaTexto);
            panelRegisto.Controls.Add(txtConfirmarSenha);
            panelRegisto.Controls.Add(lblEstadoSenha);
            panelRegisto.Controls.Add(cbDisciplinas);
            panelRegisto.Controls.Add(lblDisciplina);
            panelRegisto.Controls.Add(lblNovaSenha);
            panelRegisto.Controls.Add(lblUtilizador);
            panelRegisto.Controls.Add(label3);
            panelRegisto.Controls.Add(txtNovaSenha);
            panelRegisto.Controls.Add(txtNovoUtilizador);
            panelRegisto.Controls.Add(txtNovoNome);
            panelRegisto.Controls.Add(btnCancelar);
            panelRegisto.Controls.Add(btnConfirmarRegisto);
            panelRegisto.Location = new Point(229, 78);
            panelRegisto.Name = "panelRegisto";
            panelRegisto.Size = new Size(332, 360);
            panelRegisto.TabIndex = 8;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(152, 210);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(147, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Mostrar palavras-passe";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // lblConfirmarSenha
            // 
            lblConfirmarSenha.AutoSize = true;
            lblConfirmarSenha.Location = new Point(76, 190);
            lblConfirmarSenha.Name = "lblConfirmarSenha";
            lblConfirmarSenha.Size = new Size(38, 15);
            lblConfirmarSenha.TabIndex = 13;
            lblConfirmarSenha.Text = "label8";
            lblConfirmarSenha.Visible = false;
            lblConfirmarSenha.VisibleChanged += txtConfirmarSenha_TextChanged;
            // 
            // lblConfirmarSenhaTexto
            // 
            lblConfirmarSenhaTexto.AutoSize = true;
            lblConfirmarSenhaTexto.Location = new Point(12, 166);
            lblConfirmarSenhaTexto.Name = "lblConfirmarSenhaTexto";
            lblConfirmarSenhaTexto.Size = new Size(139, 15);
            lblConfirmarSenhaTexto.TabIndex = 12;
            lblConfirmarSenhaTexto.Text = "Confirmar palavra-passe:";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.Location = new Point(157, 163);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.Size = new Size(141, 23);
            txtConfirmarSenha.TabIndex = 11;
            txtConfirmarSenha.TextChanged += txtConfirmarSenha_TextChanged;
            // 
            // lblEstadoSenha
            // 
            lblEstadoSenha.AutoSize = true;
            lblEstadoSenha.Location = new Point(75, 131);
            lblEstadoSenha.Name = "lblEstadoSenha";
            lblEstadoSenha.Size = new Size(38, 15);
            lblEstadoSenha.TabIndex = 10;
            lblEstadoSenha.Text = "label7";
            lblEstadoSenha.Visible = false;
            lblEstadoSenha.VisibleChanged += txtNovaSenha_TextChanged;
            // 
            // cbDisciplinas
            // 
            cbDisciplinas.FormattingEnabled = true;
            cbDisciplinas.Location = new Point(155, 245);
            cbDisciplinas.Name = "cbDisciplinas";
            cbDisciplinas.Size = new Size(141, 23);
            cbDisciplinas.TabIndex = 9;
            // 
            // lblDisciplina
            // 
            lblDisciplina.AutoSize = true;
            lblDisciplina.Location = new Point(87, 248);
            lblDisciplina.Name = "lblDisciplina";
            lblDisciplina.Size = new Size(61, 15);
            lblDisciplina.TabIndex = 8;
            lblDisciplina.Text = "Disciplina:";
            // 
            // lblNovaSenha
            // 
            lblNovaSenha.AutoSize = true;
            lblNovaSenha.Location = new Point(69, 103);
            lblNovaSenha.Name = "lblNovaSenha";
            lblNovaSenha.Size = new Size(82, 15);
            lblNovaSenha.TabIndex = 7;
            lblNovaSenha.Text = "Palavra-passe:";
            // 
            // lblUtilizador
            // 
            lblUtilizador.AutoSize = true;
            lblUtilizador.Location = new Point(91, 63);
            lblUtilizador.Name = "lblUtilizador";
            lblUtilizador.Size = new Size(60, 15);
            lblUtilizador.TabIndex = 6;
            lblUtilizador.Text = "Utilizador:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 23);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 5;
            label3.Text = "Nome Completo:";
            // 
            // txtNovaSenha
            // 
            txtNovaSenha.Location = new Point(157, 100);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.Size = new Size(141, 23);
            txtNovaSenha.TabIndex = 4;
            txtNovaSenha.TextChanged += txtNovaSenha_TextChanged;
            // 
            // txtNovoUtilizador
            // 
            txtNovoUtilizador.Location = new Point(157, 60);
            txtNovoUtilizador.Name = "txtNovoUtilizador";
            txtNovoUtilizador.Size = new Size(141, 23);
            txtNovoUtilizador.TabIndex = 3;
            // 
            // txtNovoNome
            // 
            txtNovoNome.Location = new Point(157, 20);
            txtNovoNome.Name = "txtNovoNome";
            txtNovoNome.Size = new Size(141, 23);
            txtNovoNome.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.DodgerBlue;
            btnCancelar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(180, 293);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 48);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnConfirmarRegisto
            // 
            btnConfirmarRegisto.BackColor = Color.DodgerBlue;
            btnConfirmarRegisto.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnConfirmarRegisto.Location = new Point(41, 293);
            btnConfirmarRegisto.Name = "btnConfirmarRegisto";
            btnConfirmarRegisto.Size = new Size(107, 48);
            btnConfirmarRegisto.TabIndex = 0;
            btnConfirmarRegisto.Text = "Registar";
            btnConfirmarRegisto.UseVisualStyleBackColor = false;
            btnConfirmarRegisto.Click += btnConfirmarRegisto_Click;
            // 
            // rbProfessor
            // 
            rbProfessor.AutoSize = true;
            rbProfessor.Location = new Point(370, 53);
            rbProfessor.Name = "rbProfessor";
            rbProfessor.Size = new Size(74, 19);
            rbProfessor.TabIndex = 9;
            rbProfessor.TabStop = true;
            rbProfessor.Text = "Professor";
            rbProfessor.UseVisualStyleBackColor = true;
            rbProfessor.CheckedChanged += rbProfessor_CheckedChanged;
            // 
            // rbAluno
            // 
            rbAluno.AutoSize = true;
            rbAluno.Location = new Point(461, 53);
            rbAluno.Name = "rbAluno";
            rbAluno.Size = new Size(57, 19);
            rbAluno.TabIndex = 10;
            rbAluno.TabStop = true;
            rbAluno.Text = "Aluno";
            rbAluno.UseVisualStyleBackColor = true;
            rbAluno.CheckedChanged += rbAluno_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(269, 55);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 11;
            label1.Text = "Registar como:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(316, 9);
            label2.Name = "label2";
            label2.Size = new Size(171, 25);
            label2.TabIndex = 12;
            label2.Text = "CRIAR UTILIZADOR";
            // 
            // FormRegisto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rbAluno);
            Controls.Add(rbProfessor);
            Controls.Add(panelRegisto);
            Name = "FormRegisto";
            Text = "Criar Conta";
            Load += FormRegisto_Load;
            panelRegisto.ResumeLayout(false);
            panelRegisto.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelRegisto;
        private Label lblConfirmarSenha;
        private Label lblConfirmarSenhaTexto;
        private TextBox txtConfirmarSenha;
        private Label lblEstadoSenha;
        private ComboBox cbDisciplinas;
        private Label lblDisciplina;
        private Label lblNovaSenha;
        private Label lblUtilizador;
        private Label label3;
        private TextBox txtNovoNome;
        private Button btnCancelar;
        private CheckBox checkBox1;
        private TextBox txtNovaSenha;
        private TextBox txtNovoUtilizador;
        private Button btnConfirmarRegisto;
        private RadioButton rbProfessor;
        private RadioButton rbAluno;
        private Label label1;
        private Label label2;
    }
}