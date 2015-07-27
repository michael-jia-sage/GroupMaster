using System;

using Xamarin.Forms;
using Parse;

namespace GroupMaster
{
	public class App : Application
	{
		static GroupMasterDB database;
		public static GroupMasterDB Database {
			get {
				database = database ?? new GroupMasterDB ();
				return database;
			}
		}

		public App ()
		{
			LocalInfo localInfo = App.Database.GetActiveLocalInfo ();
			if (localInfo != null) {
				MainPage = new DashBoardPage();
			} else {
				MainPage = new SignUpPage();
			}
				
			// The root page of your application
//			MainPage = new ContentPage {
//				Content = new StackLayout {
//					VerticalOptions = LayoutOptions.Center,
//					Children = {
//						new Label {
//							XAlign = TextAlignment.Center,
//							Text = "Welcome to Xamarin Forms!"
//						}
//					}
//				}
//			};
		}

		protected override void OnStart ()
		{
			// Initialize the parse client with your Application ID and .NET Key found on
			// your Parse dashboard
			ParseClient.Initialize("evcq2mbbPHwCnCznl8yvbzvzMI7ij2G5G2v4oPcH",
				"3Ms32KvfmlFhsfD7y0OBIrecP04N4KZJNPYfOZqb");
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

