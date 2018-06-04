using System.Collections.Generic;
using Xamarin.Forms;

namespace BareBonesEnterprise.Model
{
    public class Author
    {
        public string Name { get; }
        public ImageSource ImageSource { get; }
        public List<Quote> Quotes { get; }

        public Author(string name, ImageSource imageSource)
        {
            Name = name;
            ImageSource = imageSource;
        }
    }
}
