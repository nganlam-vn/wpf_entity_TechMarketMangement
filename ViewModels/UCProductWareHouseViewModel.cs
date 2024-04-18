using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketMangement.Models;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using wpf_TechMarketManagemnet.ViewModels;
using System.Windows.Controls;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCProductWareHouseViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
      
        //ObservableCollection de cap nhat du lieu len giao dien ngay lap tuc
        private ObservableCollection<ProductWareHouse> _WareHouseList; //link model to viewmodel
        public ObservableCollection<ProductWareHouse> WareHouseList { get => _WareHouseList; set { _WareHouseList = value; OnPropertyChanged(nameof(WareHouseList)); } }
        public UCProductWareHouseViewModel()
        {
            LoadProductData();
        }
        private void LoadProductData()
        {
            // Load data from database
            WareHouseList = new ObservableCollection<ProductWareHouse>();
            var objectList = DataProvider.Ins.DB.Objects;
            int i = 1;
            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                var outputList = DataProvider.Ins.DB.OuputInfoes.Where(p => p.IdObject == item.Id);

                int sumInput = 0;
                int sumOutput = 0;

                // ?? 0 la neu inputList.Sum(p => p.Counts) == null thi gan = 0
                sumInput = inputList.Sum(p => p.Counts) ?? 0 ;//tinh ton kho
                               
                sumOutput = outputList.Sum(p => p.Counts) ?? 0;
                
                ProductWareHouse wareHouse = new ProductWareHouse();
                wareHouse.Number = i;
                wareHouse.Count = sumInput - sumOutput;
                wareHouse.Object = item;

                WareHouseList.Add(wareHouse);
                i++;
                
            }
            //DataProvider.Ins.DB.
        }
    }

   
}
