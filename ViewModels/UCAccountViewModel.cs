using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCAccountViewModel : BaseViewModel
    {
        private ObservableCollection<Users> _UserList; //link model to viewmodel
        public ObservableCollection<Users> UserList { get => _UserList; set { _UserList = value; OnPropertyChanged(nameof(UserList)); } }
        public UCAccountViewModel()
        {
            // Load data from database
            LoadData();
        }
        //private Users currentUser;
        LoginViewModel login = new LoginViewModel();
        private void LoadData()
        {
            //currentUser = new Users()
            //{
            //    UserName = login.UserName,
            //    Id = DataProvider.Ins.DB.Users.Where(x => x.UserName == login.UserName).SingleOrDefault().Id

            //};
            


            //UserList = new ObservableCollection<User>();
            //var userList = DataProvider.Ins.DB.Users;
            //foreach (var item in userList)
            //{
            //    UserList.Add(item);
            //}

        }
    }
}
