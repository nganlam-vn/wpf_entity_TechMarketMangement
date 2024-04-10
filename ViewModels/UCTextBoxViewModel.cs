using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.UserControls;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCTextBoxViewModel : BaseViewModel
    {
        #region commands
        public ICommand DeleteTextCommand { get; set; }
        #endregion

        public UCTextBoxViewModel()
        {
            DeleteTextCommand = new RelayCommand<UserControl>((p) => { return p == null? false : true; }, (p) => { });
        }
    }
   
}
