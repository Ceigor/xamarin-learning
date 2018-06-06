using System.Threading.Tasks;

namespace QuotesApp.Service.Abstraction
{
    public interface IHttpService
    {
       Task<T> ExecuteGetRequest<T>(string url);
    }
}
