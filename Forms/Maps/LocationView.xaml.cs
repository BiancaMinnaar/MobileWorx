using Plugin.ExternalMaps;
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
	public partial class LocationView : ContentPage
	{
		Position foodPosition = new Position(-26.052037, 28.022691);

		Position meetPos = new Position(-26.051109, 28.023601);
		Position officePos = new Position(-25.854917, 28.191140);

		Pin meetingRoomPin = null;
		Pin foodShackPin = null;


		public LocationView()
		{
			InitializeComponent();

			meetingRoomPin = new Pin { Type = PinType.Place, Position = meetPos, Label = "Meeting Room - This can be long text about the location", Address = "www.respublica.co.za" };
			foodShackPin = new Pin { Type = PinType.Place, Position = foodPosition, Label = "Mzansi Meals", Address = "www.MzansiMeals.co.za" };

			MyMap.Pins.Add(meetingRoomPin);
			MyMap.Pins.Add(foodShackPin);

			MyMap.MapType = MapType.Terrain;
			MyMap.MyLocationEnabled = true;
			MyMap.VerticalOptions = new LayoutOptions(LayoutAlignment.Fill, true);

			SetupMapEvents();

			//MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(meetPos, Distance.FromMeters(150)));
			MyMap.IsIndoorEnabled = true;
			MyMap.UiSettings.MyLocationButtonEnabled = true;
		}

		private void SetupMapEvents()
		{
			MyMap.MapClicked += (sender, e) =>
			{
				var lat = e.Point.Latitude.ToString("0.000");
				var lng = e.Point.Longitude.ToString("0.000");
				this.DisplayAlert("MapClicked", $"{lat}/{lng}", "CLOSE");
			};

			// Map Long clicked
			MyMap.MapLongClicked += (sender, e) =>
			{
				var lat = e.Point.Latitude.ToString("0.000");
				var lng = e.Point.Longitude.ToString("0.000");
				this.DisplayAlert("MapLongClicked", $"{lat}/{lng}", "CLOSE");
			};

		}

		private void btnMnzansiFoodShack_Clicked(object sender, EventArgs e)
		{
			//MyMap.MoveToRegion(new MapSpan(foodPosition, foodPosition.Latitude, foodPosition.Longitude));
			MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(foodPosition, Distance.FromMeters(125)), true);
		}

		private void btnRespublicaHeadOffice_Clicked(object sender, EventArgs e)
		{
			MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(meetPos, Distance.FromMeters(125)), true);
		}

		private async void btnNavTo_Clicked(object sender, EventArgs e)
		{
			var pin = MyMap.SelectedPin;

			if (pin != null)
			{
				var success = await CrossExternalMaps.Current.NavigateTo(pin.Label, pin.Position.Latitude, pin.Position.Longitude, Plugin.ExternalMaps.Abstractions.NavigationType.Walking);
			}
		}
	}
}