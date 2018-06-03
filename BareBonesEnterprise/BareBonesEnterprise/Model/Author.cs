using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BareBonesEnterprise.Model
{
    class Author
    {
        public string name { get; }
        public Image image { get; }
        public List<Quote> quotes { get; }

        public Author(string name, Image image, List<Quote> quotes)
        {
            this.name = name;
            this.image = image;
            this.quotes = quotes;
        }
    }
}
