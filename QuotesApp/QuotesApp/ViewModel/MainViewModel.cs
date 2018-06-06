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

        public MainViewModel()
        {
            NavigateToAuthorsCommand = new Command(async () => await navigationService.NavigateToAsync<AuthorsViewModel>());
            NavigateToCategoriesCommand = new Command(async () => await navigationService.NavigateToAsync<CategoriesViewModel>());
            NavigateToQuotesCommand = new Command(async() => await navigationService.NavigateToAsync<QuotesViewModel>());
            NavigateToRestTestCommand = new Command(async () => await navigationService.NavigateToAsync<RestTestViewModel>());
        }

 


    }
}
