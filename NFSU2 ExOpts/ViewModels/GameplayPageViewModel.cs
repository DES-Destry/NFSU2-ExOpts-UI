using DESTRY.IO.Debuging;
using System;
using System.Collections.ObjectModel;

namespace NFSU2_ExOpts.ViewModels
{
    class GameplayPageViewModel : BaseViewModel
    {
        private ObservableCollection<string> settingsCollection;

        private string enableHiddenCameraModes;
        private string enableDebugCamera;
        private string gameSpeed;
        private string worldAnimationSpeed;
        private int headlightsMode;
        private string lowBeamBrightness;
        private string highBeamBrightness;
        private string removeRaceBarriers;
        private string removeLockedAreaBarriers;
        private string showPercentOn1LapRaces;
        private string gameRegion;
        private string startingCash;
        private string unlockRegionalCars;
        private string unlockAllThings;
        private string neonBrightness;
        private string nosTrailRepeatCount;


        public ObservableCollection<string> SettingsCollection
        {
            get
            {
                return settingsCollection;
            }
            set
            {
                settingsCollection = value;
                OnPropertyChanged();
            }
        }

        public string EnableHiddenCameraModes
        {
            get
            {
                return enableHiddenCameraModes;
            }
            set
            {
                enableHiddenCameraModes = value;
                App.MainConfig["EnableHiddenCameraModes", "Gameplay"] = enableHiddenCameraModes;
                App.IsSavedData = false;

                Logs.WriteLog($"EnableHiddenCameraModes(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string EnableDebugCamera
        {
            get
            {
                return enableDebugCamera;
            }
            set
            {
                enableDebugCamera = value;
                App.MainConfig["EnableDebugCamera", "Gameplay"] = enableDebugCamera;
                App.IsSavedData = false;

                Logs.WriteLog($"EnableDebugCamera(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string GameSpeed
        {
            get
            {
                return gameSpeed;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    gameSpeed = result.ToString().Replace(",", ".");
                    App.MainConfig["GameSpeed", "Weather"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"GameSpeed(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"GameSpeed(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    gameSpeed = value;
                    OnPropertyChanged();
                }
            }
        }
        public string WorldAnimationSpeed
        {
            get
            {
                return worldAnimationSpeed;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    worldAnimationSpeed = result.ToString().Replace(",", ".");
                    App.MainConfig["WorldAnimationSpeed", "Weather"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"WorldAnimationSpeed(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"WorldAnimationSpeed(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    worldAnimationSpeed = value;
                    OnPropertyChanged();
                }
            }
        }
        public int HeadlightsMode
        {
            get
            {
                return headlightsMode;
            }
            set
            {
                headlightsMode = value;
                App.MainConfig["HeadlightsMode", "Gameplay"] = headlightsMode.ToString();
                App.IsSavedData = false;

                Logs.WriteLog($"HeadlightsMode(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string LowBeamBrightness
        {
            get
            {
                return lowBeamBrightness;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    lowBeamBrightness = result.ToString().Replace(",", ".");
                    App.MainConfig["LowBeamBrightness", "Weather"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"LowBeamBrightness(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"LowBeamBrightness(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    lowBeamBrightness = value;
                    OnPropertyChanged();
                }
            }
        }
        public string HighBeamBrightness
        {
            get
            {
                return highBeamBrightness;
            }
            set
            {
                if (double.TryParse(value.Replace(".", ","), out double result) && result >= 0)
                {
                    highBeamBrightness = result.ToString().Replace(",", ".");
                    App.MainConfig["HighBeamBrightness", "Weather"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"HighBeamBrightness(Weather) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"HighBeamBrightness(Weather) value not changed. It's empty. Waiting normal input...", "INFO");
                    highBeamBrightness = value;
                    OnPropertyChanged();
                }
            }
        }
        public string RemoveRaceBarriers
        {
            get
            {
                return removeRaceBarriers;
            }
            set
            {
                removeRaceBarriers = value;
                App.MainConfig["RemoveRaceBarriers", "Gameplay"] = removeRaceBarriers;
                App.IsSavedData = false;

                Logs.WriteLog($"RemoveRaceBarriers(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string RemoveLockedAreaBarriers
        {
            get
            {
                return removeLockedAreaBarriers;
            }
            set
            {
                removeLockedAreaBarriers = value;
                App.MainConfig["RemoveLockedAreaBarriers", "Gameplay"] = removeLockedAreaBarriers;
                App.IsSavedData = false;

                Logs.WriteLog($"RemoveLockedAreaBarriers(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowPercentOn1LapRaces
        {
            get
            {
                return showPercentOn1LapRaces;
            }
            set
            {
                showPercentOn1LapRaces = value;
                App.MainConfig["ShowPercentOn1LapRaces", "Gameplay"] = showPercentOn1LapRaces;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowPercentOn1LapRaces(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string GameRegion
        {
            get
            {
                return gameRegion;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result <= 127)
                {
                    gameRegion = result.ToString();
                    App.MainConfig["GameRegion", "Gameplay"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"GameRegion(Gameplay) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"GameRegion(Gameplay) value not changed. It's empty. Waiting normal input...", "INFO");
                    gameRegion = string.Empty;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"GameRegion(Gameplay) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    if (gameRegion.Length > 0)
                    {
                        GameRegion = value.Remove(value.Length - 1, 1);
                    }
                    else
                    {
                        GameRegion = string.Empty;
                    }
                    OnPropertyChanged();
                }
            }
        }
        public string StartingCash
        {
            get
            {
                return startingCash;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result <= 127)
                {
                    startingCash = result.ToString();
                    App.MainConfig["StartingCash", "Gameplay"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"StartingCash(Gameplay) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"StartingCash(Gameplay) value not changed. It's empty. Waiting normal input...", "INFO");
                    startingCash = string.Empty;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"StartingCash(Gameplay) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    if (startingCash.Length > 0)
                    {
                        StartingCash = value.Remove(value.Length - 1, 1);
                    }
                    else
                    {
                        StartingCash = string.Empty;
                    }
                    OnPropertyChanged();
                }
            }
        }
        public string UnlockRegionalCars
        {
            get
            {
                return unlockRegionalCars;
            }
            set
            {
                unlockRegionalCars = value;
                App.MainConfig["UnlockRegionalCars", "Gameplay"] = unlockRegionalCars;
                App.IsSavedData = false;

                Logs.WriteLog($"UnlockRegionalCars(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string UnlockAllThings
        {
            get
            {
                return unlockAllThings;
            }
            set
            {
                unlockAllThings = value;
                App.MainConfig["UnlockAllThings", "Gameplay"] = unlockAllThings;
                App.IsSavedData = false;

                Logs.WriteLog($"UnlockAllThings(Gameplay) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string NeonBrightness
        {
            get
            {
                return neonBrightness;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result <= 127)
                {
                    neonBrightness = result.ToString();
                    App.MainConfig["NeonBrightness", "Gameplay"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"NeonBrightness(Gameplay) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"NeonBrightness(Gameplay) value not changed. It's empty. Waiting normal input...", "INFO");
                    neonBrightness = string.Empty;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"NeonBrightness(Gameplay) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    if (neonBrightness.Length > 0)
                    {
                        NeonBrightness = value.Remove(value.Length - 1, 1);
                    }
                    else
                    {
                        NeonBrightness = string.Empty;
                    }
                    OnPropertyChanged();
                }
            }
        }
        public string NosTrailRepeatCount
        {
            get
            {
                return nosTrailRepeatCount;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0 && result <= 127)
                {
                    nosTrailRepeatCount = result.ToString();
                    App.MainConfig["NosTrailRepeatCount", "Gameplay"] = value;
                    App.IsSavedData = false;

                    Logs.WriteLog($"NosTrailRepeatCount(Gameplay) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"NosTrailRepeatCount(Gameplay) value not changed. It's empty. Waiting normal input...", "INFO");
                    nosTrailRepeatCount = string.Empty;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"NosTrailRepeatCount(Gameplay) value not changed. It's bullshit. Waiting normal input...", "INFO");
                    if (nosTrailRepeatCount.Length > 0)
                    {
                        NosTrailRepeatCount = value.Remove(value.Length - 1, 1);
                    }
                    else
                    {
                        NosTrailRepeatCount = string.Empty;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public GameplayPageViewModel()
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
                SettingsCollection = new ObservableCollection<string>() { "Off", "Low", "High" };

                if (!App.MainConfig.IsEmpty)
                {
                    EnableHiddenCameraModes = App.MainConfig["EnableHiddenCameraModes", "Gameplay"];
                    EnableDebugCamera = App.MainConfig["EnableDebugCamera", "Gameplay"];
                    GameSpeed = App.MainConfig["GameSpeed", "Gameplay"];
                    WorldAnimationSpeed = App.MainConfig["WorldAnimationSpeed", "Gameplay"];
                    HeadlightsMode = int.Parse(App.MainConfig["HeadlightsMode", "Gameplay"]);
                    LowBeamBrightness = App.MainConfig["LowBeamBrightness", "Gameplay"];
                    HighBeamBrightness = App.MainConfig["HighBeamBrightness", "Gameplay"];
                    RemoveRaceBarriers = App.MainConfig["RemoveRaceBarriers", "Gameplay"];
                    RemoveLockedAreaBarriers = App.MainConfig["RemoveLockedAreaBarriers", "Gameplay"];
                    ShowPercentOn1LapRaces = App.MainConfig["ShowPercentOn1LapRaces", "Gameplay"];
                    GameRegion = App.MainConfig["GameRegion", "Gameplay"];
                    StartingCash = App.MainConfig["StartingCash", "Gameplay"];
                    UnlockRegionalCars = App.MainConfig["UnlockRegionalCars", "Gameplay"];
                    UnlockAllThings = App.MainConfig["UnlockAllThings", "Gameplay"];
                    NeonBrightness = App.MainConfig["NeonBrightness", "Gameplay"];
                    NosTrailRepeatCount = App.MainConfig["NosTrailRepeatCount", "Gameplay"];
                }
                else
                {
                    EnableHiddenCameraModes = EnableDebugCamera = GameSpeed = WorldAnimationSpeed = LowBeamBrightness = HighBeamBrightness = RemoveRaceBarriers = RemoveLockedAreaBarriers = ShowPercentOn1LapRaces = GameRegion = StartingCash = UnlockRegionalCars = UnlockAllThings = NeonBrightness = NosTrailRepeatCount = string.Empty;
                    HeadlightsMode = -1;
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
