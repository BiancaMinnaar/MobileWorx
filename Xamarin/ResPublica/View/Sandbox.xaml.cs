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
using CarouselView.FormsPlugin.Abstractions;

namespace ResPublica.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Sandbox : ContentPage
	{
		OnboardingPageVm _onBoardingVm;

		public Sandbox()
		{
			Title = "Carousel View";
			_onBoardingVm = new OnboardingPageVm();
			BindingContext = _onBoardingVm;

			CarouselViewControl carouselView = new CarouselViewControl
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var onBoardingDataTemplate = new DataTemplate(CreateViewTemplate);
			carouselView.ItemTemplate = onBoardingDataTemplate;

			Grid mainContainer = new Grid { };

			mainContainer.Children.Add(carouselView, 0, 0);

			Content = mainContainer;

			#region Bindings

			carouselView.SetBinding(CarouselViewControl.ItemsSourceProperty, nameof(_onBoardingVm.BoardingObjectsList));
			carouselView.SetBinding(CarouselViewControl.PositionProperty, nameof(_onBoardingVm.Position), BindingMode.TwoWay);

			#endregion
		}

		/// <summary>
		/// Creates the view template for the OnBoarding Views.
		/// </summary>
		/// <returns>The custom Xamarin.Forms.StackLayout, OnboardingTemplateView.</returns>
		private StackLayout CreateViewTemplate()
		{
			var view = new OnboardingTemplateView();
			view.BindingContext = _onBoardingVm.BoardingObjectsList;
			view.BackGroundProperty.SetBinding(BackgroundColorProperty, nameof(OnboardingModel.Color));
			return view;
		}
	}

	public class OnboardingTemplateView : StackLayout
	{
		public BoxView BackGroundProperty;

		public OnboardingTemplateView()
		{
			BackGroundProperty = new BoxView
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Children.Add(BackGroundProperty);
		}
	}
	public class OnboardingModel
	{
		public Color Color { get; set; }
	}

	public class OnboardingPageVm : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<OnboardingModel> BoardingObjectsList { get; set; }
		public int Position { get; set; }

		public OnboardingPageVm()
		{
			BoardingObjectsList = new ObservableCollection<OnboardingModel>
		{
			new OnboardingModel
			{
				Color = Color.Red
			},
			new OnboardingModel
			{
				Color = Color.Blue
			},
			new OnboardingModel
			{
				Color = Color.Green
			},
			new OnboardingModel
			{
				Color = Color.Yellow
			}
		};
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
