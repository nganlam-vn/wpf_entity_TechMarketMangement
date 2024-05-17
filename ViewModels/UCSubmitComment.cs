using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Win32;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using wpf_TechMarketMangement.UserControls;


namespace wpf_TechMarketMangement.ViewModels
{
    public class UCSubmitComment : BaseViewModel
    {
        private ObservableCollection<Comment> _List; //link model to viewmodel
        public ObservableCollection<Comment> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }


        private string _UserNameText;
        public string UserNameText { get => _UserNameText; set { _UserNameText = value; OnPropertyChanged(); } }

        private string _UserEmailText;
        public string UserEmailText { get => _UserEmailText; set { _UserEmailText = value; OnPropertyChanged(); } }

        private string _UserPhonetText;
        public string UserPhonetText { get => _UserPhonetText; set { _UserPhonetText = value; OnPropertyChanged(); } }

        private string _UserCommentText;
        public string UserCommentText { get => _UserCommentText; set { _UserCommentText = value; OnPropertyChanged(); } }
        private int _UserRateText;
        public int UserRateText { get => _UserRateText; set { _UserRateText = value; OnPropertyChanged(); } }
        private string _Img1Text;
        public string Img1Text { get => _Img1Text; set { _Img1Text = value; OnPropertyChanged(); } }

        private string _Img2Text;
        public string Img2Text { get => _Img2Text; set { _Img2Text = value; OnPropertyChanged(); } }

        private string _Img3Text;
        public string Img3Text { get => _Img3Text; set { _Img3Text = value; OnPropertyChanged(); } }
        public ICommand BrowseCommand1 { get; set; }
        public ICommand BrowseCommand2 { get; set; }
        public ICommand BrowseCommand3 { get; set; }
        public ICommand AddCommand { get; set; }

        public UCSubmitComment()
        {
            List = new ObservableCollection<Comment>(DataProvider.Ins.DB.Comments); //lay du lieu tu database va hien thi
           

            BrowseCommand1 = new RelayCommand<object>((x) => { return true; }, (x) =>
            {
                {
                    List = new ObservableCollection<Comment>(); //lay du lieu tu database va hien thi

                    Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    ofd.Multiselect = true;
                    ofd.Title = "Select Image Files";
                    if (ofd.ShowDialog() == true)
                    {
                        Uri uri = new Uri(ofd.FileName);
                        FSubmitComment uc = new FSubmitComment();
                        //hien thi anh len
                        //uc.img4.Source = new BitmapImage(uri);
                        uc.img1.ImageSource = new BitmapImage(uri);
                        OnPropertyChanged(nameof(uc.img1));
                        //uc.img3.Source = new BitmapImage(uri);
                        //copy file to path
                        string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                        string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                        System.IO.File.Copy(sourceFile, destinationFile, true);
                        Img1Text = System.IO.Path.GetFileName(ofd.FileName);
                    }
                }
            });

            BrowseCommand2 = new RelayCommand<object>((x) => { return true; }, (x) =>
            {
                {
                    List = new ObservableCollection<Comment>(); //lay du lieu tu database va hien thi

                    Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    ofd.Multiselect = true;
                    ofd.Title = "Select Image Files";
                    if (ofd.ShowDialog() == true)
                    {
                        Uri uri = new Uri(ofd.FileName);
                        FSubmitComment uc = new FSubmitComment();
                        //hien thi anh len
                        //uc.img4.Source = new BitmapImage(uri);
                        uc.img2.ImageSource = new BitmapImage(uri);
                        OnPropertyChanged(nameof(uc.img2));
                        //uc.img3.Source = new BitmapImage(uri);
                        //copy file to path
                        string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                        string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                        System.IO.File.Copy(sourceFile, destinationFile, true);
                        Img2Text = System.IO.Path.GetFileName(ofd.FileName);
                    }
                }
            });

            BrowseCommand3 = new RelayCommand<object>((x) => { return true; }, (x) =>
            {
                {
                    List = new ObservableCollection<Comment>(); //lay du lieu tu database va hien thi

                    Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
                    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
                    ofd.Multiselect = true;
                    ofd.Title = "Select Image Files";
                    if (ofd.ShowDialog() == true)
                    {
                        Uri uri = new Uri(ofd.FileName);
                        FSubmitComment uc = new FSubmitComment();
                        //hien thi anh len
                        //uc.img4.Source = new BitmapImage(uri);
                        uc.img3.ImageSource = new BitmapImage(uri);
                        OnPropertyChanged(nameof(uc.img3));
                        //uc.img3.Source = new BitmapImage(uri);
                        //copy file to path
                        string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                        string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                        System.IO.File.Copy(sourceFile, destinationFile, true);
                        Img3Text = System.IO.Path.GetFileName(ofd.FileName);
                    }
                }
            });

            //AddCommand = new RelayCommand<Comment>((p) =>
            //{
            //    if (UserNameText == null || UserEmailText == null || UserPhonetText == null || UserCommentText == null)
            //    {
            //        return false;
            //    }
            //    return true;
            //}, (p) =>
            //{
            //    var cmt = new Comment()
            //    {
            //        DisplayName = UserNameText,
            //        Email = UserEmailText,
            //        PhoneNumber = UserPhonetText,
            //        Write = UserCommentText,
            //        StarRate = UserRateText,
            //    };
            //    DataProvider.Ins.DB.Comments.Add(cmt); //add vao
            //    DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
            //    List.Add(cmt); //add vao list
            //    System.Windows.Forms.MessageBox.Show("Your review is saved!");
            //});

        }
    }
}

