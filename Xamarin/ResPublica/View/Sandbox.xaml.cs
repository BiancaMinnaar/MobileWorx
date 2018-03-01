using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using FFImageLoading.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ResPublica.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sandbox : ContentPage
	{
		MainViewModel _vm;

		public Sandbox()
		{
			InitializeComponent();
			BindingContext = _vm = new MainViewModel();
		}

		void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
		{
			Debug.WriteLine("Position " + e.NewValue + " selected.");
		}

		void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
		{
			Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
			Debug.WriteLine("Direction = " + e.Direction);
		}
	}

}

public class MainViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;

	public MainViewModel()
	{
		MyItemsSource = new ObservableCollection<View>()
			{
				new CachedImage() { Source = "c1.jpg", DownsampleToViewSize = true, Aspect = Aspect.AspectFill },
				new CachedImage() { Source = "c2.jpg", DownsampleToViewSize = true, Aspect = Aspect.AspectFill },
				new CachedImage() { Source = "c3.jpg", DownsampleToViewSize = true, Aspect = Aspect.AspectFill }
			};

		MyCommand = new Command(() =>
		{
			Debug.WriteLine("Position selected.");
		});
	}

	ObservableCollection<View> _myItemsSource;
	public ObservableCollection<View> MyItemsSource
	{
		set
		{
			_myItemsSource = value;
			OnPropertyChanged("MyItemsSource");
		}
		get
		{
			return _myItemsSource;
		}
	}

	public Command MyCommand { protected set; get; }

	protected virtual void OnPropertyChanged(string propertyName)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
