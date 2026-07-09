using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        private int idProfessorLogado;

        private string professorLogado;

        private string stringConexao = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Dialect=3;";

        public Form2(int idProfessorLogado, string professorLogado)
        {
            InitializeComponent();

            this.idProfessorLogado = idProfessorLogado;

            this.professorLogado = professorLogado;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            carregarTurmas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void carregarTurmas()
        {
            lstTurmas.Items.Clear();

            try
            {
                using (FbConnection conexao = new FbConnection(stringConexao))
                {
                    conexao.Open();

                    string query = "SELECT NOME FROM TURMAS WHERE ID_PROFESSOR = @idProfessor ORDER BY NOME";

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@idProfessor", idProfessorLogado);

                        using (FbDataReader leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                lstTurmas.Items.Add(leitor["NOME"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar as turmas: {ex.Message}");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string nomeTurma = txtNomeTurma.Text.Trim();

            if (string.IsNullOrWhiteSpace(nomeTurma) )
            {
                MessageBox.Show("Introduza o nome da turma!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();

                    string queryVerificar = "SELECT COUNT(*) FROM TURMAS WHERE LOWER(NOME) = LOWER(@nome) AND ID_PROFESSOR = @idProfessor";

                    using (FbCommand cmdVerificar = new FbCommand(queryVerificar, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@nome", nomeTurma);
                        cmdVerificar.Parameters.AddWithValue("@idProfessor", idProfessorLogado);

                        int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (existe > 0)
                        {
                            MessageBox.Show("Essa turma já existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    string queryInsert = "INSERT INTO TURMAS (NOME, ID_PROFESSOR) VALUES (@nome, @idProfessor)";

                    using (FbCommand cmdInsert = new FbCommand(queryInsert, conexao))
                    {
                        cmdInsert.Parameters.AddWithValue("@nome", nomeTurma);
                        cmdInsert.Parameters.AddWithValue("@idProfessor", idProfessorLogado);

                        cmdInsert.ExecuteNonQuery();
                    }

                    carregarTurmas();
                    txtNomeTurma.Clear();

                    MessageBox.Show("Turma adicionada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                } catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }
    }
}