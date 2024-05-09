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
                    stInrestingProduct.Children.Add(uccard);
                }
            }
        }

    }
}
