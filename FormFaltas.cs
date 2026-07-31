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
    public partial class FormFaltas : Form
    {
        private string stringConexao = @"User=SYSDBA;Password=2t6rXhgX;Database=C:\Users\user\Desktop\AnaLara\WinFormsApp1\escola.fdb;DataSource=localhost;Port=3050;Charset=UTF8;";

        private int idAluno;
        private int idProfessor;
        private List<Falta> listaFaltas = new List<Falta>();

        public FormFaltas(int idAluno, string nomeAluno, int idProfessor)
        {
            InitializeComponent();
            this.idAluno = idAluno;
            this.idProfessor = idProfessor;

            lblAluno.Text = "Aluno: " + nomeAluno;
            CarregarFaltas();
        }

        private void FormFaltas_Load(object sender, EventArgs e)
        {

        }

        private void CarregarFaltas()
        {
            listaFaltas.Clear();

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();

                    string query = @"SELECT ID_FALTA,
                                    DATA_FALTA,
                                    QUANTIDADE,
                                    ESTADO,
                                    JUSTIFICACAO,
                                    DOCUMENTO,
                                    DATA_JUSTIFICACAO,
                                    METODO_RECUPERACAO,
                                    DATA_RECUPERACAO
                             FROM FALTAS
                             WHERE ID_ALUNO = @idAluno
                             ORDER BY DATA_FALTA DESC";

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@idAluno", idAluno);

                        using (FbDataReader leitor = comando.ExecuteReader())
                        {
                            while (leitor.Read())
                            {
                                Falta falta = new Falta();

                                falta.Id = Convert.ToInt32(leitor["ID_FALTA"]);

                                falta.DataFalta = Convert.ToDateTime(
                                    leitor["DATA_FALTA"]);

                                falta.Quantidade = Convert.ToInt32(
                                    leitor["QUANTIDADE"]);

                                falta.Estado = leitor["ESTADO"] == DBNull.Value
                                    ? null
                                    : leitor["ESTADO"].ToString();

                                falta.Justificacao = leitor["JUSTIFICACAO"] == DBNull.Value
                                    ? null
                                    : leitor["JUSTIFICACAO"].ToString();

                                falta.Documento = leitor["DOCUMENTO"] == DBNull.Value
                                    ? null
                                    : leitor["DOCUMENTO"].ToString();

                                falta.MetodoRecuperacao = leitor["METODO_RECUPERACAO"] == DBNull.Value
                                    ? null
                                    : leitor["METODO_RECUPERACAO"].ToString();

                                listaFaltas.Add(falta);
                            }
                        }
                    }

                    dgvFaltas.DataSource = null;
                    dgvFaltas.DataSource = listaFaltas;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Erro ao carregar as faltas: {ex.Message}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnRegistrarFalta_Click(object sender, EventArgs e)
        {
            int quantidade = (int)nudQuantidade.Value;
            DateTime data = dtpData.Value;

            if (quantidade <= 0)
            {
                MessageBox.Show("A quantidade de faltas deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                try
                {
                    conexao.Open();

                    string query = @"
                        INSERT INTO FALTAS
                        (
                            ID_ALUNO,
                            ID_PROFESSOR,
                            DATA_FALTA,
                            QUANTIDADE,
                            ESTADO
                        )
                        VALUES
                        (
                            @idAluno,
                            @idProfessor,
                            @dataFalta,
                            @quantidade,
                            'INJUSTIFICADA'
                        )";

                    using (FbCommand comando = new FbCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@idAluno", idAluno);
                        comando.Parameters.AddWithValue("@idProfessor", idProfessor);
                        comando.Parameters.AddWithValue("@dataFalta", data);
                        comando.Parameters.AddWithValue("@quantidade", quantidade);

                        comando.ExecuteNonQuery();
                    }

                    MessageBox.Show("Falta registada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CarregarFaltas();

                    nudQuantidade.Value = 1;
                    dtpData.Value = DateTime.Now;
                } catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao registar a falta: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
