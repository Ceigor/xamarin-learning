using QuotesApp.ViewModel.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuotesApp.Service.Abstraction
{
    public interface INavigationService
    {
        Task NavigateToAsync<View, ViewModel>() where View : Page where ViewModel : BaseViewModel;
        Task NavigateToAsync<View, ViewModel>(object parameter) where View : Page where ViewModel : BaseViewModel;
        Task RemoveCurrentFromBackStackAsync();
        Task RemoveCurrentFromBackStackAsync(object data);
        Task ClearBackStackAsync();
    }
}
