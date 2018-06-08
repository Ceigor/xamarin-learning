using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Service.Abstraction
{
    public interface IFileService
    {
        string GetLocalFilePath(string filename);
    }
}
