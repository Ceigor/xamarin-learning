using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuotesApp.Trigger
{
    public class FadeTriggerAction : TriggerAction<VisualElement>
    {
        public int StartsFrom { get; set; }

        protected override void Invoke(VisualElement visual)
        {
            visual.Animate("0", new Xamarin.Forms.Animation((d) =>
            {
                var val = StartsFrom == 1 ? d : 1 - d;
                visual.BackgroundColor = Color.FromRgb(1, val, 1);
            }),
            length: 1000,
            easing: Easing.Linear);
        }


    }
}
