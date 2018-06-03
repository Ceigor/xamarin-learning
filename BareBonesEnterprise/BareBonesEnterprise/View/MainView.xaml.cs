using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BareBonesEnterprise.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
	{
		public MainView()
		{
			InitializeComponent();
		}

        void OnAuthorsClicked(object sender, EventArgs args)
        {
            this.Navigation.PushAsync(new AuthorsView());
        }

        void OnCategoriesClicked(object sender, EventArgs args)
        {
            this.Navigation.PushAsync(new CategoriesView());
        }

        void OnQuotesClicked(object sender, EventArgs args)
        {
            this.Navigation.PushAsync(new QuotesView());
        }
    }
}
