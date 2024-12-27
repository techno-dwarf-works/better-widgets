using System;

namespace Better.Widgets.Runtime
{
    [Serializable]
    public class TextWidgetModel : WidgetModel<string>
    {
        public TextWidgetModel(string value) : base(value)
        {
        }

        protected TextWidgetModel() : this(string.Empty)
        {
        }
    }
}