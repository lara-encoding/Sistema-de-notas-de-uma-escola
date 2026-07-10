using DocumentFormat.OpenXml.Drawing.Charts;
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
            if (lstTurmas.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma turma para editar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNomeTurma.Text))
            {
                MessageBox.Show("Introduza o novo nome da turma.");
                return;
            }

            Turma turma = (Turma)lstTurmas.SelectedItem;

            try
            {
                using (FbConnection conexao = new FbConnection(stringConexao))
                {
                    conexao.Open();

                    string query = @"UPDATE TURMAS SET NOME = @novoNome WHERE ID_TURMA = @idTurma";

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@novoNome", txtNomeTurma.Text);
                        comando.Parameters.AddWithValue("@idTurma", turma.Id);

                        comando.ExecuteNonQuery();
                    }
                }

                carregarTurmas();

                MessageBox.Show("Turma editada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar a turma: {ex.Message}");
            }
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

                    string query = "SELECT ID_TURMA, NOME FROM TURMAS WHERE ID_PROFESSOR = @idProfessor ORDER BY NOME";

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@idProfessor", idProfessorLogado);

                        using (FbDataReader leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                Turma turma = new Turma();

                                turma.Id = Convert.ToInt32(leitor["ID_TURMA"]);
                                turma.Nome = leitor["NOME"].ToString();

                                lstTurmas.Items.Add(turma);
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

            if (string.IsNullOrWhiteSpace(nomeTurma))
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

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
            }
        }

        private void lstTurmas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTurmas.SelectedItem == null)
            {
                return;
            }

            Turma turma = (Turma)lstTurmas.SelectedItem;

            txtNomeTurma.Text = lstTurmas.SelectedItem.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstTurmas.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma turma para eliminar.");
                return;
            }

            Turma turma = (Turma)lstTurmas.SelectedItem;

            DialogResult resposta = MessageBox.Show($"Tem a certeza que pretende eliminara turma '{turma.Nome}'?", "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resposta == DialogResult.No)
                return;

            try
            {
                using (FbConnection conexao = new FbConnection(stringConexao))
                {
                    conexao.Open();
                    string queryVerificar = "SELECT COUNT(*) FROM ALUNOS WHERE ID_TURMA = @idTurma";

                    using (FbCommand cmdVerificar = new FbCommand(queryVerificar, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@idTurma", turma.Id);
                        int quantidade = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (quantidade > 0)
                        {
                            MessageBox.Show("Não é possível eliminar esta turma porque existem alunos associados a ela.", "Operação não permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string queryEliminar = "DELETE FROM TURMAS WHERE ID_TURMA = @idTurma";

                    using (FbCommand comando = new FbCommand(queryEliminar, conexao))
                    {
                        comando.Parameters.AddWithValue("@idTurma", turma.Id);
                        comando.ExecuteNonQuery();
                    }
                }

                carregarTurmas();
                lstTurmas.ClearSelected();
                txtNomeTurma.Clear();

                MessageBox.Show("Turma eliminada com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao eliminar a turma: {ex.Message}");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}