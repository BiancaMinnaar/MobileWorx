using System;
using Xamarin.Forms;
using HiRes.Base;
using HiRes.Implementation.ViewController;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.View
{
    public partial class WelcomeThreeView : ProjectBaseContentPage<WelcomeThreeViewController, WelcomeThreeViewModel>
    {
        public WelcomeThreeView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_WelcomeThree_Event(object sender, EventArgs e)
        {
            await _ViewController.WelcomeThree();
        }
    }
}


