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
    public partial class FormRegisto : Form
    {
        private string stringConexao = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Charset=UTF8;";

        public FormRegisto()
        {
            InitializeComponent();
        }

        private void FormRegisto_Load(object sender, EventArgs e)
        {
            CarregarDisciplinas();
            CarregarTurmas();

            txtNovaSenha.UseSystemPasswordChar = true;
            txtConfirmarSenha.UseSystemPasswordChar = true;
            rbProfessor.Checked = true;
            MostrarCamposProfessor();
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

        private void CarregarTurmas()
        {
            string query = "SELECT ID_TURMA, NOME FROM TURMAS ORDER BY NOME";

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                conexao.Open();

                using (FbCommand cmd = new FbCommand(query, conexao))
                {
                    FbDataAdapter adapter = new FbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cbTurmas.DataSource = dt;
                    cbTurmas.DisplayMember = "NOME";
                    cbTurmas.ValueMember = "ID_TURMA";
                    cbTurmas.SelectedIndex = -1;
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

        private string GerarUtilizadorAluno(FbConnection conexao, string nome)
        {
            string utilizadorBase = nome.Trim().ToLower().Replace(" ", ".");
            string utilizador = utilizadorBase;
            int contador = 1;

            while (true)
            {
                string sql = "SELECT COUNT(*) FROM ALUNOS WHERE LOWER(UTILIZADOR) = LOWER(@utilizador)";

                using (FbCommand cmd = new FbCommand(sql, conexao))
                {
                    cmd.Parameters.AddWithValue("@utilizador", utilizador);
                    int existe = Convert.ToInt32(cmd.ExecuteScalar());

                    if (existe == 0)
                    {
                        return utilizador;
                    }
                }

                utilizador = utilizadorBase + contador;
                contador++;
            }
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

        private void btnConfirmarRegisto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNovoNome.Text))
            {
                MessageBox.Show("Informe o nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!rbProfessor.Checked && !rbAluno.Checked)
            {
                MessageBox.Show("Selecione se pretende registar um professor ou um aluno.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (rbProfessor.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtNovoUtilizador.Text) ||
                    string.IsNullOrWhiteSpace(txtNovaSenha.Text) ||
                    cbDisciplinas.SelectedIndex == -1)
                {
                    MessageBox.Show("Preencha todos os campos do professor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (txtNovaSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As palavras.passe não coincidem.\n\nPor favor, confirme novamente a palavra-passe.", "Palavras-passe diferentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtConfirmarSenha.Focus();
                return;
            }

            string conexaoString = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Dialect=3;";
            string queryInsert = "";
            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    string utilizadorAluno = GerarUtilizadorAluno(conexao, txtNovoNome.Text);
                    string senhaTemporaria = "Aluno123@";

                    string senhaAluno = Seguranca.GerarHash(senhaTemporaria);

                    if (rbProfessor.Checked)
                    {
                        queryInsert = @"INSERT INTO PROFESSORES
                        (NOME, UTILIZADOR, SENHA, ID_DISCIPLINA)
                        VALUES (@nome, @user, @pass, @disciplina)";
                    }
                    else if (rbAluno.Checked)
                    {
                        queryInsert = @"INSERT INTO ALUNOS
                        (NOME, UTILIZADOR, SENHA, ID_TURMA)
                        VALUES (@nome, @user, @pass, @turma)";
                    }

                    int idDisciplina = -1;
                    int idTurma = -1;

                    if (rbProfessor.Checked)
                    {
                        idDisciplina = Convert.ToInt32(cbDisciplinas.SelectedValue);

                        if (idDisciplina == -1)
                        {
                            idDisciplina = CriarNovaDisciplina();

                            if (idDisciplina == -1)
                            {
                                return;
                            }
                        }
                    }

                    if (rbAluno.Checked)
                    {
                        idTurma = Convert.ToInt32(cbTurmas.SelectedValue);
                    }

                    string queryVerificarUtilizador;

                    string utilizador = rbProfessor.Checked
                        ? txtNovoUtilizador.Text.Trim()
                        : utilizadorAluno;

                    if (rbProfessor.Checked)
                    {
                        queryVerificarUtilizador = "SELECT COUNT(*) FROM PROFESSORES WHERE LOWER(UTILIZADOR) = LOWER(@utilizador)";
                    }
                    else
                    {
                        queryVerificarUtilizador = "SELECT COUNT(*) FROM ALUNOS WHERE LOWER(UTILIZADOR) = LOWER(@utilizador)";
                    }

                    using (FbCommand cmdVerificar = new FbCommand(queryVerificarUtilizador, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@utilizador", utilizador);
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

                        if (rbProfessor.Checked)
                        {
                            cmdInsert.Parameters.AddWithValue("@user", txtNovoUtilizador.Text);
                            cmdInsert.Parameters.AddWithValue("@pass", Seguranca.GerarHash(txtNovaSenha.Text));
                            cmdInsert.Parameters.AddWithValue("@disciplina", idDisciplina);
                        }
                        else
                        {
                            cmdInsert.Parameters.AddWithValue("@user", utilizadorAluno);
                            cmdInsert.Parameters.AddWithValue("@pass", senhaAluno);
                            cmdInsert.Parameters.AddWithValue("@turma", idTurma);
                        }
                        cmdInsert.ExecuteNonQuery();
                    }

                    if (rbAluno.Checked)
                    {
                        MessageBox.Show(
                            $"Aluno registado com sucesso!\n\n" +
                            $"Utilizador: {utilizadorAluno}\n" +
                            $"Palavra-passe temporária: {senhaTemporaria}\n\n" +
                            $"Entregue estes dados ao aluno.",
                            "Sucesso!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Conta criada com sucesso! Já pode fazer login.",
                            "Sucesso!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    txtNovoNome.Clear();
                    txtNovoUtilizador.Clear();
                    txtNovaSenha.Clear();
                    txtConfirmarSenha.Clear();

                    cbDisciplinas.SelectedIndex = -1;

                    lblEstadoSenha.Visible = false;
                    lblConfirmarSenha.Visible = false;

                    checkBox1.Checked = false;

                    rbProfessor.Checked = true;
                    txtNovoNome.Focus();

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormRegisto registo = new FormRegisto();
            registo.ShowDialog();
        }

        private void txtNovaSenha_TextChanged(object sender, EventArgs e)
        {
            AtualizarEstadoSenha();
            VerificarSenhas();
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

        private void MostrarCamposProfessor()
        {
            lblDisciplina.Visible = true;
            cbDisciplinas.Visible = true;

            lblUtilizador.Visible = true;
            txtNovoUtilizador.Visible = true;

            lblNovaSenha.Visible = true;
            txtNovaSenha.Visible = true;

            lblConfirmarSenhaTexto.Visible = true;
            txtConfirmarSenha.Visible = true;

            lblTurma.Visible = false;
            cbTurmas.Visible = false;

            checkBox1.Visible = true;
            lblEstadoSenha.Visible = true;
            lblConfirmarSenha.Visible = true;
        }

        private void MostrarCamposAluno()
        {
            lblDisciplina.Visible = false;
            cbDisciplinas.Visible = false;

            lblUtilizador.Visible = false;
            txtNovoUtilizador.Visible = false;

            lblNovaSenha.Visible = false;
            txtNovaSenha.Visible = false;

            lblConfirmarSenhaTexto.Visible = false;
            txtConfirmarSenha.Visible = false;

            lblTurma.Visible = true;
            cbTurmas.Visible = true;

            checkBox1.Visible = false;
            lblEstadoSenha.Visible = false;
            lblConfirmarSenha.Visible = false;
        }

        private void rbProfessor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProfessor.Checked)
            {
                MostrarCamposProfessor();
            }
        }

        private void rbAluno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAluno.Checked)
            {
                MostrarCamposAluno();
            }
        }
    }
}
