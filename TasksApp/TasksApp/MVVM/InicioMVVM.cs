using Core;
using Core.Dominio.Servicos;
using Core.Dominio.Servicos.Interfaces;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TasksApp.MVVM
{
    internal class InicioMVVM : ViewModelBase
    {
        private IServiceTasks _serviceTask = DependencyService.Resolve<IServiceTasks>();
        public InicioMVVM()
        {
            _diaAgenda = DateTime.Now;
            _tasks = _serviceTask.ObtenhaTasksDoPeriodo(DiaAgenda, DiaAgenda);
        }
        public DateTime DiaAgenda
        {
            get
            {
                return _diaAgenda;
            }
            set
            {
                _diaAgenda = value;
                _tasks = _serviceTask.ObtenhaTasksDoPeriodo(DiaAgenda, DiaAgenda);
                _culturaLocal = new CultureInfo("pt-BR");
                OnPropertyChanged(nameof(DiaDoMes));
                OnPropertyChanged(nameof(ListaTarefas));
                OnPropertyChanged(nameof(DescricaoMes));
                OnPropertyChanged(nameof(DescricaoDiaDaSemana));
                OnPropertyChanged(nameof(DescricaoQuantidadeDeAtividades));
            }
        }
        private CultureInfo _culturaLocal;
        private DateTime _diaAgenda;
        private List<TaskViewModel> _tasks;


        private bool _dateTimePickerFocus;
        public bool DateTimePickerFocus
        {
            get { return _dateTimePickerFocus; }
            set
            {
                _dateTimePickerFocus = value;
                OnPropertyChanged(nameof(DateTimePickerFocus));
            }
        }

        private bool _dateTimeVisible;
        public bool DateTimeVisible
        {
            get { return _dateTimeVisible; }
            set
            {
                _dateTimeVisible = value;
                OnPropertyChanged(nameof(DateTimeVisible));
            }
        }
        public Command AbraDateTimePickerCommand => new Command<DatePicker>(async (e) => AbraDateTimePicker(e));
        private void AbraDateTimePicker(DatePicker e)
        {
            if (e != null)
            {
                if (e is DatePicker datePicker)
                {
                    Device.BeginInvokeOnMainThread(() => { datePicker.Focus(); });
                }
            }
            DateTimeVisible = true;
        }

        public Command AbraTaskCommand => new Command<TaskViewModel>(async (e) => AbraTask(e));
        private void AbraTask(TaskViewModel e = null)
        {
            Device.BeginInvokeOnMainThread(() => {
                Application.Current.MainPage.Navigation.PushAsync(new DetalheTaskPage(e));
            });
        }

        public Command AbraTaskButtonCommand => new Command(execute: () => { AbraTask(); });


        public int DiaDoMes => _diaAgenda.Day;
        public string DescricaoMes => _diaAgenda.ToString("MMMM", _culturaLocal);
        public string DescricaoDiaDaSemana => _diaAgenda.DescricaoDiaDaSemana();
        public string DescricaoQuantidadeDeAtividades => _tasks.Count() > 0 ?
            $"{_tasks.Count()} Atividade{(_tasks.Count() > 1 ? "s" : "")}" : "Nenhuma atividade pra hoje";
        public bool NaoTemNenhumaAtividade => _tasks.Count() == 0;
        public List<TaskViewModel> ListaTarefas { get => _tasks; }
    }
}
