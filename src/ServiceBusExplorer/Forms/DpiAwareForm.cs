using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ServiceBusExplorer.Forms
{
    /// <summary>
    /// Base form for PerMonitorV2 on .NET Framework 4.7.2. The initial autoscale pass uses the
    /// system DPI (fixed at logon) and Control.DeviceDpi reports that same value at handle
    /// creation, even when the window is created on a monitor with a different DPI; the result
    /// is never corrected by the framework and no DpiChanged event fires. GetDpiForWindow
    /// returns the real DPI of the monitor the window is on.
    /// Also re-runs layout after a DPI change so anchored controls fit the rescaled bounds.
    /// </summary>
    public class DpiAwareForm : Form
    {
        private const int TreeViewLogicalItemHeight = 20;
        private static readonly int systemDpi = GetSystemDpi();
        private bool startupDpiCorrected;

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
            // TEMP diagnostics: prove whether the startup correction fires (drop before upstream PR)
            MainForm.StaticWriteToLog($"DpiAwareForm: {GetType().Name} systemDpi={systemDpi}, windowDpi={windowDpi}, correction={(windowDpi == systemDpi ? "skipped" : "fired")}");
            if (windowDpi != systemDpi)
            {
                var factor = (float)windowDpi / systemDpi;
                Scale(new SizeF(factor, factor));
            }
            OnDpiScaleChanged();
            PerformLayout();
            Invalidate(true);
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
            // Custom-painted controls compute sizes from the current DPI at paint time;
            // force re-layout and repaint after the framework rescale.
            OnDpiScaleChanged();
            PerformLayout();
            Invalidate(true);
        }

        /// <summary>
        /// Recomputes DPI-dependent values (item heights, image sizes, custom metrics).
        /// Called once after handle creation (after the startup correction) and on every DPI change.
        /// </summary>
        protected virtual void OnDpiScaleChanged()
        {
        }

        // Control.DeviceDpi and Control.LogicalToDeviceUnits report the system DPI (fixed at
        // logon) when called at creation time on net472; GetDpiForWindow is the OS truth.
        internal static int GetCurrentDpi(Control control)
        {
            return control.IsHandleCreated ? (int)GetDpiForWindow(control.Handle) : systemDpi;
        }

        internal static int ScaleToCurrentDpi(Control control, int logicalValue)
        {
            return (int)Math.Round(logicalValue * GetCurrentDpi(control) / 96.0);
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

        private static int GetSystemDpi()
        {
            using (var probe = new Control())
            {
                return probe.DeviceDpi;
            }
        }
    }
}
