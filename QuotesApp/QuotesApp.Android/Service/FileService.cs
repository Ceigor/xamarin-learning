using System;
using System.IO;
using QuotesApp.Service.Abstraction;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuotesApp.Droid.Service.FileService))]
namespace QuotesApp.Droid.Service
{
    class FileService : IFileService
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}