using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace HiRes.App.View.Maps
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapsView : ContentPage
	{

		public MapsView()
		{
			InitializeComponent();

			

			meetingRoomPin = new Pin { Type = PinType.Place, Position = meetPos, Label = "Respublica Meeting Room", Address = "www.ResPublica.co.za" };
			foodShackPin = new Pin { Type = PinType.Place, Position = foodPosition, Label = "Mzansi Meals", Address = "www.MzansiMeals.co.za" };

			MyMap.Pins.Add(meetingRoomPin);
			MyMap.Pins.Add(foodShackPin);

			MyMap.MapType = MapType.Terrain;
			MyMap.MyLocationEnabled = true;
			MyMap.VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true);

			SetupMapEvents();

			MyMap.MoveToRegion(new MapSpan(meetPos, meetPos.Latitude, meetPos.Longitude));
			MyMap.IsIndoorEnabled = true;
			MyMap.UiSettings.MyLocationButtonEnabled = true;
			//MyMap.VisibleRegion = new MapSpan(meetPos, meetPos.Latitude, meetPos.Longitude);
		}

	}
}