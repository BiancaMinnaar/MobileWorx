using System;
using Xamarin.Forms;
using ResPublica.Base;
using ResPublica.Implementation.ViewController;
using ResPublica.Implementation.ViewModel;

namespace ResPublica.Implementation.View
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


