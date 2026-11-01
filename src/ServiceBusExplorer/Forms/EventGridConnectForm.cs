using ServiceBusExplorer.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ServiceBusExplorer.Forms
{
    public partial class EventGridConnectForm : DpiAwareForm
    {
        private Font dpiAdjustedFont;

        protected override bool HandlesDpiScaleManually => true;

        #region Public Fields
        public string ResourceGroup;
        public string NamespaceName;
        public string SubscriptionId;
        public string ApiVersion;
        public int RetryTimeout;
        public string CloudTenant;
        public string CustomId;
        public List<string> SelectedEntities = new List<string> { Constants.TopicEntities, Constants.SubscriptionEntities };
        #endregion

        public EventGridConnectForm()
        {
            InitializeComponent();
            btnOk.Font = lblSubscriptionId.Font;
            btnCancel.Font = lblSubscriptionId.Font;
        }

        protected override void OnDpiScaleChanged()
        {
            var dpi = GetCurrentDpi(this);
            int ScaleLogical(int value) => ScaleBetweenDpi(value, 96, dpi);
            var previousFont = dpiAdjustedFont;
            dpiAdjustedFont = new Font("Microsoft Sans Serif",
                ScaleFontSizeForCurrentDpi(this, 8.25F), FontStyle.Regular, GraphicsUnit.Point);

            SuspendLayoutTree(this);
            try
            {
                SetLayoutFont(this, dpiAdjustedFont);
                // Restore logical metrics rather than scale the table's previous layout again.
                ClientSize = new Size(ScaleLogical(414), ScaleLogical(442));
                layoutRootPanel.Padding = new Padding(ScaleLogical(22), ScaleLogical(3),
                    ScaleLogical(22), ScaleLogical(12));
                layoutRootPanel.RowStyles[0].Height = ScaleLogical(22);
                pbAzure.Size = new Size(ScaleLogical(110), ScaleLogical(14));
                pbAzure.Margin = new Padding(0, ScaleLogical(6), 0, 0);
                grouperEventGridNamespaceSettings.Padding = new Padding(ScaleLogical(16),
                    ScaleLogical(30), ScaleLogical(16), ScaleLogical(12));

                foreach (Control control in contextFieldsTable.Controls)
                {
                    control.Margin = control is Label
                        ? new Padding(0, ScaleLogical(4), 0, ScaleLogical(2))
                        : new Padding(0, 0, 0, ScaleLogical(control is TextBox ? 8 : 6));
                }

                cboApiVersion.MinimumSize = new Size(ScaleLogical(193), 0);
                cboApiVersion.Width = ScaleLogical(193);
                cboApiVersion.DropDownWidth = cboApiVersion.Width;
                txtRetryTimeout.Width = ScaleLogical(103);
                cloudGroupBox.Padding = new Padding(ScaleLogical(6), ScaleLogical(4),
                    ScaleLogical(6), ScaleLogical(4));
                buttonFlowPanel.Padding = new Padding(0, ScaleLogical(8), 0, 0);
                btnOk.Size = btnCancel.Size = new Size(ScaleLogical(72), ScaleLogical(24));
                btnOk.Margin = btnCancel.Margin = new Padding(ScaleLogical(3));
            }
            finally
            {
                ResumeLayoutTree(this);
                previousFont?.Dispose();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                dpiAdjustedFont?.Dispose();
            }
        }

        private static void SuspendLayoutTree(Control control)
        {
            control.SuspendLayout();
            foreach (Control child in control.Controls)
            {
                SuspendLayoutTree(child);
            }
        }

        private static void SetLayoutFont(Control control, Font font)
        {
            control.Font = font;
            foreach (Control child in control.Controls)
            {
                SetLayoutFont(child, font);
            }
        }

        private static void ResumeLayoutTree(Control control)
        {
            foreach (Control child in control.Controls)
            {
                ResumeLayoutTree(child);
            }

            control.ResumeLayout(true);
        }

        private void customCloud_CheckedChanged(object sender, EventArgs e)
        {
            txtCustomId.Enabled = btnCustomCloud.Checked;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ResourceGroup = txtResourceGroupName.Text.Trim();
            NamespaceName = txtNamespaceName.Text.Trim();
            SubscriptionId = txtSubscriptionId.Text.Trim();
            ApiVersion = cboApiVersion.Text.Trim();

            int.TryParse(txtRetryTimeout.Text, out var retryTimoutInSeconds);
            RetryTimeout = retryTimoutInSeconds;
            CloudTenant = cloudSettingsTable.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            CustomId = txtCustomId.Text?.Trim();

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EventGridConnectForm_Load(object sender, EventArgs e)
        {
            cboApiVersion.SelectedIndex = 0;
        }
    }
}
