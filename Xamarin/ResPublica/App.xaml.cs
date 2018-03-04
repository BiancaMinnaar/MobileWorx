using Acr.UserDialogs;
using HiRes.Implementation.Repository;
using HiRes.Implementation.View;
using HiRes.View.Controls;
using Xamarin.Forms;

namespace HiRes
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			var _MasterRepo = MasterRepository.MasterRepo;
			_MasterRepo.SetRootView(new NavigationPageGradientHeader(new LoginView())
			{
				LeftColor = Color.FromHex("#67B9A6"),
				RightColor = Color.FromHex("#1795a2")
			});

			//_MasterRepo.SetRootView(new NavigationPage(new TestHarnesView()));
			MainPage = _MasterRepo.GetRootView();



		}
	}
}
