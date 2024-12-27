using System;
using UnityEngine;

namespace Better.Widgets.Runtime
{
    [Serializable]
    public abstract class WidgetModel
    {
    }

    [Serializable]
    public abstract class WidgetModel<TValue> : WidgetModel
    {
        [SerializeField] private TValue _value;
        
        public TValue Value => _value;

        public WidgetModel(TValue value)
        {
            _value = value;
        }
    }
}