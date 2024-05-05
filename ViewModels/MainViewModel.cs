using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using System.Windows; //add the System.Windows namespace
using wpf_TechMarketMangement.Models;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices; //add the System.Windows.Input namespace


namespace wpf_TechMarketMangement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public ICommand LoadedWindowCommand { get; set; } //load
      
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsLoaded = true;
                if (p == null)
                    return;
                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;
                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsSignIn)
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
