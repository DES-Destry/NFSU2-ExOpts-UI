﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace NFSU2_ExOpts.Controls
{
    public partial class Selector : UserControl
    {
        public ObservableCollection<string> ItemSource
        {
            get { return (ObservableCollection<string>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(ObservableCollection<string>), typeof(Selector), new FrameworkPropertyMetadata(new ObservableCollection<string>(),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(SlotContent_ItemSourceChangedCallBack)));




        public int CurrentItem
        {
            get { return (int)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); CurrentItemChanged?.Invoke(this); }
        }

        public static readonly DependencyProperty CurrentItemProperty =
            DependencyProperty.Register("CurrentItem", typeof(int), typeof(Selector), new FrameworkPropertyMetadata(0,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    new PropertyChangedCallback(SlotContent_CurrentItemChangedCallBack)));

        public Action<object> CurrentItemChanged;




        public Selector()
        {
            InitializeComponent();

            SelectorStage.Maximum = ItemSource.Count;
            SetSelectorValues();
        }

        private void SelectorPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentItem <= 0)
            {
                return;
            }
            else
            {
                CurrentItem--;
            }
        }

        private void SelectorNext_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentItem >= ItemSource.Count - 1)
            {
                return;
            }
            else
            {
                CurrentItem++;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SetSelectorValues();
        }

        private static void SlotContent_CurrentItemChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as Selector).Grid_Loaded(sender, null);
        }

        private static void SlotContent_ItemSourceChangedCallBack(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as Selector).Grid_Loaded(sender, null);
        }

        private void SetSelectorValues()
        {
            try
            {
                SelectorStage.Maximum = ItemSource.Count;
                SmoothProgressTo(CurrentItem + 1);

                SelectorTextContent.Text = ItemSource[CurrentItem];
            }
            catch
            {
                SelectorTextContent.Text = "NULL";
                SelectorStage.Value = 0;
            }
        }

        private void SmoothProgressTo(int value)
        {
            CircleEase backEase = new CircleEase();
            backEase.EasingMode = EasingMode.EaseIn;

            var animation = new DoubleAnimation((double)value, TimeSpan.FromSeconds(0.5));
            animation.EasingFunction = backEase;

            SelectorStage.BeginAnimation(ProgressBar.ValueProperty, animation);
        }
    }
}
