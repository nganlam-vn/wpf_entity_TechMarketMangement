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

namespace wpf_TechMarketMangement.ViewModels
{
    public class FSupplierViewModel :BaseViewModel
    {
        private ObservableCollection<Supplier> _List; //link model to viewmodel
        public ObservableCollection<Supplier> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

        private string _NameText;
        public string NameText { get => _NameText; set { _NameText = value; OnPropertyChanged(); } }

        private string _IDText;
        public string IDText { get => _IDText; set { _IDText = value; OnPropertyChanged(); } }

        private string _EmailText;
        public string EmailText { get => _EmailText; set { _EmailText = value; OnPropertyChanged(); } }

        private string _AddressText;
        public string AddressText { get => _AddressText; set { _AddressText = value; OnPropertyChanged(); } }

        private string _PhoneText;
        public string PhoneText { get => _PhoneText; set { _PhoneText = value; OnPropertyChanged(); } }

        private DateTime? _ContractDateText;
        public DateTime? ContractDateText { get => _ContractDateText; set { _ContractDateText = value; OnPropertyChanged(); } }

        private string _InfoText;
        public string InfoText { get => _InfoText; set { _InfoText = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public FSupplierViewModel()
        {
            List = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Suppliers); //lay du lieu tu database va hien thi

            AddCommand = new RelayCommand<object>((p) =>{return true;}, (p) => {
                var supplier = new Supplier() { 
                    DisplayName =  NameText,
                    IdUser = int.Parse(IDText),
                    Email = EmailText,
                    Address = AddressText,
                    Phone = PhoneText,
                    ContractDate = ContractDateText,
                    MoreInfo = InfoText,
                };
                DataProvider.Ins.DB.Suppliers.Add(supplier); //add vao
                DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
                List.Add(supplier); //add vao list
                MessageBox.Show("Your information is saved!");
            });

        }
    }
}
