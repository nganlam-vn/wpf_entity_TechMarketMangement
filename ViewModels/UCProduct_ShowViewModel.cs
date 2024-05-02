using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_TechMarketManagemnet.ViewModels;
using wpf_TechMarketMangement.Models;
using wpf_TechMarketMangement.UserControls;

namespace wpf_TechMarketMangement.ViewModels
{
    public class UCProduct_ShowViewModel : BaseViewModel
    {
        private ObservableCollection<UCCardModel> _CardList; //link model to viewmodel
        public ObservableCollection<UCCardModel> CardList { get => _CardList; set { _CardList = value; OnPropertyChanged(nameof(_CardList)); } }

        public UCProduct_ShowViewModel()
        {
           LoadCardData();
        }
        private void LoadCardData()
        {
            // Load data from database
            CardList = new ObservableCollection<UCCardModel>();
            var objectList = DataProvider.Ins.DB.Objects;

            foreach (var item in objectList)
            {
                var inputList = DataProvider.Ins.DB.InputInfoes.Where(p => p.IdObject == item.Id);
                foreach (var item2 in inputList)
                {
                    UCCard uccard = new UCCard();
                    UCProduct_Show show = new UCProduct_Show();

                   // uccard.txtType.Text = item.Type;
                    uccard.txtbName.Text = item.DisplayName;
                    uccard.txtbPrice.Text = item2.OutputPrice.ToString() + "VND";
                    show.wpCard.Children.Add(uccard);
                }

            }

        }



    }
}
