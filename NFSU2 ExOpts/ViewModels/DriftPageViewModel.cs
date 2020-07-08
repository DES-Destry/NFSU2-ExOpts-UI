using DESTRY.IO.Debuging;
using System;
using System.Collections.ObjectModel;

namespace NFSU2_ExOpts.ViewModels
{
    class DriftPageViewModel : BaseViewModel
    {
        private ObservableCollection<string> oneNineCollection;

        private int maxMultiplierCurrentItem;
        private string plusSignSelected;
        private string hideMultiplierSelected;


        public ObservableCollection<string> OneNineCollection
        {
            get
            {
                return oneNineCollection;
            }
            set
            {
                oneNineCollection = value;
                OnPropertyChanged();
            }
        }

        public int MaxMultiplierCurrentItem
        {
            get
            {
                return maxMultiplierCurrentItem + 1;
            }
            set
            {
                maxMultiplierCurrentItem = value - 1;
                App.MainConfig["MaximumMultiplier", "Drift"] = value.ToString();
                App.IsSavedData = false;

                OnPropertyChanged();
                OnPropertyChanged("MaxMultiplierCurrentItemIndex");
            }
        }
        public int MaxMultiplierCurrentItemIndex
        {
            get
            {
                return maxMultiplierCurrentItem;
            }
            set
            {
                maxMultiplierCurrentItem = value;
                App.MainConfig["MaximumMultiplier", "Drift"] = oneNineCollection[value];
                App.IsSavedData = false;

                Logs.WriteLog($"MaximumMultiplier(Drift) value has been changed to {oneNineCollection[value]}", "INFO");

                OnPropertyChanged();
                OnPropertyChanged("MaxMultiplierCurrentItem");
            }
        }
        public string PlusSignSelected
        {
            get
            {
                return plusSignSelected;
            }
            set
            {
                plusSignSelected = value;
                App.MainConfig["PlusSign", "Drift"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"PlusSign(Drift) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }
        public string HideMultiplierSelected
        {
            get
            {
                return hideMultiplierSelected;
            }
            set
            {
                hideMultiplierSelected = value;
                App.MainConfig["ShowWithoutMultiplying", "Drift"] = value;
                App.IsSavedData = false;

                Logs.WriteLog($"ShowWithoutMultiplying(Drift) value has been changed to {value}", "INFO");

                OnPropertyChanged();
            }
        }

        public DriftPageViewModel()
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
                OneNineCollection = new ObservableCollection<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                if (!App.MainConfig.IsEmpty)
                {
                    MaxMultiplierCurrentItem = int.Parse(App.MainConfig["MaximumMultiplier", "Drift"]);
                    PlusSignSelected = App.MainConfig["PlusSign", "Drift"];
                    HideMultiplierSelected = App.MainConfig["ShowWithoutMultiplying", "Drift"];
                }
                else
                {
                    MaxMultiplierCurrentItem = -1;
                    PlusSignSelected = HideMultiplierSelected = null; 
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
