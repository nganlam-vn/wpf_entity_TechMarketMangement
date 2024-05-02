using HandyControl.Themes;
using HandyControl.Tools.Extension;
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
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using wpf_TechMarketMangement.ViewModels;

namespace wpf_TechMarketMangement.UserControls
{
    //su dung code behind vi binding 2 cai (card va show) 
    public partial class UCProduct_Show : UserControl 
    {
        private ObservableCollection<UCCardModel> _CardList; //link model to viewmodel
        public ObservableCollection<UCCardModel> CardList { get => _CardList; set { _CardList = value; OnPropertyChanged(nameof(_CardList)); } }
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
        public void setActiveProductDetail(UserControl userControl)
        {
            fdetail.Visibility = Visibility.Collapsed;
            userControl.Visibility= Visibility.Visible;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbLaptop);
        }
        private void Click_Laptop(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbLaptop);

        }
        private void Click_Phone(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbPhone);
        }
        private void Click_Other(object sender, RoutedEventArgs e)
        {
            setActiveUserControl(dbOther);
        }
        public UCProduct_Show()
        {
            InitializeComponent();
            LoadCardData();
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
                    uccard.txtType.Text = item.Type;
                    uccard.txtbName.Text = item.DisplayName;
                    uccard.txtbPrice.Text = item2.OutputPrice.ToString() + "VND";
                    wpCard.Children.Add(uccard);
                }

            }
        }
    }
}
