using QuotesApp.Message;
using QuotesApp.Model;
using QuotesApp.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesView : ContentPage
    {
        public QuotesView()
        {
            InitializeComponent();
            SetSubscription();
        }

        private void SetSubscription()
        {
            MessagingCenter.Subscribe<QuoteViewModel, Quote>(
               this, MessagesKeys.QUOTE_CHANGED, async (sender, arg) =>
               {
                   await DisplayAlert(Properties.Resources.Strings.QuoteUpdated, arg.Content, Properties.Resources.Strings.Ok);
               });
        }

    }
}