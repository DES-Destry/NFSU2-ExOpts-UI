using DESTRY.IO.Debuging;
using NFSU2_ExOpts.Models;
using NFSU2_ExOpts.Pages;
using NFSU2_ExOpts.Pages.WorkPages;
using System;
using System.Windows.Controls;

namespace NFSU2_ExOpts.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private Page gamePage;
        private Page screenFXPage;
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

        private SplashScreenPage gameSplashScreenPage;
        private SplashScreenPage menuSplashScreenPage;
        private SplashScreenPage gameplaySplashScreenPage;
        private SplashScreenPage weatherSplashScreenPage;
        private SplashScreenPage lapControllersSplashScreenPage;
        private SplashScreenPage opponentsControllersSplashScreenPage;
        private SplashScreenPage driftSplashScreenPage;
        private SplashScreenPage hotkeysSplashScreenPage;
        private SplashScreenPage miscSplashScreenPage;
        private SplashScreenPage fixesSplashScreenPage;
        private SplashScreenPage presetsSplashScreenPage;

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
            try
            {
                gameSplashScreenPage = new SplashScreenPage("Game", "/NFSU2 ExOPts;component/Images/game_left_menu.png");
                menuSplashScreenPage = new SplashScreenPage("Menu settings", "/NFSU2 ExOPts;component/Images/menu_left_menu.png");
                gameplaySplashScreenPage = new SplashScreenPage("Gameplay", "/NFSU2 ExOPts;component/Images/gameplay_left_menu.png");
                weatherSplashScreenPage = new SplashScreenPage("Weather settings", "/NFSU2 ExOPts;component/Images/weather_left_menu.png");
                lapControllersSplashScreenPage = new SplashScreenPage("Laps settings", "/NFSU2 ExOPts;component/Images/lapcontroller_left_menu.png");
                opponentsControllersSplashScreenPage = new SplashScreenPage("Opponents settings", "/NFSU2 ExOPts;component/Images/opponentcontroller_left_menu.png");
                driftSplashScreenPage = new SplashScreenPage("Drift settings", "/NFSU2 ExOPts;component/Images/drift_left_menu.png");
                hotkeysSplashScreenPage = new SplashScreenPage("Hotkeys", "/NFSU2 ExOPts;component/Images/hotkeys_left_menu.png");
                miscSplashScreenPage = new SplashScreenPage("Misc", "/NFSU2 ExOPts;component/Images/misc_left_menu.png");
                fixesSplashScreenPage = new SplashScreenPage("Fixes", "/NFSU2 ExOPts;component/Images/fixes_left_menu.png");
                presetsSplashScreenPage = new SplashScreenPage("Settings presets", "/NFSU2 ExOPts;component/Images/presets_left_menu.png");
                Logs.WriteLog("All splash screens has been loaded", "INFO");

                lapControllersPage = new LapsControllerPage();
                opponentsControllersPage = new OpponentsControllersPage();
                driftPage = new DriftPage();
                miscPage = new MiscPage();
                fixesPage = new FixesPage();
                Logs.WriteLog("All work screens has been loaded", "INFO");

                gameSplashScreenPage.SetNextPageSettings(null, OpenNextPage);
                menuSplashScreenPage.SetNextPageSettings(null, OpenNextPage);
                gameplaySplashScreenPage.SetNextPageSettings(null, OpenNextPage);
                weatherSplashScreenPage.SetNextPageSettings(null, OpenNextPage);
                lapControllersSplashScreenPage.SetNextPageSettings(lapControllersPage, OpenNextPage);
                opponentsControllersSplashScreenPage.SetNextPageSettings(opponentsControllersPage, OpenNextPage);
                driftSplashScreenPage.SetNextPageSettings(driftPage, OpenNextPage);
                hotkeysSplashScreenPage.SetNextPageSettings(null, OpenNextPage);
                miscSplashScreenPage.SetNextPageSettings(miscPage, OpenNextPage);
                fixesSplashScreenPage.SetNextPageSettings(fixesPage, OpenNextPage);
                presetsSplashScreenPage.SetNextPageSettings(null, OpenNextPage);
                Logs.WriteLog("All splash screen's next screens parameters has been installed!", "INFO");

                GameOpen();
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
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
            Logs.WriteLog($"{splashScreen.SplashScreenText.Text} page has been opened", "INFO");

            AtScreenReset();
        }

        private void OpenNextPage(Page page)
        {
            CurrentPage = page;
            Logs.WriteLog("Working page has been loaded!", "INFO");
        }

        private void GameOpen()
        {
            try
            {
                OpenSplashScreen(gameSplashScreenPage);
                IsGamePageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void MenuOpen()
        {
            try
            {
                OpenSplashScreen(menuSplashScreenPage);
                IsMenuPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void GameplayOpen()
        {
            try
            {
                OpenSplashScreen(gameplaySplashScreenPage);
                IsGameplayPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void WeatherOpen()
        {
            try
            {
                OpenSplashScreen(weatherSplashScreenPage);
                IsWeatherPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void LapControllersOpen()
        {
            try
            {
                OpenSplashScreen(lapControllersSplashScreenPage);
                IsLapControllersPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void OpponentsControllerOpen()
        {
            try
            {
                OpenSplashScreen(opponentsControllersSplashScreenPage);
                IsOpponentsControllersPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void DriftOpen()
        {
            try
            {
                OpenSplashScreen(driftSplashScreenPage);
                IsDriftPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void HotkeysOpen()
        {
            try
            {
                OpenSplashScreen(hotkeysSplashScreenPage);
                IsHotkeysPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void MiscOpen()
        {
            try
            {
                OpenSplashScreen(miscSplashScreenPage);
                IsMiscPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void FixesOpen()
        {
            try
            {
                OpenSplashScreen(fixesSplashScreenPage);
                IsFixesPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void PresetsOpen()
        {
            try
            {
                OpenSplashScreen(presetsSplashScreenPage);
                IsPresetsPageAtScreen = true;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
    }
}
