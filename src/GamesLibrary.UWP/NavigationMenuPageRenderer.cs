using GamesLibrary.Client.UI;
using GamesLibrary.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uwp = Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml;
using GamesLibrary.Client.UI;
using Windows.UI.Xaml.Media;

[assembly: ExportRenderer(typeof(NavigationMenuPage), typeof(NavigationMenuPageRenderer))]
[assembly: ExportRenderer(typeof(NavigationMenuCell), typeof(NavigationMenuCellRenderer))]
[assembly: ExportRenderer(typeof(NavigationMenuListView), typeof(NavigationMenuRenderer))]
namespace GamesLibrary.UWP
{
    /// <summary>
    /// Renderer für Steuerung der Menüstruktur
    /// 
    /// </summary>
    public class NavigationMenuPageRenderer : PageRenderer
    {
    }

    /// <summary>
    /// Custom Renderer for sync in NavigationMenu between Xamarin-Forms and UWP
    /// </summary>
    public class NavigationMenuRenderer : ListViewRenderer
    {
        private object _selectedItem;

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);

            var listView = (uwp.ListView)Control;

            listView.SelectionChanged += (s, ie) =>
            {
                var lv = s as uwp.ListView;

                lv.SetValue(uwp.VirtualizingStackPanel.IsVirtualizingProperty, false);

                if (lv.SelectedItem == null) return;

                var uiElement = (uwp.ListViewItem)lv.ContainerFromItem(lv.SelectedItem);
                if (uiElement != null)
                {
                    var itemPresenter = VisualTreeHelper.GetChild(uiElement, 0);
                    var cell = (CellControl)VisualTreeHelper.GetChild(itemPresenter, 0);
                    var radioButton = (uwp.RadioButton)cell.Content;

                    radioButton.IsChecked = true;
                }
                else
                {
                    //if we don't have a value (cause virtualization), register event for later evaluation
                    _selectedItem = lv.SelectedItem;
                    lv.ContainerContentChanging += Lv_ContainerContentChanging;
                }
            };
        }

        private IDisposable _watcher;

        private void Lv_ContainerContentChanging(uwp.ListViewBase sender, uwp.ContainerContentChangingEventArgs args)
        {
            var lv = sender as uwp.ListView;

            var uiElement = (uwp.ListViewItem)lv.ContainerFromItem(_selectedItem);
            if (uiElement != null)
            {
                var itemPresenter = VisualTreeHelper.GetChild(uiElement, 0);
                var cell = (CellControl)VisualTreeHelper.GetChild(itemPresenter, 0);

                // Subscribe
                _watcher = cell.WatchProperty("Content", CellControl_ContentChanged);

                lv.ContainerContentChanging -= Lv_ContainerContentChanging;
                _selectedItem = null;
            }

        }

        private void CellControl_ContentChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var radioButton = (uwp.RadioButton)e.NewValue;
            radioButton.IsChecked = true;

            // Unsubscribe
            _watcher.Dispose();
        }
    }

    /// <summary>
    /// Renderer für Visualisierung der einzelnen Menüeinträge
    /// </summary>
    public class NavigationMenuCellRenderer : ImageCellRenderer
    {
        public override Windows.UI.Xaml.DataTemplate GetTemplate(Cell cell)
        {
            return (Windows.UI.Xaml.DataTemplate)App.Current.Resources["MenuItemTemplate"];
        }
    }
}
