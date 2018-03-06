using System;
using HiRes.Base;
using HiRes.Implementation.ViewController;
using HiRes.Implementation.ViewModel;
using Xamarin.Forms;

namespace HiRes.Implementation.View
{
    public partial class LoginView : ProjectBaseContentPage<LoginViewController, LoginViewModel>
    {
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _ViewController.InputObject.UserName = "johan@publica.co.za";
            _ViewController.InputObject.Password = "Publica!~";
            BindingContext = _ViewController.InputObject;
        }

        protected override void SetSVGCollection()
        {
            //_ViewController.InputObject.SvgCollection.Add("DefaultButtonSvgPath", new SVGBindingProperty() { SVGFullName = "ResPublica.Images.CallCalendar.svg", Width = 30, Height = 30 });
            //_ViewController.InputObject.SvgCollection.Add("StartCallSvgPath", new SVGBindingProperty() { SVGFullName = "ResPublica.Images.CallStartTime.svg", Width = 13, Height = 18 });
            //_ViewController.InputObject.SvgCollection.Add("SplashSvgPath", new SVGBindingProperty() { SVGFullName = "ResPublica.Images.Splash.svg", Width = 200, Height = 200 });
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


