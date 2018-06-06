using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using QuotesApp.Service.Abstraction;
using QuotesApp.ViewModel.Base;
using Xamarin.Forms;

namespace QuotesApp.ViewModel
{
    class TextToSpeechToTextViewModel : BaseViewModel
    {
        public string ToSpeak { get; set; }
        public ICommand SpeakCommand { get; private set; }
        
        public TextToSpeechToTextViewModel()
        {
            SpeakCommand = new Command(Speak);
        }

        private void Speak()
        {
            if (String.IsNullOrEmpty(ToSpeak))
                ToSpeak = "Nothing to speak";
            DependencyService.Get<ITextToSpeechService>().Speak(ToSpeak);
        }
    }
}
