﻿using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_TechMarketMangement.UserControls.UCSingleItem
{
    /// <summary>
    /// Interaction logic for UCDashBoardLaptop.xaml
    /// </summary>
    public partial class UCDashBoardLaptop : UserControl
    {
        public UCDashBoardLaptop()
        {
            InitializeComponent();
        }

        private void RangeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<HandyControl.Data.DoubleRange> e)
        {
            
        }
    }
}
