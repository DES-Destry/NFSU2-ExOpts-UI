using NFSU2_ExOpts.Models;
using NFSU2_ExOpts.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

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

        public BaseCommand GameCommand => new BaseCommand((obj) => GameOpen());
        public BaseCommand MenuCommand => new BaseCommand((obj) => MenuOpen());
        public BaseCommand GameplayCommand => new BaseCommand((obj) => GameplayOpen());
        public BaseCommand WeatherCommand => new BaseCommand((obj) => WeatherOpen());
        public BaseCommand LapCommand => new BaseCommand((obj) => LapControllersOpen());
        public BaseCommand OpponentsCommand => new BaseCommand((obj) => OpponentsControllerOpen());
        public BaseCommand DriftCommand => new BaseCommand((obj) => DriftOpen());
        public BaseCommand HotkeysCommand => new BaseCommand((obj) => HotkeysOpen());
        public BaseCommand MiscCommand => new BaseCommand((obj) => MiscOpen());
        public BaseCommand FixesCommand => new BaseCommand((obj) => FixesOpen());
        public BaseCommand PresetsCommand => new BaseCommand((obj) => PresetsOpen());


        public MainPageViewModel()
        {
            gameSplashScreenPage = new SplashScreenPage("Game", "/NFSU2 ExOPts;component/Images/game_left_menu.png");
            menuSplashScreenPage = new SplashScreenPage("Menu", "/NFSU2 ExOPts;component/Images/menu_left_menu.png");
            gameplaySplashScreenPage = new SplashScreenPage("Gameplay", "/NFSU2 ExOPts;component/Images/gameplay_left_menu.png");
            weatherSplashScreenPage = new SplashScreenPage("Weather", "/NFSU2 ExOPts;component/Images/weather_left_menu.png");
            lapControllersSplashScreenPage = new SplashScreenPage("Lap settings", "/NFSU2 ExOPts;component/Images/lapcontroller_left_menu.png");
            opponentsControllersSplashScreenPage = new SplashScreenPage("Opponents settings", "/NFSU2 ExOPts;component/Images/opponentcontroller_left_menu.png");
            driftSplashScreenPage = new SplashScreenPage("Drift settings", "/NFSU2 ExOPts;component/Images/drift_left_menu.png");
            hotkeysSplashScreenPage = new SplashScreenPage("Hotkeys", "/NFSU2 ExOPts;component/Images/hotkeys_left_menu.png");
            miscSplashScreenPage = new SplashScreenPage("Misc", "/NFSU2 ExOPts;component/Images/misc_left_menu.png");
            fixesSplashScreenPage = new SplashScreenPage("Fixes", "/NFSU2 ExOPts;component/Images/fixes_left_menu.png");
            presetsSplashScreenPage = new SplashScreenPage("Settings presets", "/NFSU2 ExOPts;component/Images/presets_left_menu.png");

            (gameSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (menuSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (gameplaySplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (weatherSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (lapControllersSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (opponentsControllersSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (driftSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (hotkeysSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (miscSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (fixesSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);
            (presetsSplashScreenPage as SplashScreenPage).SetNextPageSettings(null, OpenNextPage);

            GameOpen();
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

        private void OpenSplashScreen(SplashScreenPage splashScreen)
        {
            CurrentPage = splashScreen;
            AtScreenReset();
        }

        private void OpenNextPage(Page page)
        {
            CurrentPage = page;
        }

        private void GameOpen()
        {
            OpenSplashScreen((SplashScreenPage)gameSplashScreenPage);
            IsGamePageAtScreen = true;
        }
        private void MenuOpen()
        {
            OpenSplashScreen((SplashScreenPage)menuSplashScreenPage);
            IsMenuPageAtScreen = true;
        }
        private void GameplayOpen()
        {
            OpenSplashScreen((SplashScreenPage)gameplaySplashScreenPage);
            IsGameplayPageAtScreen = true;
        }
        private void WeatherOpen()
        {
            OpenSplashScreen((SplashScreenPage)weatherSplashScreenPage);
            IsWeatherPageAtScreen = true;
        }
        private void LapControllersOpen()
        {
            OpenSplashScreen((SplashScreenPage)lapControllersSplashScreenPage);
            IsLapControllersPageAtScreen = true;
        }
        private void OpponentsControllerOpen()
        {
            OpenSplashScreen((SplashScreenPage)opponentsControllersSplashScreenPage);
            IsOpponentsControllersPageAtScreen = true;
        }
        private void DriftOpen()
        {
            OpenSplashScreen((SplashScreenPage)driftSplashScreenPage);
            IsDriftPageAtScreen = true;
        }
        private void HotkeysOpen()
        {
            OpenSplashScreen((SplashScreenPage)hotkeysSplashScreenPage);
            IsHotkeysPageAtScreen = true;
        }
        private void MiscOpen()
        {
            OpenSplashScreen((SplashScreenPage)miscSplashScreenPage);
            IsMiscPageAtScreen = true;
        }
        private void FixesOpen()
        {
            OpenSplashScreen((SplashScreenPage)fixesSplashScreenPage);
            IsFixesPageAtScreen = true;
        }
        private void PresetsOpen()
        {
            OpenSplashScreen((SplashScreenPage)presetsSplashScreenPage);
            IsPresetsPageAtScreen = true;
        }
    }
}
