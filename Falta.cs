using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Falta
    {
        public int Id { get; set; }
        public DateTime DataFalta { get; set; }
        public int Quantidade { get; set; }
        public bool Justificada { get; set; }
        public bool Recuperada { get; set; }
        public string? Justificativa { get; set; }
        public string? Documento { get; set; }
        public string? MetodoRecuperacao { get; set; }
        public string JustificadaTexto => Justificada ? "Sim" : "Não";
        public string RecuperadaTexto => Recuperada ? "Sim" : "Não";
        public string InjustificadaTexto => Justificada ? "Não" : "Sim";

    }
}
