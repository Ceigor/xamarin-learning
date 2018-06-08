using QuotesApp.Service.Abstraction;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuotesApp.iOS.Service.FileService))]
namespace QuotesApp.iOS.Service
{
    class FileService : IFileService
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);
            return Path.Combine(libFolder, filename);
        }
    }
}