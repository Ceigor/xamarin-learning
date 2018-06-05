using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuotesApp
{
    [ContentProperty("Text")]
    class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "QuotesApp.Properties.Resources.Strings";
        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return null;
            Debug.WriteLine(CultureInfo.CurrentCulture.DisplayName);
            ResourceManager resourceManager = new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly);
            return resourceManager.GetString(Text, CultureInfo.CurrentCulture);
        }
    }
}
