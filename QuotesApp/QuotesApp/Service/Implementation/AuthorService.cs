using QuotesApp.Model;
using QuotesApp.Service.Abstraction;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QuotesApp.Service.Implementation
{
    class AuthorService : IAuthorService
    {
        private readonly int MOCKED_AUTHORS = 100;
        private readonly Random RANDOM = new Random();

        public List<Author> GetAuthors()
        {
            return MockAuthors();
        }

        private List<Author> MockAuthors()
        {
            var authors = new List<Author>();
            var authorsToPopulateAuthors = new List<Author>()
            {
                new Author("Atlas", ImageSource.FromFile("atlas.jpg")),
                new Author("Spiderman", ImageSource.FromFile("spiderman.png")),
                new Author("Tesla", ImageSource.FromFile("tesla.jpg")),
                new Author("Tmp", ImageSource.FromFile("tmp.jpg"))
            };
            for (var i = 0; i < MOCKED_AUTHORS; i++)
                authors.Add(GetRandomAuthor(authorsToPopulateAuthors));
            return authors;
        }

        private Author GetRandomAuthor(List<Author> authors)
        {
            return authors[RANDOM.Next(0, authors.Count)];
        }
    }
}
