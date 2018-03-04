using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using HiRes.View.Controls;
using ResPublica.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HREntry), typeof(HREntryRenderer))]
namespace ResPublica.Droid.CustomRenderers
{
	public class HREntryRenderer : EntryRenderer
	{
		HREntry element;
		public HREntryRenderer(Context context) : base(context)
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || e.NewElement == null)
				return;


			element = (HREntry)this.Element;

			var editText = this.Control;
			if (!string.IsNullOrEmpty(element.Image))
			{
				switch (element.ImageAlignment)
				{
					case ImageAlignment.Left:
						editText.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(element.Image), null, null, null);
						break;
					case ImageAlignment.Right:
						editText.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);
						break;
				}
			}
			editText.CompoundDrawablePadding = 25;


			if (Control != null)
			{
				var background = ContextCompat.GetDrawable(Context, Resource.Drawable.RoundedCornerEntry);
				GradientDrawable gd = new GradientDrawable();
				//if (Control.IsFocused)
				//	gd.SetColor(new Android.Graphics.Color(255, 255, 255));
				//else
				//	gd.SetColor(new Android.Graphics.Color(242, 242, 242));

				//gd.SetCornerRadius(25);

				//gd.SetStroke(2, new Android.Graphics.Color(204, 204, 204));
				//Control.Background = gd;

				Control.Background = background;
				//Control.SetPaddingRelative(10, 10, 10, 10);
			}
		}

		protected override void OnFocusChanged(bool gainFocus, [GeneratedEnum] FocusSearchDirection direction, Rect previouslyFocusedRect)
		{
			base.OnFocusChanged(gainFocus, direction, previouslyFocusedRect);
		}

		private BitmapDrawable GetDrawable(string imageEntryImage)
		{
			var bitmap = Resources.GetBitmap(imageEntryImage);
			//int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
			//var drawable = ContextCompat.GetDrawable(this.Context, resID);
			//var bitmap = ((BitmapDrawable)drawable).Bitmap;

			return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, element.ImageWidth * 2, element.ImageHeight * 2, true));
		}
	}

}