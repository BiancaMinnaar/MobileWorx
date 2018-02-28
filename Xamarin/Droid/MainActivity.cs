﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using TwinTechsForms.NControl.Android;
using FFImageLoading.Svg.Forms;
using FFImageLoading.Forms.Droid;

namespace ResPublica.Droid
{
    [Activity(Label = "ResPublica.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            SvgImageViewRenderer.Init();

            CachedImageRenderer.Init(true);
            var ignore = typeof(SvgCachedImage);

            LoadApplication(new App());
        }
    }
}
