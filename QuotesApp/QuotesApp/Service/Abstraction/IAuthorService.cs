using QuotesApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Service.Abstraction
{
    public interface IAuthorService
    {
        List<Author> GetAuthors();
    }
}
