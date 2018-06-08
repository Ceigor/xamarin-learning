using QuotesApp.Data;
using QuotesApp.Service.Abstraction;
using QuotesApp.View;
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
            MainPage = new NavigationPage(new MainView());
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
