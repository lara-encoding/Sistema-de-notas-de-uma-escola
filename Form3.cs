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
            CarregarDisciplinas();
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

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@user", txtUtilizador.Text);
                        comando.Parameters.AddWithValue("@pass", txtSenha.Text);

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
                                MessageBox.Show("Utilizador ou palavra-passe incorretos!", "Erro de autenticação", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrWhiteSpace(txtNovoNome.Text) || string.IsNullOrWhiteSpace(txtNovoUtilizador.Text) || string.IsNullOrWhiteSpace(txtNovaSenha.Text) || cbDisciplinas.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, preencha todos os campos do resgito!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string conexaoString = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Dialect=3;";
            string queryId = "SELECT COALESCE(MAX(ID), 0) + 1 FROM PROFESSORES";
            string queryInsert = @"INSERT INTO PROFESSORES (ID, NOME, UTILIZADOR, SENHA, ID_DISCIPLINA) VALUES (@id, @nome, @user, @pass, @disciplina)";

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    int proximoId = 1;

                    using (FbCommand cmdId = new FbCommand(queryId, conexao))
                    {
                        proximoId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    using (FbCommand cmdInsert = new FbCommand(queryInsert, conexao))
                    {
                        cmdInsert.Parameters.AddWithValue("@id", proximoId);
                        cmdInsert.Parameters.AddWithValue("@nome", txtNovoNome.Text);
                        cmdInsert.Parameters.AddWithValue("@user", txtNovoUtilizador.Text);
                        cmdInsert.Parameters.AddWithValue("@pass", txtNovaSenha.Text);
                        cmdInsert.Parameters.AddWithValue("@disciplina", cbDisciplinas.SelectedValue);

                        cmdInsert.ExecuteNonQuery();
                    }

                    MessageBox.Show("Conta criada com sucesso! Já pode fazer o login.", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    panelRegisto.Visible = false;
                    txtNovoNome.Clear();
                    txtNovoUtilizador.Clear();
                    txtNovaSenha.Clear();
                    cbDisciplinas.SelectedIndex = -1;

                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Violates FOREING KEY or UNIQUE KEY"))
                    {
                        MessageBox.Show("Este utilizador já existe! Por favor, escolha outro nome de utilizador", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao registar na base de dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtNovoNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNovoUtilizador.Focus();
            }
        }

        private void txtNovoUtilizador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNovaSenha.Focus();
            }
        }

        private void CarregarDisciplinas()
        {
            string conexaoString = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Charset=UTF8;";
            string query = "SELECT ID_DISCIPLINA, NOME FROM DISCIPLINAS ORDER BY NOME";

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        FbDataAdapter adapter = new FbDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        DataRow novaLinha = dt.NewRow();
                        novaLinha["ID_DISCIPLINA"] = -1;
                        novaLinha["NOME"] = "+ Nova disciplina...";
                        dt.Rows.Add(novaLinha);

                        cbDisciplinas.DataSource = dt;
                        cbDisciplinas.DisplayMember = "NOME";
                        cbDisciplinas.ValueMember = "ID_DISCIPLINA";
                        cbDisciplinas.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar disciplinas: {ex.Message}");
                }
            }
        }

        private void cbDisciplinas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDisciplinas.SelectedValue != null && Convert.ToInt32(cbDisciplinas.SelectedValue) == -1)
            {
                string novaDisciplina = Microsoft.VisualBasic.Interaction.InputBox("Digite o nome da nova disciplina:",
                    "Nova Disciplina", "");


                if (string.IsNullOrWhiteSpace(novaDisciplina)) 
                {
                    CarregarDisciplinas();
                    return;

                    string queryVerificar = "SELECT COUNT(*) FROM DISCIPLINAS WHERE UPPER(NOME) = UPPER(@nome)";
                    string queryInserir = "INSERT INTO DISCIPLINAS (NOME) VALUES (@nome)";

                    using (FbConnection conexao = new FbConnection(conexaoString))
                    {
                        conexao.Open();

                        using (FbCommand cmdVerificar = new FbCommand(queryVerificar, conexao))
                        {
                            cmdVerificar.Parameters.AddWithValue("@nome", novaDisciplina.Trim());
                            int quantidade = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                            if (quantidade > 0)
                            {
                                MessageBox.Show("Essa disciplina já existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                CarregarDisciplinas();
                                return;
                            }
                        }

                        using (FbCommand cmdInserir = new FbCommand(queryInserir, conexao))
                        {
                            cmdInserir.Parameters.AddWithValue("@nome", novaDisciplina.Trim());
                            cmdInserir.ExecuteNonQuery();
                        }
                        CarregarDisciplinas();
                    }
                }
            }
        }
    }
}
