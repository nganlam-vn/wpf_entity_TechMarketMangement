using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCUnitViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _List; //link model to viewmodel
        public ObservableCollection<Unit> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

        private Unit _SelectedItem;
        public Unit SelectedItem { get => _SelectedItem; set { _SelectedItem = value; OnPropertyChanged(); } }
        public UCUnitViewModel()
        {
            List = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);
        }
    }
}
