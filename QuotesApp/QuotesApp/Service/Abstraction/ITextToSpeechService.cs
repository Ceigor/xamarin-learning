using System;
using System.Collections.Generic;
using System.Text;

namespace QuotesApp.Service.Abstraction
{
    public interface ITextToSpeechService
    {
        void Speak(string text);
    }
}
