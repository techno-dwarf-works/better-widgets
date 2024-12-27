using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Attributes.Runtime.Select;
using Better.Commons.Runtime.Utility;
using Better.Tweens.Runtime;
using Better.Tweens.Runtime.Actions;
using Better.Widgets.Runtime.Extensions;
using Better.Widgets.Runtime.Visability;
using UnityEngine;

namespace Better.Widgets.Runtime
{
    public abstract class Widget : MonoBehaviour
    {
        [Select]
        [SerializeReference] private VisibilityBehaviour _visibilityBehaviour;

        private CancellationTokenSource _aliveTokenSource;

        public bool IsVisible => _visibilityBehaviour.IsVisible;

        public CancellationToken AliveToken
        {
            get
            {
                _aliveTokenSource ??= new();
                return _aliveTokenSource.Token;
            }
        }

        public virtual bool SetModel(WidgetModel model)
        {
            if (model is ResetWidgetModel)
            {
                Reset();
                return true;
            }

            if (model is VisibilityWidgetModel visibilityModel)
            {
                this.ChangeVisibility(visibilityModel.Value);
                return true;
            }

            return false;
        }

        public virtual Widget SetVisabilityHandler(VisibilityBehaviour visibilityBehaviour)
        {
            if (visibilityBehaviour == null)
            {
                DebugUtility.LogException<ArgumentNullException>(nameof(visibilityBehaviour));
                return this;
            }

            _visibilityBehaviour = visibilityBehaviour;
            return this;
        }

        public virtual Task ShowAsync(CancellationToken cancellationToken = default)
        {
            var linkedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(AliveToken, cancellationToken).Token;
            return _visibilityBehaviour.ShowAsync(linkedCancellationToken);
        }

        public virtual Task HideAsync(CancellationToken cancellationToken = default)
        {
            var linkedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(AliveToken, cancellationToken).Token;
            return _visibilityBehaviour.HideAsync(linkedCancellationToken);
        }

        public virtual Widget Reset()
        {
            _visibilityBehaviour.Reset();
            return this;
        }

#if BETTER_TWEENS
        protected TTweenCore PrepareTween<TTweenCore>(TTweenCore source)
            where TTweenCore : TweenCore, new()
        {
            var cloneTween = source.Clone();
            cloneTween.AddTrigger<StopAction>(AliveToken);

            return cloneTween;
        }
#endif
        protected virtual void OnDestroy()
        {
            _aliveTokenSource?.Cancel();
        }
    }

    public abstract class Widget<TModel> : Widget
        where TModel : WidgetModel
    {
        public sealed override bool SetModel(WidgetModel model)
        {
            if (model is TModel castedModel)
            {
                SetModel(castedModel);
            }

            return base.SetModel(model);
        }

        protected abstract bool SetModel(TModel model);
    }
}