using BareBonesEnterprise.View;
using BareBonesEnterprise.ViewModel.Base;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BareBonesEnterprise.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public List<Page> MainViews { get; }
        public ICommand NavigateCommand => new Command<int>((index) => NavigateAsync(index));

        public MainViewModel()
        {
            MainViews = new List<Page>()
            {
                new AuthorsView(),
                new CategoriesView(),
                new QuotesView()
            };
        }

        private Task NavigateAsync(int index)
        {
            Debug.WriteLine(index);
            return NavigationService.NavigateToAsync<QuotesViewModel>();
        }


    }
}
