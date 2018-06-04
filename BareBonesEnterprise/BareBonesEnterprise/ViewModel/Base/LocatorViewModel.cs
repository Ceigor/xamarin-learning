using Autofac;
using BareBonesEnterprise.Exception;
using BareBonesEnterprise.Service.Abstraction;
using BareBonesEnterprise.Service.Implementation;
using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace BareBonesEnterprise.ViewModel.Base
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
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<QuotesViewModel>();
            builder.RegisterType<AuthorsViewModel>();
            builder.RegisterType<CategoriesViewModel>();
            builder.RegisterType<QuoteViewModel>();
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
            var viewModelType = Type.GetType(viewModelName);
            if(viewModelType == null)
            {
                throw new NoSuchViewModelException(viewModelName);
            }
            return viewModelType;
        }


    }
}
