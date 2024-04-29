using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using Object = wpf_TechMarketMangement.Models.Object;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCProductUploadingViewModel : BaseViewModel
    {
        private ObservableCollection<UCProductUploadingModel> _List; //link model to viewmodel
        public ObservableCollection<UCProductUploadingModel> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

       
        private string _ProductNameText;
        public string ProductNameText { get => _ProductNameText; set { _ProductNameText = value; OnPropertyChanged(); } }

        private string _ConditionText;
        public string ConditionText { get => _ConditionText; set { _ConditionText = value; OnPropertyChanged(); } }

        private string _BrandText;
        public string BrandText { get => _BrandText; set { _BrandText = value; OnPropertyChanged(); } }

        private string _QuantityText;
        public string QuantityText { get => _QuantityText; set { _QuantityText = value; OnPropertyChanged(); } }

        private string _TypeText;
        public string TypeText { get => _TypeText; set { _TypeText = value; OnPropertyChanged(); } }

        private string _BoughtYearText;
        public string BoughtYearText { get => _BoughtYearText; set { _BoughtYearText = value; OnPropertyChanged(); } }

        private string _OriginalPriceText;
        public string OriginalPriceText { get => _OriginalPriceText; set { _OriginalPriceText = value; OnPropertyChanged(); } }

        private string _SalePriceText;
        public string SalePriceText { get => _SalePriceText; set { _SalePriceText = value; OnPropertyChanged(); } }

        private string _DescriptionText;
        public string DescriptionText { get => _DescriptionText; set { _DescriptionText = value; OnPropertyChanged(); } }

        private string _Img1Text;
        public string Img1Text { get => _Img1Text; set { _Img1Text = value; OnPropertyChanged(); } }

        private string _Img2Text;
        public string Img2Text { get => _Img2Text; set { _Img2Text = value; OnPropertyChanged(); } }

        private string _Img3Text;
        public string Img3Text { get => _Img3Text; set { _Img3Text = value; OnPropertyChanged(); } }


        public ICommand BrowseCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public UCProductUploadingViewModel()
        {
            List = new ObservableCollection<UCProductUploadingModel>(); //lay du lieu tu database va hien thi
           
            AddCommand = new RelayCommand<object>((p) =>{return true;}, (p) => 
            {
               
                var ip = new Input() { };

                var obj = new Object() 
                {
                    DisplayName = ProductNameText,
                    Brand = BrandText, 
                    Type = TypeText,
                    Img1 = Img1Text,
                    Img2 = Img2Text,
                    Img3 = Img3Text,
                };

                var inf = new InputInfo()
                {
                    //IdInput = ip.Id,
                    IdObject = obj.Id,
                    Counts = int.Parse(QuantityText),
                    InputPrice = int.Parse(OriginalPriceText),
                    OutputPrice = int.Parse(SalePriceText),

                };
                //DataProvider.Ins.DB.Inputs.Add(ip);
                //DataProvider.Ins.DB.InputInfoes.Add(inf);
                //DataProvider.Ins.DB.SaveChanges();
                UCProductUploadingModel uc = new UCProductUploadingModel();
                uc.Object = obj;
                uc.InputInfo = inf;
                uc.Input = ip;
                DataProvider.Ins.DB.Inputs.Add(ip);
                DataProvider.Ins.DB.Objects.Add(obj); //add vao
                DataProvider.Ins.DB.InputInfoes.Add(inf); //add vao
                
                DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
                List.Add(uc); //add vao list

            });

            BrowseCommand = new RelayCommand<object>((x) => { return true; }, (x) =>
            {
                {
                    List = new ObservableCollection<UCProductUploadingModel>(); //lay du lieu tu database va hien thi

                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    ofd.Multiselect = true;
                    ofd.Title = "Select Image Files";
                    bool? success = ofd.ShowDialog();
                    if (success == true)
                    {
                        string[] files = ofd.FileNames;
                        Img1Text = files[0];
                        Img2Text = files[1];
                        Img3Text = files[2];

                    }
                    else
                    {

                    }
                }

            });
        }
    }
}

