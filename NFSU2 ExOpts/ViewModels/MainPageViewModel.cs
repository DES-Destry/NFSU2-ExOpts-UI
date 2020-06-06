using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NFSU2_ExOpts.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Page gamePage;
        private Page menuPage;
        private Page gameplayPage;
        private Page weatherPage;
        private Page lapControllersPage;
        private Page opponentsControllersPage;
        private Page driftPage;
        private Page hotkeysPage;
        private Page miscPage;
        private Page fixesPage;
        private Page presetsPage;

        private Page gameSplashScreenPage;
        private Page menuSplashScreenPage;
        private Page gameplaySplashScreenPage;
        private Page weatherSplashScreenPage;
        private Page lapControllersSplashScreenPage;
        private Page opponentsControllersSplashScreenPage;
        private Page driftSplashScreenPage;
        private Page hotkeysSplashScreenPage;
        private Page miscSplashScreenPage;
        private Page fixesSplashScreenPage;
        private Page presetsSplashScreenPage;

        private bool isGamePageAtScreen = false;
        private bool isMenuPageAtScreen = false;
        private bool isGameplayPageAtScreen = false;
        private bool isWeatherPageAtScreen = false;
        private bool isLapControllersPageAtScreen = false;
        private bool isOpponentsControllersPageAtScreen = false;
        private bool isDriftPageAtScreen = false;
        private bool isHotkeysPageAtScreen = false;
        private bool isMiscPageAtScreen = false;
        private bool isFixesPageAtScreen = false;
        private bool isPresetsPageAtScreen = false;

        private Page currentPage;

        private double pageOpacity;


        public bool IsGamePageAtScreen
        {
            get
            {
                return isGamePageAtScreen;
            }
            set
            {
                isGamePageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsMenuPageAtScreen
        {
            get
            {
                return isMenuPageAtScreen;
            }
            set
            {
                isMenuPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsGameplayPageAtScreen
        {
            get
            {
                return isGameplayPageAtScreen;
            }
            set
            {
                isGameplayPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsWeatherPageAtScreen
        {
            get
            {
                return isWeatherPageAtScreen;
            }
            set
            {
                isWeatherPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsLapControllersPageAtScreen
        {
            get
            {
                return isLapControllersPageAtScreen;
            }
            set
            {
                isLapControllersPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsOpponentsControllersPageAtScreen
        {
            get
            {
                return isOpponentsControllersPageAtScreen;
            }
            set
            {
                isOpponentsControllersPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsDriftPageAtScreen
        {
            get
            {
                return isDriftPageAtScreen;
            }
            set
            {
                isDriftPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsHotkeysPageAtScreen
        {
            get
            {
                return isHotkeysPageAtScreen;
            }
            set
            {
                isHotkeysPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsMiscPageAtScreen
        {
            get
            {
                return isMiscPageAtScreen;
            }
            set
            {
                isMiscPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsFixesPageAtScreen
        {
            get
            {
                return isFixesPageAtScreen;
            }
            set
            {
                isFixesPageAtScreen = value;
                OnPropertyChanged();
            }
        }
        public bool IsPresetsPageAtScreen
        {
            get
            {
                return isPresetsPageAtScreen;
            }
            set
            {
                isPresetsPageAtScreen = value;
                OnPropertyChanged();
            }
        }

        public Page CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }

        public double PageOpacity 
        {
            get
            {
                return pageOpacity;
            }
            set
            {
                pageOpacity = value;
                OnPropertyChanged();
            }
        }


        public MainPageViewModel()
        {
            AtScreenReset();
            IsGamePageAtScreen = true;
        }

        private void AtScreenReset()
        {
            IsGamePageAtScreen = false;
            IsMenuPageAtScreen = false;
            IsGameplayPageAtScreen = false;
            IsWeatherPageAtScreen = false;
            IsLapControllersPageAtScreen = false;
            IsOpponentsControllersPageAtScreen = false;
            IsDriftPageAtScreen = false;
            IsHotkeysPageAtScreen = false;
            IsMiscPageAtScreen = false;
            IsFixesPageAtScreen = false;
            IsPresetsPageAtScreen = false;
        }
    }
}
