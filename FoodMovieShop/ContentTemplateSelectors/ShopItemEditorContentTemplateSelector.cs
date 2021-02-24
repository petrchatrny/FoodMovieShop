using FoodMovieShop.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace FoodMovieShop.ContentTemplateSelectors
{
    public class ShopItemEditorContentTemplateSelector : DataTemplateSelector
    {

        public DataTemplate FoodEditorTemplate 
        {
            get;
            set;
        }

        public DataTemplate MovieEditorTemplate
        {
            get;
            set;
        }

        public ShopItemEditorContentTemplateSelector()
        {
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null) 
            {
                return null;
            }

            if (item is Food)
            {
                return FoodEditorTemplate;
            }
            else if (item is Movie)
            {
                return MovieEditorTemplate;
            }
            else 
            {
                return null;
            }
        }
    }
}
