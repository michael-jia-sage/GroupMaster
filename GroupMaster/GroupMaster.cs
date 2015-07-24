using System;

using Xamarin.Forms;
using Parse;

namespace GroupMaster
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to Xamarin Forms!"
						}
					}
				}
			};
		}

		protected override void OnStart ()
		{
			// Initialize the parse client with your Application ID and .NET Key found on
			// your Parse dashboard
			ParseClient.Initialize("evcq2mbbPHwCnCznl8yvbzvzMI7ij2G5G2v4oPcH",
				"3Ms32KvfmlFhsfD7y0OBIrecP04N4KZJNPYfOZqb");
			var testObject = new ParseObject ("MJTest");
			testObject ["source"] = "android again";
			testObject.SaveAsync ();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

	}
}

