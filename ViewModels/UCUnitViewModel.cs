using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;


namespace wpf_TechMarketMangement.ViewModels
{
    public class UCUnitViewModel : BaseViewModel
    {
        private ObservableCollection<Unit> _List; //link model to viewmodel
        public ObservableCollection<Unit> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

        private Unit _SelectedItem;
        public Unit SelectedItem { get => _SelectedItem; 
            set { _SelectedItem = value; OnPropertyChanged(); 
                if (SelectedItem != null)
                    { 
                        SearchText = SelectedItem.DisplayName; 
                    } } }
        
        private string _SearchText;
        public string SearchText { get => _SearchText; set { _SearchText = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public UCUnitViewModel()
        {
            List = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units); //lay du lieu tu database va hien thi
            
            AddCommand = new RelayCommand<object>((p) =>
            {
                //dieu kien bam nut add
                if(string.IsNullOrEmpty(SearchText))
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName == SearchText);
                if(displayList == null || displayList.Count() != 0)
                    return false;

                return true;
                
            }, (p) => {
                var unit = new Unit() { DisplayName = SearchText };
                DataProvider.Ins.DB.Units.Add(unit); //add vao
                DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
                List.Add(unit); //add vao list
            });

            UpdateCommand = new RelayCommand<object>((p) =>
            {
                //dieu kien bam nut add
                if (string.IsNullOrEmpty(SearchText) || SelectedItem == null)
                {
                    return false;
                }
                var displayList = DataProvider.Ins.DB.Units.Where(x => x.DisplayName == SearchText);
                if (displayList == null || displayList.Count() != 0)
                    return false;

                return true;

            }, (p) => {
                var unit = DataProvider.Ins.DB.Units.Where(x => x.Id == SelectedItem.Id).SingleOrDefault();
                unit.DisplayName = SearchText; //add vao database
                
                DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
                SelectedItem.DisplayName = SearchText; //add vao list
                
            });
        }
    }
}
