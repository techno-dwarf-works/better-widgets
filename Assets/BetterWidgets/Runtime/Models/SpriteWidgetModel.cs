using System;
using UnityEngine;

namespace Better.Widgets.Runtime
{
    [Serializable]
    public class SpriteWidgetModel : WidgetModel<Sprite>
    {
        public SpriteWidgetModel(Sprite Sprite) : base(Sprite)
        {
        }

        protected SpriteWidgetModel() : this(default)
        {
        }
    }
}