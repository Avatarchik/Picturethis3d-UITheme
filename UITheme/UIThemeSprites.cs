using System;
using System.Collections.Generic;
using UnityEngine;

namespace Picturethis3d.UITheme
{
    [CreateAssetMenu(fileName = "UIThemeSprites", menuName = "Picturethis3d/UI/UIThemeSprites", order = 5)]
    public class UIThemeSprites : ScriptableObject
    {
        [Serializable]
        class ThemeSprite
        {
            [SerializeField] private UITheme theme = default;

            public UITheme Theme => theme;

            [SerializeField] private Sprite sprite = default;

            public Sprite Sprite => sprite;

            public ThemeSprite(UITheme theme)
            {
                this.theme = theme;
            }
        }

        [SerializeField] ThemeSprite[] themeSprites;

        [NonSerialized] private Dictionary<UITheme, Sprite> _themeSpritesDic;

#if UNITY_EDITOR
        private void Awake()
        {
            UpdateThemes();
        }

        private ThemeSprite Find(UITheme theme, ThemeSprite[] colors)
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
            if (themeSprites == null)
            {
                var themes = Enum.GetValues(typeof(UITheme));
                themeSprites = new ThemeSprite[themes.Length];

                int i = 0;
                foreach (UITheme theme in themes)
                {
                    themeSprites[i++] = new ThemeSprite(theme);
                }

                UnityEditor.EditorUtility.SetDirty(this);
                UnityEditor.AssetDatabase.SaveAssets();
            }
            else
            {
                if (themeSprites.Length != UIThemes.Length)
                {
                    var themes = Enum.GetValues(typeof(UITheme));

                    var updatedThemes = new ThemeSprite[themes.Length];

                    int i = 0;
                    foreach (UITheme theme in themes)
                    {
                        var existentTheme = Find(theme, themeSprites);

                        updatedThemes[i++] = existentTheme ?? new ThemeSprite(theme);
                    }

                    themeSprites = updatedThemes;

                    UnityEditor.EditorUtility.SetDirty(this);
                    UnityEditor.AssetDatabase.SaveAssets();
                }
            }
        }
#endif

        public Sprite GetSprite(UITheme theme)
        {
            if (_themeSpritesDic == null)
            {
#if UNITY_EDITOR
                UpdateThemes();
#endif
                _themeSpritesDic = new Dictionary<UITheme, Sprite>(themeSprites.Length);

                foreach (var themeSprite in themeSprites)
                {
                    _themeSpritesDic[themeSprite.Theme] = themeSprite.Sprite;
                }
            }

            return _themeSpritesDic[theme];
        }
    }
}