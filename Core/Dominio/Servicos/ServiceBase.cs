using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Core.Dominio.Servicos
{
    public class ServiceBase
    {
        protected IMapper Mapper = DependencyService.Resolve<IMapper>();
        public ServiceBase() { 
        }
    }
}
