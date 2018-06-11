using QuotesApp.Exception;
using QuotesApp.Service.Abstraction;
using QuotesApp.View;
using QuotesApp.View.Factory;
using QuotesApp.ViewModel.Base;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuotesApp.Service.Implementation
{
    class NavigationService : INavigationService
    {
        public async Task NavigateToAsync<View, ViewModel>()
        where View : Page
        where ViewModel : BaseViewModel
        {
            View page = BindedViewFactory.CreateBindedView<View, ViewModel>();
            await GetMainPage().PushAsync(page);
        }

        public async Task NavigateToAsync<View, ViewModel>(object parameter)
            where View : Page
            where ViewModel : BaseViewModel
        {
            View page = BindedViewFactory.CreateBindedView<View, ViewModel>(parameter);
            await GetMainPage().PushAsync(page);
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
