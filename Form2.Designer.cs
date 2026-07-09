namespace WinFormsApp1
{
    partial class Form2
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
            lblTitulo = new Label();
            lblNome = new Label();
            lstTurmas = new ListBox();
            txtNomeTurma = new TextBox();
            btnAdicionar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnFechar = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(178, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(134, 28);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Gerir Turmas";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(78, 252);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(93, 15);
            lblNome.TabIndex = 5;
            lblNome.Text = "Nome da Turma";
            // 
            // lstTurmas
            // 
            lstTurmas.FormattingEnabled = true;
            lstTurmas.ItemHeight = 15;
            lstTurmas.Location = new Point(78, 96);
            lstTurmas.Name = "lstTurmas";
            lstTurmas.Size = new Size(323, 139);
            lstTurmas.TabIndex = 6;
            // 
            // txtNomeTurma
            // 
            txtNomeTurma.Location = new Point(78, 270);
            txtNomeTurma.Name = "txtNomeTurma";
            txtNomeTurma.Size = new Size(323, 23);
            txtNomeTurma.TabIndex = 7;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(78, 325);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(83, 34);
            btnAdicionar.TabIndex = 8;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(202, 325);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(83, 34);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Renomear";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(318, 325);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 34);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(389, 376);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(83, 23);
            btnFechar.TabIndex = 11;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(211, 63);
            label1.Name = "label1";
            label1.Size = new Size(62, 21);
            label1.TabIndex = 12;
            label1.Text = "Turmas";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 411);
            Controls.Add(label1);
            Controls.Add(btnFechar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAdicionar);
            Controls.Add(txtNomeTurma);
            Controls.Add(lstTurmas);
            Controls.Add(lblNome);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblNome;
        private ListBox lstTurmas;
        private TextBox txtNomeTurma;
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnFechar;
        private Label label1;
    }
}