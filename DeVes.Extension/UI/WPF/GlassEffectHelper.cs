using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace DeVes.Extension.UI.WPF
{
    public class GlassEffectHelper
    {
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled();

        public static bool EnableGlassEffect(Window window)
        {
            window.MouseLeftButtonDown += (s, e) =>
            {
                window.DragMove();
            };
            return EnableGlassEffect(window, true);
        }

        public static bool EnableGlassEffect(Window window, bool enabled)
        {
            return EnableGlassEffect(window, enabled, new Thickness(-1));
        }

        public static bool EnableGlassEffect(Window window, bool enabled, Thickness margin)
        {
            if (!VersionHelper.IsAtLeastVista)
            {
                // Go and buy Windows 7 😉
                return false;
            }

            if (!DwmIsCompositionEnabled())
            {
                return false;
            }

            if (enabled)
            {
                var _hwnd = new WindowInteropHelper(window).Handle;

                var _hwndSource = HwndSource.FromHwnd(_hwnd);
                if (_hwndSource == null) return false;
                if (_hwndSource.CompositionTarget == null) return false;

                // Hintergrundfarbe von Fenster Transparent darstellen
                window.Background = Brushes.Transparent;

                // Die Farbe festlegen auf die den Glaseffekt bekommt
                _hwndSource.CompositionTarget.BackgroundColor = Colors.Transparent;

                // Den Bereich für den Glaseffekt definieren
                var _margins = new MARGINS(margin);

                // Glasseffekt aktivieren
                DwmExtendFrameIntoClientArea(_hwnd, ref _margins);
            }
            else
            {
                // Hintergrundfarbe des Fensters zurück auf die
                // Systemfarbe stellen
                window.Background = SystemColors.WindowBrush;
            }

            return true;
        }
    }
}
