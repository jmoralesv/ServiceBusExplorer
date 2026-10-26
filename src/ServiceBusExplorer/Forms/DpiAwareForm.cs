using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ServiceBusExplorer.Forms
{
    /// <summary>
    /// Base form for PerMonitorV2 on .NET Framework 4.8. GetDpiForWindow returns the DPI of the
    /// monitor the window is on, including during initial handle creation.
    /// Also re-runs layout after a DPI change so anchored controls fit the rescaled bounds.
    /// </summary>
    public class DpiAwareForm : Form
    {
        private const int TreeViewLogicalItemHeight = 20;
        private static readonly int systemDpi = GetSystemDpi();
        private bool startupDpiCorrected;
        private int lastObservedWindowDpi;

        [DllImport("user32.dll")]
        private static extern uint GetDpiForWindow(IntPtr hwnd);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (startupDpiCorrected)
            {
                return;
            }

            startupDpiCorrected = true;
            var windowDpi = (int)GetDpiForWindow(Handle);
            lastObservedWindowDpi = windowDpi;
            if (windowDpi != systemDpi)
            {
                var factor = (float)windowDpi / systemDpi;
                Scale(new SizeF(factor, factor));
            }

            OnDpiScaleChanged();
            PerformLayout();
            SynchronizeDpiAutoScaleDimensions(HandlesDpiScaleManually ? DeviceDpi : windowDpi);
            Invalidate(true);
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            var handlesDpiScaleManually = HandlesDpiScaleManually;
            var previousWindowDpi = lastObservedWindowDpi > 0 ? lastObservedWindowDpi : e.DeviceDpiOld;
            var windowDpi = GetCurrentDpi(this);
            var frameworkScaleFactor = e.DeviceDpiOld > 0
                ? (float)e.DeviceDpiNew / e.DeviceDpiOld
                : 1.0F;
            var actualScaleFactor = previousWindowDpi > 0
                ? (float)windowDpi / previousWindowDpi
                : frameworkScaleFactor;
            var correctiveScaleFactor = frameworkScaleFactor > 0
                ? actualScaleFactor / frameworkScaleFactor
                : actualScaleFactor;
            var autoscaleBaselineDpi = handlesDpiScaleManually ? DeviceDpi : previousWindowDpi;

            SynchronizeDpiAutoScaleDimensions(autoscaleBaselineDpi);
            base.OnDpiChanged(e);
            if (!handlesDpiScaleManually && Math.Abs(correctiveScaleFactor - 1.0F) > 0.001F)
            {
                ScaleChildControls(this, correctiveScaleFactor);
            }

            OnDpiScaleChanged();
            PerformLayout();
            SynchronizeDpiAutoScaleDimensions(handlesDpiScaleManually ? DeviceDpi : GetCurrentDpi(this));
            Invalidate(true);
            lastObservedWindowDpi = GetCurrentDpi(this);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (!startupDpiCorrected)
            {
                return;
            }

            var windowDpi = GetCurrentDpi(this);
            if (windowDpi != lastObservedWindowDpi)
            {
                lastObservedWindowDpi = windowDpi;
            }
        }

        /// <summary>
        /// Recomputes DPI-dependent values (item heights, image sizes, custom metrics).
        /// Called once after handle creation (after the startup correction) and on every DPI change.
        /// </summary>
        protected virtual void OnDpiScaleChanged()
        {
        }

        protected virtual bool HandlesDpiScaleManually => false;

        protected int LastObservedWindowDpi => lastObservedWindowDpi;

        internal static int GetCurrentDpi(Control control)
        {
            return control.IsHandleCreated ? (int)GetDpiForWindow(control.Handle) : systemDpi;
        }

        protected void SynchronizeDpiAutoScaleDimensions(int dpi)
        {
            SynchronizeDpiAutoScaleDimensions(this, dpi);
        }

        internal static int ScaleToCurrentDpi(Control control, int logicalValue)
        {
            return (int)Math.Round(logicalValue * GetCurrentDpi(control) / 96.0);
        }

        internal static int ScaleBetweenDpi(int value, int sourceDpi, int targetDpi)
        {
            return sourceDpi > 0
                ? (int)Math.Round(value * (double)targetDpi / sourceDpi)
                : value;
        }

        internal static float ScaleFontSizeForCurrentDpi(Control control, float logicalSizeInPoints)
        {
            return logicalSizeInPoints * GetCurrentDpi(control) / systemDpi;
        }

        internal static void ScaleBitmapToCurrentDpi(Control control, ref Bitmap bitmap)
        {
            var factor = GetCurrentDpi(control) / 96.0;
            if (factor == 1.0)
            {
                return;
            }
            var scaled = new Bitmap(bitmap,
                (int)Math.Round(bitmap.Width * factor),
                (int)Math.Round(bitmap.Height * factor));
            bitmap.Dispose();
            bitmap = scaled;
        }

        // Rows must fit the 16px node icons too: the designer ItemHeight (20 logical px) is the
        // floor and the font line height may raise it. Font.GetHeight(dpi) is exact for the
        // monitor the window is on; Font.Height uses the DPI captured when the Font was created.
        protected void ScaleTreeViewItemHeight(TreeView treeView)
        {
            var dpi = GetCurrentDpi(this);
            treeView.ItemHeight = Math.Max((int)Math.Ceiling(treeView.Font.GetHeight(dpi)),
                ScaleToCurrentDpi(this, TreeViewLogicalItemHeight));
        }

        private static void SynchronizeDpiAutoScaleDimensions(Control control, int dpi)
        {
            if (control is ContainerControl containerControl &&
                containerControl.AutoScaleMode == AutoScaleMode.Dpi)
            {
                containerControl.AutoScaleDimensions = new SizeF(dpi, dpi);
            }

            foreach (Control child in control.Controls)
            {
                SynchronizeDpiAutoScaleDimensions(child, dpi);
            }
        }

        private static void ScaleChildControls(Control control, float factor)
        {
            foreach (Control child in control.Controls)
            {
                child.Scale(new SizeF(factor, factor));
            }
        }

        private static int GetSystemDpi()
        {
            using (var probe = new Control())
            {
                return probe.DeviceDpi;
            }
        }
    }
}
