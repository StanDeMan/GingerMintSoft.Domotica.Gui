using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml.Styling;

namespace GingerMintSoft.Domotica.Gui.Style
{
    public sealed class StyleManager
    {
        public enum Theme { Citrus, Sea, Rust, Candy, Magma, Heima }

        private readonly StyleInclude _magmaStyle = CreateStyle("avares://Citrus.Avalonia/Magma.xaml");
        private readonly StyleInclude _candyStyle = CreateStyle("avares://Citrus.Avalonia/Candy.xaml");
        private readonly StyleInclude _citrusStyle = CreateStyle("avares://Citrus.Avalonia/Citrus.xaml");
        private readonly StyleInclude _rustStyle = CreateStyle("avares://Citrus.Avalonia/Rust.xaml");
        private readonly StyleInclude _seaStyle = CreateStyle("avares://Citrus.Avalonia/Sea.xaml");
        private readonly StyleInclude _heimaStyle = CreateStyle("avares://Citrus.Avalonia/Heima.xaml");
        private readonly Window _window;

        public StyleManager(Window window)
        {
            _window = window;

            // We add the style to the window styles section, so it
            // will override the default style defined in App.xaml. 
            if (window.Styles.Count == 0)
                window.Styles.Add(_heimaStyle);

            // If there are styles defined already, we assume that
            // the first style imported it related to citrus.
            // This allows one to override citrus styles.
            else window.Styles[0] = _heimaStyle;
        }

        public Theme CurrentTheme { get; private set; } = Theme.Heima;

        public void UseTheme(Theme theme)
        {
            // Here, we change the first style in the main window styles
            // section, and the main window instantly refreshes. Remember
            // to invoke such methods from the UI thread.
            _window.Styles[0] = theme switch
            {
                Theme.Citrus => _citrusStyle,
                Theme.Sea => _seaStyle,
                Theme.Rust => _rustStyle,
                Theme.Candy => _candyStyle,
                Theme.Magma => _magmaStyle,
                Theme.Heima => _heimaStyle,
                _ => throw new ArgumentOutOfRangeException(nameof(theme))
            };

            CurrentTheme = theme;
        }

        public void UseNextTheme()
        {
            // This method allows to support switching among all
            // supported color schemes one by one.
            UseTheme(CurrentTheme switch
            {
                Theme.Citrus => Theme.Sea,
                Theme.Sea => Theme.Rust,
                Theme.Rust => Theme.Candy,
                Theme.Candy => Theme.Magma,
                Theme.Magma => Theme.Citrus,
                Theme.Heima => Theme.Heima,
                _ => throw new ArgumentOutOfRangeException(nameof(CurrentTheme))
            });
        }

        private static StyleInclude CreateStyle(string url)
        {
            return new StyleInclude(new Uri("resm:Styles?assembly=Citrus.Avalonia.Sandbox"))
            {
                Source = new Uri(url)
            };
        }
    }
}

