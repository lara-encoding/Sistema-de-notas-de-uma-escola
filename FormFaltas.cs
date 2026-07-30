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
        private int idAluno;
        private int idProfessor;
        private string stringConexao;

        public FormFaltas(int idAluno, string nomeAluno, int idProfessor)
        {
            InitializeComponent();
            this.idAluno = idAluno;
            this.idProfessor = idProfessor;

            lblAluno.Text = "Aluno: " + nomeAluno;
        }

        private void FormFaltas_Load(object sender, EventArgs e)
        {

        }

        private void CarregarFaltas()
        {
            dgvFaltas.Rows.Clear();

            using (FbConnection conexao = new FbConnection(stringConexao))
            {
                conexao.Open();

                string query = @"SELECT ID_FALTA
                                        DATA_FALTA,
                                        QUANTIDADE,
                                        JUSTIFICADA,
                                        RECUPERADA
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
                            dgvFaltas.Rows.Add(
                                leitor["ID_FALTA"],
                                Convert.ToDateTime(leitor["DATA_FALTA"]).ToShortDateString(),
                                leitor["QUANTIDADE"],
                                Convert.ToBoolean(leitor["JUSTIFICADA"]) ? "Sim" : "Não",
                                Convert.ToBoolean(leitor["RECUPERADA"]) ? "Sim" : "Não");
                        }
                    }
                }
            }
        }
    }
}
