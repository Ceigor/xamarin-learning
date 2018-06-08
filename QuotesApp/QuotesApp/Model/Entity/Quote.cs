using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Model
{

    public class Quote
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Quote()
        {

        }

        public Quote(string content, string author)
        {
            Content = content;
            Author = author;
        }

        public override string ToString()
        {
            return "content: " + Content + ", Author:" + Author;
        }

        public override bool Equals(object obj)
        {
            var quote = obj as Quote;
            return quote != null &&
                    ((this == quote) ||
                   (Content == quote.Content &&
                   Author == quote.Author));
        }

        public override int GetHashCode()
        {
            var hashCode = 211671080;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Content);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            return hashCode;
        }
    }
}
