using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;

namespace wpf_TechMarketMangement.ViewModels
{
    public class FBillingViewModel : BaseViewModel
    {

        private string _EmailText;
        public string EmailText { get => _EmailText; set { _EmailText = value; OnPropertyChanged(); } }

        private string _PhoneText;
        public string PhoneText { get => _PhoneText; set { _PhoneText = value; OnPropertyChanged(); } }

        private string _AddressText;
        public string AddressText { get => _AddressText; set { _AddressText = value; OnPropertyChanged(); } }
        private string _DisplayNameText;
        public string DisplayNameText { get => _DisplayNameText; set { _DisplayNameText = value; OnPropertyChanged(); } }
        private string _MoreInfoText;
        public string MoreInfoText { get => _MoreInfoText; set { _MoreInfoText = value; OnPropertyChanged(); } }

        public ICommand PayCommand { get; set; }
        public ICommand BackCommand { get; set; }
        public FBillingViewModel()
        {
            PayCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(EmailText) || string.IsNullOrEmpty(PhoneText) || string.IsNullOrEmpty(AddressText) || string.IsNullOrEmpty(DisplayNameText))
                {
                    return false;
                }
                return true; 
            }, 
            (p) =>
            {
                var customer = new Customer()
                {
                    DisplayName = DisplayNameText,
                    Address = AddressText,
                    Phone = PhoneText,
                    Email = EmailText,
                    MoreInfo = MoreInfoText,
                };
                DataProvider.Ins.DB.Customers.Add(customer);
                DataProvider.Ins.DB.SaveChanges();
                
                MessageBox.Show("Payment success");

                var outputInfo = new OuputInfo()
                {

                };
            });

            

         }
    }
}
