using System;
using Xamarin.Forms;
using HiRes.Base;
using HiRes.Implementation.ViewController;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.View
{
    public partial class WelcomeView : ProjectBaseContentPage<WelcomeViewController, WelcomeViewModel>
    {
        public WelcomeView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Welcome_Event(object sender, EventArgs e)
        {
            await _ViewController.Welcome();
        }
    }
}


