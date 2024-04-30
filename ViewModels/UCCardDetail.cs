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
    public class UCCardDetail:BaseViewModel
    {
        private ObservableCollection<UCProductDetail> _ProductDetail; //link model to viewmodel
        public ObservableCollection<UCProductDetail> ProductDetails { get => _ProductDetail; set ; }
    }
}
