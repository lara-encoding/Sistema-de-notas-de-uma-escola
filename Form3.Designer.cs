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
            panelRegisto = new Panel();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lnkCriarConta = new LinkLabel();
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
            btnConfirmarRegisto.Location = new Point(37, 226);
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
            btnCancelar.Location = new Point(176, 226);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 48);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtNovoNome
            // 
            txtNovoNome.Location = new Point(142, 61);
            txtNovoNome.Name = "txtNovoNome";
            txtNovoNome.Size = new Size(141, 23);
            txtNovoNome.TabIndex = 2;
            txtNovoNome.KeyDown += txtNovoNome_KeyDown;
            // 
            // txtNovoUtilizador
            // 
            txtNovoUtilizador.Location = new Point(142, 101);
            txtNovoUtilizador.Name = "txtNovoUtilizador";
            txtNovoUtilizador.Size = new Size(141, 23);
            txtNovoUtilizador.TabIndex = 3;
            txtNovoUtilizador.KeyDown += txtNovoUtilizador_KeyDown;
            // 
            // txtNovaSenha
            // 
            txtNovaSenha.Location = new Point(142, 141);
            txtNovaSenha.Name = "txtNovaSenha";
            txtNovaSenha.Size = new Size(141, 23);
            txtNovaSenha.TabIndex = 4;
            // 
            // panelRegisto
            // 
            panelRegisto.Controls.Add(label5);
            panelRegisto.Controls.Add(label4);
            panelRegisto.Controls.Add(label3);
            panelRegisto.Controls.Add(txtNovaSenha);
            panelRegisto.Controls.Add(txtNovoUtilizador);
            panelRegisto.Controls.Add(txtNovoNome);
            panelRegisto.Controls.Add(btnCancelar);
            panelRegisto.Controls.Add(btnConfirmarRegisto);
            panelRegisto.Location = new Point(226, 50);
            panelRegisto.Name = "panelRegisto";
            panelRegisto.Size = new Size(332, 360);
            panelRegisto.TabIndex = 7;
            panelRegisto.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(54, 144);
            label5.Name = "label5";
            label5.Size = new Size(82, 15);
            label5.TabIndex = 7;
            label5.Text = "Palavra-passe:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(76, 104);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 6;
            label4.Text = "Utilizador:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 64);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 5;
            label3.Text = "Nome Completo:";
            // 
            // lnkCriarConta
            // 
            lnkCriarConta.AutoSize = true;
            lnkCriarConta.LinkColor = Color.White;
            lnkCriarConta.Location = new Point(319, 343);
            lnkCriarConta.Name = "lnkCriarConta";
            lnkCriarConta.Size = new Size(174, 15);
            lnkCriarConta.TabIndex = 8;
            lnkCriarConta.TabStop = true;
            lnkCriarConta.Text = "Não tem conta? Registe-se aqui";
            lnkCriarConta.LinkClicked += lnkCriarConta_LinkClicked;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(lnkCriarConta);
            Controls.Add(panelRegisto);
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
        private Panel panelRegisto;
        private Label label5;
        private Label label4;
        private Label label3;
        private LinkLabel lnkCriarConta;
    }
}