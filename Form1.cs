using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using ExcelDataReader;
using System.Linq;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string stringConexao = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050";

        private List<Aluno> listaAlunos = new List<Aluno>();
        private string nomeAntigo = "";
        private string turmaAntiga = "";
        private object comando;
        private object faltas;
        private object linha;
        private Aluno novoAluno;

        public Form1()
        {
            InitializeComponent();

            dgvAlunos.CellBeginEdit += dgvAlunos_CellBeginEdit;
            dgvAlunos.CellValueChanged += dgvAlunos_CellValueChanged;
            dgvAlunos.UserDeletingRow += dgvAlunos_UserDeletingRow;
            button1.Click += btnApagarAluno_Click;
            dgvAlunos.CellFormatting += dgvAlunos_CellFormatting;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            cmbTurmas.SelectedIndexChanged += cmbTurmas_SelectedIndexChanged;
            txtNome.TextChanged += txtNome_TextChanged;

            CarregarHistoricoDaBaseDeDados();
            ToolTip dicaBotao = new ToolTip();

            dicaBotao.AutoPopDelay = 5000;
            dicaBotao.InitialDelay = 500;

            dicaBotao.SetToolTip(button1, "Dica: Pode selecionar vários alunos segurando a tecla CTRL enquanto clicas nas linhas");
        }

        private void txtNome_TextChanged(object? sender, EventArgs e)
        {
            if (listaAlunos == null || listaAlunos.Count == 0) return;

            string textoPesquisa = txtNome.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoPesquisa))
            {
                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = listaAlunos;
            }
            else
            {
                var alunosFiltrados = listaAlunos
                    .Where(aluno => aluno.Nome != null && aluno.Nome.ToLower().Contains(textoPesquisa))
                    .ToList();

                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = alunosFiltrados;
            }

            if (dgvAlunos.Columns["Id"] != null) dgvAlunos.Columns["Id"].Visible = false;
        }

        private void cmbTurmas_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (listaAlunos == null || listaAlunos.Count == 0 || cmbTurmas.SelectedItem == null) return;

            string turmaSelecionada = cmbTurmas.SelectedItem.ToString();

            var alunosFiltrados = listaAlunos.Where(aluno => aluno.Turma == turmaSelecionada).ToList();

            dgvAlunos.DataSource = null;
            dgvAlunos.DataSource = alunosFiltrados;
            if (dgvAlunos.Columns["Id"] != null) dgvAlunos.Columns["Id"].Visible = false;
        }

        private void CarregarHistoricoDaBaseDeDados()
        {
            if (listaAlunos == null) listaAlunos = new List<Aluno>();
            listaAlunos.Clear();

            string querySelect = "SELECT NOME, TURMA, NOTA_TESTE, NOTA_TRABALHO, NOTA_PARTICIPACAO, MEDIA_FINAL, SITUACAO, FALTAS_INJUSTIFICADAS, FALTAS_JUSTIFICADAS, FALTAS_RECUPERADAS FROM ALUNOS";
            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    using (FbCommand comando = new FbCommand(querySelect, conexao))
                    {
                        using (FbDataReader leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                string nome = leitor["Nome"].ToString();
                                string turma = leitor["Turma"].ToString();
                                double notaTeste = Convert.ToDouble(leitor["NOTA_TESTE"]);
                                double notaTrabalho = Convert.ToDouble(leitor["NOTA_TRABALHO"]);
                                double notaParticipacao = Convert.ToDouble(leitor["NOTA_PARTICIPACAO"]);

                                int faltasInjustificadas = leitor["FALTAS_INJUSTIFICADAS"] != DBNull.Value ? Convert.ToInt32(leitor["FALTAS_INJUSTIFICADAS"]) : 0;
                                int faltasJustificadas = leitor["FALTAS_JUSTIFICADAS"] != DBNull.Value ? Convert.ToInt32(leitor["FALTAS_JUSTIFICADAS"]) : 0;
                                int faltasRecuperadas = leitor["FALTAS_RECUPERADAS"] != DBNull.Value ? Convert.ToInt32(leitor["FALTAS_RECUPERADAS"]) : 0;

                                Aluno aluno = new Aluno(0, nome, turma, notaTeste, notaTrabalho, notaParticipacao, faltasInjustificadas, faltasJustificadas, faltasRecuperadas);
                                listaAlunos.Add(aluno);
                            }
                        }
                    }

                    dgvAlunos.DataSource = null;
                    dgvAlunos.DataSource = listaAlunos;

                    CalcularEstatisticas(listaAlunos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar o histórico da Base de Dados: {ex.Message}", "Erro ao iniciar");
                }
            }
        }

        private void dgvAlunos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaAlunos.Count)
            {
                nomeAntigo = listaAlunos[e.RowIndex].Nome;
                turmaAntiga = listaAlunos[e.RowIndex].Turma;
            }
        }

        private void dgvAlunos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= listaAlunos.Count) return;

            Aluno alunoEditado = listaAlunos[e.RowIndex];

            alunoEditado.MediaFinal = Math.Round((alunoEditado.NotaTeste * 0.5) + (alunoEditado.NotaTrabalho * 0.3) + (alunoEditado.NotaParticipacao * 0.2), 2);

            int faltasEfetivas = alunoEditado.FaltasInjustificadas - alunoEditado.FaltasRecuperadas;

            if (alunoEditado.FaltasInjustificadas > 10)
            {
                if (faltasEfetivas <= 10 && alunoEditado.FaltasJustificadas > 0 && alunoEditado.FaltasRecuperadas > 0)
                {
                    if (alunoEditado.MediaFinal >= 10) alunoEditado.Situacao = "Aprovado(a)";
                    else if (alunoEditado.MediaFinal >= 8) alunoEditado.Situacao = "Recuperação";
                    else alunoEditado.Situacao = "Reprovado(a)";
                }
                else
                {
                    alunoEditado.Situacao = "Reprovado(a) por Faltas";
                }
            }
            else
            {
                if (alunoEditado.MediaFinal >= 10) alunoEditado.Situacao = "Aprovado(a)";
                else if (alunoEditado.MediaFinal >= 8) alunoEditado.Situacao = "Recuperação";
                else alunoEditado.Situacao = "Reprovado(a)";
            }

            CalcularEstatisticas(listaAlunos);
            dgvAlunos.Refresh();

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    string queryUpdate = "UPDATE ALUNOS SET NOME = @v_nome, TURMA = @v_turma, NOTA_TESTE = @v_teste, " +
                                         "NOTA_TRABALHO = @v_trabalho, NOTA_PARTICIPACAO = @v_participacao, " +
                                         "FALTAS_INJUSTIFICADAS = @v_faltasInjustificadas, FALTAS_JUSTIFICADAS = @v_faltasJustificadas, FALTAS_RECUPERADAS = @v_faltasRecuperadas, " +
                                         "MEDIA_FINAL = @v_media, SITUACAO = @v_situacao " +
                                         "WHERE NOME = @v_nomeAntigo AND TURMA = @v_turmaAntiga";

                    using (FbCommand comando = new FbCommand(queryUpdate, conexao))
                    {
                        comando.Parameters.AddWithValue("@v_nome", alunoEditado.Nome);
                        comando.Parameters.AddWithValue("@v_turma", alunoEditado.Turma);
                        comando.Parameters.AddWithValue("@v_teste", alunoEditado.NotaTeste);
                        comando.Parameters.AddWithValue("@v_trabalho", alunoEditado.NotaTrabalho);
                        comando.Parameters.AddWithValue("@v_participacao", alunoEditado.NotaParticipacao);
                        comando.Parameters.AddWithValue("@v_faltasInjustificadas", alunoEditado.FaltasInjustificadas);
                        comando.Parameters.AddWithValue("@v_faltasJustificadas", alunoEditado.FaltasJustificadas);
                        comando.Parameters.AddWithValue("@v_faltasRecuperadas", alunoEditado.FaltasRecuperadas);
                        comando.Parameters.AddWithValue("@v_media", alunoEditado.MediaFinal);
                        comando.Parameters.AddWithValue("@v_situacao", alunoEditado.Situacao);
                        comando.Parameters.AddWithValue("@v_nomeAntigo", string.IsNullOrEmpty(nomeAntigo) ? alunoEditado.Nome : nomeAntigo);
                        comando.Parameters.AddWithValue("@v_turmaAntiga", string.IsNullOrEmpty(turmaAntiga) ? alunoEditado.Turma : turmaAntiga);

                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao actualizar no Firebird: {ex.Message}", "Erro de Sincronização");
                }
            }
            nomeAntigo = "";
            turmaAntiga = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbTurmas.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma turma na lista antes de adicionar o aluno!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomeInserido = txtNome.Text.Trim();
            string turmaInserida = cmbTurmas.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(nomeInserido))
            {
                MessageBox.Show("Insira o nome do aluno:", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(nomeInserido, @"^[a-zA-ZáéíóúàèìòùâêîôûãõçÁÉÍÓÚÀÈÌÒÙÂÊÎÔÛÃÕÇ\s]+$"))
            {
                MessageBox.Show("O campo nome apenas pode conter letras!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool existeNaBD = false;

            using (FbConnection conexaoValidar = new FbConnection(stringConexao))
            {
                try
                {
                    conexaoValidar.Open();
                    string queryCheck = "SELECT COUNT(*) FROM ALUNOS WHERE LOWER(NOME) = LOWER(@v_nome) AND LOWER(TURMA) = LOWER(@v_turma)";

                    using (FbCommand cmdCheck = new FbCommand(queryCheck, conexaoValidar))
                    {
                        cmdCheck.Parameters.AddWithValue("@v_nome", nomeInserido);
                        cmdCheck.Parameters.AddWithValue("@v_turma", turmaInserida);

                        int resultadoDvd = Convert.ToInt32(cmdCheck.ExecuteScalar());
                        if (resultadoDvd > 0)
                        {
                            existeNaBD = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao validar duplicados na BD: {ex.Message}");
                }
            }

            if (existeNaBD)
            {
                MessageBox.Show("Já existe um aluno com esse nome nesta turma!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double notaTeste, notaTrabalho, notaParticipacao;

            if (!double.TryParse(txtNotaTeste.Text, out notaTeste) || notaTeste < 0 || notaTeste > 20)
            {
                MessageBox.Show("Nota do Teste inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtNotaTrabalho.Text, out notaTrabalho) || notaTrabalho < 0 || notaTrabalho > 20)
            {
                MessageBox.Show("Nota do Trabalho inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtNotaParticipacao.Text, out notaParticipacao) || notaParticipacao < 0 || notaParticipacao > 20)
            {
                MessageBox.Show("Nota da Participação inválida!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int faltasInseridas = Convert.ToInt32(numFaltas.Value);
            SalvarAlunoNoFirebird(0, nomeInserido, turmaInserida, notaTeste, notaTrabalho, notaParticipacao, faltasInseridas, 0, 0);

            Aluno novoAluno = new Aluno(0, txtNome.Text, cmbTurmas.Text, notaTeste, notaTrabalho, notaParticipacao, faltasInseridas, 0, 0);
            listaAlunos.Add(novoAluno);

            dgvAlunos.DataSource = null;
            dgvAlunos.DataSource = listaAlunos;

            CalcularEstatisticas(listaAlunos);

            txtNome.Clear();
            txtNotaTeste.Clear();
            txtNotaTrabalho.Clear();
            txtNotaParticipacao.Clear();
            numFaltas.Value = 0;

            if (cmbTurmas.Items.Count > 0) cmbTurmas.SelectedIndex = 0;

            txtNome.Focus();
        }

        private void SalvarAlunoNoFirebird(int id, string nome, string turma, double teste, double trabalho, double participacao, int faltasInjustificadas, int faltasJustificadas, int faltasRecuperadas)
        {
            double media = Math.Round((teste * 0.5) + (trabalho * 0.3) + (participacao * 0.2), 2);
            int faltasEfetivas = faltasInjustificadas - faltasRecuperadas;
            string situacao;

            if (faltasInjustificadas > 10)
            {
                if (faltasEfetivas <= 10 && faltasJustificadas > 0 && faltasRecuperadas > 0)
                {
                    if (media >= 10) situacao = "Aprovado(a)";
                    else if (media >= 8) situacao = "Recuperação";
                    else situacao = "Reprovado(a)";
                }
                else
                {
                    situacao = "Reprovado(a) por Faltas";
                }
            }
            else
            {
                if (media >= 10) situacao = "Aprovado(a)";
                else if (media >= 8) situacao = "Recuperação";
                else situacao = "Reprovado(a)";
            }

            string nomeLimpo = nome.Trim();
            string turmaLimpa = turma.Trim();

            string query = "UPDATE ALUNOS SET NOTA_TESTE = @teste, NOTA_TRABALHO = @trabalho, NOTA_PARTICIPACAO = @participacao, " +
                           "FALTAS_INJUSTIFICADAS = @injustificadas, FALTAS_JUSTIFICADAS = @justificadas, FALTAS_RECUPERADAS = @recuperadas, " +
                           "MEDIA_FINAL = @media, SITUACAO = @situacao WHERE ID = @id";

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    int linhasAfetadas = 0;

                    if (id > 0)
                    {
                        using (FbCommand comando = new FbCommand(query, conexao))
                        {
                            comando.Parameters.AddWithValue("@nome", nomeLimpo);
                            comando.Parameters.AddWithValue("@turma", turmaLimpa);
                            comando.Parameters.AddWithValue("@teste", teste);
                            comando.Parameters.AddWithValue("@trabalho", trabalho);
                            comando.Parameters.AddWithValue("@participacao", participacao);
                            comando.Parameters.AddWithValue("@injustificadas", faltasInjustificadas);
                            comando.Parameters.AddWithValue("@justificadas", faltasJustificadas);
                            comando.Parameters.AddWithValue("@recuperadas", faltasRecuperadas);
                            comando.Parameters.AddWithValue("@media", media);
                            comando.Parameters.AddWithValue("@situacao", situacao);

                            linhasAfetadas = comando.ExecuteNonQuery();
                        }
                    }

                    if (linhasAfetadas == 0)
                    {
                        string queryInsert = "INSERT INTO ALUNOS (NOME, TURMA, NOTA_TESTE, NOTA_TRABALHO, NOTA_PARTICIPACAO, FALTAS_INJUSTIFICADAS, FALTAS_JUSTIFICADAS, FALTAS_RECUPERADAS, MEDIA_FINAL, SITUACAO) " +
                                             "VALUES (@nome, @turma, @teste, @trabalho, @participacao, @injustificadas, @justificadas, @recuperadas, @media, @situacao)";

                        using (FbCommand comandoInsert = new FbCommand(queryInsert, conexao))
                        {
                            comandoInsert.Parameters.AddWithValue("@nome", nomeLimpo);
                            comandoInsert.Parameters.AddWithValue("@turma", turmaLimpa);
                            comandoInsert.Parameters.AddWithValue("@teste", teste);
                            comandoInsert.Parameters.AddWithValue("@trabalho", trabalho);
                            comandoInsert.Parameters.AddWithValue("@participacao", participacao);
                            comandoInsert.Parameters.AddWithValue("@injustificadas", faltasInjustificadas);
                            comandoInsert.Parameters.AddWithValue("@justificadas", faltasJustificadas);
                            comandoInsert.Parameters.AddWithValue("@recuperadas", faltasRecuperadas);
                            comandoInsert.Parameters.AddWithValue("@media", media);
                            comandoInsert.Parameters.AddWithValue("@situacao", situacao);

                            comandoInsert.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro na Base de Dados: {ex.Message}", "Erro");
                }
            }
        }

        private void btnApagarAluno_Click(object sender, EventArgs e)
        {
            if (dgvAlunos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecione primeiro os alunos na tabela clicando nas linhas deles.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult resposta = MessageBox.Show($"Tens a certeza de que queres eliminar os {dgvAlunos.SelectedRows.Count} alunos selecionados?", "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);if (resposta == DialogResult.Yes)
            {
                using (FbConnection conexao = new FbConnection(stringConexao))
                {
                    try
                    {
                        conexao.Open();

                        foreach (DataGridViewRow linha in dgvAlunos.SelectedRows)
                        {

                            if (linha.Cells["Nome"].Value == null || linha.Cells["Nome"].Value.ToString().StartsWith("---"))
                                continue;
                            string nomeParaApagar = linha.Cells["Nome"].Value.ToString();
                            string turmaParaApagar = linha.Cells["Turma"].Value.ToString();

                            string queryDelete = "DELETE FROM ALUNOS WHERE NOME = @nome AND TURMA = @turma";
                            using (FbCommand comando = new FbCommand(queryDelete, conexao))
                            {
                                comando.Parameters.AddWithValue("@nome", nomeParaApagar);
                                comando.Parameters.AddWithValue("@turma", turmaParaApagar);

                                comando.ExecuteNonQuery();
                            }
                        }
                    }
                      catch (Exception ex)
                      {
                          MessageBox.Show($"Erro ao apagar na Base de Dados: {ex.Message}", "Erro");
                          return;
                    }
                }
                CarregarHistoricoDaBaseDeDados();

                        CalcularEstatisticas(listaAlunos);
                        MessageBox.Show("Aluno eliminado com sucesso!", "Sucesso");
            }
                
        }

        private void dgvAlunos_UserDeletingRow(object? sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row != null)
            {
                DialogResult resposta = MessageBox.Show("Tens a certeza de que queres eliminar este aluno?", "Confirmar eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resposta == DialogResult.Yes)
                {
                    listaAlunos.RemoveAt(e.Row.Index);
                    this.BeginInvoke((MethodInvoker)delegate { CalcularEstatisticas(listaAlunos); });
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void CalcularEstatisticas(List<Aluno>? listaParaCalcular)
        {
            if (listaParaCalcular == null || listaParaCalcular.Count == 0)
            {
                dgvAlunos.DataSource = null;
                return;
            }

            double somaDasMedias = 0;
            double maiorMedia = -1;
            int aprovados = 0;
            int retidos = 0;
            double somaTestes = 0;
            double somaTrabalhos = 0;
            double somaParticipacao = 0;
            int totalAlunosReais = 0;

            foreach (Aluno aluno in listaParaCalcular)
            {

                if (aluno.Nome != null && aluno.Nome.Contains("---"))
                    continue;

                totalAlunosReais++;

                somaDasMedias += aluno.MediaFinal;
                somaTestes += aluno.NotaTeste;
                somaTrabalhos += aluno.NotaTrabalho;
                somaParticipacao += aluno.NotaParticipacao;

                if (aluno.MediaFinal > maiorMedia) maiorMedia = aluno.MediaFinal;
                if (aluno.Situacao != null && aluno.Situacao.ToLower().Contains("aprov")) aprovados++;
                else retidos++;
            }

            List<string> melhoresNotas = new List<string>();
            foreach (Aluno aluno in listaParaCalcular)
            {
                if (aluno.Nome != null && aluno.Nome.Contains("---")) continue;
                if (aluno.MediaFinal == maiorMedia) melhoresNotas.Add(aluno.Nome);
            }

            if (totalAlunosReais == 0) totalAlunosReais = 1;

            string nomeMelhorAluno = string.Join(", ", melhoresNotas);
            double mediaGeralTurma = Math.Round(somaDasMedias / totalAlunosReais, 2);

            lblMediaTurma.Text = $"Média da Escola: {mediaGeralTurma}";
            lblMelhorAluno.Text = $"Melhor Aluno(a): {nomeMelhorAluno} ({maiorMedia})";
            lblTotalAprovados.Text = $"Aprovados: {aprovados} (Total de alunos: {listaAlunos.Count})";
            lblTotalRetidos.Text = $"Recuperação/Reprovados: {retidos}";

            List<Aluno> listaComRodape = new List<Aluno>();
            foreach (Aluno aluno in listaParaCalcular)
            {
                if (aluno.Nome != null && !aluno.Nome.Contains("---"))
                {
                    listaComRodape.Add(aluno);
                }
            }

            Aluno linhamedia = new Aluno();
            linhamedia.Id = 0;
            linhamedia.Nome = "--- MÉDIAS DAS NOTAS ---";
            linhamedia.Turma = "";
            linhamedia.NotaTeste = Math.Round((double)somaTestes / totalAlunosReais, 2);
            linhamedia.NotaTrabalho = Math.Round((double)somaTrabalhos / totalAlunosReais, 2);
            linhamedia.NotaParticipacao = Math.Round((double)somaParticipacao / totalAlunosReais, 2);
            linhamedia.MediaFinal = mediaGeralTurma;
            linhamedia.Situacao = "Fim da Lista";

            listaComRodape.Add(linhamedia);

            dgvAlunos.DataSource = null;
            dgvAlunos.DataSource = listaComRodape;

            if (dgvAlunos.Columns["Id"] != null)
            {
                dgvAlunos.Columns["Id"].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Desejas limpar TODO o histórico?", "Limpar histórico", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultado == DialogResult.Yes)
            {
                using (FbConnection conexao = new FbConnection(stringConexao))
                {
                    try
                    {
                        conexao.Open();
                        string queryTruncate = "DELETE FROM ALUNOS";
                        using (FbCommand command = new FbCommand(queryTruncate, conexao))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao limpar a Base de Dados: {ex.Message}", "Erro");
                        return;
                    }
                }

                listaAlunos.Clear();
                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = listaAlunos;
                CalcularEstatisticas(listaAlunos);

                MessageBox.Show("Todo o histórico foi eliminado com sucesso!", "Sucesso");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click_1(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }

        private void button1_Click_1(object sender, EventArgs e) { }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 janelaTurmas = new Form2(dgvAlunos);
            janelaTurmas.ShowDialog();
        }

        private void dgvAlunos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAlunos.Columns[e.ColumnIndex].Name == "MediaFinal" && e.Value != null)
            {
                if (double.TryParse(e.Value.ToString(), out double media))
                {
                    if (media < 10)
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.SelectionForeColor = Color.Red;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.SelectionForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cmbTurmas.Focus();
            }
        }

        private void cmbTurmas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNotaTeste.Focus();
            }
        }

        private void txtNotaTeste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNotaTrabalho.Focus();
            }
        }

        private void txtNotaTrabalho_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNotaParticipacao.Focus();
            }
        }

        private void txtNotaParticipacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                numFaltas.Focus();
            }
        }

        private void numFaltas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.Focus();
            }
        }

        private void label6_Click(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaAlunos == null || listaAlunos.Count == 0) return;

            int posicao = comboBox1.SelectedIndex;
            List<Aluno> alunosFiltrados = new List<Aluno>();

            switch (posicao)
            {
                case 0:
                    alunosFiltrados = listaAlunos.ToList();
                    break;
                case 1:
                    alunosFiltrados = listaAlunos.Where(a => a.Situacao.ToLower().Contains("aprov") == true).ToList();
                    break;
                case 2:
                    alunosFiltrados = listaAlunos.Where(a => a.Situacao.ToLower().Contains("repro") == true).ToList();
                    break;
                case 3:
                    alunosFiltrados = listaAlunos.Where(a => a.Situacao.ToLower().Contains("recup") == true).ToList();
                    break;
            }
            
            CalcularEstatisticas(alunosFiltrados);
        }

        private void numFaltas_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            btnAdicionar.Focus();
        }

        private void dgvAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";
            openFileDialog.Title = "Selecionar Tabela de Notas";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoFicheiro = openFileDialog.FileName;

                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                int contagemImportados = 0;

                using (var stream = System.IO.File.Open(caminhoFicheiro, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                        });

                        var tabelaExcel = result.Tables[0];
                        listaAlunos.Clear();

                        foreach (var linhaGenerica in tabelaExcel.Rows)
                        {

                            var linha = (System.Data.DataRow)linhaGenerica;

                            if (linha[0] == null || string.IsNullOrWhiteSpace(linha[0].ToString()))
                                continue;

                            string nome = linha[0].ToString().Trim();
                            string turma = linha[1].ToString().Trim();
                            double.TryParse(linha[2]?.ToString(), out double teste);
                            double.TryParse(linha[3]?.ToString(), out double trabalho);
                            double.TryParse(linha[4]?.ToString(), out double participacao);
                            int.TryParse(linha[5]?.ToString(), out int faltas);

                            SalvarAlunoNoFirebird(0, nome, turma, teste, trabalho, participacao, faltas, 0, 0);

                            Aluno aluno = new Aluno(0, nome, turma, teste, trabalho, participacao, faltas, 0, 0);

                            contagemImportados++;
                        }
                    }
                    CarregarHistoricoDaBaseDeDados();
                }
                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = listaAlunos;

                CalcularEstatisticas(listaAlunos);

                MessageBox.Show($"{contagemImportados} alunos importados e guardados na base de dados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}