using Android.Speech.Tts;
using QuotesApp.Service.Abstraction;
using Android.Runtime;
using System.Diagnostics;
using Xamarin.Forms;

[assembly: Dependency(typeof(QuotesApp.Droid.TextToSpeechService))]
namespace QuotesApp.Droid
{
    public class TextToSpeechService : Java.Lang.Object, ITextToSpeechService, TextToSpeech.IOnInitListener
    {

        public TextToSpeech Speaker { get; private set; }
        public string ToSpeak { get; private set; }

        public void Speak(string text)
        {
            ToSpeak = text;
            if (Speaker == null)
                Speaker = new TextToSpeech(MainActivity.Instance, this);
            else
            {
                Speaker.Speak(ToSpeak, QueueMode.Flush, null, null);
                Debug.WriteLine("spoke" + ToSpeak);
            }
        }

       
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                Debug.WriteLine("speaker init");
                Speaker.Speak(ToSpeak, QueueMode.Flush, null, null);
            }
            else
                Debug.WriteLine("was quiet");
        }
     
    }
}