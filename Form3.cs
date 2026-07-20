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
        private string stringConexao = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Charset=UTF8;";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CarregarDisciplinas();

            txtNovaSenha.UseSystemPasswordChar = true;
            txtConfirmarSenha.UseSystemPasswordChar = true;
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

            if (txtNovaSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As palavras.passe não coincidem.\n\nPor favor, confirme novamente a palavra-passe.", "Palavras-passe diferentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtConfirmarSenha.Focus();
            }

            string conexaoString = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Dialect=3;";
            string queryInsert = @"INSERT INTO PROFESSORES (NOME, UTILIZADOR, SENHA, ID_DISCIPLINA) VALUES (@nome, @user, @pass, @disciplina)";

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    int idDisciplina = Convert.ToInt32(cbDisciplinas.SelectedValue);

                    if (idDisciplina == -1)
                    {
                        idDisciplina = CriarNovaDisciplina();

                        if (idDisciplina == -1)
                        {
                            return;
                        }
                    }

                    string queryVerificarUtilizador = @"SELECT COUNT(*) FROM PROFESSORES WHERE LOWER(UTILIZADOR) = LOWER(@utilizador)";

                    using (FbCommand cmdVerificar = new FbCommand(queryVerificarUtilizador, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@utilizador", txtNovoUtilizador.Text.Trim());
                        int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("Este nome de utilizador já está a ser utilizado.\n\nPor favor, escolha outro.", "Utilizador existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (FbCommand cmdInsert = new FbCommand(queryInsert, conexao))
                    {
                        cmdInsert.Parameters.AddWithValue("@nome", txtNovoNome.Text);
                        cmdInsert.Parameters.AddWithValue("@user", txtNovoUtilizador.Text);
                        cmdInsert.Parameters.AddWithValue("@pass", Seguranca.GerarHash(txtNovaSenha.Text));
                        cmdInsert.Parameters.AddWithValue("@disciplina", idDisciplina);
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
                    MessageBox.Show(
                        $"Mensagem:\n{ex.Message}\n\n" +
                        $"InnerException:\n{ex.InnerException?.Message}\n\n" +
                        $"StackTrace:\n{ex.StackTrace}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private int CriarNovaDisciplina()
        {
            string novaDisciplina = Microsoft.VisualBasic.Interaction.InputBox("Digite o nome da nova disciplina", "Nova Disciplina", "");

            if (string.IsNullOrWhiteSpace(novaDisciplina))
            {
                MessageBox.Show("É necessário informar uma disciplina.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                conexao.Open();

                string queryVerificar = "SELECT ID_DISCIPLINA FROM DISCIPLINAS WHERE UPPER(NOME) = UPPER(@nome)";

                using (FbCommand cmdVerificar = new FbCommand(queryVerificar, conexao))
                {
                    cmdVerificar.Parameters.AddWithValue("@nome", novaDisciplina.Trim());
                    object resultado = cmdVerificar.ExecuteScalar();
                    if (resultado != null)
                    {
                        return Convert.ToInt32(resultado);
                    }
                }

                string queryInserir = "INSERT INTO DISCIPLINAS (NOME) VALUES (@nome)";

                using (FbCommand cmdInserir = new FbCommand(queryInserir, conexao))
                {
                    cmdInserir.Parameters.AddWithValue("@nome", novaDisciplina.Trim());
                    cmdInserir.ExecuteNonQuery();
                }

                using (FbCommand cmdBuscar = new FbCommand(queryVerificar, conexao))
                {
                    cmdBuscar.Parameters.AddWithValue("@nome", novaDisciplina.Trim());
                    return Convert.ToInt32(cmdBuscar.ExecuteScalar());
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

        }

        private void AtualizarEstadoSenha()
        {
            string senha = txtNovaSenha.Text;

            if (string.IsNullOrEmpty(senha))
            {
                lblEstadoSenha.Visible = false;
                return;
            }

            lblEstadoSenha.Visible = true;

            bool tem8Caracteres = senha.Length >= 8;
            bool temMaiuscula = senha.Any(char.IsUpper);
            bool temMinuscula = senha.Any(char.IsLower);
            bool temNumero = senha.Any(char.IsDigit);
            bool temSimbolo = senha.Any(c => !char.IsLetterOrDigit(c));

            List<string> faltam = new List<string>();

            if (!tem8Caracteres)
                faltam.Add("8 caracteres\n");
            if (!temMaiuscula)
                faltam.Add("uma letra maiúscula");
            if (!temMinuscula)
                faltam.Add("uma letra minúscula");
            if (!temNumero)
                faltam.Add("um número");
            if (!temSimbolo)
                faltam.Add("um símbolo");

            if (faltam.Count == 0)
            {
                lblEstadoSenha.ForeColor = Color.Green;
                lblEstadoSenha.Text = "Excelente! Palavra-passe forte e segura.";
            }
            else if (faltam.Count <= 2)
            {
                lblEstadoSenha.ForeColor = Color.Orange;
                lblEstadoSenha.Text = "Está quase! Falta apenas: " + string.Join(", ", faltam) + ".";
            }
            else
            {
                lblEstadoSenha.ForeColor = Color.Red;
                lblEstadoSenha.Text = "Palavra-passe fraca. Adicione: " + string.Join(",", faltam) + ".";
            }
        }

        private void lblEstadoSenha_Click(object sender, EventArgs e)
        {

        }

        private void txtNovaSenha_TextChanged(object sender, EventArgs e)
        {
            AtualizarEstadoSenha();
            VerificarSenhas();
        }

        private void panelRegisto_Paint(object sender, PaintEventArgs e)
        {

        }

        private void VerificarSenhas()
        {
            if (string.IsNullOrWhiteSpace(txtNovaSenha.Text) && string.IsNullOrWhiteSpace(txtConfirmarSenha.Text))
            {
                lblConfirmarSenha.Visible = false;
                return;
            }

            lblConfirmarSenha.Visible = true;

            if (txtNovaSenha.Text == txtConfirmarSenha.Text)
            {
                lblConfirmarSenha.ForeColor = Color.Green;
                lblConfirmarSenha.Text = "As palavras-passe coincidem.";
            }
            else
            {
                lblConfirmarSenha.ForeColor = Color.Red;
                lblConfirmarSenha.Text = "As palavras-passe não coincidem.";
            }
        }

        private void txtConfirmarSenha_TextChanged(object sender, EventArgs e)
        {
            VerificarSenhas();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtNovaSenha.UseSystemPasswordChar = !checkBox1.Checked;
            txtConfirmarSenha.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
