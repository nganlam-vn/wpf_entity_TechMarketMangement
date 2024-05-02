using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using Object = wpf_TechMarketMangement.Models.Object;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCInputInfoViewModel : BaseViewModel
    {
        private ObservableCollection<Object> _List; //link model to viewmodel
        public ObservableCollection<Object> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }


        public UCInputInfoViewModel() 
        {

        }
    }
}
