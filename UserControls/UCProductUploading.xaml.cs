using HandyControl.Controls;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpf_TechMarketMangement.Models;
using Object = wpf_TechMarketMangement.Models.Object;
namespace wpf_TechMarketMangement.UserControls
{
    /// <summary>
    /// Interaction logic for UCProductUploading.xaml
    /// </summary>
    public partial class UCProductUploading : UserControl
    {
        //    private ObservableCollection<Object> _List; //link model to viewmodel
        //    public ObservableCollection<Object> List { get => _List; set { _List = value; OnPropertyChanged(nameof(_List)); } }

        //    public event PropertyChangedEventHandler PropertyChanged;
        //    public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }

        public UCProductUploading()
        {
            InitializeComponent();
            //LoadCardData();


        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ucInput.Visibility = Visibility.Visible;
        }



        //private void LoadCardData()
        //{


        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    List = new ObservableCollection<Object>(DataProvider.Ins.DB.Objects); //lay du lieu tu database va hien thi

        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
        //    ofd.Multiselect = true;
        //    ofd.Title = "Select Image Files";
        //    bool? success = ofd.ShowDialog();
        //    if (success == true)
        //    {
        //        string[] path = ofd.FileNames;
        //        //tblImg.Text = path;
        //        var obj = new Object();
        //        DataProvider.Ins.DB.Objects.Add(obj); //add vao
        //        DataProvider.Ins.DB.SaveChanges(); //luu lai tron database
        //        List.Add(obj); //add vao list
        //        //img1.Source = obj.Img1;
        //        //img2.Source = obj.Img2;
        //        //img3.Source = obj.Img3;

        //    }
        //    else
        //    {

        //    }
        //}
    }
}

