using System;
using System.Threading.Tasks;
using BareBonesEnterprise.Service.Abstraction;

namespace BareBonesEnterprise.ViewModel.Base
{
    public abstract class BaseViewModel : ExtendedBindableObject
    {
        public INavigationService NavigationService { get; }
       
        public BaseViewModel()
        {
            NavigationService = LocatorViewModel.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
    }
}
