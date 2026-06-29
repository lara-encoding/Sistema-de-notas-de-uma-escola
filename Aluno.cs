using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Security.Policy;

namespace WinFormsApp1
{
    public class Aluno
    {
        public string Nome { get; set; }
        public string Turma { get; set; }
        public double NotaTeste { get; set; }
        public double NotaTrabalho { get; set; }
        public double NotaParticipacao { get; set; }
        public double MediaFinal { get; set; }
        public string Situacao { get; set; }
        public int Faltas { get; set; }
        public int Id { get; internal set; }

        public Aluno(string nome, string turma, double teste, double trabalho, double participacao)
        {
            Nome = nome;
            Turma = turma;
            NotaTeste = teste;
            NotaTrabalho = trabalho;
            NotaParticipacao = participacao;

            CalcularMediaESituacao();

        }

        public Aluno()
        {
        }

        public void CalcularMediaESituacao()
        {

            MediaFinal = Math.Round((NotaTeste * 0.5) + (NotaTrabalho * 0.3) + (NotaParticipacao * 0.2), 2);

            if (MediaFinal >= 10)
            {
                Situacao = "Aprovado(a)";
            }
            else if (MediaFinal >= 8)
            {
                Situacao = "Recuperação";
            }
            else
            {
                Situacao = "Reprovado";
            }
        }
    }
}
