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

namespace WPF_TechMarketManagement.Views.UserControls.UCSingleItems
{
    /// <summary>
    /// Interaction logic for UCTextBox.xaml
    /// </summary>
    public partial class UCTextBox : UserControl
    {
        public UCTextBox()
        {
            InitializeComponent();
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Clear(); // Clear the text box
            txtInput.Focus(); // Set focus to the text box XOA co the nhap tiep
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                tbPlaceHolder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceHolder.Visibility = Visibility.Hidden;
            }
        }


    }
}
