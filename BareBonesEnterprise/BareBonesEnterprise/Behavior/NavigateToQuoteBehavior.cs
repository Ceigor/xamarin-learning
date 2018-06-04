
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace BareBonesEnterprise.Behavior
{
    class NavigateToQuoteBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button button)
        {
            button.Clicked += OnButtonClicked;
            base.OnAttachedTo(button);
        }

        protected override void OnDetachingFrom(Button button)
        {
            button.Clicked -= OnButtonClicked;
            base.OnDetachingFrom(button);
        }

        void OnButtonClicked(object sender, EventArgs args)
        {
            Debug.WriteLine("ButtonClicked!");
        }
    }
}
