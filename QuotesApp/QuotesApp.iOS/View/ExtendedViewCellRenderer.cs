using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using QuotesApp.View;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedViewCell), typeof(QuotesApp.iOS.View.ExtendedViewCellRenderer))]
namespace QuotesApp.iOS.View
{
    public class ExtendedViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as ExtendedViewCell;
            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = view.SelectedBackgroundColor.ToUIColor(),
            };
            return cell;
        }

    }
}