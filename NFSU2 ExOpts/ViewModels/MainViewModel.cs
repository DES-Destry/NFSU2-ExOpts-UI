using NFSU2_ExOpts.Models;
using NFSU2_ExOpts.Pages;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace NFSU2_ExOpts.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private Page mainPage;
        private Page settingsPage;
        private Page contactsPage;

        private BitmapImage homeHeaderImage;
        private BitmapImage settingsHeaderImage;
        private BitmapImage contactsHeaderImage;

        private Visibility notSavedVisibility;

        private Page currentPage;


        public BitmapImage HomeHeaderImage
        {
            get
            {
                return homeHeaderImage;
            }
            set
            {
                homeHeaderImage = value;
                OnPropertyChanged();
            }
        }
        public BitmapImage SettingsHeaderImage
        {
            get
            {
                return settingsHeaderImage;
            }
            set
            {
                settingsHeaderImage = value;
                OnPropertyChanged();
            }
        }
        public BitmapImage ContactsHeaderImage
        {
            get
            {
                return contactsHeaderImage;
            }
            set
            {
                contactsHeaderImage = value;
                OnPropertyChanged();
            }
        }

        public Visibility NotSavedVisibility
        {
            get
            {
                return notSavedVisibility;
            }
            set
            {
                notSavedVisibility = value;
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

        public ICommand MainPageCommand => new BaseCommand((obj) => OpenMainPage());
        public ICommand SettingsPageCommand => new BaseCommand((obj) => OpenSettingsPage());
        public ICommand ContactsPageCommand => new BaseCommand((obj) => OpenContactsPage());


        public MainViewModel()
        {
            mainPage = new MainPage();
            settingsPage = new SettingsPage();
            contactsPage = null;

            HomeHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/home_green.png", UriKind.Relative));
            SettingsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/settings_white.png", UriKind.Relative));
            ContactsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/send_email_white.png", UriKind.Relative));

            CurrentPage = mainPage;

            NotSavedVisibility = Visibility.Collapsed;
            App.OnSavedDataChanged += InMainSavedChanged;

        }

        private void InMainSavedChanged()
        {
            if (!App.IsSavedData) NotSavedVisibility = Visibility.Visible;
            else NotSavedVisibility = Visibility.Collapsed;
        }

        private void OpenMainPage()
        {
            CurrentPage = mainPage;

            HomeHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/home_green.png", UriKind.Relative));
            SettingsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/settings_white.png", UriKind.Relative));
            ContactsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/send_email_white.png", UriKind.Relative));
        }

        private void OpenSettingsPage()
        {
            CurrentPage = settingsPage;

            HomeHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/home_white.png", UriKind.Relative));
            SettingsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/settings_green.png", UriKind.Relative));
            ContactsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/send_email_white.png", UriKind.Relative));
        }

        private void OpenContactsPage()
        {
            HomeHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/home_white.png", UriKind.Relative));
            SettingsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/settings_white.png", UriKind.Relative));
            ContactsHeaderImage = new BitmapImage(new Uri("/NFSU2 ExOpts;component/Images/send_email_green.png", UriKind.Relative));
        }
    }
}
