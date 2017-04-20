using System;
using NUnit.Framework;


namespace UnitTest
{
	[TestFixture]
	public class MyTest
	{
		[Test]
		public void Pass()
		{
			Assert.True(true);
		}

		[Test]
		public void Fail()
		{
			Assert.False(true);
		}

		[Test]
		public void TestCheckEmailValidation()
		{
			Assert.True(TestDemo.GPValidator.isEmailOK("aa@@@a.com"));
		}

		[Test]
		[Ignore("another time")]
		public void Ignore()
		{
			Assert.True(false);
		}
	}
}
