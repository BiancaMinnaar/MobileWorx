using System;

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
using Acr.UserDialogs;
using HiRes;
using CarouselView.FormsPlugin.Android;

namespace ResPublica.Droid
{
	[Activity(Label = "Respublica", Icon = "@drawable/icon", Theme = "@style/MyTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			CarouselViewRenderer.Init();
			UserDialogs.Init(this);
			Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;

			global::Xamarin.Forms.Forms.Init(this, bundle);
			SvgImageViewRenderer.Init();

			CachedImageRenderer.Init(true);
			var ignore = typeof(SvgCachedImage);

			LoadApplication(new App());
		}
	}
}
