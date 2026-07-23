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
        private object nomeAluno;
        string conexaoString = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Dialect=3;";


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
            string query = @"SELECT P.ID, P.NOME, D.NOME AS DISCIPLINA
                             FROM PROFESSORES P 
                             INNER JOIN DISCIPLINAS D
                                ON P.ID_DISCIPLINA = D.ID_DISCIPLINA
                             WHERE P.UTILIZADOR = @user
                             AND P.SENHA = @pass";
            string senhaHash = Seguranca.GerarHash(txtSenha.Text);

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@user", txtUtilizador.Text);
                        comando.Parameters.AddWithValue("@pass", senhaHash);

                        using (FbDataReader leitor = comando.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                int idProfessor = Convert.ToInt32(leitor["ID"]);
                                string nomeProfessor = leitor["NOME"].ToString();
                                string disciplinaProfessor = leitor["DISCIPLINA"].ToString();

                                MessageBox.Show($"Login efetuado com sucesso\nBem vindo(a), {nomeProfessor}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();

                                EscolhaTurma ecraTurma = new EscolhaTurma(idProfessor, nomeProfessor, disciplinaProfessor);
                                ecraTurma.ShowDialog();

                                this.Close();
                            }
                            else
                            {
                                VerificarLoginAluno();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao ligar à base de dados: {ex.Message}", "Erro do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VerificarLoginAluno()
        {
            string query = @"SELECT ID, NOME, ID_TURMA
                            FROM ALUNOS
                            WHERE UTILIZADOR = @user
                            AND SENHA = @pass";

            string senhaHash = Seguranca.GerarHash(txtSenha.Text);

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@user", txtUtilizador.Text.Trim());
                        comando.Parameters.AddWithValue("@pass", senhaHash);

                        using (FbDataReader leitor = comando.ExecuteReader())
                        {
                            if (leitor.Read())
                            {
                                int idAluno = Convert.ToInt32(leitor["ID"]);
                                string nomeAluno = leitor["NOME"].ToString();
                                int idTurma = Convert.ToInt32(leitor["ID_TURMA"]);

                                MessageBox.Show($"Bem vindo(a), {nomeAluno}!",
                                    "Login efetuado",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                this.Hide();

                                FormAluno aluno = new FormAluno(idAluno, nomeAluno, idTurma);
                                aluno.ShowDialog();

                                this.Close();
                            } else
                            {
                                MessageBox.Show("Utilizador ou palavra-passe incorretos.",
                                    "Erro!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            FormRegisto registo = new FormRegisto();
            registo.ShowDialog();
        }

        private void cbDisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void lblEstadoSenha_Click(object sender, EventArgs e)
        {

        }

        private void panelRegisto_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
