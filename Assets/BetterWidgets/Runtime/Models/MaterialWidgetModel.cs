using System;
using UnityEngine;

namespace Better.Widgets.Runtime
{
    [Serializable]
    public class MaterialWidgetModel : WidgetModel<Material>
    {
        public MaterialWidgetModel(Material material) : base(material)
        {
        }

        protected MaterialWidgetModel() : this(default)
        {
        }
    }
}