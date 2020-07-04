using DESTRY.IO.Debuging;
using NFSU2_ExOpts.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace NFSU2_ExOpts.ViewModels
{
    public class GamePageViewModel : BaseViewModel
    {
        private Visibility administratorVisibility;
        private Visibility gameNotFoundVisisbility;
        private Visibility texmodNotFoundVisibility;
        private Visibility exoptsConfigNotFoundVisibility;
        private Visibility sfxConfigNotFoundVisibility;

        private string lastStartup;
        private string ingameTime;


        public Visibility AdministratorVisibility
        {
            get
            {
                return administratorVisibility;
            }
            set
            {
                administratorVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility GameNotFoundVisisbility
        {
            get
            {
                return gameNotFoundVisisbility;
            }
            set
            {
                gameNotFoundVisisbility = value;
                OnPropertyChanged();
            }
        }
        public Visibility TexmodNotFoundVisibility
        {
            get
            {
                return texmodNotFoundVisibility;
            }
            set
            {
                texmodNotFoundVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility ExOptsConfigNotFoundVisibility
        {
            get
            {
                return exoptsConfigNotFoundVisibility;
            }
            set
            {
                exoptsConfigNotFoundVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility SfxConfigNotFoundVisibility
        {
            get
            {
                return sfxConfigNotFoundVisibility;
            }
            set
            {
                sfxConfigNotFoundVisibility = value;
                OnPropertyChanged();
            }
        }

        public string LastStartup
        {
            get
            {
                return lastStartup;
            }
            set
            {
                lastStartup = value;
                OnPropertyChanged();
            }
        }
        public string IngameTime
        {
            get
            {
                return ingameTime;
            }
            set
            {
                ingameTime = value;
                OnPropertyChanged();
            }
        }

        public ICommand PlayCommand => new BaseCommand(obj => Play());
        public ICommand TexmodStartCommand => new BaseCommand(obj => TexmodStart());


        public GamePageViewModel()
        {
            AdministratorCheck();
            GamePathCheck();
            TexmodPathCheck();
            ExOptsConfigPathCheck();
            SfxConfigPathCheck();

            GameDataChanged();
            App.OnGameDataChanged += GameDataChanged;
        }

        private void Play()
        {
            try
            {
                if (File.Exists(App.GameExePath))
                {
                    Process.Start(App.GameExePath);
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void TexmodStart()
        {
            try
            {
                if (File.Exists(App.TexmodExePath))
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(App.TexmodExePath);
                    startInfo.Verb = "runas";

                    Process.Start(startInfo);
                }
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }

        private void GameDataChanged()
        {
            ulong hours = App.GameData.TimeInSec / 3600;
            ulong minutes = App.GameData.TimeInSec / 60 % 60;

            string dateTime = App.GameData.LastStartup.ToString("MM.dd.yyyy");

            LastStartup = $"Last startup at {dateTime}";
            IngameTime = $"You played {hours} hours {minutes} minutes";
        }
        private void AdministratorCheck()
        {
            try
            {
                string testFileName = Guid.NewGuid().ToString();

                File.Create(testFileName).Close();
                File.WriteAllText(testFileName, "Hello world!");
                File.Delete(testFileName);

                AdministratorVisibility = Visibility.Collapsed;
            }
            catch (UnauthorizedAccessException)
            {
                AdministratorVisibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                Errors.WriteError(ex);
            }
        }
        private void GamePathCheck()
        {
            if (File.Exists(App.GameExePath)) GameNotFoundVisisbility = Visibility.Collapsed;
            else GameNotFoundVisisbility = Visibility.Visible;
        }
        private void TexmodPathCheck()
        {
            if (File.Exists(App.TexmodExePath)) TexmodNotFoundVisibility = Visibility.Collapsed;
            else TexmodNotFoundVisibility = Visibility.Visible;
        }
        private void ExOptsConfigPathCheck()
        {
            if (App.MainConfigExists) ExOptsConfigNotFoundVisibility = Visibility.Collapsed;
            else ExOptsConfigNotFoundVisibility = Visibility.Visible;
        }
        private void SfxConfigPathCheck()
        {
            if (true) SfxConfigNotFoundVisibility = Visibility.Collapsed;
            else SfxConfigNotFoundVisibility = Visibility.Visible;
        }
    }
}
