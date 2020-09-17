using UnityEngine;
using UnityEngine.UI;

namespace Picturethis3d.UITheme
{
    [RequireComponent(typeof(Image))]
    public class ImageUIThemeSprite : MonoBehaviourUIThemeSprite
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

            if (themeSprites != default)
            {
                var sprite = themeSprites.GetSprite(theme);

                if (sprite)
                {
                    image.enabled = true;
                    image.sprite = sprite;
                }
                else
                {
                    image.enabled = false;
                }
            }
        }
    }
}