using DESTRY.IO.Debuging;
using NFSU2_ExOpts.Models;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace NFSU2_ExOpts.ViewModels
{
    class SettingsPageViewModel : BaseViewModel
    {
        private string lastUIVersion;
        private string lastExOptsVersion;

        private Visibility notSavedVisibility;
        private Visibility connectionErrorVisibility;
        private Visibility updateAviableVisibility;


        public string ConfigPath
        {
            get
            {
                if (App.IsMainConfigOpened)
                {
                    return "Current file:   Main NFSU2 ExOpts configuration file.";
                }
                else
                {
                    return $"Current file:  {Path.GetFullPath(App.CustomConfigPath)}";
                }
            }
            set
            {
                OnPropertyChanged();
            }
        }
        public string CurrentUIVersion
        {
            get
            {
                return $"Current UI version: {App.Version}";
            }
            set
            {
                OnPropertyChanged();
            }
        }
        public string CurrentExOptsVersion
        {
            get
            {
                return $"Current ExOpts version: {App.ExOptsVersion}";
            }
        }
        public string LastUIVersion
        {
            get
            {
                return lastUIVersion;
            }
            set
            {
                lastUIVersion = value;
                OnPropertyChanged();
            }
        }
        public string LastExOptsVersion
        {
            get
            {
                return lastExOptsVersion;
            }
            set
            {
                lastExOptsVersion = value;
                OnPropertyChanged();
            }
        }

        public Visibility NotSavedVisibility
        {
            get
            {
                return notSavedVisibility;
            }
            set
            {
                notSavedVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility ConnectionErrorVisibility
        {
            get
            {
                return connectionErrorVisibility;
            }
            set
            {
                connectionErrorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility UpdateAviableVisibility
        {
            get
            {
                return updateAviableVisibility;
            }
            set
            {
                updateAviableVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => new BaseCommand(obj => Save());
        public ICommand CancelCommand => new BaseCommand(obj => Cancel());
        public ICommand DefaultCommand => new BaseCommand(obj => Default());
        public ICommand InstallerCommand => new BaseCommand(obj => OpenInstaller());


        public SettingsPageViewModel()
        {
            NotSavedVisibility = Visibility.Collapsed;

            if (App.ConnectionError) ConnectionErrorVisibility = Visibility.Visible;
            else ConnectionErrorVisibility = Visibility.Collapsed;

            UpdateAviableVisibility = Visibility.Collapsed;

            App.OnSavedDataChanged += SavedChanged;
            App.OnLastVersionDataGetted += LastVersionInfoGetted;
        }

        private void SavedChanged()
        {
            if (!App.IsSavedData) NotSavedVisibility = Visibility.Visible;
            else NotSavedVisibility = Visibility.Collapsed;
        }
        private void LastVersionInfoGetted()
        {
            if (App.ConnectionError) ConnectionErrorVisibility = Visibility.Visible;
            else ConnectionErrorVisibility = Visibility.Collapsed;

            if ((!App.ConnectionError && App.LastVersion != null && App.ExOptsLastVersion != null) && (App.Version != App.LastVersion || App.ExOptsVersion != App.ExOptsLastVersion))
            {
                UpdateAviableVisibility = Visibility.Visible;
            }
            else
            {
                UpdateAviableVisibility = Visibility.Collapsed;
            }

            if (!App.ConnectionError && App.LastVersion != null && App.ExOptsLastVersion != null)
            {
                LastUIVersion = $"Last UI version:        {App.LastVersion}";
                LastExOptsVersion = $"Last ExOpts version:        {App.ExOptsLastVersion}";
            }
            else
            {
                LastUIVersion = "Last UI version:        error";
                LastExOptsVersion = "Last ExOpts version:        error";
            }
        }

        private void Save()
        {
            App.MainConfig.Save();
            App.IsSavedData = true;

            Logs.WriteLog("All user changes has been applied.", "INFO");
        }
        private void Cancel()
        {
            if (!App.IsSavedData)
            {
                App.MainConfig.Clear();
                if (App.IsMainConfigOpened)
                {
                    App.MainConfig.Load(App.MainConfigPath);
                }
                else
                {
                    App.MainConfig.Load(App.CustomConfigPath);
                }

                App.UpdateConfig();
                App.IsSavedData = true;

                Logs.WriteLog("All user changes has been canceled.", "INFO");
            }
        }
        private void Default()
        {
            App.MainConfig["AnyTrackInAnyMode", "Hotkeys "] = "36";
            App.MainConfig["Headlights", "Hotkeys "] = "72";
            App.MainConfig["FreezeCamera", "Hotkeys "] = "19";
            App.MainConfig["UnlockAllThings", "Hotkeys "] = "116";
            App.MainConfig["AutoDrive", "Hotkeys "] = "117";
            App.MainConfig["EnableSaveLoadHotPos", "Hotkeys "] = "0";

            App.MainConfig["Minimum", "LapControllers"] = "0";
            App.MainConfig["Maximum", "LapControllers"] = "127";
            App.MainConfig["KOEnabled", "LapControllers"] = "5";

            App.MainConfig["Minimum", "OpponentControllers"] = "0";
            App.MainConfig["Maximum", "OpponentControllers"] = "5";
            App.MainConfig["KOEnabled", "OpponentControllers"] = "5";
            App.MainConfig["MaximumLANPlayers", "OpponentControllers"] = "6";

            App.MainConfig["MaximumMultiplier", "Drift"] = "5";
            App.MainConfig["PlusSign", "Drift"] = "0";
            App.MainConfig["ShowWithoutMultiplying", "Drift"] = "0";

            App.MainConfig["ShowOutrun", "Menu"] = "0";
            App.MainConfig["ShowMoreRaceOptions", "Menu"] = "1";
            App.MainConfig["ShowMoreCustomizationOptions", "Menu"] = "1";
            App.MainConfig["ShowOnline", "Menu"] = "1";
            App.MainConfig["ShowSubs", "Menu"] = "0";
            App.MainConfig["ShowSpecialVinyls", "Menu"] = "1";
            App.MainConfig["ShowDebugCarCustomize", "Menu"] = "0";
            App.MainConfig["ShowDebugEventID", "Menu"] = "0";
            App.MainConfig["AnyTrackInAnyRaceMode", "Menu"] = "0";
            App.MainConfig["FreeRunTrackSelect", "Menu"] = "1";
            App.MainConfig["OutrunTrackSelect", "Menu"] = "1";
            App.MainConfig["SplashScreenTimeLimit", "Menu"] = "30";
            App.MainConfig["ShowcaseCamInfiniteYRotation", "Menu"] = "0";
            App.MainConfig["AllowLongerProfileNames", "Menu"] = "1";
            App.MainConfig["DisableTakeover", "Menu"] = "0";

            App.MainConfig["EnableHiddenCameraModes", "Gameplay"] = "0";
            App.MainConfig["EnableDebugCamera", "Gameplay"] = "0";
            App.MainConfig["GameSpeed", "Gameplay"] = "1";
            App.MainConfig["WorldAnimationSpeed", "Gameplay"] = "45";
            App.MainConfig["HeadlightsMode", "Gameplay"] = "2";
            App.MainConfig["LowBeamBrightness", "Gameplay"] = "0.75";
            App.MainConfig["HighBeamBrightness", "Gameplay"] = "1";
            App.MainConfig["RemoveRaceBarriers", "Gameplay"] = "0";
            App.MainConfig["RemoveLockedAreaBarriers", "Gameplay"] = "0";
            App.MainConfig["ShowPercentOn1LapRaces", "Gameplay"] = "1";
            App.MainConfig["GameRegion", "Gameplay"] = "0";
            App.MainConfig["StartingCash", "Gameplay"] = "0";
            App.MainConfig["UnlockRegionalCars", "Gameplay"] = "1";
            App.MainConfig["UnlockAllThings", "Gameplay"] = "0";
            App.MainConfig["NeonBrightness", "Gameplay"] = "1";
            App.MainConfig["NosTrailRepeatCount", "Gameplay"] = "8";

            App.MainConfig["AlwaysRain", "Weather"] = "0";
            App.MainConfig["GeneralRainAmount", "Weather"] = "1";
            App.MainConfig["RoadReflectionAmount", "Weather"] = "1";
            App.MainConfig["RainSize", "Weather"] = "0.03";
            App.MainConfig["RainIntensity", "Weather"] = "0.7";
            App.MainConfig["RainCrossing", "Weather"] = "0.02";
            App.MainConfig["RainSpeed", "Weather"] = "0.03";
            App.MainConfig["RainGravity", "Weather"] = "0.35";

            App.MainConfig["DisappearingWheelsFix", "Fixes"] = "1";
            App.MainConfig["ExperimentalSplitScreenFix", "Fixes"] = "0";
            App.MainConfig["HoodDecalsFix", "Fixes"] = "1";
            App.MainConfig["CabinNeonFix", "Fixes"] = "1";

            App.MainConfig["WindowedMode", "Misc"] = "0";
            App.MainConfig["SkipMovies", "Misc"] = "0";
            App.MainConfig["EnableSound", "Misc"] = "1";
            App.MainConfig["EnableMusic", "Misc"] = "1";
            App.MainConfig["AllowMultipleInstances", "Misc"] = "0";

            App.UpdateConfig();
        }
        private void OpenInstaller()
        {
            //Opening installer app(installer now not created!)
        }
    }
}
