using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodMovieShop.Model
{
    public abstract class ShopItem : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { Set(() => Name, ref name, value); }
        }

        private int price;
        public int Price
        {
            get { return price; }
            set { Set(() => Price, ref price, value); }
        }

        private string imageLink;

        public string ImageLink
        {
            get { return imageLink; }
            set { Set(() => ImageLink, ref imageLink, value); }
        }

        protected ShopItem(string name, int price, string imageLink)
        {
            Name = name;
            Price = price;
            ImageLink = imageLink;
        }
    }
}
