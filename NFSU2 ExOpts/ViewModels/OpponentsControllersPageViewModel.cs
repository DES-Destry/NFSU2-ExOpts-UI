using System.Collections.ObjectModel;

namespace NFSU2_ExOpts.ViewModels
{
    class OpponentsControllersPageViewModel : BaseViewModel
    {

        private ObservableCollection<string> zeroFiveCollection;
        private ObservableCollection<string> twoSixCollection;
        private int minimumCurrentItem;
        private int maximumCurrentItem;
        private int koEnabledCurrentItem;
        private int maxLanPlayersCurrentItem;

        public ObservableCollection<string> ZeroFiveCollection 
        { 
            get 
            {
                return zeroFiveCollection;
            }
            set
            {
                zeroFiveCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<string> TwoSixCollection
        {
            get
            {
                return twoSixCollection;
            }
            set
            {
                twoSixCollection = value;
                OnPropertyChanged();
            }
        }
        public int MinimumCurrentItem
        {
            get
            {
                return minimumCurrentItem;
            }
            set
            {
                if (maximumCurrentItem >= value)
                {
                    minimumCurrentItem = value;
                    App.IniFile["Minimum"] = minimumCurrentItem.ToString();

                    OnPropertyChanged();
                }
                else
                {
                    minimumCurrentItem--;
                }
            }
        }
        public int MaximumCurrentItem
        {
            get
            {
                return maximumCurrentItem;
            }
            set
            {
                if (minimumCurrentItem <= value)
                {
                    maximumCurrentItem = value;
                    App.IniFile["Maximum"] = maximumCurrentItem.ToString();

                    OnPropertyChanged();
                }
                else
                {
                    maximumCurrentItem++;
                }
            }
        }
        public int KoEnabledCurrentItem
        {
            get
            {
                return koEnabledCurrentItem;
            }
            set
            {
                koEnabledCurrentItem = value;
                App.IniFile["KOEnabled"] = koEnabledCurrentItem.ToString();

                OnPropertyChanged();
            }
        }
        public int MaxLanPlayersCurrentItem
        {
            get
            {
                return maxLanPlayersCurrentItem + 2;
            }
            set
            {
                maxLanPlayersCurrentItem = value - 2;
                App.IniFile["MaximumLANPlayers"] = maxLanPlayersCurrentItem.ToString();

                OnPropertyChanged();
            }
        }
        public int MaxLanPlayersCurrentItemIndex
        {
            get
            {
                return maxLanPlayersCurrentItem;
            }
            set
            {
                maxLanPlayersCurrentItem = value;
                App.IniFile["MaximumLANPlayers"] = maxLanPlayersCurrentItem.ToString();

                OnPropertyChanged();
            }
        }

        public OpponentsControllersPageViewModel()
        {
            SetValues();
        }

        private void SetValues()
        {
            ZeroFiveCollection = new ObservableCollection<string>() { "0", "1", "2", "3", "4", "5" };
            TwoSixCollection = new ObservableCollection<string>() { "2", "3", "4", "5", "6" };

            if (!App.IniFile.IsEmpty)
            {
                MinimumCurrentItem = int.Parse(App.IniFile["Minimum", "OpponentControllers"]);
                MaximumCurrentItem = int.Parse(App.IniFile["Maximum", "OpponentControllers"]);
                KoEnabledCurrentItem = int.Parse(App.IniFile["KOEnabled", "OpponentControllers"]);
                MaxLanPlayersCurrentItem = int.Parse(App.IniFile["MaximumLANPlayers", "OpponentControllers"]);
            }
            else
            {
                MinimumCurrentItem = MaximumCurrentItem = KoEnabledCurrentItem = MaxLanPlayersCurrentItem = -1;
            }
        }
    }
}
