using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using ResPublica.Droid.CustomRenderers;
using ResPublica.View.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HREntry), typeof(HREntryRenderer))]
namespace ResPublica.Droid.CustomRenderers
{
	public class HREntryRenderer : EntryRenderer
	{
		public HREntryRenderer(Context context) : base(context)
		{
		}

		public HREntryRenderer()
		{

		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				var background = ContextCompat.GetDrawable(Context, Resource.Drawable.RoundedCornerEntry);

				Control.Background = background;
				Control.SetPadding(10, 10, 10, 3);
			}
		}
	}

}