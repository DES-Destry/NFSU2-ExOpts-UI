﻿using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
            DataContext = new GamePageViewModel();
        }
    }
}
