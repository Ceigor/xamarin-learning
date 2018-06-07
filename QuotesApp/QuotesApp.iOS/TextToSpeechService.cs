using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AVFoundation;
using Foundation;
using QuotesApp.Service.Abstraction;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuotesApp.iOS.TextToSpeechService))]
namespace QuotesApp.iOS
{
    public class TextToSpeechService : ITextToSpeechService
    {
        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };
            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}