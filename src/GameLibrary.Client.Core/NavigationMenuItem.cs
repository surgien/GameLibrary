using System;

namespace GameLibrary.Client.Core.ViewModel
{
    public class NavigationMenuItem
    {
        public string IconSource { get; set; }
        public Type TargetViewModelType { get; set; }
        public string Title { get; set; }
        public string IconGlyphText { get; set; }
    }
}