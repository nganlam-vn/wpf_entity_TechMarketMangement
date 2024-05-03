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

namespace wpf_TechMarketMangement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        public void setActiveUserControl(UserControl userControl)
        {
            fHome.Visibility = Visibility.Collapsed;  
            fAccount.Visibility = Visibility.Collapsed;
            fProduct.Visibility = Visibility.Collapsed;
            fAddProduct.Visibility = Visibility.Collapsed;
            fCart.Visibility = Visibility.Collapsed;
            userControl.Visibility = Visibility.Visible;
        }
        public void setActiveFind(UserControl userControl)
        {
            //fFind.Visibility = Visibility.Collapsed;
            userControl.Visibility = Visibility.Visible;
        }


        private void Click_menu(object sender, MouseEventArgs e) 
        {
            setActiveUserControl(fHome);
        }
        private void Click_home(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(fHome);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(fProduct);

        }

        private void Click_Product(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(fAddProduct);
        }

        private void Click_Account(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(fAccount);
        }

        private void Click_Cart(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(fCart);
        }

       
        
    }
}
