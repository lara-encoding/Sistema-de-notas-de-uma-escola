namespace WinFormsApp1
{
    partial class Form3
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
            label2 = new Label();
            txtUtilizador = new TextBox();
            txtSenha = new TextBox();
            chkMostrarSenha = new CheckBox();
            btnEntrar = new Button();
            label1 = new Label();
            btnConfirmarRegisto = new Button();
            btnCancelar = new Button();
            txtNovoNome = new TextBox();
            txtNovoUtilizador = new TextBox();
            txtNovaSenha = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cbDisciplinas = new ComboBox();
            lnkCriarConta = new LinkLabel();
            panelRegisto = new Panel();
            lblConfirmarSenha = new Label();
            label7 = new Label();
            txtConfirmarSenha = new TextBox();
            lblEstadoSenha = new Label();
            checkBox1 = new CheckBox();
            panelRegisto.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(226, 182);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 1;
            label2.Text = "Palavra-passe:";
            // 
            // txtUtilizador
            // 
            txtUtilizador.Location = new Point(334, 128);
            txtUtilizador.Name = "txtUtilizador";
            txtUtilizador.Size = new Size(149, 23);
            txtUtilizador.TabIndex = 2;
            txtUtilizador.KeyDown += txtUtilizador_KeyDown;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(334, 181);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(149, 23);
            txtSenha.TabIndex = 3;
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // chkMostrarSenha
            // 
            chkMostrarSenha.AutoSize = true;
            chkMostrarSenha.Location = new Point(357, 210);
            chkMostrarSenha.Name = "chkMostrarSenha";
            chkMostrarSenha.Size = new Size(101, 19);
            chkMostrarSenha.TabIndex = 4;
            chkMostrarSenha.Text = "Mostrar senha";
            chkMostrarSenha.UseVisualStyleBackColor = true;
            chkMostrarSenha.CheckedChanged += chkMostrarSenha_CheckedChanged;
            // 
            // btnEntrar
            // 
            btnEntrar.BackColor = Color.DodgerBlue;
            btnEntrar.FlatStyle = FlatStyle.Flat;
            btnEntrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            btnEntrar.ForeColor = Color.White;
            btnEntrar.Location = new Point(351, 259);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(107, 48);
            btnEntrar.TabIndex = 5;
            btnEntrar.Text = "Entrar";
            btnEntrar.UseVisualStyleBackColor = false;
            btnEntrar.Click += btnEntrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(251, 127);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 6;
            label1.Text = "Utilizador:";
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
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNovoNome
            // 
            txtNovoNome.Location = new Point(157, 20);
            txtNovoNome.Name = "txtNovoNome";
            txtNovoNome.Size = new Size(141, 23);
            txtNovoNome.TabIndex = 2;
            txtNovoNome.KeyDown += txtNovoNome_KeyDown;
            // 
            // txtNovoUtilizador
            // 
            txtNovoUtilizador.Location = new Point(157, 60);
            txtNovoUtilizador.Name = "txtNovoUtilizador";
            txtNovoUtilizador.Size = new Size(141, 23);
            txtNovoUtilizador.TabIndex = 3;
            txtNovoUtilizador.KeyDown += txtNovoUtilizador_KeyDown;
            // 
            // txtNovaSenha
            // 
            txtNovaSenha.Location = new Point(157, 100);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.Size = new Size(141, 23);
            txtNovaSenha.TabIndex = 4;
            txtNovaSenha.TextChanged += txtNovaSenha_TextChanged;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 63);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 6;
            label4.Text = "Utilizador:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 103);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 7;
            label5.Text = "Palavra-passe:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(74, 242);
            label6.Name = "label6";
            label6.Size = new Size(61, 15);
            label6.TabIndex = 8;
            label6.Text = "Disciplina:";
            // 
            // cbDisciplinas
            // 
            cbDisciplinas.FormattingEnabled = true;
            cbDisciplinas.Location = new Point(155, 245);
            cbDisciplinas.Name = "cbDisciplinas";
            cbDisciplinas.Size = new Size(141, 23);
            cbDisciplinas.TabIndex = 9;
            cbDisciplinas.SelectedIndexChanged += cbDisciplinas_SelectedIndexChanged;
            // 
            // lnkCriarConta
            // 
            lnkCriarConta.AutoSize = true;
            lnkCriarConta.LinkColor = Color.White;
            lnkCriarConta.Location = new Point(309, 413);
            lnkCriarConta.Name = "lnkCriarConta";
            lnkCriarConta.Size = new Size(174, 15);
            lnkCriarConta.TabIndex = 8;
            lnkCriarConta.TabStop = true;
            lnkCriarConta.Text = "Não tem conta? Registe-se aqui";
            lnkCriarConta.LinkClicked += lnkCriarConta_LinkClicked;
            // 
            // panelRegisto
            // 
            panelRegisto.Controls.Add(checkBox1);
            panelRegisto.Controls.Add(lblConfirmarSenha);
            panelRegisto.Controls.Add(label7);
            panelRegisto.Controls.Add(txtConfirmarSenha);
            panelRegisto.Controls.Add(lblEstadoSenha);
            panelRegisto.Controls.Add(cbDisciplinas);
            panelRegisto.Controls.Add(label6);
            panelRegisto.Controls.Add(label5);
            panelRegisto.Controls.Add(label4);
            panelRegisto.Controls.Add(label3);
            panelRegisto.Controls.Add(txtNovaSenha);
            panelRegisto.Controls.Add(txtNovoUtilizador);
            panelRegisto.Controls.Add(txtNovoNome);
            panelRegisto.Controls.Add(btnCancelar);
            panelRegisto.Controls.Add(btnConfirmarRegisto);
            panelRegisto.Location = new Point(226, 32);
            panelRegisto.Name = "panelRegisto";
            panelRegisto.Size = new Size(332, 360);
            panelRegisto.TabIndex = 7;
            panelRegisto.Visible = false;
            // 
            // lblConfirmarSenha
            // 
            lblConfirmarSenha.AutoSize = true;
            lblConfirmarSenha.Location = new Point(75, 178);
            lblConfirmarSenha.Name = "lblConfirmarSenha";
            lblConfirmarSenha.Size = new Size(38, 15);
            lblConfirmarSenha.TabIndex = 13;
            lblConfirmarSenha.Text = "label8";
            lblConfirmarSenha.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 151);
            label7.Name = "label7";
            label7.Size = new Size(139, 15);
            label7.TabIndex = 12;
            label7.Text = "Confirmar palavra-passe:";
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.Location = new Point(156, 151);
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
            lblEstadoSenha.Click += lblEstadoSenha_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(150, 202);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(147, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Mostrar palavras-passe";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(panelRegisto);
            Controls.Add(lnkCriarConta);
            Controls.Add(label1);
            Controls.Add(btnEntrar);
            Controls.Add(chkMostrarSenha);
            Controls.Add(txtSenha);
            Controls.Add(txtUtilizador);
            Controls.Add(label2);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Acesso ao Sistema";
            Load += Form3_Load;
            panelRegisto.ResumeLayout(false);
            panelRegisto.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtUtilizador;
        private TextBox txtSenha;
        private CheckBox chkMostrarSenha;
        private Button btnEntrar;
        private Label label1;
        private Button btnConfirmarRegisto;
        private Button btnCancelar;
        private TextBox txtNovoNome;
        private TextBox txtNovoUtilizador;
        private TextBox txtNovaSenha;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cbDisciplinas;
        private LinkLabel lnkCriarConta;
        private Panel panelRegisto;
        private Label lblEstadoSenha;
        private Label label7;
        private TextBox txtConfirmarSenha;
        private Label lblConfirmarSenha;
        private CheckBox checkBox1;
    }
}