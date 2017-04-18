using Xamarin.Forms;
using XamarinFormsDemo;
using TestDemo;

namespace XamarinFormsShared
{
	public partial class App : Application
	{
		AbsoluteLayout mainLayout = new AbsoluteLayout();

		public App()
		{
			InitializeComponent();

			DBManager.sharedManager.createTables();

			MainPage = new LoginPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}


		public void showLoading() {
			var containerPage = Application.Current.MainPage;

			var indicator = new ActivityIndicator()
			{
				Color = Color.Blue,
			};
			indicator.SetBinding(VisualElement.IsVisibleProperty, new Binding("IsBusy", BindingMode.OneWay, source: containerPage));
			indicator.SetBinding(ActivityIndicator.IsRunningProperty, new Binding("IsBusy", BindingMode.OneWay, source: containerPage));
			AbsoluteLayout.SetLayoutFlags(indicator, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(indicator, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			mainLayout.Children.Add(indicator);

			containerPage.IsBusy = true;
		}

		public void hideLoading() {
			mainLayout.IsVisible = false;
		}
 	}
}
