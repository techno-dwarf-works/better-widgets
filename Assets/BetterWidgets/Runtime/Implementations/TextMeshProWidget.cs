using Better.Widgets.Runtime.Extensions;
using TMPro;

namespace Better.Widgets.Runtime
{
    public class TextMeshProWidget : GraphicWidget<TMP_Text>
    {
        public override bool SetModel(WidgetModel model)
        {
            switch (model)
            {
                case TextWidgetModel textModel:
                    SetText(textModel.Value);
                    break;
                default:
                    return base.SetModel(model);
            }

            this.Show();
            return true;
        }

        public void SetText(string value)
        {
            Graphic.SetText(value);
        }
    }
}