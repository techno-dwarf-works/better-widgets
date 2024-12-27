using Better.Tweens.Runtime;
using Better.Widgets.Runtime.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Better.Widgets.Runtime
{
    public abstract class GraphicWidget<TGraphic> : UIWidget
        where TGraphic : Graphic
    {
        [SerializeField] private TGraphic _graphic;

#if BETTER_TWEENS
        [SerializeField] private ColorGraphicTween _colorGraphicTween;
#endif

        protected TGraphic Graphic => _graphic;

        public override bool SetModel(WidgetModel model)
        {
            switch (model)
            {
                case MaterialWidgetModel materialModel:
                    SetMaterial(materialModel.Value);
                    break;
                case ColorWidgetModel colorModel:
                    SetColorModel(colorModel);
                    break;
                default:
                    return base.SetModel(model);
            }

            this.Show();
            return true;
        }

        public void SetColorModel(ColorWidgetModel colorModel)
        {
#if BETTER_TWEENS
            if (IsVisible)
            {
                PrepareTween(_colorGraphicTween).SetOptions(colorModel.Value).Play();
                return;
            }
#endif

            SetColor(colorModel.Value);
        }

        public void SetColor(Color value)
        {
            Graphic.color = value;
        }

        public void SetMaterial(Material value)
        {
            Graphic.material = value;
        }
    }
}