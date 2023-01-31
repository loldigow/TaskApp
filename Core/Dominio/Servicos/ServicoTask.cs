using Core.Dominio.Servicos.Interfaces;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Core.Dominio.Servicos
{
    public class ServicoTask : ServiceBase, IServiceTasks
    {
        private readonly ITaskRepository _taskRepository = DependencyService.Resolve<ITaskRepository>();
        public void ExcluaTask(int codigo)
        {
            var task = _taskRepository.ObtenhaPorCodigo(codigo);
            _taskRepository.Exclua(task);
        }

        public void GuardeNoBanco(TaskViewModel taskViewModel)
        {
            var task = _taskRepository.ObtenhaPorCodigo(taskViewModel.Codigo);
            if (task == null)
            {
                var codigoTask = _taskRepository.GereCodigoAtividade();
                taskViewModel.Codigo = codigoTask;
                _taskRepository.SalveNoBanco(taskViewModel);
                return;
            }
            _taskRepository.Altere(task);
        }

        public TaskViewModel ObtenhaTaskPorCodigo(int Codigo)
        {
            return Mapper.Map<TaskViewModel>(_taskRepository.ObtenhaPorCodigo(Codigo));
        }

        public List<TaskViewModel> ObtenhaTasksDoPeriodo(DateTime inicio, DateTime fim)

        {
            var teste = _taskRepository.ObtenhaTasksDoDia(inicio);
            return Mapper.Map<List<TaskViewModel>>(teste);
        }
    }
}
