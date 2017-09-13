using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesLibrary.Client.Core
{
    /// <summary>
    /// TODO: Adapt Plugin https://github.com/jamesmontemagno/SettingsPlugin
    /// </summary>
    public static class Settings
    {
        public static ApplicationTheme CurrentTheme { get; set; } = ApplicationTheme.Default;
    }

    public enum ApplicationTheme
    {
        Default,
        Dark,
        Light,
    }
}
