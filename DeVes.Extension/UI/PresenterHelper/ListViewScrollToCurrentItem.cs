using System.Windows;
using System.Windows.Controls;

namespace DeVes.Extension.UI.PresenterHelper
{
    public static class ListViewScrollToCurrentItem
    {
        public static readonly DependencyProperty AutoScrollToCurrentItemProperty =
            DependencyProperty.RegisterAttached("AutoScrollToCurrentItem",
                typeof(bool), typeof(ListViewScrollToCurrentItem),
                new UIPropertyMetadata(default(bool), OnAutoScrollToCurrentItemChanged));

        public static bool GetAutoScrollToCurrentItem(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToCurrentItemProperty);
        }

        public static void OnAutoScrollToCurrentItemChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var _listBox = obj as ListBox;
            if (_listBox == null) return;

            var _newValue = (bool)e.NewValue;
            if (_newValue)
                _listBox.SelectionChanged += ListBoxSelectionChanged;
            else
                _listBox.SelectionChanged -= ListBoxSelectionChanged;
        }

        static void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var _listBox = sender as ListBox;
            if (_listBox == null || _listBox.SelectedItem == null || _listBox.Items == null) return;

            _listBox.Items.MoveCurrentTo(_listBox.SelectedItem);
            _listBox.ScrollIntoView(_listBox.SelectedItem);
        }

        public static void SetAutoScrollToCurrentItem(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToCurrentItemProperty, value);
        }
    }
}
