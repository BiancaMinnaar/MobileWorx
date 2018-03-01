using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ResPublica.View.Controls
{
	public class HREntry : Entry
	{
		public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string), typeof(HREntry), string.Empty);

		public static readonly BindableProperty ImageHeightProperty =	 BindableProperty.Create(nameof(ImageHeight), typeof(int), typeof(HREntry), 40);

		public static readonly BindableProperty ImageWidthProperty = BindableProperty.Create(nameof(ImageWidth), typeof(int), typeof(HREntry), 40);

		public static readonly BindableProperty ImageAlignmentProperty = BindableProperty.Create(nameof(ImageAlignment), typeof(ImageAlignment), typeof(HREntry), ImageAlignment.Left);

		public int ImageWidth
		{
			get { return (int)GetValue(ImageWidthProperty); }
			set { SetValue(ImageWidthProperty, value); }
		}

		public int ImageHeight
		{
			get { return (int)GetValue(ImageHeightProperty); }
			set { SetValue(ImageHeightProperty, value); }
		}

		public string Image
		{
			get { return (string)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public ImageAlignment ImageAlignment
		{
			get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
			set { SetValue(ImageAlignmentProperty, value); }
		}
	}

	public enum ImageAlignment
	{
		Left,
		Right
	}
}
