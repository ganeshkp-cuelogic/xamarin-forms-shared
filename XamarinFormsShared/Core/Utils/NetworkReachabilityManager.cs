using System;
using Xamarin.Forms;
using XamarinFormsDemo;
using Connectivity.Plugin;

namespace TestDemo
{
	public class NetworkReachabilityManager
	{
		public NetworkReachabilityManager()
		{
			
		}
		public static bool isInternetAvailable() {
			return CrossConnectivity.Current.IsConnected;
		}
	}
}
