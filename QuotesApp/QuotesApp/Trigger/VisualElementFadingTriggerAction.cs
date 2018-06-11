using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuotesApp.Trigger
{
    public class VisualElementFadingTriggerAction : TriggerAction<VisualElement>
    {
        public VisualElementFadingTriggerAction()
        {
            Anchor = new Point(0.5, 0.5);
            Scale = 0.5;
            Length = 500;
            Opacity = 0.1;
        }

        public Point Anchor { set; get; }

        public double Scale { set; get; }

        public uint Length { set; get; }

        public double Opacity { set; get; }

        protected override async void Invoke(VisualElement visual)
        {
            visual.AnchorX = Anchor.X;
            visual.AnchorY = Anchor.Y;
            await visual.FadeTo(Opacity, Length/ 4, Easing.SinOut);
            await visual.ScaleTo(Scale, Length / 4, Easing.SinOut);
            await visual.ScaleTo(1, Length / 4, Easing.SinIn);
            await visual.FadeTo(1, Length / 4, Easing.SinOut);
        }
    }
}
