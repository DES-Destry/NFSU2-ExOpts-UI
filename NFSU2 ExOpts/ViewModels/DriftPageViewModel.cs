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
                App.IniFile["MaximumMultiplier", "Drift"] = value.ToString();
                App.IsSavedData = false;

                OnPropertyChanged();
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
                App.IniFile["MaximumMultiplier", "Drift"] = value.ToString();
                App.IsSavedData = false;

                OnPropertyChanged();
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
                App.IniFile["PlusSign", "Drift"] = value;
                App.IsSavedData = false;

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
                App.IniFile["ShowWithoutMultiplying", "Drift"] = value;
                App.IsSavedData = false;

                OnPropertyChanged();
            }
        }

        public DriftPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            try
            {
                OneNineCollection = new ObservableCollection<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

                if (!App.IniFile.IsEmpty)
                {
                    MaxMultiplierCurrentItem = int.Parse(App.IniFile["MaximumMultiplier", "Drift"]);
                    PlusSignSelected = App.IniFile["PlusSign", "Drift"];
                    HideMultiplierSelected = App.IniFile["ShowWithoutMultiplying", "Drift"];
                }
                else
                {
                    MaxMultiplierCurrentItem = -1;
                    PlusSignSelected = null;
                    HideMultiplierSelected = null;
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
