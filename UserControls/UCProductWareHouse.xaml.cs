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
using wpf_TechMarketMangement.ViewModels;

namespace wpf_TechMarketMangement.UserControls
{

    public partial class UCProductWareHouse : UserControl
    {
        public UCProductWareHouseViewModel ViewModel { get; set; }
        public UCProductWareHouse()
        {
            InitializeComponent();
            this.DataContext = ViewModel = new UCProductWareHouseViewModel();
        }

       
    }
}
