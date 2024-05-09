using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using wpf_TechMarketMangement.Models;
using wpf_TechMarketMangement.UserControls.UCSingleItem;

namespace wpf_TechMarketMangement.UserControls
{
    /// <summary>
    /// Interaction logic for FCart.xaml
    /// </summary>
    public partial class FCart : UserControl
    {
        private ObservableCollection<Cart> _CartList; //link model to viewmodel
        public ObservableCollection<Cart> CartList { get => _CartList; set { _CartList = value; OnPropertyChanged(nameof(CartList)); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public FCart()
        {
            InitializeComponent();
        }
        public void LoadCart()
        {
            CartList = new ObservableCollection<Cart>();
            var cartlist = DataProvider.Ins.DB.Carts.Where(x => x.IdUser == Properties.Settings.Default.idUser);
            
            foreach (var item in cartlist)
            {
            //    UCCart ucCart = new UCCart();
            //    var objList = DataProvider.Ins.DB.Objects.Where(t => t.Id == item.IdObject).SingleOrDefault();
            //    var inputInfoList = DataProvider.Ins.DB.InputInfoes.Where(z => z.IdObject == item.IdObject).SingleOrDefault();

            //    ucCart.tblDisplayName.Text = objList.DisplayName;
            //    ucCart.tblColor.Text = inputInfoList.Color;
            //    ucCart.tblPrice.Text = inputInfoList.OutputPrice.ToString();
                


            }

        }
    }
}
