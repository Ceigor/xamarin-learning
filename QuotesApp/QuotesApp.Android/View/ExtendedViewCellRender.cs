using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using QuotesApp.Droid.View;
using QuotesApp.View;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedViewCell), typeof(QuotesApp.Droid.View.ExtendedViewCellRender))]
namespace QuotesApp.Droid.View
{
    public class ExtendedViewCellRender : ViewCellRenderer
    {
        private Android.Views.View _cellCore;
        private Drawable _unselectedBackground;
        private bool _selected;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cellCore = base.GetCellCore(item, convertView, parent, context);
            _selected = false;
            _unselectedBackground = _cellCore.Background;
            System.Diagnostics.Debug.WriteLine("GetCellCore");
            return _cellCore;
        }

        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnCellPropertyChanged(sender, args);
            System.Diagnostics.Debug.WriteLine("OnCellPropertyChanged, event = " + args.PropertyName);
            if(args.PropertyName == "IsSelected")
            {
                _selected = !_selected;
                if(_selected)
                {
                    var extendedViewCell = sender as ExtendedViewCell;
                    System.Diagnostics.Debug.WriteLine("SettingColor = " + extendedViewCell.SelectedBackgroundColor);
                    _cellCore.SetBackgroundColor(extendedViewCell.SelectedBackgroundColor.ToAndroid());
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("SettingUnselectedColor  = " + _unselectedBackground);
                    _cellCore.SetBackground(_unselectedBackground);
                }
            }
        }
    }
}