using DESTRY.IO.Debuging;
using System;

namespace NFSU2_ExOpts.ViewModels
{
    class FixesPageViewModel : BaseViewModel
    {
        private string disappearingWheelsFix;
        private string experimentalSplitScreenFix;
        private string hoodDecalsFix;
        private string cabinNeonFix;

        public string DisappearingWheelsFix
        {
            get
            {
                return disappearingWheelsFix;
            }
            set
            {
                disappearingWheelsFix = value;
                App.IniFile["DisappearingWheelsFix", "Fixes"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"DisappearingWheelsFix(Fixes) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string ExperimentalSplitScreenFix
        {
            get
            {
                return experimentalSplitScreenFix;
            }
            set
            {
                experimentalSplitScreenFix = value;
                App.IniFile["ExperimentalSplitScreenFix", "Fixes"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"ExperimentalSplitScreenFix(Fixes) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string HoodDecalsFix
        {
            get
            {
                return hoodDecalsFix;
            }
            set
            {
                hoodDecalsFix = value;
                App.IniFile["HoodDecalsFix", "Fixes"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"HoodDecalsFix(Fixes) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string CabinNeonFix
        {
            get
            {
                return cabinNeonFix;
            }
            set
            {
                cabinNeonFix = value;
                App.IniFile["CabinNeonFix", "Fixes"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"CabinNeonFix(Fixes) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }

        public FixesPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            try
            {
                if (!App.IniFile.IsEmpty)
                {
                    DisappearingWheelsFix = App.IniFile["DisappearingWheelsFix", "Fixes"];
                    ExperimentalSplitScreenFix = App.IniFile["ExperimentalSplitScreenFix", "Fixes"];
                    HoodDecalsFix = App.IniFile["HoodDecalsFix", "Fixes"];
                    CabinNeonFix = App.IniFile["CabinNeonFix", "Fixes"];
                }
                else
                {
                    DisappearingWheelsFix = ExperimentalSplitScreenFix = HoodDecalsFix = CabinNeonFix = "NULL";
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
