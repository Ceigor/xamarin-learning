using BareBonesEnterprise.Model;
using BareBonesEnterprise.Service.Abstraction;
using System.Collections.Generic;
using Xamarin.Forms;

namespace BareBonesEnterprise.Service.Implementation
{
    class AuthorService : IAuthorService
    {
        private readonly int MOCKED_AUTHORS = 100;

        public List<Author> GetAuthors()
        {
            return MockAuthors();
        }

        private List<Author> MockAuthors()
        {
            var authors = new List<Author>();
            var imageSource = Device.RuntimePlatform == Device.Android ? ImageSource.FromFile("tmp.jpg") : ImageSource.FromFile("Images/tmp.jpg");
            var authorToPopulateAuthors = new Author("Cycero", imageSource);
            for (var i = 0; i < MOCKED_AUTHORS; i++)
                authors.Add(authorToPopulateAuthors);
            return authors;
        }
    }
}
