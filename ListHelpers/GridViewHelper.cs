﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Template10
{
    public partial class GridViewHelper : DependencyObject
    {
        public static SelectorInfo GetSelectedItemStyle(GridView obj)
            => (SelectorInfo)obj.GetValue(SelectedItemStyleProperty);
        public static void SetSelectedItemStyle(GridView obj, SelectorInfo value)
            => obj.SetValue(SelectedItemStyleProperty, value);
        public static readonly DependencyProperty SelectedItemStyleProperty =
            DependencyProperty.RegisterAttached("SelectedItemStyle", typeof(SelectorInfo),
                typeof(GridViewHeaderItem), new PropertyMetadata(null, SelectedItemStyleChanged));
        private static void SelectedItemStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            if (d is GridView gridview && args.NewValue is SelectorInfo data)
            {
                gridview.SelectionChanged += (s, e) =>
                {
                    foreach (var item in e.RemovedItems)
                    {
                        Debug.WriteLine($"Removing {item}");
                        if (TryGetRoot(item, out var element))
                        {
                            element.Style = data.NormalStyle;
                        }
                    }

                    foreach (var item in e.AddedItems)
                    {
                        Debug.WriteLine($"Adding {item}");
                        if (TryGetRoot(item, out var element))
                        {
                            element.Style = data.SelectedStyle;
                        }
                    }
                };
            }

            bool TryGetRoot(object context, out FrameworkElement value)
            {
                var container = gridview.ContainerFromItem(context);
                if (container is GridViewItem item && item != null)
                {
                    if (item.ContentTemplateRoot is FrameworkElement element)
                    {
                        value = element;
                        return true;
                    }
                    else
                    {
                        Debugger.Break();
                        value = null;
                        return false;
                    }
                }
                else
                {
                    Debugger.Break();
                    value = null;
                    return false;
                }
            }
        }
    }
}
