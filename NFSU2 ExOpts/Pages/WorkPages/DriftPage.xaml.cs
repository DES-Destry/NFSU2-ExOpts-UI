﻿using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class DriftPage : Page
    {
        public DriftPage()
        {
            InitializeComponent();
            DataContext = new DriftPageViewModel();
        }
    }
}
