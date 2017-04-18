using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Windows.Input;
using TestDemo;
using System.Diagnostics;

namespace XamarinFormsShared
{
	public partial class Login : ContentPage
	{
		public ICommand LoginCommand { get; private set;}

		public Login()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			//LoginCommand = new Xamarin.Forms.Command(onClickOfLogin);
			btnLogin.Clicked += onClickOfLogin;
			Debug.WriteLine("---------- OnAppear called!");		
		}

		private bool validateFields() {			
			bool status = true;
			if (entryEmail.Text.Length == 0) {
				status = false;
                DisplayAlert("Alert", "Please enter email id", "OK");
			} else if(!GPValidator.isEmailOK(entryEmail.Text)) {
				status = false;	
                DisplayAlert("Alert", "Please enter valid email id", "OK");
			} else if (entryPassword.Text.Length == 0) {
                DisplayAlert("Alert", "Please enter password", "OK");
				status = false;
			}
			return status;
		}

		public void onClickOfLogin(object sender, EventArgs e) {			

			Debug.WriteLine("Email Id - " + entryEmail.Text);
			Debug.WriteLine("Password- " + entryPassword.Text);		 

			if (validateFields()) {
				//Hit the API
				LoginRequestModel loginRequest = new LoginRequestModel();
				loginRequest.email = entryEmail.Text;
				loginRequest.password = entryPassword.Text;
				if(NetworkReachabilityManager.isInternetAvailable()) {
					LoginAPIManager.SharedManager.doLogin(loginRequest, (LoginResponse loginResponse, GPError error) =>
					{

					});	
				} else {
					DisplayAlert("Alert", "No internet connetion available", "OK");	
				}
			}
		}
	}
}
