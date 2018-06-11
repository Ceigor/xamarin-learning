using System;
using System.Threading.Tasks;
using QuotesApp.Service.Abstraction;

namespace QuotesApp.ViewModel.Base
{
    public abstract class BaseViewModel : ExtendedBindableObject
    {
        protected INavigationService navigationService;


        public BaseViewModel()
        {
            navigationService = LocatorViewModel.Resolve<INavigationService>();
        }
    }
}
