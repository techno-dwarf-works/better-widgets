using Better.Widgets.Runtime.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Better.Widgets.Runtime
{
    public abstract class RawImageWidget : GraphicWidget<RawImage>
    {
        public override bool SetModel(WidgetModel model)
        {
            switch (model)
            {
                case TextureWidgetModel textureModel:
                    SetTexture(textureModel.Value);
                    break;
                default:
                    return base.SetModel(model);
            }

            this.Show();
            return true;
        }

        public void SetTexture(Texture value)
        {
            Graphic.texture = value;
        }
    }
}