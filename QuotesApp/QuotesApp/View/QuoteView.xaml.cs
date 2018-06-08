using QuotesApp.Message;
using QuotesApp.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuoteView : ContentPage
    {
        public QuoteView()
        {
            InitializeComponent();
            SetSubscription();
        }

        private void SetSubscription()
        {
            MessagingCenter.Subscribe<QuoteViewModel>(
               this, MessagesKeys.NOTHING_CHANGED, async (sender) =>
               {
                   await DisplayAlert(Properties.Resources.Strings.NothingNewToSave, "", Properties.Resources.Strings.Ok);
               });
        }
    }
}