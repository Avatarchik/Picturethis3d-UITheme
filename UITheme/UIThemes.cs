using System;

namespace Picturethis3d.UITheme
{
    public enum UITheme
    {
        None = 0,
        Dark = 1,
        Light = 2,
        Generic = 512,
        Elran = 1024,
        Boyteks = 2048
    }

    public static class UIThemes
    {
        public static event Action<UITheme> Changed = delegate { };

        private static UITheme _theme = UITheme.Generic;

        public static readonly int Length;

        static UIThemes()
        {
            Length = Enum.GetValues(typeof(UITheme)).Length;
        }

        public static UITheme Theme
        {
            get => _theme;

            set
            {
                if (_theme != value)
                {
                    _theme = value;
                    Changed(value);
                }
            }
        }
    }
}