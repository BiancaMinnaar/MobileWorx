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
	[Activity(Label = "ResPublica.Droid", NoHistory = true, Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class SplashActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{

			base.OnCreate(bundle);

			OverridePendingTransition(Resource.Animation.design_bottom_sheet_slide_in, Resource.Animation.design_bottom_sheet_slide_out);

			var intent = new Intent(this, typeof(MainActivity));

			OverridePendingTransition(Resource.Animation.design_bottom_sheet_slide_in, Resource.Animation.design_bottom_sheet_slide_out);

			StartActivity(intent);
			Finish();
		}
	}
}