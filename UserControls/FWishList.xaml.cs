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
    /// Interaction logic for FWishList.xaml
    /// </summary>
    public partial class FWishList : UserControl
    {
        private ObservableCollection<WishList> _WishList; //link model to viewmodel
        public ObservableCollection<WishList> WishList { get => _WishList; set { _WishList = value; OnPropertyChanged(nameof(WishList)); } }


        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public FWishList()
        {
            InitializeComponent();
            LoadCart(); 
        }
        public void LoadCart()
        {
            WishList = new ObservableCollection<WishList>();
            var wishLists = DataProvider.Ins.DB.WishLists.Where(x => x.IdUser == Properties.Settings.Default.idUser);

            foreach (var item in wishLists)
            {
                UCCart ucCart = new UCCart();
                var objList = DataProvider.Ins.DB.Objects.Where(t => t.Id == item.IdObject).SingleOrDefault();
                var inputInfoList = DataProvider.Ins.DB.InputInfoes.Where(z => z.IdObject == item.IdObject).SingleOrDefault();
                ucCart.tblDisplayName.Text = objList.DisplayName;
                ucCart.tblColor.Text = inputInfoList.Color;
                ucCart.tblPrice.Text = inputInfoList.OutputPrice.ToString();
                stCart.Children.Add(ucCart);
            }
        }
    }
}
