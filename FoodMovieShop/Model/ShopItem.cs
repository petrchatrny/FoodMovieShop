using GalaSoft.MvvmLight;

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

        private int inStock;
        public int InStock 
        {
            get { return inStock; }
            set { Set(() => InStock, ref inStock, value); }
        }
        
        private string imageLink;

		public string ImageLink
        {
            get { return imageLink; }
            set { Set(() => ImageLink, ref imageLink, value); }
        }

        protected ShopItem(string name, int price, int inStock, string imageLink)
        {
            Name = name;
            Price = price;
            InStock = inStock;
            ImageLink = imageLink;
        }
    }
}
