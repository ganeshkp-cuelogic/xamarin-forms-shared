
using System;
using System.Collections.Generic;
using System.Diagnostics;
using TestDemo;
using Xamarin.Forms;
using Acr.UserDialogs;

namespace XamarinFormsShared
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//LoginCommand = new Xamarin.Forms.Command(onClickOfLogin);
			btnLogin.Clicked += onClickOfLogin;
			Debug.WriteLine("---------- OnAppear called!");

			entryEmail.Text = "ganesh.nist@gmail.com";
			entryPassword.Text = "adminasdf";
		}

		private bool validateFields()
		{
			bool status = true;
			if (entryEmail.Text == null || entryEmail.Text.Length == 0)
			{
				status = false;
				DisplayAlert("Alert", "Please enter email id", "OK");
			}
			else if (!GPValidator.isEmailOK(entryEmail.Text))
			{
				status = false;
				DisplayAlert("Alert", "Please enter valid email id", "OK");
			}
			else if (entryPassword.Text == null && entryPassword.Text.Length == 0)
			{
				DisplayAlert("Alert", "Please enter password", "OK");
				status = false;
			}
			return status;
		}

		public void onClickOfLogin(object sender, EventArgs e)
		{

			Debug.WriteLine("Email Id - " + entryEmail.Text);
			Debug.WriteLine("Password- " + entryPassword.Text);

			if (validateFields())
			{
				//Hit the API
				LoginRequestModel loginRequest = new LoginRequestModel();
				loginRequest.email = entryEmail.Text;
				loginRequest.password = entryPassword.Text;
				if (NetworkReachabilityManager.isInternetAvailable())
				{
					UserDialogs.Instance.ShowLoading("Loading ...", MaskType.Gradient);
					LoginAPIManager.SharedManager.doLogin(loginRequest, (LoginResponse loginResponse, GPError error) =>
					{
						UserDialogs.Instance.HideLoading();
						if (error != null)
						{
							DisplayAlert("Alert", error.Message, "OK");
						}
						else
						{
							//DisplayAlert("Message", "Login Successfull", "OK");
							moveToRestaurantsScreen();
						}
					});
				}
				else
				{
					DisplayAlert("Alert", "No internet connetion available", "OK");
				}
			}
		}

		private void moveToRestaurantsScreen()
		{
			App.Current.MainPage = new NavigationPage(new RestaurantsPage());
		}
	}
}
