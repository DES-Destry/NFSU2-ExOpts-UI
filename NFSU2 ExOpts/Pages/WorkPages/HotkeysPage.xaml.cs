﻿using NFSU2_ExOpts.ViewModels;
using System.Windows.Controls;

namespace NFSU2_ExOpts.Pages.WorkPages
{
    public partial class HotkeysPage : Page
    {
        public HotkeysPage()
        {
            InitializeComponent();
            DataContext = new HotkeysPageViewModel();
        }
    }
}
