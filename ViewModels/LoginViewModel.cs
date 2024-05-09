using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;


namespace wpf_TechMarketMangement.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool IsSignIn { get; set; }
        private string _UserName;
        public string UserName { get => _UserName; set { _UserName = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        public ICommand SignInCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }

       
        public LoginViewModel()
        {
            IsSignIn = false;
            SignInCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { SignIn(p);});
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }
        void SignIn(Window p)
        {
            if(p == null)
            {
                return;
            }
            //Lingq
            var accCount = DataProvider.Ins.DB.Users.Where( x => x.UserName == UserName && x.Password == Password).Count(); //check username and password in database
            if(accCount > 0) //dang nhap dung thi cho vao Home
            {   
                //currentUser = new Users() 
                //{
                //    UserName = UserName,
                //    Id = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName).SingleOrDefault().Id

                //};
                //MessageBox.Show("Welcome " + currentUser.UserName +" ," + currentUser.Id);
               
                Properties.Settings.Default.username = UserName;
                Properties.Settings.Default.idUser = DataProvider.Ins.DB.Users.Where(x => x.UserName == UserName).SingleOrDefault().Id;
                Properties.Settings.Default.password = Password;
                Properties.Settings.Default.Save();
                IsSignIn = true;
                p.Close();
            }
            else
            {
                IsSignIn = false;
                MessageBox.Show("Wrong User Name or Password");
            }
            

        }

    }
}
