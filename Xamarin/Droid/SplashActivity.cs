using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ResPublica.Droid
{
	[Activity(Label = "Respublica", NoHistory = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{

			base.OnCreate(bundle);

			var intent = new Intent(this, typeof(MainActivity));

			OverridePendingTransition(Resource.Animation.abc_fade_in, Resource.Animation.abc_fade_out);

			StartActivity(intent);
			Finish();
		}
	}
}