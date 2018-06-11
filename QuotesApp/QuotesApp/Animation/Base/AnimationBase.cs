using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuotesApp.Animation.Base
{
    public abstract class AnimationBase : BindableObject
    {
        private bool IsRunning = false;

        public static readonly BindableProperty TargetProperty =
            BindableProperty.Create("Target", typeof(VisualElement), typeof(AnimationBase), null, propertyChanged: (bindable, oldValue, newValue) =>
            ((AnimationBase)bindable).Target = (VisualElement)newValue);

        public VisualElement Target
        {
            get { return (VisualElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly BindableProperty DurationProperty =
            BindableProperty.Create("Duration", typeof(string), typeof(AnimationBase), "1000", propertyChanged: (bindable, oldValue, newValue) =>
            ((AnimationBase)bindable).Duration = (string)newValue);

        public string Duration
        {
            get { return (string)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        public static readonly BindableProperty EasingProperty =
            BindableProperty.Create("Easing", typeof(EasingType), typeof(AnimationBase), EasingType.Linear, propertyChanged: (bindable, oldValue, newValue) =>
            ((AnimationBase)bindable).Easing = (EasingType)newValue);

        public EasingType Easing
        {
            get { return (EasingType)GetValue(EasingProperty); }
            set { SetValue(EasingProperty, value); }
        }

        public static readonly BindableProperty RepeatForverProperty =
            BindableProperty.Create("RepeatForever", typeof(bool), typeof(AnimationBase), false, propertyChanged: (bindable, oldValue, newValue) =>
            ((AnimationBase)bindable).RepeatForever = (bool)newValue);

        public bool RepeatForever
        {
            get { return (bool)GetValue(RepeatForverProperty); }
            set { SetValue(RepeatForverProperty, value); }
        }

        public static readonly BindableProperty DelayProperty =
            BindableProperty.Create("Delay", typeof(int), typeof(AnimationBase), 0, propertyChanged: (bindable, oldValue, newValue) =>
            ((AnimationBase)bindable).Delay = (int)newValue);
       
        public int Delay
        {
            get { return (int)GetValue(DelayProperty); }
            set { SetValue(DelayProperty, value); }
        }

        protected abstract Task BeginAnimation();
     
        public async Task Begin()
        {
            try
            {
                if (!IsRunning)
                {
                    IsRunning = true;
                    await InternalBegin().ContinueWith(t => t.Exception, TaskContinuationOptions.OnlyOnFaulted)
                        .ConfigureAwait(false);
                }
            }
            catch(System.Exception exception)
            {
                Debug.WriteLine($"Exception in animation {exception}");
            }
        }

        private async Task InternalBegin()
        {
            if (Delay > 0)
                await Task.Delay(Delay);
            if (!RepeatForever)
                await BeginAnimation();
            else
            {
                do
                    BeginResetAnimation();
                while (RepeatForever);
            }
        }

        private async void BeginResetAnimation()
        {
            await BeginAnimation();
            await ResetAnimation();
        }

        protected abstract Task ResetAnimation();

        public async Task Reset()
        {
            await ResetAnimation();
        }

    }
}
