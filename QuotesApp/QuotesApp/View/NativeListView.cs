using QuotesApp.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QuotesApp.View
{
    public class NativeListView : ListView
    {
        public event EventHandler<SelectedItemChangedEventArgs> SuperEvent;

       
    }
}
