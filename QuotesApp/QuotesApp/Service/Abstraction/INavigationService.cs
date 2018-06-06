﻿using QuotesApp.ViewModel.Base;
using System.Threading.Tasks;

namespace QuotesApp.Service.Abstraction
{
    public interface INavigationService
    {
        Task InitializeAsync();
        Task NavigateToAsync<ViewModel>() where ViewModel : BaseViewModel;
        Task NavigateToAsync<ViewModel>(object parameter) where ViewModel : BaseViewModel;
        Task RemoveCurrentFromBackStackAsync();
        Task RemoveCurrentFromBackStackAsync(object data);
        Task ClearBackStackAsync();
    }
}
