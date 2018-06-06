using Newtonsoft.Json;
using QuotesApp.Model;
using QuotesApp.Service.Abstraction;
using QuotesApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuotesApp.ViewModel
{
    class RestTestViewModel : BaseViewModel
    {
        private const string REST_TEST_URL = "https://jsonplaceholder.typicode.com/posts";
        private readonly IHttpService HttpService;
        public ICommand TestRestCommand { get; private set; }
        private ObservableCollection<RestTestModel> restTestModels;
        public ObservableCollection<RestTestModel> RestTestModels
        {
            get { return restTestModels; }
            private set
            {
                restTestModels = value;
                RaisePropertyChanged(() => RestTestModels);
            }
        }

        public RestTestViewModel(IHttpService httpService)
        {
            HttpService = httpService;
            TestRestCommand = new Command(() => Test());
        }

        private async void Test()
        {
            Debug.WriteLine("Testing rest!");
            RestTestModels = new ObservableCollection<RestTestModel>(await HttpService.ExecuteGetRequest<List<RestTestModel>>(REST_TEST_URL));
        }
    }
}
