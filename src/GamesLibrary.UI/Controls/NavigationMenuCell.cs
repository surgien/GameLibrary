using Xamarin.Forms;

namespace GamesLibrary.Client.UI
{
    /// <summary>
    /// ImageCell-Extension with IconGlyph
    /// </summary>
    public class NavigationMenuCell : ImageCell
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
