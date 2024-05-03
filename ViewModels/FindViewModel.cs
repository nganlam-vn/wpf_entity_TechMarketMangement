using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using Object = wpf_TechMarketMangement.Models.Object;

namespace wpf_TechMarketMangement.ViewModels
{
    public class FindViewModel:BaseViewModel
    {
        private List<Object> _ObjList; //link model to viewmodel
        public List<Object> ObjList { get => _ObjList; set { _ObjList = value; OnPropertyChanged(nameof(_ObjList)); } }

        private string _FilterName;
        public string FilterName { get => _FilterName; set { _FilterName = value; OnPropertyChanged(nameof(_FilterName)); ObjList = Filter(value); } }
        public FindViewModel()
        {
            //this is the constructor
        }

        public void LoadData()
        {
            ObjList = new List<Object>(DataProvider.Ins.DB.Objects); //lay du lieu tu database va hien thi


        }

        public List<Object> Filter(string name)
        {
            var objs = DataProvider.Ins.DB.Objects
                                         .Where(t => t.DisplayName.ToLower().Contains(name.ToLower()))
                                         .ToList();
            return objs;


        }

    }
}
