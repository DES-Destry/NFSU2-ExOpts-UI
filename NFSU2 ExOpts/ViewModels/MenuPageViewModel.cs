using DESTRY.IO.Debuging;
using System;

namespace NFSU2_ExOpts.ViewModels
{
    class MenuPageViewModel : BaseViewModel
    {
        private string showOutrun;
        private string showMoreRaceOptions;
        private string showMoreCustomizationOptions;
        private string showOnline;
        private string showSubs;
        private string showSpecialVinyls;
        private string showDebugCarCustomize;
        private string showDebugEventID;
        private string anyTrackInAnyRaceMode;
        private string freeRunTrackSelect;
        private string outrunTrackSelect;
        private string splashScreenTimeLimit;
        private string showcaseCamInfiniteYRotation;
        private string allowLongerProfileNames;
        private string disableTakeover;

        public string ShowOutrun
        {
            get
            {
                return showOutrun;
            }
            set
            {
                showOutrun = value;
                App.IniFile["ShowOutrun", "Menu"] = showOutrun;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowOutrun(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowMoreRaceOptions
        {
            get
            {
                return showMoreRaceOptions;
            }
            set
            {
                showMoreRaceOptions = value;
                App.IniFile["ShowMoreRaceOptions", "Menu"] = showMoreRaceOptions;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowMoreRaceOptions(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowMoreCustomizationOptions
        {
            get
            {
                return showMoreCustomizationOptions;
            }
            set
            {
                showMoreCustomizationOptions = value;
                App.IniFile["ShowMoreCustomizationOptions", "Menu"] = showMoreCustomizationOptions;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowMoreCustomizationOptions(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowOnline
        {
            get
            {
                return showOnline;
            }
            set
            {
                showOnline = value;
                App.IniFile["ShowOnline", "Menu"] = showOnline;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowOnline(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowSubs
        {
            get
            {
                return showSubs;
            }
            set
            {
                showSubs = value;
                App.IniFile["ShowSubs", "Menu"] = showSubs;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowSubs(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowSpecialVinyls
        {
            get
            {
                return showSpecialVinyls;
            }
            set
            {
                showSpecialVinyls = value;
                App.IniFile["ShowSpecialVinyls", "Menu"] = showSpecialVinyls;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowSpecialVinyls(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowDebugCarCustomize
        {
            get
            {
                return showDebugCarCustomize;
            }
            set
            {
                showDebugCarCustomize = value;
                App.IniFile["ShowDebugCarCustomize", "Menu"] = showDebugCarCustomize;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowDebugCarCustomize(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ShowDebugEventID
        {
            get
            {
                return showDebugEventID;
            }
            set
            {
                showDebugEventID = value;
                App.IniFile["ShowDebugEventID", "Menu"] = showDebugEventID;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowDebugEventID(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string AnyTrackInAnyRaceMode
        {
            get
            {
                return anyTrackInAnyRaceMode;
            }
            set
            {
                anyTrackInAnyRaceMode = value;
                App.IniFile["AnyTrackInAnyRaceMode", "Menu"] = anyTrackInAnyRaceMode;
                App.IsSavedData = false;

                Logs.WriteLog($"AnyTrackInAnyRaceMode(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string FreeRunTrackSelect
        {
            get
            {
                return freeRunTrackSelect;
            }
            set
            {
                freeRunTrackSelect = value;
                App.IniFile["FreeRunTrackSelect", "Menu"] = freeRunTrackSelect;
                App.IsSavedData = false;

                Logs.WriteLog($"FreeRunTrackSelect(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string OutrunTrackSelect
        {
            get
            {
                return outrunTrackSelect;
            }
            set
            {
                outrunTrackSelect = value;
                App.IniFile["OutrunTrackSelect", "Menu"] = outrunTrackSelect;
                App.IsSavedData = false;

                Logs.WriteLog($"OutrunTrackSelect(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string SplashScreenTimeLimit
        {
            get
            {
                return splashScreenTimeLimit;
            }
            set
            {
                if (int.TryParse(value, out int result) && result >= 0)
                {
                    splashScreenTimeLimit = result.ToString();
                    App.IniFile["SplashScreenTimeLimit", "Menu"] = splashScreenTimeLimit;
                    App.IsSavedData = false;

                    Logs.WriteLog($"SplashScreenTimeLimit(Menu) value has been changed to {value}", "INFO");

                    OnPropertyChanged();
                }
                else if (value == string.Empty)
                {
                    Logs.WriteLog($"SplashScreenTimeLimit(Menu) value not changed. It's empty. Waiting normal input...", "INFO");
                    splashScreenTimeLimit = value;
                    OnPropertyChanged();
                }
                else
                {
                    Logs.WriteLog($"SplashScreenTimeLimit(Menu) value not changed. It's bullshit. Lastest change not applied.", "INFO");
                    if (splashScreenTimeLimit.Length > 0)
                    {
                        SplashScreenTimeLimit = value.Remove(value.Length - 1, 1);
                    }
                    else
                    {
                        SplashScreenTimeLimit = string.Empty;
                    }
                    OnPropertyChanged();
                }
            }
        }
        public string ShowcaseCamInfiniteYRotation
        {
            get
            {
                return showcaseCamInfiniteYRotation;
            }
            set
            {
                showcaseCamInfiniteYRotation = value;
                App.IniFile["ShowcaseCamInfiniteYRotation", "Menu"] = showcaseCamInfiniteYRotation;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowcaseCamInfiniteYRotation(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string AllowLongerProfileNames
        {
            get
            {
                return allowLongerProfileNames;
            }
            set
            {
                allowLongerProfileNames = value;
                App.IniFile["AllowLongerProfileNames", "Menu"] = allowLongerProfileNames;
                App.IsSavedData = false;

                Logs.WriteLog($"AllowLongerProfileNames(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string DisableTakeover
        {
            get
            {
                return disableTakeover;
            }
            set
            {
                disableTakeover = value;
                App.IniFile["DisableTakeover", "Menu"] = disableTakeover;
                App.IsSavedData = false;

                Logs.WriteLog($"DisableTakeover(Menu) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }


        public MenuPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            try
            {
                if (!App.IniFile.IsEmpty)
                {
                    ShowOutrun = App.IniFile["ShowOutrun", "Menu"];
                    ShowMoreRaceOptions = App.IniFile["ShowMoreRaceOptions", "Menu"];
                    ShowMoreCustomizationOptions = App.IniFile["ShowMoreCustomizationOptions", "Menu"];
                    ShowOnline = App.IniFile["ShowOnline", "Menu"];
                    ShowSubs = App.IniFile["ShowSubs", "Menu"];
                    ShowSpecialVinyls = App.IniFile["ShowSpecialVinyls", "Menu"];
                    ShowDebugCarCustomize = App.IniFile["ShowDebugCarCustomize", "Menu"];
                    ShowDebugEventID = App.IniFile["ShowDebugEventID", "Menu"];
                    AnyTrackInAnyRaceMode = App.IniFile["AnyTrackInAnyRaceMode", "Menu"];
                    FreeRunTrackSelect = App.IniFile["FreeRunTrackSelect", "Menu"];
                    OutrunTrackSelect = App.IniFile["OutrunTrackSelect", "Menu"];
                    SplashScreenTimeLimit = App.IniFile["SplashScreenTimeLimit", "Menu"];
                    ShowcaseCamInfiniteYRotation = App.IniFile["ShowcaseCamInfiniteYRotation", "Menu"];
                    AllowLongerProfileNames = App.IniFile["AllowLongerProfileNames", "Menu"];
                    DisableTakeover = App.IniFile["DisableTakeover", "Menu"];
                }
                else
                {
                    ShowOutrun = ShowMoreRaceOptions = ShowMoreCustomizationOptions = ShowOnline = ShowSubs = ShowSpecialVinyls = ShowDebugCarCustomize = ShowDebugEventID = AnyTrackInAnyRaceMode = FreeRunTrackSelect = OutrunTrackSelect = SplashScreenTimeLimit = ShowcaseCamInfiniteYRotation = AllowLongerProfileNames = DisableTakeover = "NULL";
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
