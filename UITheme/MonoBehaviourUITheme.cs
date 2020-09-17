using UnityEngine;

namespace Picturethis3d.UITheme
{
    public class MonoBehaviourUITheme : MonoBehaviour
    {
        [SerializeField] protected UIThemeColors themeColors = default;

        public UIThemeColors ColorsTheme
        {
            get => themeColors;
            set
            {
                if (themeColors != value)
                {
                    themeColors = value;
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

        private void OnDisable()
        {
            UIThemes.Changed -= OnChanged;
        }

        protected virtual void UpdateComponent()
        {
        }

        protected virtual void OnChanged(UITheme theme)
        {
        }
    }
}