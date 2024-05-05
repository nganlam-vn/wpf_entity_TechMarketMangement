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
    public class UCAccountViewModel : BaseViewModel
    {
        private ObservableCollection<User> _UserList; //link model to viewmodel
        public ObservableCollection<User> UserList { get => _UserList; set { _UserList = value; OnPropertyChanged(nameof(_UserList)); } }
        public UCAccountViewModel()
        {

        }
        private void LoadProductData()
        {
            // Load data from database
            UserList = new ObservableCollection<User>();
            var userList = DataProvider.Ins.DB.Objects;
            foreach (var item in userList)
            {
                //var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                //var outputList = DataProvider.Ins.DB.OuputInfoes.Where(p => p.IdObject == item.Id);

                //int sumInput = 0;
                //int sumOutput = 0;

                //// ?? 0 la neu inputList.Sum(p => p.Counts) == null thi gan = 0
                //sumInput = inputList.Sum(p => p.Counts) ?? 0;//tinh ton kho

                //sumOutput = outputList.Sum(p => p.Counts) ?? 0;

                //ProductWareHouse wareHouse = new ProductWareHouse();
                //wareHouse.Number = i;
                //wareHouse.Count = sumInput - sumOutput;
                //wareHouse.Object = item;

                //UserList.Add(wareHouse);
                //i++;

            }
            //DataProvider.Ins.DB.
        }
    }
}
