using System;
using UnityEngine;

namespace Better.Widgets.Runtime
{
    [Serializable]
    public class ColorWidgetModel : WidgetModel<Color>
    {
        public ColorWidgetModel(Color color) : base(color)
        {
        }

        protected ColorWidgetModel() : this(Color.white)
        {
        }
    }
}