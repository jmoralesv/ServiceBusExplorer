using System;
using System.Drawing;
using System.Windows.Forms;

namespace ServiceBusExplorer.Forms
{
    /// <summary>
    /// Base form for PerMonitorV2 on .NET Framework 4.7.2. The initial autoscale pass runs
    /// before the handle exists and uses the system DPI (fixed at logon); when the form opens
    /// on a monitor with a different DPI the result is never corrected by the framework.
    /// Also re-runs layout after a DPI change so anchored controls fit the rescaled bounds.
    /// </summary>
    public class DpiAwareForm : Form
    {
        private static readonly int systemDpi = GetSystemDpi();
        private bool startupDpiCorrected;

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (startupDpiCorrected || DeviceDpi == systemDpi)
            {
                return;
            }
            startupDpiCorrected = true;
            var factor = (float)DeviceDpi / systemDpi;
            Scale(new SizeF(factor, factor));
            PerformLayout();
            Invalidate(true);
        }

        protected override void OnDpiChanged(DpiChangedEventArgs e)
        {
            base.OnDpiChanged(e);
            // Custom-painted controls compute sizes from the current DPI at paint time;
            // force re-layout and repaint after the framework rescale.
            PerformLayout();
            Invalidate(true);
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
