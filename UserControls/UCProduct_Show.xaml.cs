using HandyControl.Themes;
using HandyControl.Tools.Extension;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using wpf_TechMarketMangement.ViewModels;
using Object = wpf_TechMarketMangement.Models.Object;

namespace wpf_TechMarketMangement.UserControls
{
    //su dung code behind vi binding 2 cai (card va show) 
    public partial class UCProduct_Show : UserControl
    {
        private List<Object> _ObjList; //link model to viewmodel
        public List<Object> ObjList { get => _ObjList; set { _ObjList = value; OnPropertyChanged(nameof(ObjList)); } }

        private List<Cart> _CartList; //link model to viewmodel
        public List<Cart> CartList { get => _CartList; set { _CartList = value; OnPropertyChanged(nameof(CartList)); } }

        private string _FilterName;
        public string FilterName { get => _FilterName; set { _FilterName = value; OnPropertyChanged(nameof(FilterName)); ObjList = Filter(value); LoadCardData(); } }

        private int _BrandChoice;
        public int BrandChoice { get  => _BrandChoice;  set { _BrandChoice = value; OnPropertyChanged(nameof(Filters)); ObjList = Filters(value); LoadCardData(); } }

        private int _PriceChoice;
        public int priceChoice { get { return _PriceChoice; } set { _PriceChoice = value; } }


        private ObservableCollection<UCCardModel> _CardList; //link model to viewmodel
        public ObservableCollection<UCCardModel> CardList { get => _CardList; set { _CardList = value; OnPropertyChanged(nameof(CardList)); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }
        private void Click_Laptop(object sender, RoutedEventArgs e)
        {
            LoadCardDataLaptop();

        }
        private void Click_Phone(object sender, RoutedEventArgs e)
        {
            LoadCardDataPhone();
        }
        private void Click_Other(object sender, RoutedEventArgs e)
        {
            LoadCardDataOther();
        }
        public UCProduct_Show()
        {
            InitializeComponent();
            this.DataContext = this;
            ObjList = new List<Object>();
            ObjList = DataProvider.Ins.DB.Objects.ToList();
            LoadCardData();

        }
        public List<Object> Filter(string name)
        {
            var objs = DataProvider.Ins.DB.Objects
                                         .Where(t => t.DisplayName.ToLower().Contains(name.ToLower()))
                                         .AsNoTracking()
                                         .ToList();
            if (name == "")
            {
                objs = DataProvider.Ins.DB.Objects.ToList();
            }
            return objs;
        }
        public List<Object> Filters(int brand)
        {
            var objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand != null).ToList();
            if (brand == 1)
            {
                objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand == "APPLE").ToList(); 
            }
            else if (brand == 2)
            {
                objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand == "ASUS").ToList();
            }
            else if (brand == 3)
            {
                objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand == "ACER").ToList();
            }

            else if (brand == 4)
            {
                objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand == "LENOVO").ToList();
            }

            else if (brand == 5)
            {
                objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand == "DELL").ToList();
            }

            else if (brand == 6)
            {
                objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand == "SAMSUNG").ToList();
            }
            else
            {
                objs = DataProvider.Ins.DB.Objects.Where(t => t.Brand != null).ToList();
            }
            return objs;
        }
        private void LoadCardData()
        {
            wpCard.Children.Clear();
            // Load data from database
            CardList = new ObservableCollection<UCCardModel>();

            foreach (var item in ObjList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                foreach (var item2 in inputList)
                {
                    UCCard uccard = new UCCard(); //ui element
                    
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
                            MessageBox.Show("Successfully add to cart!");
                            var cart = new Cart()
                            {
                                IdObject = item.Id,
                                IdUser = Properties.Settings.Default.idUser,
                            };
                            DataProvider.Ins.DB.Carts.Add(cart);
                            DataProvider.Ins.DB.SaveChanges();
                            OnPropertyChanged(nameof(CartList));

                        };

                        ProductDetail.btnAddWishList.Click += (senders, t) =>
                        {
                            MessageBox.Show("Successfully add to Wish List!");
                            var wishlist = new WishList()
                            {
                                IdObject = item.Id,
                                IdUser = Properties.Settings.Default.idUser,
                            };
                            DataProvider.Ins.DB.WishLists.Add(wishlist);
                            DataProvider.Ins.DB.SaveChanges();
                            OnPropertyChanged(nameof(WishList));

                        };
                        int i = item.IdSupplier;
                        var obj = DataProvider.Ins.DB.Suppliers.Where(t => t.Id == i);
                        foreach (var item3 in obj)
                        {
                            ProductDetail.Seller.Text = item3.DisplayName.ToString();
                        }
                        ProductDetail.btnAddToCart.Click += (senders, t) =>
                        {
                            MessageBox.Show("Successfully add to cart!");
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
                    wpCard.Children.Add(uccard);
                }
            }
        }

        private void LoadCardDataLaptop()
        {
            wpCard.Children.Clear();

            // Load data from database
            CardList = new ObservableCollection<UCCardModel>();
            var objectList = DataProvider.Ins.DB.Objects;
            foreach (var item in objectList)
            {
                if (item.IdUnit == 1)
                {
                    var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                    foreach (var item2 in inputList)
                    {
                        UCCard uccard = new UCCard(); //ui element
                        uccard.txtbName.Text = item.DisplayName;
                        uccard.txtbPrice.Text = item2.OutputPrice.ToString() + "VND";
                        uccard.btnDetail.Click += (sender, e) =>
                        {
                            //var detail = new UCProduct_Detail();
                            //detail.DataContext = new UCProduct_DetailViewModel(item);
                            //detail.ShowDialog();
                            ucProductDetail.Visibility = Visibility.Visible;
                            ProductDetail.price.Text = item2.OutputPrice.ToString() + "VND";
                            ProductDetail.priceBought.Text = item2.InputPrice.ToString() +"VND";
                            ProductDetail.idProduct.Text = item.Id.ToString();
                            ProductDetail.brandProduct.Text = item.Brand;
                            ProductDetail.conditionProduct.Text = item2.Condition.ToString();
                            ProductDetail.colorProduct.Content = item2.Color.ToString();
                            ProductDetail.txtbRAM.Text = item.RAM.ToString();
                            ProductDetail.txtbROM.Text = item.ROM.ToString();
                            ProductDetail.txtbBattery.Text = item.Battery.ToString();
                            ProductDetail.txtbOS.Text = item.OS.ToString();
                           

                            //MessageBox.Show(item.DisplayName);
                        };
                        wpCard.Children.Add(uccard);
                    }
                }
            }
        }
        private void LoadCardDataPhone()
        {
            wpCard.Children.Clear();

            // Load data from database
            CardList = new ObservableCollection<UCCardModel>();
            var objectList = DataProvider.Ins.DB.Objects;
            foreach (var item in objectList)
            {
                if (item.IdUnit == 2)
                {
                    var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                    foreach (var item2 in inputList)
                    {
                        UCCard uccard = new UCCard(); //ui element
                        uccard.txtbName.Text = item.DisplayName;
                        uccard.txtbPrice.Text = item2.OutputPrice.ToString() + "VND";
                        uccard.btnDetail.Click += (sender, e) =>
                        {
                            //var detail = new UCProduct_Detail();
                            //detail.DataContext = new UCProduct_DetailViewModel(item);
                            //detail.ShowDialog();
                            ucProductDetail.Visibility = Visibility.Visible;
                            ProductDetail.price.Text = item2.OutputPrice.ToString() + "VND";
                            ProductDetail.idProduct.Text = item.Id.ToString();
                            ProductDetail.brandProduct.Text = item.Brand;
                            ProductDetail.conditionProduct.Text = item2.Condition.ToString();
                            ProductDetail.colorProduct.Content = item2.Color.ToString();
                            ProductDetail.txtbRAM.Text = item.RAM.ToString();
                            ProductDetail.txtbROM.Text = item.ROM.ToString();
                            ProductDetail.txtbBattery.Text = item.Battery.ToString();
                            ProductDetail.txtbOS.Text = item.OS.ToString();
                            ProductDetail.priceBought.Text = item2.InputPrice.ToString();
                            //MessageBox.Show(item.DisplayName);
                        };
                        wpCard.Children.Add(uccard);
                    }
                }
            }
        }

        private void LoadCardDataOther()
        {
            wpCard.Children.Clear();
            CardList = new ObservableCollection<UCCardModel>();
            var objectList = DataProvider.Ins.DB.Objects;
            foreach (var item in objectList)
            {
                if (item.IdUnit == 3)
                {
                    var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                    foreach (var item2 in inputList)
                    {
                        UCCard uccard = new UCCard(); //ui element
                        uccard.txtbName.Text = item.DisplayName;
                        uccard.txtbPrice.Text = item2.OutputPrice.ToString() + "VND";
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
                            ProductDetail.txtbRAM.Text = item.RAM.ToString();
                            ProductDetail.txtbROM.Text = item.ROM.ToString();
                            ProductDetail.txtbBattery.Text = item.Battery.ToString();
                            ProductDetail.priceBought.Text = item2.InputPrice.ToString();
                            //MessageBox.Show(item.DisplayName);
                        };
                        wpCard.Children.Add(uccard);
                    }
                }
            }
        }
        
    }

}
