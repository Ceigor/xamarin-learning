using BareBonesEnterprise.Model;
using System.Collections.Generic;

namespace BareBonesEnterprise.Service.Abstraction
{
    interface IQuoteService
    {
        List<Quote> GetQuotes();
    }
}
