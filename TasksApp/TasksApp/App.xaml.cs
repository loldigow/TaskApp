using Core.Dominio;
using Core.Dominio.Servicos;
using Core.Dominio.Servicos.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoMapper;
using Core.Classes;
using Core.ViewModel;

namespace TasksApp
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<IMapper>(ConfigureAutoMapper());
            DependencyService.RegisterSingleton<ITaskRepository>(new TaskRepositoryMock());
            DependencyService.RegisterSingleton<IServiceTasks>(new ServicoTask());
            ConfigureAutoMapper();
            InitializeComponent();
            MainPage = new NavigationPage(new Inicio());
        }

        private static IMapper ConfigureAutoMapper()
        {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<Task, TaskViewModel>();
                cfg.CreateMap<TaskViewModel, Task>();
            });
            return configuration.CreateMapper();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
