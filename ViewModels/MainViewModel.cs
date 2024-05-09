using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using System.Windows; //add the System.Windows namespace
using wpf_TechMarketMangement.Models;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates; //add the System.Windows.Input namespace


namespace wpf_TechMarketMangement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; } //load
        public ICommand LogoutCommand { get; set; }
        public ICommand SignInCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public MainViewModel()
        {

            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsLoaded = true;
                if (p == null) //check null
                    return;
                //Hien login window len truoc
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog(); /*chi tuong tac voi LoginWindow khong tuong tac voi mainWindow*/
               
                if (loginWindow.DataContext == null)
                    return;

                var loginVM = loginWindow.DataContext as LoginViewModel;
                if(loginVM.IsSignIn) //method in SignInViewModel
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });

            LogoutCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                //if (p == null) //check null
                //    return;
                //p.Close();
                
                
            });

            SignInCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
               
                //bug 
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog(); /*chi tuong tac voi LoginWindow khong tuong tac voi mainWindow*/

                if (loginWindow.DataContext == null)
                    return;

                var loginVM = loginWindow.DataContext as LoginViewModel;
                if (loginVM.IsSignIn) //method in SignInViewModel
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            });



            //var a = DataProvider.Ins.DB.Users.First();
            //MessageBox.Show(a.DisplayName);
        }
    }
}
