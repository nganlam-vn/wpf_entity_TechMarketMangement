using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using Object = System.Object;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCSubmitComment : BaseViewModel
    {
        //private ObservableCollection<Comment> _List; //link model to viewmodel
        //public ObservableCollection<Comment> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }


        //private string _UserName;
        //public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        //private string _UserEmail;
        //public string UserEmail { get => _UserEmail; set { _UserEmail = value; OnPropertyChanged(); } }

        //private string _UserPhone;
        //public string UserPhone { get => _UserPhone; set { _UserPhone = value; OnPropertyChanged(); } }

        //private string _UserComment;
        //public string UserComment { get => _UserComment; set { _UserComment = value; OnPropertyChanged(); } }
        //private int _UserRate;
        //public int UserRate { get => _UserRate; set { _UserRate = value; OnPropertyChanged(); } }
        //private string _Img1Text;
        //public string Img1Text { get => _Img1Text; set { _Img1Text = value; OnPropertyChanged(); } }

        //private string _Img2Text;
        //public string Img2Text { get => _Img2Text; set { _Img2Text = value; OnPropertyChanged(); } }

        //private string _Img3Text;
        //public string Img3Text { get => _Img3Text; set { _Img3Text = value; OnPropertyChanged(); } }
        //public ICommand BrowseCommand1 { get; set; }
        //public ICommand BrowseCommand2 { get; set; }
        //public ICommand BrowseCommand3 { get; set; }
        //public ICommand AddComment { get; set; }

        //public UCSubmitComment()
        //{
        //    List = new ObservableCollection<Comment>(DataProvider.Ins.DB.Comments); //lay du lieu tu database va hien thi
        //    AddComment = new RelayCommand<Comment>((p) =>
        //    {
        //        if (UserName == null || UserEmail == null || UserPhone == null || UserComment == null){
        //            return false;
        //        }
        //        return true;
        //    }, (p) =>
        //    {
        //        var cmt = new Comment()
        //        {
        //            DisplayName = UserName,
        //            Email = UserEmail,
        //            PhoneNumber = UserPhone,
        //            Write = UserComment,
        //            StarRate = UserRate,
        //        };
        //        DataProvider.Ins.DB.Comments.Add(cmt); //add vao
        //        DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
        //        List.Add(cmt); //add vao list
        //        System.Windows.Forms.MessageBox.Show("Your review is saved!");
        //    });

        //}
    }
}

