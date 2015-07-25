using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Parse;

namespace GroupMaster
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			LocalInfo localInfo = App.Database.GetActiveLocalInfo ();
			if (localInfo != null) {
				lblTitle.Text = "Welcome " + localInfo.UserName;
			} else {
				lblTitle.Text = "Not logged in";
			}
		}

		async void btnOneTapSignUp_Clicked(object sender, EventArgs args)
		{
			var query = from dictionary in ParseObject.GetQuery("Dictionary")
					where dictionary.Get<int>("dicType") == 1 && dictionary.Get<bool>("isAvailable")
				select dictionary;
			IEnumerable<ParseObject> results = await query.Limit(1).FindAsync();

			if (results == null || results.Count() <= 0) 
			{
				await DisplayAlert ("Sign Up Failed", "There's no available usernames in the pool.", "OK");
				return;
			}

			var dic = results.First();
//			// or using LINQ
//			var query = ParseObject.GetQuery("GameScore").WhereEqualTo("playerName", "Dan Stemkoski");
//			IEnumerable<ParseObject> results = await query.FindAsync();

			if (dic == null) 
			{
				await DisplayAlert ("Sign Up Failed", "There's no available usernames in the pool.", "OK");
				return;
			}
				
			string userName = dic.Get<string> ("dicValue");
			string password = "111111";
			var user = new ParseUser()
			{
				Username = userName,
				Password = password
			};
			await user.SignUpAsync ();

			dic["isAvailable"] = false;
			await dic.SaveAsync ();

			await ParseUser.LogInAsync (userName, password);

			App.Database.DeleteAllLocalInfos ();

			LocalInfo localInfo = new LocalInfo ();
			localInfo.UserName = userName;
			localInfo.Passcode = password;
			localInfo.Active = true;
			App.Database.SaveLocalInfo (localInfo);

			lblTitle.Text = "Welcome " + userName;
			lblMessage.Text = "New user signed up: \n" + userName + "  --  " + password;
		}
	}
}

