using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace GameLibrary.Client.UI
{
    public partial class NavigationMenuPage : ContentPage
    {
        public ListView ListView { get { return NavigationListView; } }

        public NavigationMenuPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Last searched",
                IconSource = "\uE8EF;",
                IconGlyphText = "\uE773",
                TargetType = typeof(ContactsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Watchlist",
                IconSource = "asdasd",
                IconGlyphText = "\uE728",
                TargetType = typeof(Testpage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Archive",
                IconSource = "asdasd",
                IconGlyphText = "\uE82D",
                TargetType = typeof(ContactsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Next Releases",
                IconSource = "asdasd",
                IconGlyphText = "\uEE93",
                TargetType = typeof(ContactsPage)
            });

            NavigationListView.ItemsSource = masterPageItems;
        }
    }
}
