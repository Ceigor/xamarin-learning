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

        public MainViewModel()
        {
            NavigateToAuthorsCommand = new Command(async () => await AuthorsAsync());
            NavigateToCategoriesCommand = new Command(async () => await CategoriesAsync());
            NavigateToQuotesCommand = new Command(async() => await QuotesAsync());
        }

        private async Task AuthorsAsync()
        {
            Debug.WriteLine("navigationService.NavigateToAsync<AuthorsViewModel>()");
            await navigationService.NavigateToAsync<AuthorsViewModel>();
        }

        private async Task CategoriesAsync()
        {
            Debug.WriteLine("navigationService.NavigateToAsync<CategoriesViewModel>()");
            await navigationService.NavigateToAsync<CategoriesViewModel>();
        }

        private async Task QuotesAsync()
        {
            Debug.WriteLine("navigationService.NavigateToAsync<QuotesViewModel>()");
            await navigationService.NavigateToAsync<QuotesViewModel>();
        }


    }
}
