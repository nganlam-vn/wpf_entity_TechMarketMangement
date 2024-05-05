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
    //bug chua get all lai sau filter dc
    //su dung code behind vi binding 2 cai (card va show) 
    public partial class UCProduct_Show : UserControl
    {
       

        private List<Object> _ObjList; //link model to viewmodel
        public List<Object> ObjList { get => _ObjList; set { _ObjList = value; OnPropertyChanged(nameof(ObjList)); } }

        private string _FilterName;
        public string FilterName { get => _FilterName; set { _FilterName = value; OnPropertyChanged(nameof(FilterName)); ObjList = Filter(value); LoadCardData(); } }

        private ObservableCollection<UCCardModel> _CardList; //link model to viewmodel
        public ObservableCollection<UCCardModel> CardList { get => _CardList; set { _CardList = value; OnPropertyChanged(nameof(CardList)); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void setActiveUserControl(UserControl userControl)
        {
            dbPhone.Visibility = Visibility.Collapsed;
            dbLaptop.Visibility = Visibility.Collapsed;
            dbOther.Visibility = Visibility.Collapsed;
            userControl.Visibility = Visibility.Visible;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbLaptop);
        }
        private void Click_Laptop(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbLaptop);
            LoadCardDataLaptop();

        }
        private void Click_Phone(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbPhone);
            LoadCardDataPhone();
        }
        private void Click_Other(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbOther);
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
                objs=DataProvider.Ins.DB.Objects.ToList ();
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
                    uccard.txtType.Text = item.Unit.DisplayName;
                    uccard.txtbName.Text = item.DisplayName;
                    uccard.txtbPrice.Text = item2.OutputPrice.ToString() + "VND";
                    //"D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\
                    //uccard.imgCard.ImageSource = new BitmapImage(new Uri(item.Img1));
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
                        ProductDetail.nameProduct.Text = item.DisplayName;
                        

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
                        uccard.txtType.Text = item.Unit.DisplayName;
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
                        uccard.txtType.Text = item.Unit.DisplayName;
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

            // Load data from database
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
                        uccard.txtType.Text = item.Unit.DisplayName;
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

                            //MessageBox.Show(item.DisplayName);
                        };
                        wpCard.Children.Add(uccard);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ucProductDetail.Visibility = Visibility.Collapsed;
        }

    }
}
