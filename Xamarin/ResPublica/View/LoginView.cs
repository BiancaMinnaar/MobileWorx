using System;
using ResPublica.Base;
using ResPublica.Implementation.ViewController;
using ResPublica.Implementation.ViewModel;
using Xamarin.Forms;

namespace ResPublica.Implementation.View
{
    public partial class LoginView : ProjectBaseContentPage<LoginViewController, LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
            _ViewController.InputObject.SvgCollection.Add("DefaultButtonSvgPath", new SVGBindingProperty() { SVGFullName = "ResPublica.Images.Button_Default.svg", Width = 30, Height = 30 });
        }

        public async void On_Login_Event(object sender, EventArgs e)
        {
            await _ViewController.Login();
        }

        public void RegisterView(object sender, EventArgs e)
        {
            _ViewController.RegisterView();
        }
    }
}


