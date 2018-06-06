using QuotesApp.Exception;
using QuotesApp.Service.Abstraction;
using QuotesApp.ViewModel;
using QuotesApp.ViewModel.Base;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuotesApp.Service.Implementation
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
            var navigationPage = Application.Current.MainPage;
            if (navigationPage is NavigationPage)
            {
                Debug.WriteLine("Pushing page = " + page);
                await ((NavigationPage)navigationPage).PushAsync(page);
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
            var viewFullName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewFullName);
            if (viewType == null)
            {
                throw new NoSuchViewException(viewFullName);
            }
            return viewType;
        }

        public Task RemoveCurrentFromBackStackAsync()
        {
            return GetMainPage().Navigation.PopModalAsync();
        }

        private NavigationPage GetMainPage()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;
            if (!(Application.Current.MainPage is NavigationPage))
                throw InvalidTypeException.CreateExpectedActualException(typeof(NavigationPage), Application.Current.MainPage.GetType());
            return mainPage;
        }

        public Task RemoveCurrentFromBackStackAsync(object data)
        {
            var mainPage = GetMainPage();
            var previousPage = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2];
            var previousPageViewModel = previousPage.BindingContext as IEditableItemViewModel;
            if (previousPageViewModel == null)
                throw InvalidTypeException.CreateExpectedActualException(typeof(IEditableItemViewModel), previousPageViewModel?.GetType());
            previousPageViewModel.SetChanged(data);
            return mainPage.Navigation.PopAsync();
        }

        public Task ClearBackStackAsync()
        {
            var mainPage = GetMainPage();
            for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
            {
                var page = mainPage.Navigation.NavigationStack[i];
                mainPage.Navigation.RemovePage(page);
            }
            return Task.FromResult(true);
        }
    }
}
