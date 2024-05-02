using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCProductDetailViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand AddCartCommand { get; set; }
        public UCProductDetailViewModel()
        {
            AddCartCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                MessageBox.Show("Successfully add to cart!");
            });

        }
    }
}
