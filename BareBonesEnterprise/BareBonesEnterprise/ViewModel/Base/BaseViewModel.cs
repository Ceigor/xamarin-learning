using System;
using System.Threading.Tasks;
using BareBonesEnterprise.Service.Abstraction;

namespace BareBonesEnterprise.ViewModel.Base
{
    public abstract class BaseViewModel : ExtendedBindableObject
    {
        protected INavigationService navigationService;


        public BaseViewModel()
        {
            navigationService = LocatorViewModel.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }
    }
}
