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
        public int Id { get; internal set; }
        public int FaltasInjustificadas { get; set; }
        public int FaltasJustificadas { get; set; }
        public int FaltasRecuperadas { get; set; }

        public Aluno(int id, string nome, string turma, double teste, double trabalho, double participacao, int faltasInjustificadas, int faltasJustificadas, int faltasRecuperadas)
        {
            Id = id;
            Nome = nome;
            Turma = turma;
            NotaTeste = teste;
            NotaTrabalho = trabalho;
            NotaParticipacao = participacao;
            FaltasInjustificadas = faltasInjustificadas;
            FaltasJustificadas = faltasJustificadas;
            FaltasRecuperadas = faltasRecuperadas;

            CalcularMediaESituacao();
        }

        public Aluno()
        {
        }

        public void CalcularMediaESituacao()
        {
            MediaFinal = Math.Round((NotaTeste * 0.5) + (NotaTrabalho * 0.3) + (NotaParticipacao * 0.2), 2);

            int faltasEfetivas = FaltasInjustificadas - FaltasRecuperadas;


            if (FaltasInjustificadas > 10)
            {
                if (faltasEfetivas <= 10 && FaltasJustificadas > 0 && FaltasRecuperadas > 0)
                {
                    if (MediaFinal >= 10) Situacao = "Aprovado(a)";
                    else if (MediaFinal >= 8) Situacao = "Recuperação";
                    else Situacao = "Reprovado(a)";
                } else
                {
                    Situacao = "Reprovado(a) por Faltas";
                }
            } else
            {
                if (MediaFinal >= 10) Situacao = "Aprovado(a)";
                else if (MediaFinal >= 8) Situacao = "Recuperação";
                else Situacao = "Reprovado(a)";
            }
        }
    }
}
