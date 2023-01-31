using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Classes
{
    public class Task
    {
        public int Codigo { get; set; }
        public string? DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Concluido { get; set; }
        public string? DetalheAtividade { get; set; }
    }
}
