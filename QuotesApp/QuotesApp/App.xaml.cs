using QuotesApp.Data;
using QuotesApp.Service.Abstraction;
using QuotesApp.View;
using QuotesApp.View.Factory;
using QuotesApp.ViewModel;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace QuotesApp
{
	public partial class App : Application
	{

        private static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(DependencyService.Get<IFileService>().GetLocalFilePath(Database.DATABASE_NAME));
                }
                return database;
            }
        }

        public App ()
		{
			InitializeComponent();
            MainView mainView = BindedViewFactory.CreateBindedView<MainView, MainViewModel>();
            MainPage = new NavigationPage(mainView);
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
