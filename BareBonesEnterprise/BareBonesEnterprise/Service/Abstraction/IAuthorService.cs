using BareBonesEnterprise.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BareBonesEnterprise.Service.Abstraction
{
    public interface IAuthorService
    {
        List<Author> GetAuthors();
    }
}
