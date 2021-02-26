using FoodMovieShop.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace FoodMovieShop.Converters
{
	public class InStockToBackgroundColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var shopItem = (ShopItem)value;
			if (shopItem == null) 
			{
				return null;
			}

			if (shopItem.InStock <= 0)
			{
				return new SolidColorBrush(Colors.Gray);
			}

			else
			{
				if (shopItem is Food)
				{
					return new SolidColorBrush(Colors.CornflowerBlue);
				}
				else if (shopItem is Movie)
				{
					return new SolidColorBrush(Colors.IndianRed);
				}
				else
				{
					return null;
				}
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return value;
		}
	}
}
