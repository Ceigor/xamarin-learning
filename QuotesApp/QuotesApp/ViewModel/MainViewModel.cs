using QuotesApp.View;
using QuotesApp.ViewModel.Base;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuotesApp.ViewModel
{
    class MainViewModel : BaseViewModel
    {
     
        public ICommand NavigateToAuthorsCommand { get; }
        public ICommand NavigateToCategoriesCommand { get; }
        public ICommand NavigateToQuotesCommand { get;  }
        public ICommand NavigateToRestTestCommand { get; }
        public ICommand NavigateToTextToSpeechToTextCommand { get; }
        public ICommand NavigateToSettingsCommand { get; }

        public MainViewModel()
        {
            NavigateToAuthorsCommand = new Command(async () => await navigationService.NavigateToAsync<AuthorsView, AuthorsViewModel>());
            NavigateToCategoriesCommand = new Command(async () => await navigationService.NavigateToAsync<CategoriesView, CategoriesViewModel>());
            NavigateToQuotesCommand = new Command(async() => await navigationService.NavigateToAsync<QuotesView, QuotesViewModel>());
            NavigateToRestTestCommand = new Command(async () => await navigationService.NavigateToAsync<RestTestView, RestTestViewModel>());
            NavigateToTextToSpeechToTextCommand = new Command(async () => await navigationService.NavigateToAsync<TextToSpeechToTextView, TextToSpeechToTextViewModel>());
            NavigateToSettingsCommand = new Command(async () => await navigationService.NavigateToAsync<SettingsView, SettingsViewModel>());
        }

 


    }
}
