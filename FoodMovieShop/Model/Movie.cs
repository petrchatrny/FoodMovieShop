namespace FoodMovieShop.Model
{
	public class Movie : ShopItem
    {
        private int lenght;
        public int Lenght
        {
            get { return lenght; }
            set { Set(() => Lenght, ref lenght, value); }
        }

        private string director;
        public string Director
        {
            get { return director; }
            set { Set(() => Director, ref director, value); }
        }

        public Movie(string name, int price, int inStock, string imageLink, int lenght, string director) : base(name, price, inStock, imageLink)
        {
            Lenght = lenght;
            Director = director;
        }
    }
}
