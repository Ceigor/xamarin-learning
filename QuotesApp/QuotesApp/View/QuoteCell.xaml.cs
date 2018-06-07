
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuoteCell : ViewCell
    {
        public QuoteCell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Debug.WriteLine("Is enabled?" + IsEnabled);
        }
    }
}