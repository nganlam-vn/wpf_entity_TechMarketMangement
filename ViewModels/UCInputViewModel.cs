using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using Object = wpf_TechMarketMangement.Models.Object;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCInputViewModel : BaseViewModel
    {
        private ObservableCollection<InputInfo> _List; //link model to viewmodel
        public ObservableCollection<InputInfo> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }
        private ObservableCollection<Object> _ObjectList; //link model to viewmodel
        public ObservableCollection<Object> ObjectList { get => _ObjectList; set { _ObjectList = value; OnPropertyChanged(nameof(_ObjectList)); } }

        private int _QuantityText;
        public int QuantityText { get => _QuantityText; set { _QuantityText = value; OnPropertyChanged(); } }

        private int _ConditionText;
        public int ConditionText { get => _ConditionText; set { _ConditionText = value; OnPropertyChanged(); } }

        private Object _ObjectText;
        public Object ObjectText { get => _ObjectText; set { _ObjectText = value; OnPropertyChanged(); } }

        private int _OriginalPriceText;
        public int OriginalPriceText { get => _OriginalPriceText; set { _OriginalPriceText = value; OnPropertyChanged(); } }

        private int _BoughtYearText;
        public int BoughtYearText { get => _BoughtYearText; set { _BoughtYearText = value; OnPropertyChanged(); } }

        private string _ColorText;
        public string ColorText { get => _ColorText; set { _ColorText = value; OnPropertyChanged(); } }
        private int _SalePriceText;
        public int SalePriceText { get => _SalePriceText; set { _SalePriceText = value; OnPropertyChanged(); } }
        private string _MoreInfoText;
        public string MoreInfoText { get => _MoreInfoText; set { _MoreInfoText = value; OnPropertyChanged(); } }

        public ICommand AddCommand;
        public UCInputViewModel()
        {
            AddCommand = new RelayCommand<object>((p) =>
            {
                if (QuantityText == 0 || ConditionText == 0 || ObjectText == null || OriginalPriceText == 0 || BoughtYearText == 0 || ColorText == null || SalePriceText == 0 || MoreInfoText == null)
                {
                    //MessageBox.Show("Please fill in all the information!");
                }
                return true;
            }, (p) =>
            {
                var input = new InputInfo()
                {
                    IdObject = ObjectText.Id,
                    Counts = QuantityText,
                    Condition = ConditionText,
                    InputPrice = OriginalPriceText,
                    BoughtYear = BoughtYearText,
                    Color = ColorText,
                    OutputPrice = SalePriceText,
                    Description = MoreInfoText,
                };
                DataProvider.Ins.DB.InputInfoes.Add(input); //add vao
                DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
                List.Add(input); //add vao list
                MessageBox.Show("Your request is sent to Admin. Please wait, your product will be uploaded soon!");
            });

        }
    }
}
