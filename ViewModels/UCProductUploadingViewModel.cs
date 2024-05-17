using HandyControl.Tools.Extension;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using wpf_TechMarketMangement.UserControls;
using Object = wpf_TechMarketMangement.Models.Object;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCProductUploadingViewModel : BaseViewModel
    {
        private ObservableCollection<Object> _List; //link model to viewmodel
        public ObservableCollection<Object> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

        private ObservableCollection<Supplier> _SuppilierList; //link model to viewmodel
        public ObservableCollection<Supplier> SuppilierList { get => _SuppilierList; set { _SuppilierList = value; OnPropertyChanged(nameof(_SuppilierList)); } }

        private ObservableCollection<Unit> _UnitList; //link model to viewmodel
        public ObservableCollection<Unit> UnitList { get => _UnitList; set { _UnitList = value; OnPropertyChanged(nameof(_UnitList)); } }

        private string _ProductNameText;
        public string ProductNameText { get => _ProductNameText; set { _ProductNameText = value; OnPropertyChanged(); } }

        private string _BrandText;
        public string BrandText { get => _BrandText; set { _BrandText = value; OnPropertyChanged(); } }

        private Supplier _SupplierText;
        public Supplier SupplierText { get => _SupplierText; set { _SupplierText = value; OnPropertyChanged(); } }

        private Unit _UnitText;
        public Unit UnitText { get => _UnitText; set { _UnitText = value; OnPropertyChanged(); } }

        private string _Img4Text;
        public string Img4Text { get => _Img4Text; set { _Img4Text = value; OnPropertyChanged(); } }

        private string _Img2Text;
        public string Img2Text { get => _Img2Text; set { _Img2Text = value; OnPropertyChanged(); } }

        private string _Img3Text;
        public string Img3Text { get => _Img3Text; set { _Img3Text = value; OnPropertyChanged(); } }
        private int _RAMText;
        public int RAMText { get => _RAMText; set { _RAMText = value; OnPropertyChanged(); } }
        private int _ROMText;
        public int ROMText { get => _ROMText; set { _ROMText = value; OnPropertyChanged(); } }
        private int _BatteryText;
        public int BatteryText { get => _BatteryText; set { _BatteryText = value; OnPropertyChanged(); } }

        public ICommand BrowseCommand1 { get; set; }
        public ICommand BrowseCommand2 { get; set; }
        public ICommand BrowseCommand3 { get; set; }
        public ICommand AddCommand { get; set; }
        public UCProductUploadingViewModel()
        {
            List = new ObservableCollection<Object>(DataProvider.Ins.DB.Objects); //lay du lieu tu database va hien thi
            SuppilierList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Suppliers);
            UnitList = new ObservableCollection<Unit>(DataProvider.Ins.DB.Units);

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (ProductNameText == null || BrandText == null || SupplierText == null || UnitText == null || RAMText == 0 || ROMText == 0 || BatteryText == 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var obj = new Object()
                {
                    DisplayName = ProductNameText,
                    Brand = BrandText,
                    //Type = TypeText.Type,
                    IdUnit = UnitText.Id,
                    IdSupplier = SupplierText.Id,
                    Img1 = Img4Text,
                    Img2 = Img2Text,
                    Img3 = Img3Text,
                    RAM = RAMText,
                    ROM = ROMText,
                    Battery = BatteryText,
                };
                DataProvider.Ins.DB.Objects.Add(obj); //add vao
                DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
                List.Add(obj); //add vao list
                MessageBox.Show("Your information is saved!");
                UCInput uc = new UCInput();
                uc.Visibility=Visibility.Visible;

            });

            BrowseCommand1 = new RelayCommand<object>((x) => { return true; }, (x) =>
            {
                {
                    List = new ObservableCollection<Object>(); //lay du lieu tu database va hien thi

                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    ofd.Multiselect = true;
                    ofd.Title = "Select Image Files";
                    if (ofd.ShowDialog() == true)
                    {
                        Uri uri = new Uri(ofd.FileName);
                        UCProductUploading uc = new UCProductUploading();
                        //hien thi anh len
                        //uc.img4.Source = new BitmapImage(uri);
                        uc.img2.Source = new BitmapImage(uri);
                        //uc.img3.Source = new BitmapImage(uri);
                        //copy file to path
                        string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                        string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                        System.IO.File.Copy(sourceFile, destinationFile, true);
                        Img2Text = System.IO.Path.GetFileName(ofd.FileName);
                    }
                }
            });

            BrowseCommand2 = new RelayCommand<object>((x) => { return true; }, (x) =>
            {
                {
                    List = new ObservableCollection<Object>(); //lay du lieu tu database va hien thi

                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    ofd.Multiselect = true;
                    ofd.Title = "Select Image Files";
                    if (ofd.ShowDialog() == true)
                    {
                        Uri uri = new Uri(ofd.FileName);
                        UCProductUploading uc = new UCProductUploading();
                        //hien thi anh len
                        //uc.img4.Source = new BitmapImage(uri);
                        uc.img3.Source = new BitmapImage(uri);
                        //uc.img3.Source = new BitmapImage(uri);
                        //copy file to path
                        string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                        string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                        System.IO.File.Copy(sourceFile, destinationFile, true);
                        Img3Text = System.IO.Path.GetFileName(ofd.FileName);
                    }
                }

            });

            BrowseCommand3 = new RelayCommand<object>((x) => { return true; }, (x) =>
            {
                {
                    List = new ObservableCollection<Object>(); //lay du lieu tu database va hien thi

                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    ofd.Multiselect = true;
                    ofd.Title = "Select Image Files";
                    if (ofd.ShowDialog() == true)
                    {
                        Uri uri = new Uri(ofd.FileName);
                        UCProductUploading uc = new UCProductUploading();
                        //hien thi anh len
                        //uc.img4.Source = new BitmapImage(uri);
                        uc.img4.Source = new BitmapImage(uri);
                        //uc.img3.Source = new BitmapImage(uri);
                        //copy file to path
                        string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                        string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                        System.IO.File.Copy(sourceFile, destinationFile, true);
                        Img4Text = System.IO.Path.GetFileName(ofd.FileName);
                    }
                }
            });
        }
    }

}

