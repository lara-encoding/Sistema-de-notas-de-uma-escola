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
            lnkCriarConta = new LinkLabel();
            rbProfessor = new RadioButton();
            rbAluno = new RadioButton();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(227, 216);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 1;
            label2.Text = "Palavra-passe:";
            // 
            // txtUtilizador
            // 
            txtUtilizador.Location = new Point(335, 162);
            txtUtilizador.Name = "txtUtilizador";
            txtUtilizador.Size = new Size(186, 23);
            txtUtilizador.TabIndex = 2;
            txtUtilizador.KeyDown += txtUtilizador_KeyDown;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(335, 215);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(186, 23);
            txtSenha.TabIndex = 3;
            txtSenha.KeyDown += txtSenha_KeyDown;
            // 
            // chkMostrarSenha
            // 
            chkMostrarSenha.AutoSize = true;
            chkMostrarSenha.Location = new Point(358, 244);
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
            btnEntrar.Location = new Point(352, 287);
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
            label1.Location = new Point(252, 161);
            label1.Name = "label1";
            label1.Size = new Size(77, 20);
            label1.TabIndex = 6;
            label1.Text = "Utilizador:";
            // 
            // lnkCriarConta
            // 
            lnkCriarConta.AutoSize = true;
            lnkCriarConta.LinkColor = Color.White;
            lnkCriarConta.Location = new Point(319, 364);
            lnkCriarConta.Name = "lnkCriarConta";
            lnkCriarConta.Size = new Size(174, 15);
            lnkCriarConta.TabIndex = 8;
            lnkCriarConta.TabStop = true;
            lnkCriarConta.Text = "Não tem conta? Registe-se aqui";
            lnkCriarConta.LinkClicked += lnkCriarConta_LinkClicked;
            // 
            // rbProfessor
            // 
            rbProfessor.AutoSize = true;
            rbProfessor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rbProfessor.Location = new Point(352, 113);
            rbProfessor.Name = "rbProfessor";
            rbProfessor.Size = new Size(84, 23);
            rbProfessor.TabIndex = 9;
            rbProfessor.TabStop = true;
            rbProfessor.Text = "Professor";
            rbProfessor.UseVisualStyleBackColor = true;
            rbProfessor.CheckedChanged += rbProfessor_CheckedChanged;
            // 
            // rbAluno
            // 
            rbAluno.AutoSize = true;
            rbAluno.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rbAluno.Location = new Point(458, 113);
            rbAluno.Name = "rbAluno";
            rbAluno.Size = new Size(63, 23);
            rbAluno.TabIndex = 10;
            rbAluno.TabStop = true;
            rbAluno.Text = "Aluno";
            rbAluno.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(244, 115);
            label3.Name = "label3";
            label3.Size = new Size(87, 19);
            label3.TabIndex = 11;
            label3.Text = "Entrar como:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(303, 48);
            label4.Name = "label4";
            label4.Size = new Size(190, 25);
            label4.TabIndex = 12;
            label4.Text = "ACESSO AO SISTEMA";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(rbAluno);
            Controls.Add(rbProfessor);
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
        private LinkLabel lnkCriarConta;
        private RadioButton rbProfessor;
        private RadioButton rbAluno;
        private Label label3;
        private Label label4;
    }
}