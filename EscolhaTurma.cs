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
    public partial class EscolhaTurma : Form
    {
        private string conexaoString = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Dialect=3;";
        private string professorLogado;
        private int idProfessorLogado;

        public EscolhaTurma(int idProfessorLogado, string professorLogado)
        {
            InitializeComponent();
            this.idProfessorLogado = idProfessorLogado;
            this.professorLogado = professorLogado;
        }

        public void EscolhaTurma_Load(object sender, EventArgs e)
        {
            carregarTurmas();
        }

        private void carregarTurmas()
        {
            string query = @"SELECT t.ID_TURMA, t.NOME FROM TURMAS t " +
                "INNER JOIN PROFESSORES p ON t.ID_PROFESSOR = p.ID " +
                "WHERE p.NOME LIKE @professor " +
                "ORDER BY t.NOME";

            using (FbConnection conexao = new FbConnection(conexaoString))
            {
                try
                {
                    conexao.Open();

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@professor", "%" + this.professorLogado + "%");

                        FbDataAdapter adapter = new FbDataAdapter(comando);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            DialogResult resposta = MessageBox.Show("Ainda não existem turmas registradas para este professor.\n\nPrentende criar a primeira turma?", "Sem Turmas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (resposta == DialogResult.Yes)
                            {
                                Form2 gerirTurmas = new Form2(idProfessorLogado, professorLogado);
                                gerirTurmas.ShowDialog();

                                carregarTurmas();
                            }
                            else
                            {
                                this.Hide();
                                Form3 login = new Form3();
                                login.ShowDialog();
                                this.Close();
                            }

                            return;
                        }

                        cbTurmas.Enabled = true;
                        btnEntrarTurma.Enabled = true;
                        lblSemTurmas.Visible = false;

                        cbTurmas.DataSource = dt;
                        cbTurmas.DisplayMember = "NOME";
                        cbTurmas.ValueMember = "ID_TURMA";
                        cbTurmas.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar as turmas: {ex.Message}", "Erro do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrarTurma_Click(object sender, EventArgs e)
        {
            if (cbTurmas.SelectedIndex == -1 || cbTurmas.SelectedValue == null)
            {
                MessageBox.Show("Por favor, selecione uma turma antes de continuar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idTurmaSelecionada = Convert.ToInt32(cbTurmas.SelectedValue);
            string nomeTurmaSelecionada = cbTurmas.Text;

            this.Hide();

            Form1 principal = new Form1(idProfessorLogado, professorLogado, idTurmaSelecionada, nomeTurmaSelecionada);
            principal.ShowDialog();

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) { 
                
            Utilidades.TerminarSessao(this);
            
        }
    }
}
