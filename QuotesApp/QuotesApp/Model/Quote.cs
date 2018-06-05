using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Model
{

    public class Quote
    {
        public string Content { get; set; }
        public string Author { get; set; }

        public Quote(string content, string author)
        {
            Content = content;
            Author = author;
        }

        public override string ToString()
        {
            return "content: " + Content + ", Author:" + Author;
        }

    }
}
