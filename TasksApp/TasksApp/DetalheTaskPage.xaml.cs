using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksApp.MVVM;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TasksApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalheTaskPage : ContentPage
	{
		public DetalheTaskPage (TaskViewModel task = null)
		{
			InitializeComponent ();
			BindingContext = new DetalheMVVM(task);
		}
	}
}