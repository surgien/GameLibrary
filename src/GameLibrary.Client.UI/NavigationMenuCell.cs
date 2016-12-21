using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GameLibrary.Client.UI
{
    public class NavigationMenuCell: ImageCell
    {
        public static readonly BindableProperty IconGlyphProperty =
  BindableProperty.Create("IconGlyph", typeof(string), typeof(NavigationMenuPage), null);

        /// <summary>
        /// Glyphicon in hamburgermenu
        /// </summary>
        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }
    }
}
