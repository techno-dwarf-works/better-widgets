using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Attributes.Runtime.Manipulation;
using Better.Attributes.Runtime.Validation;
using UnityEngine;

namespace Better.Widgets.Runtime.Visability
{
    [Serializable]
    public abstract class VisibilityBehaviour
    {
        private CancellationTokenSource _cancellationTokenSource;

        public abstract bool IsVisible { get; }
        
        internal Task ShowAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            if (_cancellationTokenSource.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }

            return OnShowAsync(_cancellationTokenSource.Token);
        }

        internal Task HideAsync(CancellationToken cancellationToken)
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            if (_cancellationTokenSource.IsCancellationRequested)
            {
                return Task.CompletedTask;
            }

            return OnHideAsync(_cancellationTokenSource.Token);
        }

        internal void Reset()
        {
            _cancellationTokenSource?.Cancel();
            OnReset();
        }

        protected abstract Task OnShowAsync(CancellationToken cancellationToken);
        protected abstract Task OnHideAsync(CancellationToken cancellationToken);
        protected abstract void OnReset();
    }

    [Serializable]
    public abstract class VisibilityBehaviour<TSource> : VisibilityBehaviour
    {
        [ReadOnly] [Find(ValidateIfFieldEmpty = false)]
        [SerializeField] private TSource _source;

        protected TSource Source => _source;

        public VisibilityBehaviour()
        {
        }

        public VisibilityBehaviour(TSource source)
        {
            _source = source;
        }
    }
}