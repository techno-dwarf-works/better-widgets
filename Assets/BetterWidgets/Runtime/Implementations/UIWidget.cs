using UnityEngine;

namespace Better.Widgets.Runtime
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIWidget : Widget
    {
        private RectTransform _rectTransform;

        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = GetComponent<RectTransform>();
                }

                return _rectTransform;
            }
        }
    }

    [RequireComponent(typeof(RectTransform))]
    public abstract class UIWidget<TModel> : Widget<TModel>
        where TModel : WidgetModel
    {
        private RectTransform _rectTransform;

        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = GetComponent<RectTransform>();
                }

                return _rectTransform;
            }
        }
    }
}