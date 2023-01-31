using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Dominio.Servicos.Interfaces
{
    public interface IServiceTasks
    {
        public List<TaskViewModel> ObtenhaTasksDoPeriodo(DateTime Inicio, DateTime fim);
        public TaskViewModel ObtenhaTaskPorCodigo(int Codigo);
        void GuardeNoBanco(TaskViewModel taskViewModel);
        void ExcluaTask(int codigo);
    }
}
