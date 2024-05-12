using HandyControl.Controls;
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

namespace wpf_TechMarketMangement.UserControls
{
    /// <summary>
    /// Interaction logic for Fhome.xaml
    /// </summary>
    public partial class Fhome : UserControl
    {
        public Fhome()
        {
            InitializeComponent();
            LoadCardData();
        }
        private ObservableCollection<UCCardModel> _CardList; //link model to viewmodel
        public ObservableCollection<UCCardModel> CardList { get => _CardList; set { _CardList = value; OnPropertyChanged(nameof(_CardList)); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadCardData()
        {
            // Load data from database
          
            CardList = new ObservableCollection<UCCardModel>();
            var objectList = DataProvider.Ins.DB.Objects;
            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                foreach (var item2 in inputList)
                {
                    UCCard uccard = new UCCard(); //ui element
                    //uccard.txtType.Text = item.IdUnit;
                    uccard.txtbName.Text = item.DisplayName;
                    uccard.txtbPrice.Text = item2.OutputPrice.ToString() + "VND";
                    //uccard.imgCard.ImageSource = new BitmapImage(new Uri("D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + item.Img1, UriKind.Relative));
                    uccard.txtbAdress.Text = item2.Address;
                    uccard.btnDetail.Click += (sender, e) =>
                    {
                        //var detail = new UCProduct_Detail();
                        //detail.DataContext = new UCProduct_DetailViewModel(item);
                        //detail.ShowDialog();
                        ucProductDetail.Visibility = Visibility.Visible;
                        ProductDetail.price.Text = item2.OutputPrice.ToString() + "VND";
                        ProductDetail.priceBought.Text = item2.InputPrice.ToString() + "VND";
                        ProductDetail.idProduct.Text = item.Id.ToString();
                        ProductDetail.brandProduct.Text = item.Brand;
                        ProductDetail.conditionProduct.Text = item2.Condition.ToString();
                        ProductDetail.colorProduct.Content = item2.Color.ToString();
                        ProductDetail.nameProduct.Text = item.DisplayName;
                        ProductDetail.txtbRAM.Text = item.RAM.ToString();
                        ProductDetail.txtbROM.Text = item.ROM.ToString();
                        ProductDetail.txtbBattery.Text = item.Battery.ToString();
                        ProductDetail.txtbOS.Text = item.OS.ToString();
                        //ProductDetail.imgCart1.ImageSource = new BitmapImage(new Uri("D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + item.Img1, UriKind.Relative));
                        //ProductDetail.imgCart2.ImageSource = new BitmapImage(new Uri("D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + item.Img2, UriKind.Relative));
                        //ProductDetail.imgCart3.ImageSource = new BitmapImage(new Uri("D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + item.Img3, UriKind.Relative));

                        ProductDetail.btnAddToCart.Click += (senders, t) =>
                        {
                            System.Windows.MessageBox.Show("Successfully add to cart!");
                            var cart = new Cart()
                            {
                                IdObject = item.Id,
                                IdUser = Properties.Settings.Default.idUser,
                            };
                            DataProvider.Ins.DB.Carts.Add(cart);
                            DataProvider.Ins.DB.SaveChanges();
                           

                        };

                        ProductDetail.btnAddWishList.Click += (senders, t) =>
                        {
                            System.Windows.MessageBox.Show("Successfully add to Wish List!");
                            var wishlist = new WishList()
                            {
                                IdObject = item.Id,
                                IdUser = Properties.Settings.Default.idUser,
                            };
                            DataProvider.Ins.DB.WishLists.Add(wishlist);
                            DataProvider.Ins.DB.SaveChanges();
                            

                        };
                        int i = item.IdSupplier;
                        var obj = DataProvider.Ins.DB.Suppliers.Where(t => t.Id == i);
                        foreach (var item3 in obj)
                        {
                            ProductDetail.Seller.Text = item3.DisplayName.ToString();
                        }
                        ProductDetail.btnAddToCart.Click += (senders, t) =>
                        {
                            System.Windows.MessageBox.Show("Successfully add to cart!");
                            var cart = new Cart()
                            {
                                IdObject = item.Id,
                                IdUser = Properties.Settings.Default.idUser,
                            };
                            DataProvider.Ins.DB.Carts.Add(cart);
                            DataProvider.Ins.DB.SaveChanges();

                        };
                        //MessageBox.Show(item.DisplayName);
                    };
                    if (item.IdUnit ==1 )
                    {
                        spLaptop.Children.Add(uccard);
                    }
                    else if (item.IdUnit == 2)
                    {
                        spPhone.Children.Add(uccard);
                    }
                    else
                    {
                        spOther.Children.Add(uccard);
                    }

                }
            }
        }

    }
}
