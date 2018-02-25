using HiRes.App.Model;
using HiRes.App.ViewModel.Residences;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HiRes.App.View.Residences
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Residences_List_View : ContentPage
	{

		public Residences_List_ViewModel ViewModel { get; private set; }

		private Residence _SelectedItem = null;

		public Residences_List_View()
		{
			InitializeComponent();
			this.ViewModel = new Residences_List_ViewModel();

			lstResidences.ItemsSource = ViewModel.Residences;
		}

		public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var res = e.SelectedItem as Residence;
			if (res != null)
			{
				_SelectedItem = res;
				Navigation.PushAsync(new Residence_Detail_View(res));
			}
		}

	}
}
