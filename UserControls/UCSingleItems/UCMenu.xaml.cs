﻿using System;
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

namespace TechMarket_Management.View.UserControls
{
    /// <summary>
    /// Interaction logic for UCMenu.xaml
    /// </summary>
    public partial class UCMenu : UserControl
    {
        public UCMenu()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            FProduct product = new FProduct();
        }
    }
}
