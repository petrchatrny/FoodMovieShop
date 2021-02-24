using FoodMovieShop.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FoodMovieShop.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // observable list
        private ObservableCollection<ShopItem> shopItems;
        public ObservableCollection<ShopItem> ShopItems 
        {
            get { return shopItems; }
            set { Set(() => ShopItems, ref shopItems, value); }
        }

        // selected item of observable list
        private ShopItem selectedShopItem;

        public ShopItem SelectedShopItem 
        {
            get { return selectedShopItem; }
            set { 
                Set(() => SelectedShopItem, ref selectedShopItem, value);
                DeleteShopItemCommand.RaiseCanExecuteChanged();
            }
        }

        // commands
        public RelayCommand FetchDataFromApiCommand { get; private set; }
        public RelayCommand AddShopItemCommand { get; private set; }
        public RelayCommand DeleteShopItemCommand { get; private set; }

        // constructor
        public MainViewModel()
        {
            this.ShopItems = new ObservableCollection<ShopItem>();
            this.AddShopItemCommand = new RelayCommand(AddShopItem);
            this.DeleteShopItemCommand = new RelayCommand(DeleteShopItem, () => SelectedShopItem != null);
        }

        // methods
        private void AddShopItem() 
        {
            var shopItem = new Food("maso", 50, "fasfsafsadf", 10, 15);

            ShopItems.Add(shopItem);
            SelectedShopItem = shopItem;
        }

        private void DeleteShopItem()
        {
            if (SelectedShopItem == null) 
            {
                return;
            }

            ShopItems.Remove(SelectedShopItem);

            if (ShopItems.Count > 0) 
            {
                SelectedShopItem = ShopItems.Last();
            }
        }
    }
}
