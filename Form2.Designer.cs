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
            txtNovaTurma = new TextBox();
            btnAdicionar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnFechar = new Button();
            label1 = new Label();
            txtTurmaExistente = new Label();
            cmbTurmasExistentes = new ComboBox();
            btnAssociarTurma = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitulo.Location = new Point(295, 20);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(134, 28);
            lblTitulo.TabIndex = 4;
            lblTitulo.Text = "Gerir Turmas";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(195, 303);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(72, 15);
            lblNome.TabIndex = 5;
            lblNome.Text = "Nova Turma";
            // 
            // lstTurmas
            // 
            lstTurmas.FormattingEnabled = true;
            lstTurmas.ItemHeight = 15;
            lstTurmas.Location = new Point(195, 87);
            lstTurmas.Name = "lstTurmas";
            lstTurmas.Size = new Size(323, 79);
            lstTurmas.TabIndex = 6;
            lstTurmas.SelectedIndexChanged += lstTurmas_SelectedIndexChanged;
            // 
            // txtNovaTurma
            // 
            txtNovaTurma.Location = new Point(195, 321);
            txtNovaTurma.Name = "txtNovaTurma";
            txtNovaTurma.Size = new Size(323, 23);
            txtNovaTurma.TabIndex = 7;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(194, 372);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(83, 42);
            btnAdicionar.TabIndex = 8;
            btnAdicionar.Text = "Criar Nova Turma";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(313, 372);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(83, 42);
            btnEditar.TabIndex = 9;
            btnEditar.Text = "Renomear";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(434, 372);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(83, 42);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnFechar
            // 
            btnFechar.Location = new Point(505, 429);
            btnFechar.Name = "btnFechar";
            btnFechar.Size = new Size(83, 23);
            btnFechar.TabIndex = 11;
            btnFechar.Text = "Fechar";
            btnFechar.UseVisualStyleBackColor = true;
            btnFechar.Click += btnFechar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(195, 65);
            label1.Name = "label1";
            label1.Size = new Size(135, 19);
            label1.TabIndex = 12;
            label1.Text = "Turmas do Professor";
            // 
            // txtTurmaExistente
            // 
            txtTurmaExistente.AutoSize = true;
            txtTurmaExistente.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtTurmaExistente.Location = new Point(195, 181);
            txtTurmaExistente.Name = "txtTurmaExistente";
            txtTurmaExistente.Size = new Size(118, 19);
            txtTurmaExistente.TabIndex = 13;
            txtTurmaExistente.Text = "Turmas Existentes";
            // 
            // cmbTurmasExistentes
            // 
            cmbTurmasExistentes.FormattingEnabled = true;
            cmbTurmasExistentes.Location = new Point(195, 203);
            cmbTurmasExistentes.Name = "cmbTurmasExistentes";
            cmbTurmasExistentes.Size = new Size(323, 23);
            cmbTurmasExistentes.TabIndex = 14;
            // 
            // btnAssociarTurma
            // 
            btnAssociarTurma.Location = new Point(195, 245);
            btnAssociarTurma.Name = "btnAssociarTurma";
            btnAssociarTurma.Size = new Size(97, 40);
            btnAssociarTurma.TabIndex = 15;
            btnAssociarTurma.Text = "Associar Turma";
            btnAssociarTurma.UseVisualStyleBackColor = true;
            btnAssociarTurma.Click += btnAssociarTurma_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 490);
            Controls.Add(btnAssociarTurma);
            Controls.Add(cmbTurmasExistentes);
            Controls.Add(txtTurmaExistente);
            Controls.Add(label1);
            Controls.Add(btnFechar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAdicionar);
            Controls.Add(txtNovaTurma);
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
        private TextBox txtNovaTurma;
        private Button btnAdicionar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnFechar;
        private Label label1;
        private Label txtTurmaExistente;
        private ComboBox cmbTurmasExistentes;
        private Button btnAssociarTurma;
    }
}