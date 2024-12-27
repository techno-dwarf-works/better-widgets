using System;
using UnityEngine;

namespace Better.Widgets.Runtime
{
    [Serializable]
    public class TextureWidgetModel : WidgetModel<Texture>
    {
        public TextureWidgetModel(Texture texture) : base(texture)
        {
        }

        protected TextureWidgetModel() : this(default)
        {
        }
    }
}