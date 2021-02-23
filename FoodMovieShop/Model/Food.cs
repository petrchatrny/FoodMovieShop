using System;
using System.Collections.Generic;
using System.Text;

namespace FoodMovieShop.Model
{
    public class Food : ShopItem
    {
        private int ammount;
        public int Ammount
        {
            get { return ammount; }
            set { Set(() => Ammount, ref ammount, value); }
        }

        private int readyInMinutes;

        public int ReadyInMinutes
        {
            get { return readyInMinutes; }
            set { Set(() => ReadyInMinutes, ref readyInMinutes, value); }
        }

        public Food(string name, int price, string imageLink, int ammount, int readyInMinutes) : base(name, price, imageLink)
        {
            Ammount = ammount;
            ReadyInMinutes = readyInMinutes;
        }
    }
}
