using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DialogView : ContentView
	{
		public DialogView ()
		{
			InitializeComponent ();
		}
	}
}