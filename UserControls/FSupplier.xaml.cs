using HandyControl.Tools;
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

namespace wpf_TechMarketMangement.UserControls
{
    /// <summary>
    /// Interaction logic for FSupplier.xaml
    /// </summary>
    public partial class FSupplier : UserControl
    {
      
        public FSupplier()
        {
            InitializeComponent();
            ConfigHelper.Instance.SetLang("en");
        }
    }
}
