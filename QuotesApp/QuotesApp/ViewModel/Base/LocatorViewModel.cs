using Autofac;
using QuotesApp.Exception;
using QuotesApp.Service.Abstraction;
using QuotesApp.Service.Implementation;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace QuotesApp.ViewModel.Base
{
    class LocatorViewModel
    {
        private static readonly IContainer container;
        public static readonly BindableProperty AutowireViewModelProperty =
            BindableProperty.CreateAttached("AutowireViewModel", typeof(bool), typeof(LocatorViewModel), default(bool), propertyChanged: OnAutowireViewModelChanged);

        static LocatorViewModel()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<QuoteService>().As<IQuoteService>();
            builder.RegisterType<AuthorService>().As<IAuthorService>();
            builder.RegisterType<HttpService>().As<IHttpService>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<QuotesViewModel>();
            builder.RegisterType<AuthorsViewModel>();
            builder.RegisterType<CategoriesViewModel>();
            builder.RegisterType<RestTestViewModel>();
            builder.RegisterType<TextToSpeechToTextViewModel>();
            builder.RegisterType<QuoteViewModel>();
            builder.RegisterType <SettingsViewModel>();
            container = builder.Build();
        }

        public static bool GetAutowireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutowireViewModelProperty);
        }

        public static void SetAutowireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutowireViewModelProperty, value);
        }

        public static T Resolve<T>() where T : class
        {
            return container.Resolve<T>();
        }

        private static void OnAutowireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if(!(bindable is Element))
            {
                throw new NoSuchViewException();
            }
            var viewModelType = GetViewModelFromView(view.GetType());
            var viewModel = container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }

        
        private static Type GetViewModelFromView(Type viewType)
        {
            var viewModelName = viewType.FullName.Replace(".View", ".ViewModel") + "Model";
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var fullViewModelName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewModelName, viewAssemblyName);
            var viewModelType = Type.GetType(fullViewModelName);
            if(viewModelType == null)
            {
                throw new NoSuchViewModelException(fullViewModelName);
            }
            return viewModelType;
        }


    }
}
