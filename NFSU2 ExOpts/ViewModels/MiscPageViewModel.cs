using DESTRY.IO.Debuging;
using System;
using System.Collections.ObjectModel;

namespace NFSU2_ExOpts.ViewModels
{
    class MiscPageViewModel : BaseViewModel
    {
        private ObservableCollection<string> windowedModesCollection;

        private int windowedModeIndex;
        private string skipMovies;
        private string enableSound;
        private string enableMusic;
        private string multipleInstances;


        public ObservableCollection<string> WindowedModesCollection
        {
            get
            {
                return windowedModesCollection;
            }
            set
            {
                windowedModesCollection = value;
                OnPropertyChanged();
            }
        }

        public int WindowedModeIndex
        {
            get
            {
                return windowedModeIndex;
            }
            set
            {
                windowedModeIndex = value;
                App.IniFile["WindowedMode", "Misc"] = value.ToString();
                App.IsSavedData = false;

                Logs.WriteLog($"WindowedMode(Misc) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string SkipMovies
        {
            get
            {
                return skipMovies;
            }
            set
            {
                skipMovies = value;
                App.IniFile["SkipMovies", "Misc"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"SkipMovies(Misc) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string EnableSound
        {
            get
            {
                return enableSound;
            }
            set
            {
                enableSound = value;
                App.IniFile["EnableSound", "Misc"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"EnableSound(Misc) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string EnableMusic
        {
            get
            {
                return enableMusic;
            }
            set
            {
                enableMusic = value;
                App.IniFile["EnableMusic", "Misc"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"EnableMusic(Misc) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string MultipleInstances
        {
            get
            {
                return multipleInstances;
            }
            set
            {
                multipleInstances = value;
                App.IniFile["AllowMultipleInstances", "Misc"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"AllowMultipleInstances(Misc) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }

        public MiscPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            try
            {
                WindowedModesCollection = new ObservableCollection<string>() { "Full screen", "Windowed", "Bordered" };

                if (!App.IniFile.IsEmpty)
                {
                    WindowedModeIndex = int.Parse(App.IniFile["WindowedMode", "Misc"]);
                    SkipMovies = App.IniFile["SkipMovies", "Misc"];
                    EnableSound = App.IniFile["EnableSound", "Misc"];
                    EnableMusic = App.IniFile["EnableMusic", "Misc"];
                    MultipleInstances = App.IniFile["AllowMultipleInstances", "Misc"];
                }
                else
                {
                    WindowedModeIndex = -1;
                    SkipMovies = EnableSound = EnableMusic = MultipleInstances = null;
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
