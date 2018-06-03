using BareBonesEnterprise.ViewModel.Base;
using System.Threading.Tasks;

namespace BareBonesEnterprise.Service.Abstraction
{
    interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync<ViewModel>() where ViewModel : BaseViewModel;
        Task NavigateToAsync<ViewModel>(object parameter) where ViewModel : BaseViewModel;
    }
}
