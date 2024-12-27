using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Better.Widgets.Runtime.Visability
{
    [Serializable]
    public class ActivationVisibilityBehaviour : VisibilityBehaviour<GameObject>
    {
        public override bool IsVisible => Source.activeSelf;

        protected override Task OnShowAsync(CancellationToken cancellationToken)
        {
            ChangeState(true);
            return Task.CompletedTask;
        }

        protected override Task OnHideAsync(CancellationToken cancellationToken)
        {
            ChangeState(false);
            return Task.CompletedTask;
        }

        protected override void OnReset()
        {
            ChangeState(false);
        }

        private void ChangeState(bool isActive)
        {
            Source.SetActive(isActive);
        }
    }
}