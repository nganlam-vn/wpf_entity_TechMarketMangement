using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using System.Windows; //add the System.Windows namespace
using wpf_TechMarketMangement.Models;

namespace wpf_TechMarketMangement.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsLoaded = false;
        public MainViewModel()
        {
            if (!IsLoaded) /*neu da load r thi ko load lai*/
            {
                IsLoaded = true;
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog(); /*chi tuong tac voi LoginWindow khong tuong tac voi mainWindow*/
            }

            //var a = DataProvider.Ins.DB.Users.First();
            //MessageBox.Show(a.DisplayName);
        }
    }
}
