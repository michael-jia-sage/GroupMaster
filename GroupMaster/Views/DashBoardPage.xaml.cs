using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Parse;

namespace GroupMaster
{
	public partial class DashBoardPage : ContentPage
	{
		public DashBoardPage ()
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

		async void btnCostMemo_Clicked(object sender, EventArgs args)
		{
		}

		async void btnAddPayment_Clicked(object sender, EventArgs args)
		{
		}

		async void btnZicZac_Clicked(object sender, EventArgs args)
		{
		}

		async void btnDigitMine_Clicked(object sender, EventArgs args)
		{
		}

		async void btnLogout_Clicked(object sender, EventArgs args)
		{
		}
	}
}

