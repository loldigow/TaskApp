using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Core
{
    public static class MetodosDeExtencao
    {
        public static string DescricaoDiaDaSemana(this DateTime dia)
        {
            var diaDaSemana = dia.DayOfWeek;
            switch(diaDaSemana)
            {
                case DayOfWeek.Sunday:
                    return "Domingo";

                case DayOfWeek.Monday:
                    return "Segunda-Feira";

                case DayOfWeek.Tuesday:
                    return "Terça-Feira";

                case DayOfWeek.Wednesday:
                    return "Quarta-Feira";

                case DayOfWeek.Thursday:
                    return "Quinta-Feira";

                case DayOfWeek.Friday:
                    return "Sexta-Feira";

                case DayOfWeek.Saturday:
                    return "Sábado";

                default:
                    return "Desconhecido";
            }
        }
    }
}
