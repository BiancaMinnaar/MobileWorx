using HiRes.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HiRes.App.View.Residences
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Residence_Detail_View : ContentPage
	{

		public Residence ViewModel { get; private set; }

		public Residence_Detail_View(Residence viewModel)
		{
			InitializeComponent();
			this.ViewModel = viewModel;

			BindingContext = viewModel;

			// TODO: remove temp code for debugging
			////var assembly = typeof(Residence_Detail_View).GetTypeInfo().Assembly;
			////foreach (var res in assembly.GetManifestResourceNames())
			////{
			////	System.Diagnostics.Debug.WriteLine("found resource: " + res);
			////}

			// todo:
			// hide visual elements based on availablity
			// eg: don't show loungeinfo if there is none

			AddFacilities();
		}

		private void AddFacilities()
		{
			AddFacilityIfApplicable(_ => _.LoungeInfo, "icon-facilities-lounge");
			AddFacilityIfApplicable(_ => _.SecurityInfo, "icon-facilities-biometric");
			AddFacilityIfApplicable(_ => _.RulesInfo, "icon-facilities-printing");
			AddFacilityIfApplicable(_ => _.WaterAndLightsInfo, "icon-facilities-water");
			AddFacilityIfApplicable(_ => _.SocialInfo, "icon-facilities-socials");

			AddFacilityIfApplicable(_ => _.SleepingArrangementInfo, "icon-facilities-bunk-beds");
			AddFacilityIfApplicable(_ => _.BathroomInfo, "icon-facilities-bathroom");
			AddFacilityIfApplicable(_ => _.KitchenInfo, "icon-facilities-kitchen");
			AddFacilityIfApplicable(_ => _.BedroomInfo, "icon-facilities-bedroom");
			AddFacilityIfApplicable(_ => _.CleaningInfo, "icon-facilities-cleaning");

			AddFacilityIfApplicable(_ => _.CanteenInfo, "icon-facilities-canteen");
			AddFacilityIfApplicable(_ => _.WifiInfo, "icon-facilities-wifi");
			AddFacilityIfApplicable(_ => _.ComputerLabInfo, "icon-facilities-pc-lab");
			AddFacilityIfApplicable(_ => _.TvInfo, "icon-facilities-tv");
			AddFacilityIfApplicable(_ => _.StudyInfo, "icon-facilities-study");

			AddFacilityIfApplicable(_ => _.GamesRoomInfo, "icon-facilities-games-room");
			AddFacilityIfApplicable(_ => _.GymInfo, "icon-facilities-gym");
			AddFacilityIfApplicable(_ => _.SwimmingInfo, "icon-facilities-swimming");
			AddFacilityIfApplicable(_ => _.ShopInfo, "icon-facilities-shop");
			AddFacilityIfApplicable(_ => _.ParkingInfo, "icon-facilities-parking");

			AddFacilityIfApplicable(_ => _.BraaiInfo, "icon-facilities-braai");

		}

		private void AddFacilityIfApplicable(Func<Residence, string> getter, string imageResource)
		{
			try
			{
				var value = getter(this.ViewModel);
				if (false == string.IsNullOrEmpty(value))
				{
					var layout = new StackLayout() { Orientation = StackOrientation.Horizontal };
					layout.Children.Add(
						new Image()
						{
							Source = ImageSource.FromResource(imageResource),
							//HorizontalOptions = LayoutOptions.Start,
							//VerticalOptions = LayoutOptions.Start,
						});
					layout.Children.Add(
						new Label()
						{
							Text = value,
							//HorizontalOptions = LayoutOptions.StartAndExpand,
							//VerticalOptions = LayoutOptions.StartAndExpand,
						});
					KeyInfoStack.Children.Add(layout);
				}
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.WriteLine("wtf: {0}", exc);
			}
		}
	}
}