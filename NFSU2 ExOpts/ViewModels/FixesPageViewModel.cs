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
                App.MainConfig["DisappearingWheelsFix", "Fixes"] = value;
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
                App.MainConfig["ExperimentalSplitScreenFix", "Fixes"] = value;
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
                App.MainConfig["HoodDecalsFix", "Fixes"] = value;
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
                App.MainConfig["CabinNeonFix", "Fixes"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"CabinNeonFix(Fixes) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }

        public FixesPageViewModel()
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
                    DisappearingWheelsFix = App.MainConfig["DisappearingWheelsFix", "Fixes"];
                    ExperimentalSplitScreenFix = App.MainConfig["ExperimentalSplitScreenFix", "Fixes"];
                    HoodDecalsFix = App.MainConfig["HoodDecalsFix", "Fixes"];
                    CabinNeonFix = App.MainConfig["CabinNeonFix", "Fixes"];
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
