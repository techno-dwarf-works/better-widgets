#if BETTER_TWEENS
using System;
using System.Threading;
using System.Threading.Tasks;
using Better.Tweens.Runtime;
using UnityEngine;

namespace Better.Widgets.Runtime.Visability
{
    [Serializable]
    public class FadeVisibilityBehaviour : VisibilityBehaviour<CanvasGroup>
    {
        [Min(0f)]
        [SerializeField] private float _duration;

        private FadeCanvasGroupTween _tween;

        public override bool IsVisible => Source.alpha > 0f;

        private void TrySetupTween()
        {
            if (_tween != null) return;

            _tween = new();
            _tween.SetTarget(Source)
                .From(0f)
                .SetOptions(1f)
                .SetDuration(_duration);
        }

        protected override Task OnShowAsync(CancellationToken cancellationToken)
        {
            TrySetupTween();
            return _tween.Play().AwaitPlaying(cancellationToken);
        }

        protected override Task OnHideAsync(CancellationToken cancellationToken)
        {
            TrySetupTween();
            return _tween.Rewind().AwaitPlaying(cancellationToken);
        }

        protected override void OnReset()
        {
            TrySetupTween();
            _tween.InstantRewound();
        }
    }
}
#endif