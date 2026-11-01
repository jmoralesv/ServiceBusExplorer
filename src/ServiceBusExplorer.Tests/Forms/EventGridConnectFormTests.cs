using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FluentAssertions;
using ServiceBusExplorer.Forms;
using Xunit;

namespace ServiceBusExplorer.Tests.Forms
{
    public class EventGridConnectFormTests
    {
        [Fact]
        public void RepeatedDpiLayout_KeepsControlFontsUsable()
        {
            RunOnStaThread(() =>
            {
                using (var form = new EventGridConnectForm())
                using (var initialFont = new Font("Microsoft Sans Serif", 10F))
                {
                    var input = FindControl<TextBox>(form, "txtSubscriptionId");
                    input.Font = initialFont;
                    var updateLayout = typeof(EventGridConnectForm).GetMethod("OnDpiScaleChanged",
                        BindingFlags.Instance | BindingFlags.NonPublic);

                    updateLayout.Invoke(form, null);
                    updateLayout.Invoke(form, null);

                    input.Font.GetHeight(96F).Should().BeGreaterThan(0);
                }
            });
        }

        [Fact]
        public void Show_SelectsSubscriptionIdAndDefaultApiVersion()
        {
            RunOnStaThread(() =>
            {
                using (var form = new EventGridConnectForm())
                {
                    form.Show();
                    Application.DoEvents();

                    Control selected = form;
                    while (selected is ContainerControl container && container.ActiveControl != null)
                    {
                        selected = container.ActiveControl;
                    }

                    selected.Should().Be(FindControl<TextBox>(form, "txtSubscriptionId"));
                    FindControl<ComboBox>(form, "cboApiVersion").SelectedIndex.Should().Be(0);
                }
            });
        }

        [Theory]
        [InlineData(false, "Public")]
        [InlineData(true, "Custom Tenant ID")]
        public void ConfirmConnection_ReadsTenantSelectionFromLayoutPanel(bool useCustomTenant, string expectedTenant)
        {
            RunOnStaThread(() =>
            {
                using (var form = new EventGridConnectForm())
                {
                    var customTenant = FindControl<RadioButton>(form, "btnCustomCloud");
                    var tenantId = FindControl<TextBox>(form, "txtCustomId");
                    customTenant.Checked = useCustomTenant;
                    tenantId.Enabled.Should().Be(useCustomTenant);
                    tenantId.Text = " tenant-id ";

                    var confirm = typeof(EventGridConnectForm).GetMethod("btnOk_Click",
                        BindingFlags.Instance | BindingFlags.NonPublic);
                    confirm.Invoke(form, new object[] { null, EventArgs.Empty });

                    form.CloudTenant.Should().Be(expectedTenant);
                    form.CustomId.Should().Be("tenant-id");
                    form.DialogResult.Should().Be(DialogResult.OK);
                }
            });
        }

        private static T FindControl<T>(Control root, string name) where T : Control
        {
            return (T)root.Controls.Find(name, true).Single();
        }

        private static void RunOnStaThread(Action action)
        {
            Exception exception = null;
            var thread = new Thread(() =>
            {
                try
                {
                    action();
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            if (exception != null)
            {
                throw exception;
            }
        }
    }
}
