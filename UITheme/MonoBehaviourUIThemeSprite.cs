using UnityEngine;

namespace Picturethis3d.UITheme
{
    public class MonoBehaviourUIThemeSprite : MonoBehaviour
    {
        [SerializeField] protected UIThemeSprites themeSprites = default;

        public UIThemeSprites SpritesTheme
        {
            get => themeSprites;
            set
            {
                if (themeSprites != value)
                {
                    themeSprites = value;
                    OnChanged(UIThemes.Theme);
                }
            }
        }

        private void OnEnable()
        {
            UpdateComponent();

            UIThemes.Changed += OnChanged;
            OnChanged(UIThemes.Theme);
        }

        protected virtual void UpdateComponent()
        {
        }

        private void OnDisable()
        {
            UIThemes.Changed -= OnChanged;
        }

        protected virtual void OnChanged(UITheme theme)
        {
        }
    }
}