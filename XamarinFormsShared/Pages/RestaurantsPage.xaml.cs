using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Acr.UserDialogs;
using TestDemo;

namespace XamarinFormsShared
{
	public partial class RestaurantsPage : ContentPage
	{
		public RestaurantsPage()
		{
			Title = "Restaurants";
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			fetchRestruants(null);
		}

		private void fetchRestruants(Tuple<double, double> location)
		{
			UserDialogs.Instance.ShowLoading("Fetching Restruants...", MaskType.Gradient);
			GPRestaurantsProvider.sharedProvider.getRestaurants(location, (restaurants, error) =>
			{
				UserDialogs.Instance.HideLoading();
				if (error == null)
				{
					listView.ItemsSource = restaurants;
				}
				else
				{
					UserDialogs.Instance.ShowError(error.Message, 2000);
				}
			});
		}
	}
}
