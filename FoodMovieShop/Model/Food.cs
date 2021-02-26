namespace FoodMovieShop.Model
{
	public class Food : ShopItem
    {
        private int servings;
        public int Servings
        {
            get { return servings; }
            set { Set(() => Servings, ref servings, value); }
        }

        private int readyInMinutes;

        public int ReadyInMinutes
        {
            get { return readyInMinutes; }
            set { Set(() => ReadyInMinutes, ref readyInMinutes, value); }
        }

        public Food(string name, int price, int inStock, string imageLink, int ammount, int readyInMinutes) : base(name, price, inStock, imageLink)
        {
            Servings = ammount;
            ReadyInMinutes = readyInMinutes;
        }
    }
}
