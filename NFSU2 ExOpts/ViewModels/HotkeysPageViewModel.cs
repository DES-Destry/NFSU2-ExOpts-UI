using DESTRY.IO.Debuging;
using System;

namespace NFSU2_ExOpts.ViewModels
{
    public class HotkeysPageViewModel : BaseViewModel
    {
        private string anyTrackInAnyMode;
        private string headlights;
        private string freezeCamera;
        private string unlockAllThings;
        private string autoDrive;
        private string enableSaveLoadHotPos;


        public string AnyTrackInAnyMode
        {
            get
            {
                return anyTrackInAnyMode;
            }
            set
            {
                anyTrackInAnyMode = value;
                App.IniFile["AnyTrackInAnyMode", "Hotkeys "] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"AnyTrackInAnyMode(Hotkeys) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string Headlights
        {
            get
            {
                return headlights;
            }
            set
            {
                headlights = value;
                App.IniFile["Headlights", "Hotkeys "] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"Headlights(Hotkeys) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string FreezeCamera
        {
            get
            {
                return freezeCamera;
            }
            set
            {
                freezeCamera = value;
                App.IniFile["FreezeCamera", "Hotkeys "] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"FreezeCamera(Hotkeys) value has been changed to {value}", "INFO");

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
                App.IniFile["UnlockAllThings", "Hotkeys "] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"UnlockAllThings(Hotkeys) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string AutoDrive
        {
            get
            {
                return autoDrive;
            }
            set
            {
                autoDrive = value;
                App.IniFile["AutoDrive", "Hotkeys "] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"AutoDrive(Hotkeys) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string EnableSaveLoadHotPos
        {
            get
            {
                return enableSaveLoadHotPos;
            }
            set
            {
                enableSaveLoadHotPos = value;
                App.IniFile["EnableSaveLoadHotPos", "Hotkeys "] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"EnableSaveLoadHotPos(Hotkeys) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }


        public HotkeysPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            try
            {
                if (!App.IniFile.IsEmpty)
                {
                    AnyTrackInAnyMode = App.IniFile["AnyTrackInAnyMode", "Hotkeys "];
                    Headlights = App.IniFile["Headlights", "Hotkeys "];
                    FreezeCamera = App.IniFile["FreezeCamera", "Hotkeys "];
                    UnlockAllThings = App.IniFile["UnlockAllThings", "Hotkeys "];
                    AutoDrive = App.IniFile["AutoDrive", "Hotkeys "];
                    EnableSaveLoadHotPos = App.IniFile["EnableSaveLoadHotPos", "Hotkeys "];
                }
                else
                {
                    AnyTrackInAnyMode = Headlights = FreezeCamera = UnlockAllThings = AutoDrive = EnableSaveLoadHotPos = "NULL";
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
