using Android.Util;
using HiRes.App.Services.CardIO;
using HiRes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HiRes.App.View.Payments
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ManualCaptureCreditCardView : ContentPage
	{
		ICardService cardCaptureService = null;
		VM vm = new VM();
		public ManualCaptureCreditCardView()
		{
			InitializeComponent();
			BindingContext = vm;
			cardCaptureService = DependencyService.Get<ICardService>();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			try
			{
				var result = await cardCaptureService.Run();

				vm.CardCCV = result.CCV;
				vm.CardNumber = result.RedactedCardNumber;
				vm.CardType = result.CardType;
				vm.ExpiryMonth = result.ExpiryMonth;
				vm.ExpiryYear = result.ExpiryYear;
				vm.Name = result.Name;

			}
			catch (Exception ex)
			{
				// Just ignore exceptions just don't update the properties if we get exception from the Intent
				Log.Error("Card Capture Service Error : ", ex.Message);

			}
		}

		public class VM : BindableBase
		{
			string _cardNumber = string.Empty;
			int _expiryMonth;
			int _expiryYear;
			string _name = string.Empty;
			string _cardCCV = string.Empty;
			string _cardType = string.Empty;

			public VM()
			{
			}

			public string CardNumber { get { return _cardNumber; } set { SetProperty(ref _cardNumber, value); } }
			public int ExpiryMonth { get { return _expiryMonth; } set { SetProperty(ref _expiryMonth, value); } }
			public int ExpiryYear { get { return _expiryYear; } set { SetProperty(ref _expiryYear, value); } }
			public string Name { get { return _name; } set { SetProperty(ref _name, value); } }
			public string CardCCV { get { return _cardCCV; } set { SetProperty(ref _cardCCV, value); } }
			public string CardType { get { return _cardType; } set { SetProperty(ref _cardType, value); } }
		}
	}
}