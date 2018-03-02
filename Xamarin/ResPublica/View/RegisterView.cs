using System;
using Xamarin.Forms;
using HiRes.Base;
using HiRes.Implementation.ViewController;
using HiRes.Implementation.ViewModel;

namespace HiRes.Implementation.View
{
    public partial class RegisterView : ProjectBaseContentPage<RegisterViewController, RegisterViewModel>
    {
        public RegisterView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Register_Event(object sender, EventArgs e)
        {
            await _ViewController.Register();
        }
    }
}


