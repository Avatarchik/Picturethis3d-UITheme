using UnityEngine;
using UnityEngine.UI;

namespace Picturethis3d.UITheme
{
    [RequireComponent(typeof(Image))]
    public class ImageUITheme : MonoBehaviourUITheme
    {
        [SerializeField] private Image image = default;

        protected override void UpdateComponent()
        {
            base.UpdateComponent();

            if (image == default)
            {
                image = GetComponent<Image>();
            }
        }

        protected override void OnChanged(UITheme theme)
        {
            base.OnChanged(theme);

            if (themeColors != default)
            {
                image.color = themeColors.GetColor(theme);
            }
        }
    }
}