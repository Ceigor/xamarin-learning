using BareBonesEnterprise.Exception;
using BareBonesEnterprise.Service.Abstraction;
using BareBonesEnterprise.ViewModel;
using BareBonesEnterprise.ViewModel.Base;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BareBonesEnterprise.Service.Implementation
{
    class NavigationService : INavigationService
    {
        public Task InitializeAsync()
        {
            return NavigateToAsync<MainViewModel>();
        }

        public Task NavigateToAsync<ViewModel>() where ViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(ViewModel), null);
        }

        public Task NavigateToAsync<ViewModel>(object parameter) where ViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(ViewModel), parameter);
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType);
            Debug.WriteLine("IInternalNavigateToAsync()");
            var navigationPage = Application.Current.MainPage as NavigationPage;
            if (navigationPage != null)
            {
                Debug.WriteLine("Pushing page = " + page);
                await navigationPage.PushAsync(page);
            }
            else
            {
                Debug.WriteLine("Navigation page is equal to null!");
            }
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Page CreatePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            return Activator.CreateInstance(pageType) as Page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            if (viewType == null)
            {
                throw new NoSuchViewException(viewName);
            }
            return viewType;
        }
    }
}
