using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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


        // writing for close button
        //public UCTextBoxViewModel()
        //{
        //    DeleteTextCommand = new RelayCommand<UserControl>((p) => { return p == null? false : true; }, (p) => { FrameworkElement window = GetWindowParent(p);
        //        var w = window as Window;
        //        if (w != null)
        //        {
        //            w.Close();
        //        }
        //    });
        //}
        //FrameworkElement GetWindowParent(UserControl p)
        //{
        //    FrameworkElement parent = p; // p is usercontrol

        //    while(parent.Parent != null)
        //    {
        //        parent = p.Parent as FrameworkElement;
        //    }
        //    return parent;
        //}
    }
   
}
