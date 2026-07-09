using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public static class Utilidades
    {
        public static void TerminarSessao(Form formularioAtual)
        {
            DialogResult resposta = MessageBox.Show("Tem a certeza de que pretende terminar a sessão?\n\nSerá necessário iniciar sessão novamente.", "Terminar Sessão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resposta == DialogResult.Yes)
            {
                formularioAtual.Hide();

                Form3 login = new Form3();
                login.ShowDialog();

                formularioAtual.Close();
            }
        }
    }
}
