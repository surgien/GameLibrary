using GameLibrary.UWP.Renderer;
using GamesLibrary.Client.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(IconNavigationPageRenderer))]
namespace GameLibrary.UWP.Renderer
{
    /// <summary>
    /// Renderer for injection of iconchars
    /// </summary>
    public class IconNavigationPageRenderer : NavigationPageRenderer
    {
        public IconNavigationPageRenderer()
        {
            ElementChanged += NavigationMenuPageRenderer_ElementChanged;
        }

        private void NavigationMenuPageRenderer_ElementChanged(object sender, VisualElementChangedEventArgs e)
        {
            ContainerElement.Loaded += (s, ie) =>
            {
                var innerGrid = VisualTreeHelper.GetChild(ContainerElement, 0);

                var grid = VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(innerGrid)));

                var cmdBar = grid.FindChild<FormsCommandBar>("CommandBar");
                foreach (AppBarButton cmd in cmdBar.PrimaryCommands)
                {
                    var toolBarItem = ((FrameworkElement)cmd).DataContext as IconToolbarItem;
                    if (!string.IsNullOrEmpty(toolBarItem.IconGlyph))
                    {
                        var myBinding = new Windows.UI.Xaml.Data.Binding()
                        {
                            Source = toolBarItem,
                            Path = new PropertyPath(nameof(IconToolbarItem.IconGlyph)),
                            Mode = Windows.UI.Xaml.Data.BindingMode.OneWay,
                            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
                        };
                        var icon = new FontIcon() { FontFamily = new FontFamily("Segoe MDL2 Assets"), Glyph = toolBarItem.IconGlyph };
                        icon.SetBinding(FontIcon.GlyphProperty, myBinding);
                        cmd.Icon = icon;
                    }
                }
            };
        }

    }
}
