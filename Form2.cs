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
                    string turmaLinha = linha.Cells["Turma"].Value?.ToString() ?? "";

                    Aluno al = new Aluno(nomeLinha, turmaLinha, 0, 0, 0);

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
            double mediaTurma = 0;

            if (quantidadeAlunos > 0)
            {
                double soma = listaFiltrada.Sum(a => a.MediaFinal);
                mediaTurma = Math.Round(soma / quantidadeAlunos, 2);
            }

            MessageBox.Show($"--- Estatísticas da Turma {nomeDaTurma} ---\n\n" +
                            $"Alunos na turma: {quantidadeAlunos}\n" +
                            $"Média da turma: {(quantidadeAlunos > 0 ? mediaTurma.ToString() : "-")}", 
                            $"Informação {nomeDaTurma}",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            TurmaSelecionada = nomeDaTurma;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
