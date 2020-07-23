using ExOpts_Installer.Models;
using ExOpts_Installer.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ExOpts_Installer.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private readonly Page updatesPage;
        private readonly Page cachePage;
        private readonly Page uninstallPage;

        private Page currentPage;

        private Visibility updatesSelectedVisibility;
        private Visibility cacheSelectedVisibility;
        private Visibility uninstallSelectedVisibility;


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

        public Visibility UpdatesSelectedVisibility
        {
            get
            {
                return updatesSelectedVisibility;
            }
            set
            {
                updatesSelectedVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility CacheSelectedVisibility
        {
            get
            {
                return cacheSelectedVisibility;
            }
            set
            {
                cacheSelectedVisibility = value;
                OnPropertyChanged();
            }
        }
        public Visibility UninstallSelectedVisibility
        {
            get
            {
                return uninstallSelectedVisibility;
            }
            set
            {
                uninstallSelectedVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdatesSelectedCommand => new BaseCommand(obj => UpdatesSelected());
        public ICommand CacheSelectedCommand => new BaseCommand(obj => CacheSelected());
        public ICommand UninstallSelectedCommand => new BaseCommand(obj => UnistallSelected());


        public MainViewModel()
        {
            ResetSelected();
            UpdatesSelectedVisibility = Visibility.Visible;

            updatesPage = new UpdatesPage();
            cachePage = null;
            uninstallPage = null;

            CurrentPage = updatesPage;
        }


        private void ResetSelected()
        {
            UpdatesSelectedVisibility = Visibility.Collapsed;
            CacheSelectedVisibility = Visibility.Collapsed;
            UninstallSelectedVisibility = Visibility.Collapsed;
        }

        private void UpdatesSelected()
        {
            ResetSelected();
            UpdatesSelectedVisibility = Visibility.Visible;

            CurrentPage = updatesPage;
        }
        private void CacheSelected()
        {
            ResetSelected();
            CacheSelectedVisibility = Visibility.Visible;

            CurrentPage = cachePage;
        }
        private void UnistallSelected()
        {
            ResetSelected();
            UninstallSelectedVisibility = Visibility.Visible;

            CurrentPage = uninstallPage;
        }
    }
}
