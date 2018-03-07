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
        int pageCounter;

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
            pageCounter = -1;
            WelcomeViewContent.Children.Clear();
            WelcomeViewContent.Children.Add(pageCounterRight);
        }

        StackLayout pageCounterRight
        {
            get
            {
                int _pageCounter = ++pageCounter;
                if (!(_pageCounter < pages.Count))
                {
                    _pageCounter = pageCounter = 0;
                }
                return pages[_pageCounter];
            }
        }

        StackLayout pageCounterLeft
        {
            get
            {
                int _pageCounter = --pageCounter;
                if ((_pageCounter <= -1))
                {
                    _pageCounter = pageCounter = 0;
                }
                return pages[_pageCounter];
            }
        }

        protected override void SetSVGCollection()
        {
        }

        public async void On_Welcome_Event(object sender, EventArgs e)
        {
            await _ViewController.Welcome();
        }

        void SwipeRight()
        {
            _ViewController.InputObject.IsSwipeDetected = true;
            WelcomeViewContent.Children.Clear();
            WelcomeViewContent.Children.Add(pageCounterRight);
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                _ViewController.InputObject.IsSwipeDetected = false;
                return false;
            });
        }

        void SwipeLeft()
        {
            _ViewController.InputObject.IsSwipeDetected = true;
            WelcomeViewContent.Children.Clear();
            WelcomeViewContent.Children.Add(pageCounterLeft);
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                _ViewController.InputObject.IsSwipeDetected = false;
                return false;
            });
        }


        async void Handle_Swipe(object sender, PanUpdatedEventArgs e)
        {
            if (e.TotalX < 0 && Math.Abs(e.TotalX) > Math.Abs(e.TotalY))
            {
                if (!_ViewController.InputObject.IsSwipeDetected)
                {
                    SwipeRight();
                }
            }
            else if (e.TotalX > 0 && e.TotalX > Math.Abs(e.TotalY))
            {
                if (!_ViewController.InputObject.IsSwipeDetected)
                {
                    SwipeLeft();
                }
            }
        }
    }
}


