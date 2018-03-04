using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using FFImageLoading.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections;

namespace HiRes.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sandbox : CarouselPage
	{
		public Sandbox()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{

		}
	}

}

