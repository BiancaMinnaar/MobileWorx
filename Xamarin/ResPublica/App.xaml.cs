using Acr.UserDialogs;
using HiRes.Implementation.Repository;
using HiRes.Implementation.View;
using Xamarin.Forms;

namespace HiRes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var _MasterRepo = MasterRepository.MasterRepo;
            _MasterRepo.SetRootView(new NavigationPage(new LoginView()));
            //_MasterRepo.SetRootView(new NavigationPage(new TestHarnesView()));
            MainPage = _MasterRepo.GetRootView();

			

		}
	}
}
