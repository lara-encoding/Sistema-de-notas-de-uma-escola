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
    public partial class FormFaltas : Form
    {
        private int idAluno;
        private int idProfessor;
        public FormFaltas(int idAluno, string nomeAluno, int idProfessor)
        {
            InitializeComponent();
            this.idAluno = idAluno;
            this.idProfessor = idProfessor;

            lblAluno.Text = "Aluno: " + nomeAluno;
        }

        private void FormFaltas_Load(object sender, EventArgs e)
        {

        }
    }
}
