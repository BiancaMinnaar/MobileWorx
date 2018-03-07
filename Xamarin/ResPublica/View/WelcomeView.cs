using System;
using Xamarin.Forms;
using HiRes.Base;
using HiRes.Implementation.ViewController;
using HiRes.Implementation.ViewModel;
using System.Collections.Generic;

namespace HiRes.Implementation.View
{
    public partial class WelcomeView : ProjectBaseContentPage<WelcomeViewController, WelcomeViewModel>
    {
        List<StackLayout> pages;

        public WelcomeView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
            pages = new List<StackLayout>()
            {
                new WelcomeOneView(),
                new WelcomeTwoView(),
                new WelcomeThreeView()
            };
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Welcome_Event(object sender, EventArgs e)
        {
            await _ViewController.Welcome();
        }

        async void Handle_Swipe(object sender, PanUpdatedEventArgs e)
        {
            if (e.TotalX < 0 && Math.Abs(e.TotalX) > Math.Abs(e.TotalY))
            {
                
            }
            else if (e.TotalX > 0 && e.TotalX > Math.Abs(e.TotalY))
            {
                
            }
        }
    }
}


