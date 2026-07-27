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
        private int idTurma;

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

                    string novoNome = txtNomeTurma.Text.Trim();

                    string queryVerificar = @"SELECT COUNT(*)
                                            FROM TURMAS
                                            WHERE LOWER(NOME) = LOWER(@nome)
                                            AND ID_TURMA <> @idTurma";

                    using (FbCommand cmdVerificar = new FbCommand(stringConexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@nome", novoNome);
                        cmdVerificar.Parameters.AddWithValue("@idTurma", turma.Id);

                        int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());
                        
                        if (existe > 0)
                        {
                            MessageBox.Show("Essa turma já existe!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string query = @"UPDATE TURMAS SET NOME = @novoNome WHERE ID_TURMA = @idTurma";

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@novoNome", novoNome);
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

                    string query = @"SELECT T.ID_TURMA, T.NOME 
                    FROM TURMAS T
                    INNER JOIN PROFESSORES_TURMA PT
                        ON PT.ID_TURMA = T.ID_TURMA
                    WHERE PT.ID_PROFESSOR = @idProfessor
                    ORDER BY T.NOME";

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

                    string queryVerificar = "SELECT ID_TURMA FROM TURMAS WHERE LOWER(NOME) = LOWER(@nome)";

                    using (FbCommand cmdVerificar = new FbCommand(queryVerificar, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@nome", nomeTurma);

                        object resultado = cmdVerificar.ExecuteScalar();
                        int idTurma;

                        if (resultado == null)
                        {
                            idTurma = -1;
                        } else
                        {
                            idTurma = Convert.ToInt32(resultado);
                        }
                    }

                    if (idTurma == -1)
                    {
                        string queryInsert = "INSERT INTO TURMAS (NOME) VALUES (@nome)";

                        using (FbCommand cmdInsert = new FbCommand(queryInsert, conexao))
                        {
                            cmdInsert.Parameters.AddWithValue("@nome", nomeTurma);
                            cmdInsert.ExecuteNonQuery();
                        }

                        string queryBuscarId = "SELECT ID_TURMA FROM TURMAS WHERE LOWER(NOME) = LOWER(@nome)";

                        using (FbCommand cmdBuscar = new FbCommand(queryBuscarId, conexao))
                        {
                            cmdBuscar.Parameters.AddWithValue("@nome", nomeTurma);
                            idTurma = Convert.ToInt32(cmdBuscar.ExecuteScalar());
                        }
                    }

                    string queryVerificarAssociacao = @"SELECT COUNT(*)
                                                       FROM PROFESSORES_TURMAS
                                                       WHERE ID_PROFESSOR = @idProfessor
                                                       AND ID_TURMA = @idTurma";

                    using (FbCommand cmdVerificar = new FbCommand(queryVerificarAssociacao, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@idProfessor", idProfessorLogado);
                        cmdVerificar.Parameters.AddWithValue("@idTurma", idTurma);

                        int existeAssociacao = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (existeAssociacao > 0)
                        {
                            MessageBox.Show("Já está associado a esta turma.",
                                "Aviso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string queryAssociar = @"INSERT INTO PROFESSORES_TURMA
                                            (ID_PROFESSOR, ID_TURMA)
                                            VALUES (@idProfessor, @idTurma)";

                    using (FbCommand cmdAssociar = new FbCommand(queryAssociar, conexao))
                    {
                        cmdAssociar.Parameters.AddWithValue("@idPorfessor", idProfessorLogado);
                        cmdAssociar.Parameters.AddWithValue("@idTurma", idTurma);

                        cmdAssociar.ExecuteNonQuery();
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

                    string queryEliminarAssociacao = @"DELETE FROM PROFESSORES_TURMAS
                                                        WHERE ID_PROFESSOR = @idProfessor
                                                        AND ID_TURMA = @idTurma";

                    using (FbCommand cmd = new FbCommand(queryEliminarAssociacao, conexao))
                    {
                        cmd.Parameters.AddWithValue("@idProfessor", idProfessorLogado);
                        cmd.Parameters.AddWithValue("@idTurma", turma.Id);

                        cmd.ExecuteNonQuery();
                    }

                    string queryVerificarProfessores = @"SELECT COUNT(*)
                                                        FROM PROFESSORES_TURMAS
                                                        WHERE ID_TURMA = @idTurma";

                    using (FbCommand cmdVerificar = new FbCommand(queryVerificarProfessores, conexao))
                    {
                        cmdVerificar.Parameters.AddWithValue("@idTurma", turma.Id);

                        int quantidadeProfessores = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                        if (quantidadeProfessores == 0)
                        {
                            string queryEliminar = "DELETE FROM TURMAS WHERE ID_TURMA = @idTurma";

                            using (FbCommand comando = new FbCommand(queryEliminar, conexao))
                            {
                                comando.Parameters.AddWithValue("@idTurma", turma.Id);
                                comando.ExecuteNonQuery();
                            }
                        }
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