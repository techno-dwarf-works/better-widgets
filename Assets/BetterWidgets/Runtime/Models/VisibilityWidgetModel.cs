using System;

namespace Better.Widgets.Runtime
{
    [Serializable]
    public class VisibilityWidgetModel : WidgetModel<bool>
    {
        public VisibilityWidgetModel(bool show) : base(show)
        {
        }

        protected VisibilityWidgetModel() : this(default)
        {
        }
    }
}