using FirebirdSql.Data.FirebirdClient;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string conexaoString = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Dialect=3;";
            string query = "SELECT NOME FROM PROFESSORES WHERE UTILIZADOR = @user AND SENHA = @pass";

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@user", txtUtilizador.Text);
                        comando.Parameters.AddWithValue("@pass", txtSenha.Text);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            string nomeProfessor = resultado.ToString();

                            MessageBox.Show($"Login efetuado com sucesso!\nBem vindo(a), {nomeProfessor}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            Form1 principal = new Form1(txtUtilizador.Text);
                            principal.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Utilizador ou palavra-passe incorretos!", "Erro de autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao ligar à base de dados: {ex.Message}", "Erro do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chkMostrarSenha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarSenha.Checked)
            {
                txtSenha.PasswordChar = '\0';
            }
            else
            {
                txtSenha.PasswordChar = '*';
            }
        }

        private void txtUtilizador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtSenha.Focus();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnEntrar.Focus();
            }
        }

        private void lnkCriarConta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelRegisto.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            panelRegisto.Visible = false;
        }

        private void btnConfirmarRegisto_Click(object sender, EventArgs e)
        {

        }
    }
}
