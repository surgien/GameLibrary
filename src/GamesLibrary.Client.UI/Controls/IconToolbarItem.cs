using GamesLibrary.Client.UI;
using System.ComponentModel;
using Xamarin.Forms;

namespace GamesLibrary.Client.UI
{
    /// <summary>
    /// ToolbarItem-Extension with IconGlyph
    /// </summary>
    public class IconToolbarItem : ToolbarItem
    {
        public static readonly BindableProperty IconGlyphProperty =
  BindableProperty.Create("IconGlyph", typeof(string), typeof(NavigationMenuPage), null);

        /// <summary>
        /// Glyphicon in CommandBar
        /// </summary>
        public string IconGlyph
        {
            get { return (string)GetValue(IconGlyphProperty); }
            set { SetValue(IconGlyphProperty, value); }
        }
    }
}
