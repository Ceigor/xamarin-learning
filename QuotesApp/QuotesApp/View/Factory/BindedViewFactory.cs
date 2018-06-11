using QuotesApp.Exception;
using QuotesApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace QuotesApp.View.Factory
{
    class BindedViewFactory
    {
        public static View CreateBindedView<View, ViewModel>() where View : Page where ViewModel : BaseViewModel
        {
            View view = CreateView<View>();
            view.BindingContext = CreateViewModel<ViewModel>();
            return view;
        }

        public static View CreateBindedView<View, ViewModel>(object viewModelParameter) where View : Page where ViewModel : BaseViewModel
        {
            View view = CreateBindedView<View, ViewModel>();
            var detailViewModel = view.BindingContext as IDetailViewModel;
            if (detailViewModel != null)
                detailViewModel.SetDetailId(viewModelParameter);
            else
                Debug.WriteLine("View model is not of this type " + typeof(IDetailViewModel));
            return view;
        }

        private static View CreateView<View>() where View : Page
        {
 
            if (typeof(View) == typeof(MainView))
                return (new MainView() as View);
            if (typeof(View) == typeof(AuthorsView))
                return (new AuthorsView() as View);
            if (typeof(View) == typeof(CategoriesView))
                return (new CategoriesView() as View);
            if (typeof(View) == typeof(CategoriesView))
                return (new CategoriesView() as View);
            if (typeof(View) == typeof(QuotesView))
                return (new QuotesView() as View);
            if (typeof(View) == typeof(RestTestView))
                return (new RestTestView() as View);
            if (typeof(View) == typeof(TextToSpeechToTextView))
                return (new TextToSpeechToTextView() as View);
            if (typeof(View) == typeof(SettingsView))
                return (new SettingsView() as View);
            if (typeof(View) == typeof(QuoteView))
                return (new QuoteView() as View);
            throw new NoSuchViewException(typeof(View));
        }

        private static ViewModel CreateViewModel<ViewModel>() where ViewModel : BaseViewModel
        {
            return LocatorViewModel.Resolve<ViewModel>();
        }
    }
}
