using QuotesApp.Animation.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuotesApp.Animation
{
    [ContentProperty("Animations")]
    class AnimationsContainer : AnimationBase
    {
        public List<AnimationBase> Animations { get; }

        public AnimationsContainer()
        {
            Animations = new List<AnimationBase>();
        }

        public AnimationsContainer(List<AnimationBase> animations)
        {
            Animations = animations;
        }

        protected override async Task BeginAnimation()
        {
            foreach (var animation in Animations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Begin();
            }
        }

        protected override async Task ResetAnimation()
        {
            foreach (var animation in Animations)
            {
                if (animation.Target == null)
                    animation.Target = Target;

                await animation.Reset();
            }
        }
    }
}
