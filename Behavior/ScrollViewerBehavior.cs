using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace VisualChatBot.Behavior
{
    public class ScrollViewerBehavior
    {
        public static bool GetAutoScrollToEnd(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToEndProperty);
        }

        public static void SetAutoScrollToEnd(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToEndProperty, value);
        }

        public static readonly DependencyProperty AutoScrollToEndProperty =
            DependencyProperty.RegisterAttached("AutoScrollToEnd", typeof(bool), typeof(ScrollViewerBehavior), new PropertyMetadata(false, (o, e) =>
            {
                var scrollViewer = o as ScrollViewer;
                if (scrollViewer == null)
                {
                    return;
                }
                if ((bool)e.NewValue)
                {
                    scrollViewer.ScrollToBottom();
                    SetAutoScrollToEnd(o, false);
                }
            }));
    }
}
