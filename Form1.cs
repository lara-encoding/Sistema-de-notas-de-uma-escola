using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Text.RegularExpressions;
using ClosedXML.Excel;
using ExcelDataReader;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Vml.Office;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private string stringConexao = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Charset=UTF8;";

        private List<Aluno> listaAlunos = new List<Aluno>();
        private string nomeAntigo = "";
        private string turmaAntiga = "";
        private object comando;
        private object faltas;
        private object linha;
        private Aluno novoAluno;
        private bool emValidacao = false;
        private bool bloqueioPopupAtivo = false;
        private bool gravandoDados = false;
        private string ultimoConteudoExportado = "";
        private string professorLogado;
        private int idProfessorLogado;
        private int idTurmaAtual;
        private string nomeTurmaAtual;
        private string turmaAtual = "1ºA";
        private string disciplinaProfessor;

        public Form1(int idProfessorLogado, string professorLogado, string disciplinaProfessor, int idTurmaAtual, string nomeTurmaAtual)
        {
            InitializeComponent();
            this.idProfessorLogado = idProfessorLogado;
            this.professorLogado = professorLogado;
            this.disciplinaProfessor = disciplinaProfessor;
            this.idTurmaAtual = idTurmaAtual;
            this.nomeTurmaAtual = nomeTurmaAtual;

            this.Text = "Gestão de Alunos";

            dgvAlunos.CellBeginEdit += dgvAlunos_CellBeginEdit;
            dgvAlunos.CellValueChanged += dgvAlunos_CellValueChanged;
            dgvAlunos.UserDeletingRow += dgvAlunos_UserDeletingRow;
            button1.Click += btnApagarAluno_Click;
            dgvAlunos.CellFormatting += dgvAlunos_CellFormatting;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            txtNome.TextChanged += txtNome_TextChanged;
            button6.Click += button6_Click;

            CarregarHistoricoDaBaseDeDados();
            ToolTip dicaBotao = new ToolTip();

            dicaBotao.AutoPopDelay = 5000;
            dicaBotao.InitialDelay = 500;

            dicaBotao.SetToolTip(button1, "Dica: Pode selecionar vários alunos segurando a tecla CTRL enquanto clicas nas linhas");
        }

        private void EnviarEmailAluno(Aluno aluno, string emailDestinatario)
        {
            string emailRemetente = "anamedici634@gmail.com";
            string palavraPasse = "czpbrzktanvhyyik";

            string assunto = $"Notas e Situação Final - {aluno.Nome}";
            string corpoTexto = "";

            int faltasEfetivas = aluno.FaltasInjustificadas - aluno.FaltasRecuperadas;

            switch (aluno.Situacao)
            {
                case "Aprovado(a)":
                    corpoTexto = $"Olá {aluno.Nome}," +
            $"\n\nParabéns! É com grande satisfação que informo que foste Aprovado(a).\n" +
            $"A tua média final nesta disciplina foi de {aluno.MediaFinal} valores.\n" +
            $"Continua com o excelente trabalho e votos de ótimas férias!\n" +
            $"\nAtenciosamente,\n" +
            $"O Teu Professor / Conselho de Turma.";
                    break;

                case "Recuperação":
                    corpoTexto = $"Olá {aluno.Nome}," +
            $"\n\nEnvio esta mensagem para informar que a tua situação atual é de Recuperação de Nota.\n" +
            $"A tua média final momentânea é de {aluno.MediaFinal} valores.\n" +
            $"As tuas notas parciais foram:\n" +
            $"- Nota do Teste: {aluno.Nota_Teste}\n" +
            $"- Nota do Trabalho: {aluno.Nota_Trabalho}\n" +
            $"- Nota de Participação: {aluno.Nota_Participacao}\n" +
            $"\nComo tens direito a realizar uma prova de recurso para tentar melhorar esta nota, por favor, entra em contacto comigo o quanto antes para combinarmos os detalhes e a data da prova." +
            $"\n\nAtenciosamente," +
                    $"\nO Teu Professor.";
                    break;

                case "Reprovado(a) por Faltas":
                    corpoTexto = $"Olá {aluno.Nome}," +
            $"\n\nEntro em contacto para informar que a tua situação final nesta disciplina é de Reprovado(a) por Faltas, por teres excedido o limite legal de faltas.\n" +
            $"\n- Total de Faltas Injustificadas: {aluno.FaltasInjustificadas}" +
            $"\n- Faltas Efetivas(após recuperação): {faltasEfetivas}" +
            $"\nPara saberes quais os procedimentos necessários agora, deverás consultar a secretaria ou a direção da escola juntamente com o teu encarregado de educação." +
            $"\n\nAtenciosamente," +
            $"\nO Teu Professor.";
                    break;

                default:
                    corpoTexto = $"Olá {aluno.Nome}," +
            $"Informo que a tua situação final é de Reprovado(a) por insuficiência de nota.\n" +
            $"\nA tua média final foi de {aluno.MediaFinal} valores, ficando abaixo do mínimo de 10 valores necessário para transitar." +
            $"\nPara esclarecimentos adicionais sobre a avaliação ou sobre os próximos passos, entra em contacto comigo ou consulta a secretaria da escola." +
            $"\n\nAtenciosamente," +
            $"\nO Teu Professor.";
                    break;
            }

            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls13;

                MailMessage email = new MailMessage();
                email.From = new MailAddress(emailRemetente, "Professor (Via Sistema)");
                email.To.Add(emailDestinatario);
                email.Subject = assunto;
                email.Body = corpoTexto;
                email.BodyEncoding = System.Text.Encoding.UTF8;
                email.IsBodyHtml = false;

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(emailRemetente.Trim(), palavraPasse.Trim());
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(email);

                MessageBox.Show($"Email enviado com sucesso para {aluno.Nome}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                string erroDetalhado = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Erro técnico ao enviar e-mail: {ex.Message}", "Erro de Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (cmbTurmas.SelectedItem == null)
                return;

            Turma turmaSelecionada = (Turma)cmbTurmas.SelectedItem;

            idTurmaAtual = turmaSelecionada.Id;
            nomeTurmaAtual = turmaSelecionada.Nome;

            this.Text = "Gestão de Alunos";

            CarregarHistoricoDaBaseDeDados();
        }

        private void CarregarHistoricoDaBaseDeDados()
        {
            if (listaAlunos == null) listaAlunos = new List<Aluno>();
            listaAlunos.Clear();

            string querySelect = "SELECT ID, NOME, NOTA_TESTE, NOTA_TRABALHO, NOTA_PARTICIPACAO, MEDIA_FINAL, SITUACAO, FALTAS_INJUSTIFICADAS, FALTAS_JUSTIFICADAS, FALTAS_RECUPERADAS FROM ALUNOS WHERE ID_TURMA = @idTurma";
            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();
                    using (FbCommand comando = new FbCommand(querySelect, conexao))
                    {
                        comando.Parameters.AddWithValue("@idTurma", this.idTurmaAtual);

                        using (FbDataReader leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                int id = Convert.ToInt32(leitor["ID"]);
                                string nome = leitor["NOME"].ToString();

                                nome = nome.Replace("Ã©", "é")
                                           .Replace("Ã§", "ç")
                                           .Replace("Âº", "º");

                                string turma = this.nomeTurmaAtual;
                                double notaTeste = Convert.ToDouble(leitor["NOTA_TESTE"]);
                                double notaTrabalho = Convert.ToDouble(leitor["NOTA_TRABALHO"]);
                                double notaParticipacao = Convert.ToDouble(leitor["NOTA_PARTICIPACAO"]);

                                int faltasInjustificadas = leitor["FALTAS_INJUSTIFICADAS"] != DBNull.Value ? Convert.ToInt32(leitor["FALTAS_INJUSTIFICADAS"]) : 0;
                                int faltasJustificadas = leitor["FALTAS_JUSTIFICADAS"] != DBNull.Value ? Convert.ToInt32(leitor["FALTAS_JUSTIFICADAS"]) : 0;
                                int faltasRecuperadas = leitor["FALTAS_RECUPERADAS"] != DBNull.Value ? Convert.ToInt32(leitor["FALTAS_RECUPERADAS"]) : 0;

                                Aluno aluno = new Aluno(id, nome, turma, notaTeste, notaTrabalho, notaParticipacao, faltasInjustificadas, faltasJustificadas, faltasRecuperadas);
                                listaAlunos.Add(aluno);
                            }
                        }
                    }

                    dgvAlunos.DataSource = null;
                    dgvAlunos.DataSource = listaAlunos;

                    if (dgvAlunos.Columns["ID"] != null) dgvAlunos.Columns["ID"].Visible = false;

                    CalcularEstatisticas(listaAlunos);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar o histórico: {ex.Message}");
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
            if (gravandoDados) return;

            if (e.RowIndex < 0 || e.RowIndex >= listaAlunos.Count) return;

            Aluno alunoEditado = listaAlunos[e.RowIndex];

            if (alunoEditado.FaltasRecuperadas > alunoEditado.FaltasJustificadas)
            {
                gravandoDados = true;

                MessageBox.Show($"Erro: As faltas recuperadas ({alunoEditado.FaltasRecuperadas}) não podem ser maiores do que as faltas justificadas ({alunoEditado.FaltasJustificadas})!",
                                "Aviso de Validação",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                alunoEditado.FaltasRecuperadas = alunoEditado.FaltasJustificadas;
                dgvAlunos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = alunoEditado.FaltasJustificadas;

                dgvAlunos.Refresh();

                gravandoDados = false;
                return;
            }

            alunoEditado.MediaFinal = Math.Round((alunoEditado.Nota_Teste * 0.5) + (alunoEditado.Nota_Trabalho * 0.3) + (alunoEditado.Nota_Participacao * 0.2), 2);

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
                    string queryUpdate = "UPDATE ALUNOS SET NOME = @v_nome, NOTA_TESTE = @v_teste, " +
                                         "NOTA_TRABALHO = @v_trabalho, NOTA_PARTICIPACAO = @v_participacao, " +
                                         "FALTAS_INJUSTIFICADAS = @v_faltasInjustificadas, FALTAS_JUSTIFICADAS = @v_faltasJustificadas, FALTAS_RECUPERADAS = @v_faltasRecuperadas, " +
                                         "MEDIA_FINAL = @v_media, SITUACAO = @v_situacao " +
                                         "WHERE ID = @v_id";

                    using (FbCommand comando = new FbCommand(queryUpdate, conexao))
                    {
                        comando.Parameters.AddWithValue("@v_nome", alunoEditado.Nome);
                        comando.Parameters.AddWithValue("@v_teste", alunoEditado.Nota_Teste);
                        comando.Parameters.AddWithValue("@v_trabalho", alunoEditado.Nota_Trabalho);
                        comando.Parameters.AddWithValue("@v_participacao", alunoEditado.Nota_Participacao);
                        comando.Parameters.AddWithValue("@v_faltasInjustificadas", alunoEditado.FaltasInjustificadas);
                        comando.Parameters.AddWithValue("@v_faltasJustificadas", alunoEditado.FaltasJustificadas);
                        comando.Parameters.AddWithValue("@v_faltasRecuperadas", alunoEditado.FaltasRecuperadas);
                        comando.Parameters.AddWithValue("@v_media", alunoEditado.MediaFinal);
                        comando.Parameters.AddWithValue("@v_situacao", alunoEditado.Situacao);
                        comando.Parameters.AddWithValue("@v_id", alunoEditado.Id);

                        comando.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar no Firebird: {ex.Message}", "Erro de Sincronização");
                }
            }
            nomeAntigo = "";
            turmaAntiga = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nomeOriginal = txtNome.Text;
            TextInfo textInfo = new CultureInfo("pt-PT").TextInfo;
            string nomeFormatado = textInfo.ToTitleCase(nomeOriginal.ToLower());

            nomeFormatado = nomeFormatado
                .Replace(" Da ", " da ")
                .Replace(" De ", " de ")
                .Replace(" Do ", " do ")
                .Replace(" Das ", " das ")
                .Replace(" Dos ", " dos ")
                .Replace(" E ", " e ");

            string nomeInserido = nomeFormatado.Trim();

            if (string.IsNullOrWhiteSpace(nomeInserido))
            {
                MessageBox.Show("Insira o nome do aluno:", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    string queryCheck = "SELECT COUNT(*) FROM ALUNOS WHERE LOWER(NOME) = LOWER(@v_nome)";

                    using (FbCommand cmdCheck = new FbCommand(queryCheck, conexaoValidar))
                    {
                        cmdCheck.Parameters.AddWithValue("@v_nome", nomeInserido);

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
                MessageBox.Show("Já existe um aluno com esse nome registado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            SalvarAlunoNoFirebird(0, nomeInserido, turmaAtual, notaTeste, notaTrabalho, notaParticipacao, faltasInseridas, 0, 0);
            CarregarHistoricoDaBaseDeDados();

            txtNome.Clear();
            txtNotaTeste.Clear();
            txtNotaTrabalho.Clear();
            txtNotaParticipacao.Clear();
            numFaltas.Value = 0;

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }

            comboBox1_SelectedIndexChanged(cb1, EventArgs.Empty);

            MessageBox.Show($"Aluno adicionado com sucesso!\n\n" +
                "Utilizador: {utilizador}\n" + 
                $"Palavra-passe inicial: Aluno123@",
                "Conta criada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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
                    if (media >= 10)
                        situacao = "Aprovado(a)";
                    else if (media >= 8)
                        situacao = "Recuperação";
                    else
                        situacao = "Reprovado(a)";
                }
                else
                {
                    if (media < 8)
                        situacao = "Reprovado(a) por Nota e Faltas";
                    else
                        situacao = "Reprovado(a) por Faltas";
                }
            }
            else
            {
                if (media >= 10)
                    situacao = "Aprovado(a)";
                else if (media >= 8)
                    situacao = "Recuperação";
                else
                    situacao = "Reprovado(a)";
            }

            string nomeLimpo = nome.Trim();

            string query = "UPDATE ALUNOS SET NOME = @nome, NOTA_TESTE = @teste, NOTA_TRABALHO = @trabalho, NOTA_PARTICIPACAO = @participacao, " +
                           "FALTAS_INJUSTIFICADAS = @injustificadas, FALTAS_JUSTIFICADAS = @justificadas, FALTAS_RECUPERADAS = @recuperadas, " +
                           "MEDIA_FINAL = @media, SITUACAO = @situacao WHERE ID = @id";

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();

                    if (id == 0)
                    {
                        string queryExiste = "SELECT ID FROM ALUNOS WHERE LOWER(NOME) = LOWER(@nome) AND ID_TURMA = @idTurma";

                        using (FbCommand comandoExiste = new FbCommand(queryExiste, conexao))
                        {
                            comandoExiste.Parameters.AddWithValue("@nome", nomeLimpo);
                            comandoExiste.Parameters.AddWithValue("@idTurma", idTurmaAtual);

                            object resultado = comandoExiste.ExecuteScalar();

                            if (resultado != null)
                            {
                                id = Convert.ToInt32(resultado);
                            }
                        }
                    }
                    int linhasAfetadas = 0;

                    if (id > 0)
                    {
                        using (FbCommand comando = new FbCommand(query, conexao))
                        {
                            comando.Parameters.AddWithValue("@id", id);
                            comando.Parameters.AddWithValue("@nome", nomeLimpo);
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
                        string utilizador = nomeLimpo
                            .ToLower()
                            .Replace(" ", ".");

                        string senhaHash = Seguranca.GerarHash("Aluno123@");

                        string queryInsert = "INSERT INTO ALUNOS (NOME, UTILIZADOR, SENHA, NOTA_TESTE, NOTA_TRABALHO, NOTA_PARTICIPACAO, FALTAS_INJUSTIFICADAS, FALTAS_JUSTIFICADAS, FALTAS_RECUPERADAS, MEDIA_FINAL, SITUACAO, ID_TURMA) " +
                                             "VALUES (@nome, @utilizador, @senha, @teste, @trabalho, @participacao, @injustificadas, @justificadas, @recuperadas, @media, @situacao, @idTurma)";

                        using (FbCommand comandoInsert = new FbCommand(queryInsert, conexao))
                        {
                            comandoInsert.Parameters.AddWithValue("@nome", nomeLimpo);
                            comandoInsert.Parameters.AddWithValue("@utilizador", utilizador);
                            comandoInsert.Parameters.AddWithValue("@senha", senhaHash);
                            comandoInsert.Parameters.AddWithValue("@teste", teste);
                            comandoInsert.Parameters.AddWithValue("@trabalho", trabalho);
                            comandoInsert.Parameters.AddWithValue("@participacao", participacao);
                            comandoInsert.Parameters.AddWithValue("@injustificadas", faltasInjustificadas);
                            comandoInsert.Parameters.AddWithValue("@justificadas", faltasJustificadas);
                            comandoInsert.Parameters.AddWithValue("@recuperadas", faltasRecuperadas);
                            comandoInsert.Parameters.AddWithValue("@media", media);
                            comandoInsert.Parameters.AddWithValue("@situacao", situacao);
                            comandoInsert.Parameters.AddWithValue("@idTurma", idTurmaAtual);

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

            DialogResult resposta = MessageBox.Show($"Tens a certeza de que queres eliminar os {dgvAlunos.SelectedRows.Count} alunos selecionados?", "Confirmar Eliminação", MessageBoxButtons.YesNo, MessageBoxIcon.Question); if (resposta == DialogResult.Yes)
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

                            int idAluno = Convert.ToInt32(linha.Cells["ID"].Value);

                            string queryDelete = "DELETE FROM ALUNOS WHERE ID = @id";
                            using (FbCommand comando = new FbCommand(queryDelete, conexao))
                            {
                                comando.Parameters.AddWithValue("@id", idAluno);
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
                somaTestes += aluno.Nota_Teste;
                somaTrabalhos += aluno.Nota_Trabalho;
                somaParticipacao += aluno.Nota_Participacao;

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

            lblMediaTurma.Text = $"Média da Turma: {mediaGeralTurma}";
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
            linhamedia.Nota_Teste = Math.Round((double)somaTestes / totalAlunosReais, 2);
            linhamedia.Nota_Trabalho = Math.Round((double)somaTrabalhos / totalAlunosReais, 2);
            linhamedia.Nota_Participacao = Math.Round((double)somaParticipacao / totalAlunosReais, 2);
            linhamedia.MediaFinal = mediaGeralTurma;
            linhamedia.Situacao = "Fim da Lista";

            listaComRodape.Add(linhamedia);

            dgvAlunos.CellValueChanged -= dgvAlunos_CellValueChanged;

            dgvAlunos.DataSource = null;
            dgvAlunos.DataSource = listaComRodape;

            dgvAlunos.CellValueChanged += dgvAlunos_CellValueChanged;

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
                        MessageBox.Show($"Erro ao limpar a Base de Dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                listaAlunos.Clear();
                dgvAlunos.DataSource = null;
                dgvAlunos.DataSource = listaAlunos;
                CalcularEstatisticas(listaAlunos);

                MessageBox.Show("Todo o histórico foi eliminado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e) { }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"Professor(a): {professorLogado} | Disciplina: {disciplinaProfessor}";

            CarregarTurmas();
            CarregarHistoricoDaBaseDeDados();
        }

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
            Form2 janelaTurmas = new Form2(idProfessorLogado, professorLogado);
            janelaTurmas.ShowDialog();
        }

        private void dgvAlunos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAlunos.Columns[e.ColumnIndex].Name == "MediaFinal" && e.Value != null)
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
                    alunosFiltrados = listaAlunos.Where(a => a.Situacao != null && a.Situacao.ToLower().Contains("aprov")).ToList();
                    break;
                case 2:
                    alunosFiltrados = listaAlunos.Where(a => a.Situacao != null && a.Situacao.ToLower().Contains("repro")).ToList();
                    break;
                case 3:
                    alunosFiltrados = listaAlunos.Where(a => a.Situacao != null && a.Situacao.ToLower().Contains("recup")).ToList();
                    break;
            }

            CalcularEstatisticas(alunosFiltrados);
        }

        private void numFaltas_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            btnAdicionar.Focus();
        }

        private void dgvAlunos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

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

                try
                {
                    using (var stream = System.IO.File.Open(caminhoFicheiro, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });

                            if (result.Tables.Count == 0) return;

                            var tabelaExcel = result.Tables[0];
                            listaAlunos.Clear();

                            foreach (var linhaGenerica in tabelaExcel.Rows)
                            {
                                var linha = (System.Data.DataRow)linhaGenerica;

                                if (linha[0] == null || string.IsNullOrWhiteSpace(linha[0].ToString()))
                                    continue;

                                string nome = linha[0].ToString().Trim();
                                TextInfo textInfo = new CultureInfo("pt-PT").TextInfo;
                                nome = textInfo.ToTitleCase(nome.ToLower());

                                nome = nome
                                .Replace(" Da ", " da ")
                                .Replace(" De ", " de ")
                                .Replace(" Do ", " do ")
                                .Replace(" Das ", " das ")
                                .Replace(" Dos ", " dos ")
                                .Replace(" E ", " e ");

                                double.TryParse(linha[1]?.ToString(), out double teste);
                                double.TryParse(linha[2]?.ToString(), out double trabalho);
                                double.TryParse(linha[3]?.ToString(), out double participacao);
                                int.TryParse(linha[4]?.ToString(), out int faltas);

                                SalvarAlunoNoFirebird(0, nome, "", teste, trabalho, participacao, faltas, 0, 0);
                                contagemImportados++;
                            }
                        }
                    }

                    CarregarHistoricoDaBaseDeDados();
                    MessageBox.Show($"{contagemImportados} alunos importados e sincronizados com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao ler ou processar o ficheiro Excel: {ex.Message}", "Erro de Importação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvAlunos.Rows.Count == 0) return;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < dgvAlunos.Columns.Count; i++)
            {
                if (!dgvAlunos.Columns[i].Visible) continue;
                sb.Append(dgvAlunos.Columns[i].HeaderText);
                if (i < dgvAlunos.Columns.Count - 1) sb.Append(";");
            }
            sb.AppendLine();

            for (int i = 0; i < dgvAlunos.Rows.Count; i++)
            {
                if (dgvAlunos.Rows[i].IsNewRow) continue;

                for (int j = 0; j < dgvAlunos.Columns.Count; j++)
                {
                    if (!dgvAlunos.Columns[j].Visible) continue;
                    string valor = dgvAlunos.Rows[i].Cells[j].Value?.ToString() ?? "";
                    sb.Append(valor.Replace(";", ","));
                    if (j < dgvAlunos.Columns.Count - 1) sb.Append(";");
                }
                sb.AppendLine();
            }

            string conteudoAtual = sb.ToString();

            if (conteudoAtual == ultimoConteudoExportado)
            {
                MessageBox.Show("As informações não foram alteradas desde a última exportação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Ficheiro CSV (*.csv)|*.csv";
            sfd.FileName = "Relatorio_Alunos.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.Write(conteudoAtual);
                    }

                    ultimoConteudoExportado = conteudoAtual;
                    MessageBox.Show("Dados exportados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao exportar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvAlunos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleciona o aluno(a) na tabela clicando no início da linha dele.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow linhaSelecionada = dgvAlunos.SelectedRows[0];

            if (linhaSelecionada.Cells["Nome"].Value == null || linhaSelecionada.Cells["Nome"].Value.ToString().StartsWith("---"))
            {
                MessageBox.Show("Não podes enviar um e-mail para a linha de médias do rodapé!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nomeAluno = linhaSelecionada.Cells["Nome"].Value.ToString();
            string turmaAluno = linhaSelecionada.Cells["Turma"].Value.ToString();

            Aluno alunoSelecionado = listaAlunos.FirstOrDefault(a => a.Nome == nomeAluno && a.Turma == turmaAluno);

            if (alunoSelecionado != null)
            {
                string emailDestino = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Insira o e-mail do(a) aluno(a) {alunoSelecionado.Nome}:",
                    "Enviar Relatório de Notas",
                    "");

                if (!string.IsNullOrWhiteSpace(emailDestino) && emailDestino.Contains("@"))
                {
                    EnviarEmailAluno(alunoSelecionado, emailDestino);
                }
                else if (!string.IsNullOrWhiteSpace(emailDestino))
                {
                    MessageBox.Show("O e-mail digitado parece inválido. Certifica-te de que incluis o '@'.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Aluno não encontrado na lista interna.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarTurmas()
        {
            cmbTurmas.Items.Clear();

            string query = "SELECT ID_TURMA, NOME FROM TURMAS WHERE ID_PROFESSOR = @idProfessor ORDER BY NOME";

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();

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

                                cmbTurmas.Items.Add(turma);
                            }
                        }
                    }
                    for (int i = 0; i < cmbTurmas.Items.Count; i++)
                    {
                        Turma turma = (Turma)cmbTurmas.Items[i];

                        if (turma.Id == idTurmaAtual)
                        {
                            cmbTurmas.SelectedIndex = i;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar as turmas: {ex.Message}");
                }
            }
        }

        private void btnTerminarSessao_Click(object sender, EventArgs e)
        {
            Utilidades.TerminarSessao(this);
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}