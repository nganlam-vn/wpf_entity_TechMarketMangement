using System;
using System.Collections.Generic;
using System.Linq;
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
using wpf_TechMarketMangement.UserControls.UCSingleItem;

namespace wpf_TechMarketMangement.UserControls
{
    /// <summary>
    /// Interaction logic for FProductDetail.xaml
    /// </summary>
    public partial class FProductDetail : UserControl
    {
        string userText;
        string emailText;
        string phoneText;
        string commentText;
        int startRate;
        string Img1Text;
        string Img2Text;
        string Img3Text;
        public FProductDetail()
        {
            InitializeComponent();
            LoadData();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fsubmitComment.Visibility = Visibility.Visible;
        }

        public void LoadData()
        {
           
            fsubmitComment.txtRate.ValueChanged += (sender, e) =>
            {
                startRate = (int)fsubmitComment.txtRate.Value;
            };
            fsubmitComment.txtUserName.TextChanged += (sender, e) =>
            {
                userText = fsubmitComment.txtUserName.Text;
            };
            fsubmitComment.txtEmail.TextChanged += (sender, e) =>
            {
                emailText = fsubmitComment.txtEmail.Text;
            };
            fsubmitComment.txtPhone.TextChanged += (sender, e) =>
            {
                phoneText = fsubmitComment.txtPhone.Text;
            };
            fsubmitComment.txtComment.TextChanged += (sender, e) =>
            {
                commentText = fsubmitComment.txtComment.Text;
            };

            fsubmitComment.btnImg1.Click += (sender, e) =>
            {
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
                   
                    //uc.img3.Source = new BitmapImage(uri);
                    //copy file to path
                    string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                    //string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                    Img1Text = System.IO.Path.GetFileName(ofd.FileName);
                }
            };

            fsubmitComment.btnImg2.Click += (sender, e) =>
            {
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

                    //uc.img3.Source = new BitmapImage(uri);
                    //copy file to path
                    string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                    //string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                    //System.IO.File.Copy(sourceFile, destinationFile, true);
                    Img2Text = System.IO.Path.GetFileName(ofd.FileName);
                }
            };

            fsubmitComment.btnImg3.Click += (sender, e) =>
            {
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

                    //uc.img3.Source = new BitmapImage(uri);
                    //copy file to path
                    string sourceFile = ofd.FileName; //lay duong dan file tu bat ki vi tri trong may
                    //string destinationFile = "D:\\baitap\\HK2_2023-2024\\WindowsDev\\Win_Ex\\DoAnCuoiKy\\wpf_entity_TechMarketMangement\\Asset\\Products\\Laptop\\" + System.IO.Path.GetFileName(ofd.FileName);
                    //System.IO.File.Copy(sourceFile, destinationFile, true);
                    Img3Text = System.IO.Path.GetFileName(ofd.FileName);
                }
            };

            //DataContext = new UCSubmitComment();
            fsubmitComment.btnSubmit.Click += (sender, e) =>
            {
                var comment = new Comment()
                {
                    DisplayName = userText,
                    Email = emailText,
                    PhoneNumber = phoneText,
                    IdUser = Properties.Settings.Default.idUser,
                    Write = commentText,
                    StarRate = startRate,
                    Img1 = Img1Text,
                    Img2 = Img2Text,
                    Img3 = Img3Text,
                    IdObject = 1,
                };
                DataProvider.Ins.DB.Comments.Add(comment);
                DataProvider.Ins.DB.SaveChanges();
                MessageBox.Show("Successfully submit comment!");

               

            };
            UCCommentCard uCCommentCard = new UCCommentCard();
            uCCommentCard.tblDisplayName.Text = userText;
            uCCommentCard.tblUserName.Text = Properties.Settings.Default.username;
            uCCommentCard.tblComment.Text = commentText;

            spCommentCard.Children.Add(uCCommentCard);
            fsubmitComment.btnX.Click += (sender, e) =>
            {
                fsubmitComment.Visibility = Visibility.Collapsed;
                spCommentCard.Visibility = Visibility.Visible;
            };
                

        }

        //private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Successfully add to cart!");
        //}

    }
}
