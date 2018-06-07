using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace QuotesApp.View
{
    public class ExtendedViewCell : ViewCell
    {
        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create("SelectedBackgroundColor",
                                    typeof(Color),
                                    typeof(ExtendedViewCell),
                                    Color.Default);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set
            {
                SetValue(SelectedBackgroundColorProperty, value);
                Debug.WriteLine("Setting color = " + value);
            }
        }
    }
}
