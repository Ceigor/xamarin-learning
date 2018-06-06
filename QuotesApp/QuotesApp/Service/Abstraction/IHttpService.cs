using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuotesApp.Service.Abstraction
{
    public interface IHttpService
    {
        Task<String> ExecuteGetRequest(string url);
    }
}
