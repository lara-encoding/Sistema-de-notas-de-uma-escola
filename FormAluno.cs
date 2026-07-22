using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormAluno : Form
    {
        private int idAluno;
        private string nomeAluno;
        private int idTurma;

        public FormAluno(int idAluno, string nomeAluno, int idTurma)
        {
            InitializeComponent();
            this.idAluno = idAluno;
            this.nomeAluno = nomeAluno;
            this.idTurma = idTurma;
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = $"Bem-vindo(a), {nomeAluno}";
        }
    }
}
