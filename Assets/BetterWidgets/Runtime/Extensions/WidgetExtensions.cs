using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Better.Commons.Runtime.Extensions;
using Better.Widgets.Runtime.Visability;

namespace Better.Widgets.Runtime.Extensions
{
    public static class WidgetExtensions
    {
        public static IEnumerable<Widget> SetModel(this IEnumerable<Widget> self, WidgetModel model)
        {
            foreach (var widget in self)
            {
                widget.SetModel(model);
            }

            return self;
        }

        public static IEnumerable<Widget> SetModels(this IEnumerable<Widget> self, IEnumerable<WidgetModel> models)
        {
            foreach (var model in models)
            {
                self.SetModel(model);
            }

            return self;
        }

        public static IEnumerable<Widget> SetVisabilityHandler(this IEnumerable<Widget> self, VisibilityBehaviour visibilityBehaviour)
        {
            foreach (var widget in self)
            {
                widget.SetVisabilityHandler(visibilityBehaviour);
            }

            return self;
        }

        public static IEnumerable<Task> ShowAsync(this IEnumerable<Widget> self, CancellationToken cancellationToken = default)
        {
            var tasks = self.Select(w => w.ShowAsync(cancellationToken));
            return tasks;
        }

        public static Widget Show(this Widget self)
        {
            self.ShowAsync().Forget();
            return self;
        }

        public static IEnumerable<Widget> Show(this IEnumerable<Widget> self)
        {
            foreach (var widget in self)
            {
                widget.Show();
            }

            return self;
        }

        public static IEnumerable<Task> HideAsync(this IEnumerable<Widget> self, CancellationToken cancellationToken = default)
        {
            var tasks = self.Select(w => w.HideAsync(cancellationToken));
            return tasks;
        }

        public static Widget Hide(this Widget self)
        {
            self.HideAsync().Forget();
            return self;
        }

        public static IEnumerable<Widget> Hide(this IEnumerable<Widget> self)
        {
            foreach (var widget in self)
            {
                widget.Hide();
            }

            return self;
        }

        public static Task ChangeVisibilityAsync(this Widget self, bool state, CancellationToken cancellationToken = default)
        {
            if (state)
            {
                return self.ShowAsync(cancellationToken);
            }

            return self.HideAsync(cancellationToken);
        }

        public static IEnumerable<Task> ChangeVisibilityAsync(this IEnumerable<Widget> self, bool state, CancellationToken cancellationToken = default)
        {
            var tasks = self.Select(w => w.ChangeVisibilityAsync(state, cancellationToken));
            return tasks;
        }

        public static Widget ChangeVisibility(this Widget self, bool state)
        {
            self.ChangeVisibilityAsync(state).Forget();
            return self;
        }

        public static IEnumerable<Widget> ChangeVisibility(this IEnumerable<Widget> self, bool state)
        {
            foreach (var widget in self)
            {
                widget.ChangeVisibility(state);
            }

            return self;
        }

        public static IEnumerable<Widget> Reset(IEnumerable<Widget> self)
        {
            foreach (var widget in self)
            {
                widget.Reset();
            }

            return self;
        }
    }
}