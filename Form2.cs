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
    public partial class Form2 : Form
    {   

            private List<Aluno> listaCompleta = new List<Aluno>();

        public string TurmaSelecionada { get; private set; } = "";

        public Form2(DataGridView dgvOriginal)
        {
            InitializeComponent();

            if(dgvOriginal != null && dgvOriginal.Rows.Count > 0)
            {
                foreach (DataGridViewRow linha in  dgvOriginal.Rows)
                {
                    if (linha.IsNewRow) continue;

                    string nomeLinha = linha.Cells["Nome"].Value?.ToString() ?? "";

                    if (nomeLinha == "--- TOTAIS DA TURMA ---") continue;

                    string turmaLinha = linha.Cells["Turma"].Value?.ToString() ?? "";
                    string situacaoLinha = linha.Cells["Situacao"].Value?.ToString() ?? "";

                    Aluno al = new Aluno(nomeLinha, turmaLinha, 0, 0, 0);
                    al.Situacao = situacaoLinha;

                    double media = 0;
                    if (linha.Cells["MediaFinal"].Value != null){
                        double.TryParse(linha.Cells["MediaFinal"].Value?.ToString(), out media);
                    }
                    al.MediaFinal = media;

                    listaCompleta.Add(al);
                }
            }
            AssociarEventosAosBotoes();
        }

        private void AssociarEventosAosBotoes()
        {
            foreach (Control controlo in this.Controls){
                if (controlo is Button botao)
                {
                    botao.Click += botaoTurma_Click;
                }
            }
        }

        private void botaoTurma_Click(object? sender, EventArgs e)
        {
            Button botaoClicado = (Button)sender;
            string nomeDaTurma = botaoClicado.Text;

            List<Aluno> listaFiltrada = listaCompleta
                                        .Where(a => a.Turma.Equals(nomeDaTurma, StringComparison.OrdinalIgnoreCase))
                                        .ToList();

            int quantidadeAlunos = listaFiltrada.Count;

            if (quantidadeAlunos == 0)
            {
                MessageBox.Show($"A turma {nomeDaTurma} ainda não tem alunos registados.",
                                $"Informação {nomeDaTurma}",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            double soma = listaFiltrada.Sum(a => a.MediaFinal);
            double mediaTurma = Math.Round(soma / quantidadeAlunos, 2);
            int aprovados = listaFiltrada.Count(a => a.Situacao == "Aprovado(a)");
            int retidos = quantidadeAlunos - aprovados;

            double maiorMedia = listaFiltrada.Max(a => a.MediaFinal);
            List<string> melhoresNotas = listaFiltrada
                .Where(a => a.MediaFinal == maiorMedia)
                .Select(a => a.Nome)
                .ToList();

            string nomeMelhorAluno = string.Join(", ", melhoresNotas);

            string mensagem = $"--- Estatísticas da Turma {nomeDaTurma} ---\n\n" +
                              $"Total de Alunos: {quantidadeAlunos}\n" +
                              $"Média Geral da Turma: {mediaTurma}\n" +
                              $"Alunos Aprovados. {aprovados}\n" +
                              $"Em Recuperação/Reprovados: {retidos}\n " +
                              $"Melhor Aluno(a): {nomeMelhorAluno} ({maiorMedia})";

            MessageBox.Show(mensagem, $"Relatótio da Turma {nomeDaTurma}",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);

            TurmaSelecionada = nomeDaTurma;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
