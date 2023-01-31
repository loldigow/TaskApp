using Core.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Core.Dominio
{
    public class TaskRepositoryMock : ITaskRepository
    {
        private List<Task> _tasks = new List<Task>();
        public TaskRepositoryMock()
        {
            _tasks.Add(new Task()
            {
                Codigo = 1,
                DescricaoAtividade = $"atividade dia 1",
                Concluido = true,
                DataInicio = DateTime.Parse("01/01/2023  05:30:00", new CultureInfo("PT-br")),
                DataFim = DateTime.Parse("01/01/2023   06:00:00", new CultureInfo("PT-br")),
                DetalheAtividade = "Fazer oração matinal"
            });
            _tasks.Add(new Task()
            {
                Codigo = 1,
                DescricaoAtividade = $"teste atividade",
                Concluido = true,
                DataInicio = DateTime.Parse("01/02/2023  05:30:00", new CultureInfo("PT-br")),
                DataFim = DateTime.Parse("01/02/2023   06:00:00", new CultureInfo("PT-br")),
                DetalheAtividade = "Fazer oração matinal"
            });
            _tasks.Add(new Task()
            {
                Codigo = 2,
                DescricaoAtividade = "Go work",
                Concluido = true,
                DataInicio = DateTime.Parse("02/01/2023 08:00:00", new CultureInfo("PT-br")),
                DataFim = DateTime.Parse("02/01/2023 09:00:00", new CultureInfo("PT-br")),
                DetalheAtividade = "Arrumar para ir trabalhar"
            });
            _tasks.Add(new Task()
            {

                Codigo = 3,
                DescricaoAtividade = "Atividade 1 do dia",
                Concluido = true,
                DataInicio = DateTime.Parse("01/01/2023 10:00:00", new CultureInfo("PT-br")),
                DataFim = DateTime.Parse("01/01/2023 10:00:00", new CultureInfo("PT-br")),
                DetalheAtividade = "Foco NPS"
            });
            _tasks.Add(new Task()
            {
                Codigo = 4,
                DescricaoAtividade = "intervalo",
                Concluido = false,
                DataInicio = DateTime.Parse("03/01/2023 12:00:00", new CultureInfo("PT-br")),
                DataFim = DateTime.Parse("03/01/2023 12:00:00", new CultureInfo("PT-br")),
                DetalheAtividade = "Almoço"
            });
        }
        public void Altere(Task task)
        {
            _tasks.Remove(task);
            _tasks.Add(task);
        }

        public void Exclua(Task task)
        {
            _tasks.Remove(task);
        }

        public int GereCodigoAtividade()
        {
            return _tasks.Max(x => x.Codigo) + 1;
        }

        public Task ObtenhaPorCodigo(int codigo)
        {
            return _tasks.FirstOrDefault(x => x.Codigo == codigo);
        }

        public List<Task> ObtenhaTasksDoDia(DateTime dia)
        {
            return _tasks.Where(x => x.DataInicio <= dia && dia <= x.DataFim).ToList();
        }

        public void SalveNoBanco(Task task)
        {
            _tasks.Add(task);
        }
    }
}
