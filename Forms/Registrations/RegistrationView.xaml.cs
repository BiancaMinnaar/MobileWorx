using HiRes.App.ViewModel.Registrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HiRes.App.View.Registrations
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationView : ContentPage
	{
		public RegistrationView()
		{
			InitializeComponent();
			BindingContext = new RegistrationViewModel();
		}
	}
}