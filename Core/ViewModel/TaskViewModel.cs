using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Core.ViewModel
{
    public class TaskViewModel
    {
        public int Codigo { get; set; }
        public string? DescricaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Concluido { get; set; }
        public string DetalheAtividade { get; set; }
        public Color BackGround => Color.FromArgb(100, 255, 255, 255);
        public string SourceCheckBox => Concluido ? "check.PNG" : "Uncheck.PNG";
        public string DataInicioEFimDescricao => $"De {DataInicio:HH:mm:} as {DataFim::HH:mm:}";

    }
}
