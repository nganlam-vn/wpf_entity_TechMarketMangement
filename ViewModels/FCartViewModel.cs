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
    public class FCartViewModel : BaseViewModel
    {
        private ObservableCollection<Voucher> _VoucherList; //link model to viewmodel
        public ObservableCollection<Voucher> VoucherList { get => _VoucherList; set { _VoucherList = value; OnPropertyChanged(nameof(VoucherList)); } }


        public FCartViewModel()
        {
            LoadData();

        }

        public void LoadData()
        {
            VoucherList = new ObservableCollection<Voucher>(DataProvider.Ins.DB.Vouchers);
            var inputinfoList = DataProvider.Ins.DB.InputInfoes;
        }
    }
}
