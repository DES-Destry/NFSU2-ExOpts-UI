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
                App.MainConfig["AnyTrackInAnyMode", "Hotkeys "] = value;
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
                App.MainConfig["Headlights", "Hotkeys "] = value;
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
                App.MainConfig["FreezeCamera", "Hotkeys "] = value;
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
                App.MainConfig["UnlockAllThings", "Hotkeys "] = value;
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
                App.MainConfig["AutoDrive", "Hotkeys "] = value;
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
                App.MainConfig["EnableSaveLoadHotPos", "Hotkeys "] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"EnableSaveLoadHotPos(Hotkeys) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }


        public HotkeysPageViewModel()
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
                if (!App.MainConfig.IsEmpty)
                {
                    AnyTrackInAnyMode = App.MainConfig["AnyTrackInAnyMode", "Hotkeys "];
                    Headlights = App.MainConfig["Headlights", "Hotkeys "];
                    FreezeCamera = App.MainConfig["FreezeCamera", "Hotkeys "];
                    UnlockAllThings = App.MainConfig["UnlockAllThings", "Hotkeys "];
                    AutoDrive = App.MainConfig["AutoDrive", "Hotkeys "];
                    EnableSaveLoadHotPos = App.MainConfig["EnableSaveLoadHotPos", "Hotkeys "];
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
