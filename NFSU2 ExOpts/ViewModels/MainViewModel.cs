﻿using NFSU2_ExOpts.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NFSU2_ExOpts.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private Page mainPage;
        private Page settingsPage;

        private Page currentPage;
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

        public MainViewModel()
        {
            mainPage = new MainPage();
            CurrentPage = mainPage;
        }
    }
}