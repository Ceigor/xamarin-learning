using QuotesApp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace QuotesApp.ViewModel
{
    public class SettingsViewModel : BaseViewModel
    {
        public const string SWITCH_KEY = "switch";
        public bool SwitchOn { get; private set; }
        public ICommand SwitchCommand { get; private set; }

        public SettingsViewModel()
        {
            SetSwitchOnAsync();
            SwitchCommand = new Command(SaveSwitchState);
        }

        private async void SaveSwitchState()
        {
            SwitchOn = !SwitchOn;
            Debug.WriteLine("Saving switch state = " + SwitchOn);
            Application.Current.Properties[SWITCH_KEY] = SwitchOn;
            await Application.Current.SavePropertiesAsync();
        }

        private async void SetSwitchOnAsync()
        {
            await Task.Run(() => SetSwitch());
        }

        private void SetSwitch()
        {
            if(!Application.Current.Properties.ContainsKey(SWITCH_KEY))
            {
                Debug.WriteLine("Dictionary does not contain this key!");
                return;
            }
            var switchOn = Application.Current.Properties[SWITCH_KEY];
            Debug.WriteLine("Have switch on = " + switchOn);
            if (switchOn is bool)
                SwitchOn = (bool)switchOn;
            else
                SwitchOn = false;
        }
    }
}
