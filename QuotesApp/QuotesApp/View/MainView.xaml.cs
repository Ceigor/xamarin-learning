using QuotesApp.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
	{
		public MainView()
		{
			InitializeComponent();
		}

        public void OnFastClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new RestTestView());
        }
    }
}
