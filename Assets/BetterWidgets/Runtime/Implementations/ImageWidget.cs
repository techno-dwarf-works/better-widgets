using Better.Widgets.Runtime.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Better.Widgets.Runtime
{
    public abstract class ImageWidget : GraphicWidget<Image>
    {
        public override bool SetModel(WidgetModel model)
        {
            switch (model)
            {
                case SpriteWidgetModel spriteModel:
                    SetSprite(spriteModel.Value);
                    break;
                default:
                    return base.SetModel(model);
            }

            this.Show();
            return true;
        }

        public Widget SetSprite(Sprite value)
        {
            Graphic.sprite = value;
            return this;
        }
    }
}