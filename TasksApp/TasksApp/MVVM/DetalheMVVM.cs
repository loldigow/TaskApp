using Core.Dominio.Servicos.Interfaces;
using Core.ViewModel;
using System;
using Xamarin.Forms;

namespace TasksApp.MVVM
{
    class DetalheMVVM : ViewModelBase
    {
        private IServiceTasks _serviceTask = DependencyService.Resolve<IServiceTasks>();
        private DateTime _dataInicio;
        private TimeSpan _horaInicio;
        private DateTime _dataFim;
        private TimeSpan _horaFim;
        private string _descricaoTask;
        private string _detalheAtividade;
        private bool _novaAtividade;
        private TaskViewModel _task;

        public Command ComandoFechar => new Command(execute: () => { Feche(); });
        public Command ComandoAlterar => new Command(execute: () => { Altere(); });
        public Command ComandoExcluir => new Command(execute: () => { Exclua(); });

        private async void Exclua()
        {
            _serviceTask.ExcluaTask(_task.Codigo);
            await Application.Current.MainPage.DisplayAlert("Sucesso", "Apagado com sucesso", "OK");
            Feche();
        }

        private async void Altere()
        {
            _serviceTask.GuardeNoBanco(MonteAtividade());
            await Application.Current.MainPage.DisplayAlert("Sucesso", "Salvo com sucesso", "OK");
            Feche();
        }

        private TaskViewModel MonteAtividade()
        {
            return new TaskViewModel()
            {
                Concluido = false,
                DataFim = _dataFim,
                DetalheAtividade = _detalheAtividade,
                DataInicio = _dataInicio,
                DescricaoAtividade = _descricaoTask
            };
        }

        private void Feche()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public DateTime DataInicio
        {
            get { return _dataInicio; }
            set
            {
                _dataInicio = value;
                OnPropertyChanged(nameof(DataInicio));
            }
        }
        public DateTime DataFim
        {
            get { return _dataFim; }
            set
            {
                _dataFim = value;
                OnPropertyChanged(nameof(DataFim));
            }
        }
        public TimeSpan HoraInicio
        {
            get { return _horaInicio; }
            set
            {
                _horaInicio = value;
                OnPropertyChanged(nameof(HoraInicio));
            }
        }
        public TimeSpan HoraFim
        {
            get { return _horaFim; }
            set
            {
                _horaFim = value;
                OnPropertyChanged(nameof(HoraFim));
            }
        }

        public string DescricaoTask => _descricaoTask;
        public string NotasAtividade => _detalheAtividade;
        public string DescricaoNovaAtividade => _novaAtividade ? "Criar Atividade" : "Visualizar Atividade";
        public string TextoBotaoSalvar => _novaAtividade ? "Salvar" : _task.Concluido ? "Reabrir" : "Finalizar";
        public DetalheMVVM(TaskViewModel task)
        {
            if (task != null)
            {
                _dataInicio = task.DataInicio;
                _dataFim = task.DataFim;
                _horaInicio = task.DataInicio.TimeOfDay;
                _horaFim = task.DataFim.TimeOfDay;
                _descricaoTask = task.DescricaoAtividade;
            }
            else
            {
                _novaAtividade = true;
                _dataInicio = DateTime.Now;
                _dataFim = DateTime.Now;
                _horaInicio = DateTime.Now.TimeOfDay;
                _horaFim = DateTime.Now.TimeOfDay.Add(new TimeSpan(1, 0, 0));
            }
            _task = task;
        }
    }
}
