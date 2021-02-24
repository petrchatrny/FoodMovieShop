using FoodMovieShop.Enum;
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
        public RelayCommand<ShopItemType> AddShopItemCommand { get; private set; }
        public RelayCommand DeleteShopItemCommand { get; private set; }

        // constructor
        public MainViewModel()
        {
            this.ShopItems = new ObservableCollection<ShopItem>();
            this.AddShopItemCommand = new RelayCommand<ShopItemType>(AddShopItem);
            this.DeleteShopItemCommand = new RelayCommand(DeleteShopItem, () => SelectedShopItem != null);
        }

        // methods
        private void AddShopItem(ShopItemType type)
        {
            ShopItem shopItem = null;
            switch (type)
            {
                case ShopItemType.Food:
                    shopItem = new Food("New food", 0, "https://s3.amazonaws.com/vulture-food-photos/defaultvulture.png", 0, 0);
                    break;
                case ShopItemType.Movie:
                    shopItem = new Movie("New Movie", 0, "https://media.comicbook.com/files/img/default-movie.png", 0, "unknown");
                    break;
            }
            if (shopItem != null) 
            {
                ShopItems.Add(shopItem);
                SelectedShopItem = shopItem;
            }
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
