using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Acr.UserDialogs;
using TestDemo;
using System.Threading;

namespace XamarinFormsShared
{
	public partial class RestaurantsPage : ContentPage
	{
		public RestaurantsPage()
		{
			Title = "Restaurants";
			InitializeComponent();
			showSettings();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			fetchRestruants(Tuple.Create(18.534095, 73.877834));
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

		private void showSettings() {
			ToolbarItems.Add(new ToolbarItem("Logout", "power.png",() => {
				UserDialogs.Instance.Toast("You are logged out successfully");
				DBManager.sharedManager.deleteCurrentSetting();;
				AppRepository.sharedRepository.deleteUserInfo();
				App.Current.MainPage = new LoginPage();	
			}));
		}

	}
}
