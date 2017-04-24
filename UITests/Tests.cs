using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using TestDemo;
using System.Threading;

namespace XamarinFormsShared.UITests
{
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		[Test]
		public void WelcomeTextIsDisplayed()
		{
			AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to Xamarin Forms!"));
			app.Screenshot("Welcome screen.");

			Assert.IsTrue(results.Any());
		}

		[Test]
		public void TestLoginForm()
		{
			app.Screenshot("App Started - Login Screen");

			app.EnterText("EntryEmail", "ganesh.nist@gmail.com.dom");
			app.EnterText("EntryPassword", "ganesh");
			app.Tap("ButtonLogin");
			app.DismissKeyboard();
			app.Screenshot("Login failed due to invalid credentials");


			//Using the correcting credentials
			app.Screenshot("Entering correct credentials");
			app.Tap("EntryEmail");
			app.ClearText();
			app.EnterText("EntryEmail", "ganesh.nist@gmail.com");

			app.Tap("EntryPassword");
			app.ClearText();
			app.EnterText("EntryPassword", "adminasdf");
			app.Tap("ButtonLogin");
			app.DismissKeyboard();
		}

		[Test]
		public void TestLoginScreenUI()
		{

		}
	}
}
