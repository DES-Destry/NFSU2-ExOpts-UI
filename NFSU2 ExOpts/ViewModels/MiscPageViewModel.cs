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
                App.MainConfig["WindowedMode", "Misc"] = value.ToString();
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
                App.MainConfig["SkipMovies", "Misc"] = value;
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
                App.MainConfig["EnableSound", "Misc"] = value;
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
                App.MainConfig["EnableMusic", "Misc"] = value;
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
                App.MainConfig["AllowMultipleInstances", "Misc"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"AllowMultipleInstances(Misc) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }

        public MiscPageViewModel()
        {
            try
            {
                App.OnOutDataUpdated += SetValues;
                SetValues();
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        private void SetValues()
        {
            try
            {
                WindowedModesCollection = new ObservableCollection<string>() { "Full screen", "Windowed", "Bordered" };

                if (!App.MainConfig.IsEmpty)
                {
                    WindowedModeIndex = int.Parse(App.MainConfig["WindowedMode", "Misc"]);
                    SkipMovies = App.MainConfig["SkipMovies", "Misc"];
                    EnableSound = App.MainConfig["EnableSound", "Misc"];
                    EnableMusic = App.MainConfig["EnableMusic", "Misc"];
                    MultipleInstances = App.MainConfig["AllowMultipleInstances", "Misc"];
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
