using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Text.RegularExpressions;

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
        }

        private void txtNome_TextChanged(object? sender, EventArgs e)
        {
            if (listaAlunos == null || listaAlunos.Count == 0) return;

            string textoPesquisa = txtNome.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(textoPesquisa))
            {
                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = listaAlunos;
            } else
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

            string querySelect = "SELECT NOME, TURMA, NOTA_TESTE, NOTA_TRABALHO, NOTA_PARTICIPACAO, FALTAS, MEDIA_FINAL, SITUACAO FROM ALUNOS";
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

                                int faltasRecuperadas = leitor["FALTAS"] != DBNull.Value ? Convert.ToInt32(leitor["FALTAS"]) : 0;

                                Aluno aluno = new Aluno(nome, turma, notaTeste, notaTrabalho, notaParticipacao, faltasRecuperadas);
                                listaAlunos.Add(aluno);
                            }
                        }
                    }

                    dgvAlunos.DataSource = null;
                    dgvAlunos.DataSource = listaAlunos;

                    CalcularEstatisticas();
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

            if (alunoEditado.MediaFinal >= 10) alunoEditado.Situacao = "Aprovado(a)";
            else if (alunoEditado.MediaFinal >= 8) alunoEditado.Situacao = "Recuperação";
            else alunoEditado.Situacao = "Reprovado(a)";

            CalcularEstatisticas();
            dgvAlunos.Refresh();

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    string queryUpdate = "UPDATE ALUNOS SET NOME = @v_nome, TURMA = @v_turma, NOTA_TESTE = @v_teste, " +
                                         "NOTA_TRABALHO = @v_trabalho, NOTA_PARTICIPACAO = @v_participacao, FALTAS = @v_faltas, " +
                                         "MEDIA_FINAL = @v_media, SITUACAO = @v_situacao " +
                                         "WHERE NOME = @v_nomeAntigo AND TURMA = @v_turmaAntiga";

                    using (FbCommand comando = new FbCommand(queryUpdate, conexao))
                    {
                        comando.Parameters.AddWithValue("@v_nome", alunoEditado.Nome);
                        comando.Parameters.AddWithValue("@v_turma", alunoEditado.Turma);
                        comando.Parameters.AddWithValue("@v_teste", alunoEditado.NotaTeste);
                        comando.Parameters.AddWithValue("@v_trabalho", alunoEditado.NotaTrabalho);
                        comando.Parameters.AddWithValue("@v_participacao", alunoEditado.NotaParticipacao);
                        comando.Parameters.AddWithValue("@v_faltas", alunoEditado.Faltas);
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
            SalvarAlunoNoFirebird(nomeInserido, turmaInserida, notaTeste, notaTrabalho, notaParticipacao, faltasInseridas);

            Aluno novoAluno = new Aluno(txtNome.Text, cmbTurmas.Text, notaTeste, notaTrabalho, notaParticipacao, faltasInseridas);
            listaAlunos.Add(novoAluno);

            dgvAlunos.DataSource = null;
            dgvAlunos.DataSource = listaAlunos;

            CalcularEstatisticas();

            txtNome.Clear();
            txtNotaTeste.Clear();
            txtNotaTrabalho.Clear();
            txtNotaParticipacao.Clear();
            numFaltas.Value = 0;

            if (cmbTurmas.Items.Count > 0) cmbTurmas.SelectedIndex = 0;

            txtNome.Focus();
        }

        private void SalvarAlunoNoFirebird(string nome, string turma, double teste, double trabalho, double participacao, int faltas)
        {
            double media = Math.Round((teste * 0.5) + (trabalho * 0.3) + (participacao * 0.2), 2);
            string situacao = media >= 10 ? "Aprovado(a)" : (media >= 8 ? "Recuperação" : "Reprovado(a)");

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();

                    int proximoId = 1;
                    string sqlId = "SELECT COALESCE(MAX(ID), 0) + 1 FROM ALUNOS";
                    using (FbCommand cmdId = new FbCommand(sqlId, conexao))
                    {
                        proximoId = Convert.ToInt32(cmdId.ExecuteScalar());
                    }

                    string query = "INSERT INTO ALUNOS (ID, NOME, TURMA, NOTA_TESTE, NOTA_TRABALHO, NOTA_PARTICIPACAO, FALTAS, MEDIA_FINAL, SITUACAO) " +
                                   "VALUES (@id, @nome, @turma, @teste, @trabalho, @participacao, @faltas, @media, @situacao)";

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@id", proximoId);
                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@turma", turma);
                        comando.Parameters.AddWithValue("@teste", teste);
                        comando.Parameters.AddWithValue("@trabalho", trabalho);
                        comando.Parameters.AddWithValue("@participacao", participacao);
                        comando.Parameters.AddWithValue("@faltas", faltas);
                        comando.Parameters.AddWithValue("@media", media);
                        comando.Parameters.AddWithValue("@situacao", situacao);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Aluno gravado no Firebird com sucesso!", "Sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro na Base de Dados: {ex.Message}", "Erro");
                }
            }
        }

        private void btnApagarAluno_Click(object sender, EventArgs e)
        {
            if (dgvAlunos.CurrentRow != null && dgvAlunos.CurrentRow.Index >= 0)
            {
                int indiceSelecionado = dgvAlunos.CurrentRow.Index;

                if (indiceSelecionado < listaAlunos.Count)
                {
                    string nomeParaApagar = dgvAlunos.CurrentRow.Cells["Nome"].Value.ToString();
                    string turmaParaApagar = dgvAlunos.CurrentRow.Cells["Turma"].Value.ToString();

                    DialogResult resposta = MessageBox.Show($"Tens a certeza de que queres eliminar o(a) aluno(a) {nomeParaApagar}?", "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resposta == DialogResult.Yes)
                    {
                        using (FbConnection conexao = new FbConnection(stringConexao))
                        {
                            try
                            {
                                conexao.Open();
                                string queryDelete = "DELETE FROM ALUNOS WHERE NOME = @nome AND TURMA = @turma";
                                using (FbCommand comando = new FbCommand(queryDelete, conexao))
                                {
                                    comando.Parameters.AddWithValue("@nome", nomeParaApagar);
                                    comando.Parameters.AddWithValue("@turma", turmaParaApagar);

                                    comando.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao apagar na Base de Dados: {ex.Message}", "Erro");
                                return;
                            }
                        }

                        listaAlunos.RemoveAt(indiceSelecionado);

                        dgvAlunos.DataSource = null;
                        dgvAlunos.DataSource = listaAlunos;

                        CalcularEstatisticas();
                        MessageBox.Show("Aluno eliminado com sucesso!", "Sucesso");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleciona primeiro um aluno na tabela clicando na linha dele.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    this.BeginInvoke((MethodInvoker)delegate { CalcularEstatisticas(); });
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void CalcularEstatisticas()
        {
            if (listaAlunos == null || listaAlunos.Count == 0) return;

            double somaDasMedias = 0;
            double maiorMedia = -1;
            int aprovados = 0;
            int retidos = 0;
            double somaTestes = 0;
            double somaTrabalhos = 0;
            double somaParticipacao = 0;

            foreach (Aluno aluno in listaAlunos)
            {
                somaDasMedias += aluno.MediaFinal;
                somaTestes += aluno.NotaTeste;
                somaTrabalhos += aluno.NotaTrabalho;
                somaParticipacao += aluno.NotaParticipacao;

                if (aluno.MediaFinal > maiorMedia) maiorMedia = aluno.MediaFinal;
                if (aluno.Situacao == "Aprovado(a)") aprovados++;
                else retidos++;
            }

            List<string> melhoresNotas = new List<string>();
            foreach (Aluno aluno in listaAlunos)
            {
                if (aluno.MediaFinal == maiorMedia) melhoresNotas.Add(aluno.Nome);
            }

            string nomeMelhorAluno = string.Join(", ", melhoresNotas);
            double mediaGeralTurma = Math.Round(somaDasMedias / listaAlunos.Count, 2);

            lblMediaTurma.Text = $"Média da Escola: {mediaGeralTurma}";
            lblMelhorAluno.Text = $"Melhor Aluno(a): {nomeMelhorAluno} ({maiorMedia})";
            lblTotalAprovados.Text = $"Aprovados: {aprovados} (Total de alunos: {listaAlunos.Count})";
            lblTotalRetidos.Text = $"Recuperação/Reprovados: {retidos}";

            List<Aluno> listaComRodape = new List<Aluno>(listaAlunos);

            Aluno linhamedia = new Aluno();
            linhamedia.Id = 0;
            linhamedia.Nome = "--- MÉDIAS DAS NOTAS ---";
            linhamedia.Turma = "";
            linhamedia.NotaTeste = Math.Round(somaTestes / listaAlunos.Count, 2);
            linhamedia.NotaTrabalho = Math.Round(somaTrabalhos / listaAlunos.Count, 2);
            linhamedia.NotaParticipacao = Math.Round(somaParticipacao / listaAlunos.Count, 2);
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
                        MessageBox.Show("Erro ao limpar a Bae de Dados: {ex.Message}", "Erro");
                        return;
                    }
                }

                listaAlunos.Clear();
                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = listaAlunos;
                CalcularEstatisticas();

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

            dgvAlunos.DataSource = null;

            int posicao = comboBox1.SelectedIndex;

            if (posicao == 0)
            {
                dgvAlunos.DataSource = listaAlunos;
            }
            else if (posicao == 1)
            {
                var filtrados = listaAlunos.Where(aluno => aluno.Situacao != null && aluno.Situacao.ToLower().Contains("aprov")).ToList();
                dgvAlunos.DataSource = filtrados;
            }
            else if (posicao == 2)
            {
                var filtrados = listaAlunos.Where(aluno => aluno.Situacao != null && aluno.Situacao.ToLower().Contains("repro")).ToList();
                dgvAlunos.DataSource = filtrados;
            }
            else if (posicao == 3)
            {
                var filtrados = listaAlunos.Where(aluno => aluno.Situacao != null && aluno.Situacao.ToLower().Contains("recup")).ToList();
                dgvAlunos.DataSource = filtrados;
            }

            dgvAlunos.Refresh();

            if (dgvAlunos.Columns["Id"] != null) dgvAlunos.Columns["Id"].Visible = false;
        }

        private void numFaltas_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            btnAdicionar.Focus();
        }
    }
}