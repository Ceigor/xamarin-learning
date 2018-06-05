using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Model
{

    public class Quote
    {
        public string Content { get; }
        public string Author { get; }

        public Quote(string content, string author)
        {
            Content = content;
            Author = author;
        }

    }
}
