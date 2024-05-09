using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCProductDetailViewModel : BaseViewModel
    {
        private ObservableCollection<Supplier> _List; //link model to viewmodel
        public ObservableCollection<Supplier> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

        private string _NameText;
        public string NameText { get => _NameText; set { _NameText = value; OnPropertyChanged(); } }
        public bool IsLoaded = false;
        public ICommand AddCartCommand { get; set; }
        public UCProductDetailViewModel()
        {
            AddCartCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
            });

        }
    }
}
