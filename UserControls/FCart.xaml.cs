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
            LoadCart();
        }
        public void LoadCart()
        {
            int provisionalPrice = 0 ;
            int intoMoneyPrice = 0;
            CartList = new ObservableCollection<Cart>();
            var cartlist = DataProvider.Ins.DB.Carts.Where(x => x.IdUser == Properties.Settings.Default.idUser);
            
            foreach (var item in cartlist)
            {
                UCCart ucCart = new UCCart();
                ucCart.btnRemove.Click += (sender, e) =>
                {
                    var cart = DataProvider.Ins.DB.Carts.Where(x => x.Id == item.Id).SingleOrDefault();
                    DataProvider.Ins.DB.Carts.Remove(cart);
                    DataProvider.Ins.DB.SaveChanges();
                    spCart.Children.Remove(ucCart);
                    OnPropertyChanged(nameof(CartList));
                };
                var objList = DataProvider.Ins.DB.Objects.Where(t => t.Id == item.IdObject).SingleOrDefault();
                var inputInfoList = DataProvider.Ins.DB.InputInfoes.Where(z => z.IdObject == item.IdObject).SingleOrDefault();

                ucCart.tblDisplayName.Text = objList.DisplayName;
                ucCart.tblColor.Text = inputInfoList.Color;
                ucCart.tblPrice.Text = inputInfoList.OutputPrice.ToString();
                ucCart.tblColor.Text = inputInfoList.Color;
                //ucCart.imgCart.ImageSource = new BitmapImage(new Uri("D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + objList.Img1, UriKind.Relative));
                ucCart.cbSelected.Checked += (sender, e) =>
                {
                    
                    CheckBox cb = sender as CheckBox;
                    
                    if (cb.IsChecked == true)
                    {
                        // Nếu checkbox được kiểm tra, thêm giá trị của sản phẩm vào provisionalPrice
                        provisionalPrice += int.Parse(ucCart.tblPrice.Text);
                    }


                    ucCart.cbSelected.Unchecked += (sender1, e1) =>
                    { 
                        if(provisionalPrice <= 0)
                        {
                            provisionalPrice = 0;
                        }
                        else
                        {
                            provisionalPrice -= int.Parse(ucCart.tblPrice.Text);
                        }
                        
                    };

                    // Cập nhật giá trị hiển thị của tblIntoMoney
                    tblProvisional.Text = provisionalPrice.ToString();
                    OnPropertyChanged(nameof(tblProvisional));
                    cbVoucher.SelectionChanged += (sender2, e2) =>
                    {
                        // Lấy giá trị của voucher được chọn
                        var voucher = cbVoucher.SelectedItem as Voucher;
                        if (voucher != null)
                        {
                            // Tính giá trị giảm giá
                            int discount = DataProvider.Ins.DB.Vouchers.Where(x => x.Id == voucher.Id).Select(x => x.Discount).SingleOrDefault();
                            tblDiscount.Text = "- " + discount.ToString();
                            // Cập nhật giá trị hiển thị của provisionalPrice
                            intoMoneyPrice = (provisionalPrice - discount);
                            tblIntoMoney.Text = intoMoneyPrice.ToString();
                            OnPropertyChanged(nameof(tblIntoMoney));
                            FBillingView.tblTotal.Text = tblIntoMoney.Text;
                        }
                    };
                   

                    FBillingView.tblProvisional.Text = tblProvisional.Text;
                   
                    FBillingView.tblDiscount.Text = tblDiscount.Text;
                    FBillingView.btnBack.Click += (sender3, e3) =>
                    {
                       FBillingView.Visibility = Visibility.Hidden;
                    };
                   
                    UCMiniCart uc = new UCMiniCart();
                    uc.imgMiniCart.ImageSource = ucCart.imgCart.ImageSource;
                    uc.tblDisplayName.Text = ucCart.tblDisplayName.Text;
                    uc.tblColor.Text = ucCart.tblColor.Text;
                    uc.tblPrice.Text = ucCart.tblPrice.Text;
                    FBillingView.spBill.Children.Add(uc);
                                   
                };
                spCart.Children.Add(ucCart);
                
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FBillingView.Visibility = Visibility.Visible;
        }
    }
}
