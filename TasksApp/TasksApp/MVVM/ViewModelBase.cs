using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TasksApp.MVVM
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _estaOcupado = false;
        public event EventHandler MudandoOcupacao;

        public bool EstaOcupado
        {
            get { return _estaOcupado; }
            set
            {
                if (_estaOcupado != value)
                {
                    _estaOcupado = value;

                    OnPropertyChanged(nameof(EstaOcupado));
                    OnIsBusyChanged();
                }
            }
        }

        protected virtual void OnIsBusyChanged()
        {
            var ev = MudandoOcupacao;
            if (ev != null)
            {
                ev(this, EventArgs.Empty);
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            var ev = PropertyChanged;
            if (ev != null)
            {
                ev(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
