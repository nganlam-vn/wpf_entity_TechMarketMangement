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
        private ObservableCollection<User> _UserList; //link model to viewmodel
        public ObservableCollection<User> UserList { get => _UserList; set { _UserList = value; OnPropertyChanged(nameof(UserList)); } }
        private int _IdText;
        public int IdText { get => _IdText; set { _IdText = value; } }

        private string _UserNameText;
        public string UserNameText { get => _UserNameText; set { _UserNameText = value; } }
        private string _RoleText;
        public string RoleText { get => _RoleText; set { _RoleText = value; } }
        private string _FullNameText;
        public string FullNameText { get => _FullNameText; set { _FullNameText = value; } }
        
        private string _WelcomeText;
        public string WelcomeText { get => _WelcomeText; set { _WelcomeText = value; } }
        public UCAccountViewModel()
        {
            // Load data from database
            LoadData();
        }
        //private Users currentUser;
        LoginViewModel login = new LoginViewModel();
        private void LoadData()
        {
            if (Properties.Settings.Default.idUser >= 1 )
            {
                IdText = Properties.Settings.Default.idUser;
                UserNameText = Properties.Settings.Default.username;
                FullNameText = DataProvider.Ins.DB.Users.Where(x => x.Id == IdText).SingleOrDefault().DisplayName;
                var role = DataProvider.Ins.DB.Users.Where(x => x.Id == IdText).SingleOrDefault().IdRole;
                RoleText = DataProvider.Ins.DB.UserRoles.Where(x => x.Id == role).SingleOrDefault().DisplayName;
                WelcomeText = "Welcome " + FullNameText + "!";
            }
           
        }
      
    }
}
