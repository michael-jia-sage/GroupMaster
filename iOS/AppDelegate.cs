using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
//using Parse;

namespace GroupMaster.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
//		public AppDelegate ()
//		{
//			// Initialize the Parse client with your Application ID and .NET Key found on
//			// your Parse dashboard
//			ParseClient.Initialize("evcq2mbbPHwCnCznl8yvbzvzMI7ij2G5G2v4oPcH",
//				"3Ms32KvfmlFhsfD7y0OBIrecP04N4KZJNPYfOZqb");
//		}

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			// Code for starting up the Xamarin Test Cloud Agent
			#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
			#endif

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

