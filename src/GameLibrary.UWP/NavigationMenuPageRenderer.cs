using GameLibrary.Client.UI;
using GameLibrary.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uwp = Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml;

[assembly: ExportRenderer(typeof(NavigationMenuPage), typeof(NavigationMenuPageRenderer))]
[assembly: ExportRenderer(typeof(NavigationMenuCell), typeof(NavigationMenuCellRenderer))]
namespace GameLibrary.UWP
{
    /// <summary>
    /// Renderer für Steuerung der Menüstruktur
    /// 
    /// </summary>
    public class NavigationMenuPageRenderer : PageRenderer
    {
    }

    /// <summary>
    /// Renderer für Visualisierung der einzelnen Menüeinträge
    /// </summary>
    public class NavigationMenuCellRenderer : ImageCellRenderer
    {
        public override Windows.UI.Xaml.DataTemplate GetTemplate(Cell cell)
        {
            return (Windows.UI.Xaml.DataTemplate)App.Current.Resources["MenuItemTemplate"];

            //return base.GetTemplate(cell);
        }
    }
}
