using System;
using Xamarin.Forms;
using HiRes.Base;
using HiRes.Implementation.ViewController;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.View
{
    public partial class WelcomeTwoView : ProjectBaseContentPage<WelcomeTwoViewController, WelcomeTwoViewModel>
    {
        public WelcomeTwoView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_WelcomeTwo_Event(object sender, EventArgs e)
        {
            await _ViewController.WelcomeTwo();
        }
    }
}


