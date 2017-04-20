using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using TestDemo;

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
			//Arrange
			app.EnterText("EntryEmail", "ganesh.nist@gmail.com.dom");
			app.EnterText("EntryPassword", "ganesh");

			//Act
			app.Tap("ButtonLogin");

			//Assert
			var query = app.Query("EntryEmail").First();
			
		}
	}
}
