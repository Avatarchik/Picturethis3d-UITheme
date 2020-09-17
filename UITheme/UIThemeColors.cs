using System;
using System.Collections.Generic;
using UnityEngine;

namespace Picturethis3d.UITheme
{
    [CreateAssetMenu(fileName = "UIThemeColors", menuName = "PictureThis/UI/UIThemeColors", order = 4)]
    public class UIThemeColors : ScriptableObject
    {
        [Serializable]
        class ThemeColor
        {
            [SerializeField] private UITheme theme = default;

            public UITheme Theme => theme;

            [SerializeField] private Color color = Color.white;

            public Color Color => color;

            public ThemeColor(UITheme theme)
            {
                this.theme = theme;
            }

            public ThemeColor(UITheme theme, Color color)
            {
                this.theme = theme;
                this.color = color;
            }
        }

        [SerializeField] ThemeColor[] themeColors;

        [NonSerialized] private Dictionary<UITheme, Color> _themeColorsDic;

#if UNITY_EDITOR
        private void Awake()
        {
            UpdateThemes();
        }

        private ThemeColor Find(UITheme theme, ThemeColor[] colors)
        {
            foreach (var t in colors)
            {
                if (t.Theme == theme)
                {
                    return t;
                }
            }

            return null;
        }

        private void UpdateThemes()
        {
            if (themeColors == null)
            {
                var themes = Enum.GetValues(typeof(UITheme));
                themeColors = new ThemeColor[themes.Length];

                int i = 0;
                foreach (UITheme theme in themes)
                {
                    themeColors[i++] = new ThemeColor(theme);
                }

                UnityEditor.EditorUtility.SetDirty(this);
                UnityEditor.AssetDatabase.SaveAssets();
            }
            else
            {
                if (themeColors.Length != UIThemes.Length)
                {
                    var themes = Enum.GetValues(typeof(UITheme));

                    var updatedThemes = new ThemeColor[themes.Length];

                    int i = 0;
                    foreach (UITheme theme in themes)
                    {
                        var existentTheme = Find(theme, themeColors);

                        updatedThemes[i++] = existentTheme ?? new ThemeColor(theme);
                    }

                    themeColors = updatedThemes;

                    UnityEditor.EditorUtility.SetDirty(this);
                    UnityEditor.AssetDatabase.SaveAssets();
                }
            }
        }
#endif

        public Color GetColor(UITheme theme)
        {
            if (_themeColorsDic == null)
            {
#if UNITY_EDITOR
                UpdateThemes();
#endif
                _themeColorsDic = new Dictionary<UITheme, Color>(themeColors.Length);

                foreach (var themeColor in themeColors)
                {
                    _themeColorsDic[themeColor.Theme] = themeColor.Color;
                }
            }

            return _themeColorsDic[theme];
        }
    }
}