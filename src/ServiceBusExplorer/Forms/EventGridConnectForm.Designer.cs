#region Copyright
//=======================================================================================
// Microsoft Azure Customer Advisory Team 
//
// This sample is supplemental to the technical guidance published on my personal
// blog at http://blogs.msdn.com/b/paolos/. 
// 
// Author: Paolo Salvatori
//=======================================================================================
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE 
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT 
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE 
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY 
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING 
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================
#endregion

namespace ServiceBusExplorer.Forms
{
    partial class EventGridConnectForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventGridConnectForm));
            this.layoutRootPanel = new System.Windows.Forms.TableLayoutPanel();
            this.contextFieldsTable = new System.Windows.Forms.TableLayoutPanel();
            this.cloudSettingsTable = new System.Windows.Forms.TableLayoutPanel();
            this.logoFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pbAzure = new System.Windows.Forms.PictureBox();
            this.grouperEventGridNamespaceSettings = new ServiceBusExplorer.Controls.Grouper();
            this.cboApiVersion = new System.Windows.Forms.ComboBox();
            this.cloudGroupBox = new System.Windows.Forms.GroupBox();
            this.btnPublicCloud = new System.Windows.Forms.RadioButton();
            this.btnCustomCloud = new System.Windows.Forms.RadioButton();
            this.txtCustomId = new System.Windows.Forms.TextBox();
            this.lblCloud = new System.Windows.Forms.Label();
            this.txtRetryTimeout = new System.Windows.Forms.TextBox();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.txtSubscriptionId = new System.Windows.Forms.TextBox();
            this.lblApiVersion = new System.Windows.Forms.Label();
            this.txtResourceGroupName = new System.Windows.Forms.TextBox();
            this.lblResourceGroupName = new System.Windows.Forms.Label();
            this.lblSubscriptionId = new System.Windows.Forms.Label();
            this.txtNamespaceName = new System.Windows.Forms.TextBox();
            this.lblNamespaceName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbAzure)).BeginInit();
            this.layoutRootPanel.SuspendLayout();
            this.contextFieldsTable.SuspendLayout();
            this.cloudSettingsTable.SuspendLayout();
            this.logoFlowPanel.SuspendLayout();
            this.buttonFlowPanel.SuspendLayout();
            this.grouperEventGridNamespaceSettings.SuspendLayout();
            this.cloudGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOk.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(72, 24);
            this.btnOk.TabIndex = 46;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 47;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pbAzure
            // 
            this.pbAzure.BackgroundImage = global::ServiceBusExplorer.Properties.Resources.MicrosoftAzureWhiteLogo;
            this.pbAzure.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbAzure.ErrorImage = null;
            this.pbAzure.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pbAzure.Name = "pbAzure";
            this.pbAzure.Size = new System.Drawing.Size(110, 14);
            this.pbAzure.TabIndex = 48;
            this.pbAzure.TabStop = false;
            // 
            // grouperEventGridNamespaceSettings
            // 
            this.grouperEventGridNamespaceSettings.BackgroundColor = System.Drawing.Color.White;
            this.grouperEventGridNamespaceSettings.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperEventGridNamespaceSettings.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperEventGridNamespaceSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperEventGridNamespaceSettings.BorderThickness = 1F;
            this.grouperEventGridNamespaceSettings.Controls.Add(this.contextFieldsTable);
            this.grouperEventGridNamespaceSettings.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperEventGridNamespaceSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperEventGridNamespaceSettings.ForeColor = System.Drawing.Color.White;
            this.grouperEventGridNamespaceSettings.GroupImage = null;
            this.grouperEventGridNamespaceSettings.GroupTitle = "Context Settings";
            this.grouperEventGridNamespaceSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouperEventGridNamespaceSettings.Location = new System.Drawing.Point(22, 25);
            this.grouperEventGridNamespaceSettings.Margin = System.Windows.Forms.Padding.Empty;
            this.grouperEventGridNamespaceSettings.Name = "grouperEventGridNamespaceSettings";
            this.grouperEventGridNamespaceSettings.Padding = new System.Windows.Forms.Padding(20);
            this.grouperEventGridNamespaceSettings.PaintGroupBox = true;
            this.grouperEventGridNamespaceSettings.RoundCorners = 4;
            this.grouperEventGridNamespaceSettings.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperEventGridNamespaceSettings.ShadowControl = false;
            this.grouperEventGridNamespaceSettings.ShadowThickness = 1;
            this.grouperEventGridNamespaceSettings.Size = new System.Drawing.Size(368, 367);
            this.grouperEventGridNamespaceSettings.TabIndex = 37;
            // 
            // cboApiVersion
            // 
            this.cboApiVersion.FormattingEnabled = true;
            this.cboApiVersion.Items.AddRange(new object[] {
            "2023-12-15-preview",
            "2023-06-01-preview"});
            this.cboApiVersion.Dock = System.Windows.Forms.DockStyle.Left;
            this.cboApiVersion.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.cboApiVersion.Name = "cboApiVersion";
            this.cboApiVersion.Size = new System.Drawing.Size(193, 21);
            this.cboApiVersion.TabIndex = 54;
            // 
            // cloudGroupBox
            // 
            this.cloudGroupBox.BackColor = System.Drawing.Color.Transparent;
            this.cloudGroupBox.Controls.Add(this.cloudSettingsTable);
            this.cloudGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.cloudGroupBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.cloudGroupBox.Name = "cloudGroupBox";
            this.cloudGroupBox.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.cloudGroupBox.Size = new System.Drawing.Size(335, 54);
            this.cloudGroupBox.TabIndex = 53;
            this.cloudGroupBox.TabStop = false;
            // 
            // btnPublicCloud
            // 
            this.btnPublicCloud.AutoSize = true;
            this.btnPublicCloud.Checked = true;
            this.btnPublicCloud.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPublicCloud.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPublicCloud.Margin = System.Windows.Forms.Padding.Empty;
            this.btnPublicCloud.Name = "btnPublicCloud";
            this.btnPublicCloud.Size = new System.Drawing.Size(54, 17);
            this.btnPublicCloud.TabIndex = 40;
            this.btnPublicCloud.TabStop = true;
            this.btnPublicCloud.Text = "Public";
            this.btnPublicCloud.UseVisualStyleBackColor = true;
            // 
            // btnCustomCloud
            // 
            this.btnCustomCloud.AutoSize = true;
            this.btnCustomCloud.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCustomCloud.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomCloud.Margin = System.Windows.Forms.Padding.Empty;
            this.btnCustomCloud.Name = "btnCustomCloud";
            this.btnCustomCloud.Size = new System.Drawing.Size(111, 17);
            this.btnCustomCloud.TabIndex = 40;
            this.btnCustomCloud.Text = "Custom Tenant ID";
            this.btnCustomCloud.UseVisualStyleBackColor = true;
            this.btnCustomCloud.CheckedChanged += new System.EventHandler(this.customCloud_CheckedChanged);
            // 
            // txtCustomId
            // 
            this.txtCustomId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomId.Enabled = false;
            this.txtCustomId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCustomId.Margin = System.Windows.Forms.Padding.Empty;
            this.txtCustomId.Name = "txtCustomId";
            this.txtCustomId.Size = new System.Drawing.Size(188, 20);
            this.txtCustomId.TabIndex = 41;
            // 
            // lblCloud
            // 
            this.lblCloud.AutoSize = true;
            this.lblCloud.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCloud.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCloud.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblCloud.Name = "lblCloud";
            this.lblCloud.Size = new System.Drawing.Size(74, 13);
            this.lblCloud.TabIndex = 51;
            this.lblCloud.Text = "Cloud Tenant:";
            // 
            // txtRetryTimeout
            // 
            this.txtRetryTimeout.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtRetryTimeout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtRetryTimeout.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.txtRetryTimeout.Name = "txtRetryTimeout";
            this.txtRetryTimeout.Size = new System.Drawing.Size(103, 20);
            this.txtRetryTimeout.TabIndex = 19;
            this.txtRetryTimeout.Text = "60";
            // 
            // lblTimeout
            // 
            this.lblTimeout.AutoSize = true;
            this.lblTimeout.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTimeout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimeout.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(90, 13);
            this.lblTimeout.TabIndex = 18;
            this.lblTimeout.Text = "Retry Timeout (s):";
            // 
            // txtSubscriptionId
            // 
            this.txtSubscriptionId.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSubscriptionId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSubscriptionId.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.txtSubscriptionId.Name = "txtSubscriptionId";
            this.txtSubscriptionId.Size = new System.Drawing.Size(336, 20);
            this.txtSubscriptionId.TabIndex = 0;
            // 
            // lblApiVersion
            // 
            this.lblApiVersion.AutoSize = true;
            this.lblApiVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblApiVersion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblApiVersion.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblApiVersion.Name = "lblApiVersion";
            this.lblApiVersion.Size = new System.Drawing.Size(65, 13);
            this.lblApiVersion.TabIndex = 10;
            this.lblApiVersion.Text = "API Version:";
            // 
            // txtResourceGroupName
            // 
            this.txtResourceGroupName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResourceGroupName.BackColor = System.Drawing.SystemColors.Window;
            this.txtResourceGroupName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtResourceGroupName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.txtResourceGroupName.Name = "txtResourceGroupName";
            this.txtResourceGroupName.Size = new System.Drawing.Size(336, 20);
            this.txtResourceGroupName.TabIndex = 1;
            // 
            // lblResourceGroupName
            // 
            this.lblResourceGroupName.AutoSize = true;
            this.lblResourceGroupName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResourceGroupName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblResourceGroupName.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblResourceGroupName.Name = "lblResourceGroupName";
            this.lblResourceGroupName.Size = new System.Drawing.Size(119, 13);
            this.lblResourceGroupName.TabIndex = 0;
            this.lblResourceGroupName.Text = "Resource Group Name:";
            // 
            // lblSubscriptionId
            // 
            this.lblSubscriptionId.AutoSize = true;
            this.lblSubscriptionId.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubscriptionId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubscriptionId.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblSubscriptionId.Name = "lblSubscriptionId";
            this.lblSubscriptionId.Size = new System.Drawing.Size(82, 13);
            this.lblSubscriptionId.TabIndex = 6;
            this.lblSubscriptionId.Text = "Subscription ID:";
            // 
            // txtNamespaceName
            // 
            this.txtNamespaceName.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNamespaceName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtNamespaceName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.txtNamespaceName.Name = "txtNamespaceName";
            this.txtNamespaceName.Size = new System.Drawing.Size(336, 20);
            this.txtNamespaceName.TabIndex = 3;
            // 
            // lblNamespaceName
            // 
            this.lblNamespaceName.AutoSize = true;
            this.lblNamespaceName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNamespaceName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNamespaceName.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.lblNamespaceName.Name = "lblNamespaceName";
            this.lblNamespaceName.Size = new System.Drawing.Size(98, 13);
            this.lblNamespaceName.TabIndex = 2;
            this.lblNamespaceName.Text = "Namespace Name:";
            //
            // contextFieldsTable
            //
            this.contextFieldsTable.ColumnCount = 1;
            this.contextFieldsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contextFieldsTable.Controls.Add(this.lblSubscriptionId, 0, 0);
            this.contextFieldsTable.Controls.Add(this.txtSubscriptionId, 0, 1);
            this.contextFieldsTable.Controls.Add(this.lblResourceGroupName, 0, 2);
            this.contextFieldsTable.Controls.Add(this.txtResourceGroupName, 0, 3);
            this.contextFieldsTable.Controls.Add(this.lblNamespaceName, 0, 4);
            this.contextFieldsTable.Controls.Add(this.txtNamespaceName, 0, 5);
            this.contextFieldsTable.Controls.Add(this.lblApiVersion, 0, 6);
            this.contextFieldsTable.Controls.Add(this.cboApiVersion, 0, 7);
            this.contextFieldsTable.Controls.Add(this.lblTimeout, 0, 8);
            this.contextFieldsTable.Controls.Add(this.txtRetryTimeout, 0, 9);
            this.contextFieldsTable.Controls.Add(this.lblCloud, 0, 10);
            this.contextFieldsTable.Controls.Add(this.cloudGroupBox, 0, 11);
            this.contextFieldsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contextFieldsTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.contextFieldsTable.Margin = System.Windows.Forms.Padding.Empty;
            this.contextFieldsTable.Name = "contextFieldsTable";
            this.contextFieldsTable.Padding = System.Windows.Forms.Padding.Empty;
            this.contextFieldsTable.RowCount = 12;
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.contextFieldsTable.TabIndex = 0;
            this.contextFieldsTable.TabStop = false;
            //
            // cloudSettingsTable
            //
            this.cloudSettingsTable.ColumnCount = 2;
            this.cloudSettingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize));
            this.cloudSettingsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.cloudSettingsTable.Controls.Add(this.btnPublicCloud, 0, 0);
            this.cloudSettingsTable.Controls.Add(this.btnCustomCloud, 0, 1);
            this.cloudSettingsTable.Controls.Add(this.txtCustomId, 1, 1);
            this.cloudSettingsTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cloudSettingsTable.Margin = System.Windows.Forms.Padding.Empty;
            this.cloudSettingsTable.Name = "cloudSettingsTable";
            this.cloudSettingsTable.Padding = System.Windows.Forms.Padding.Empty;
            this.cloudSettingsTable.RowCount = 2;
            this.cloudSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.cloudSettingsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.cloudSettingsTable.TabIndex = 0;
            this.cloudSettingsTable.TabStop = false;
            this.cloudSettingsTable.SetColumnSpan(this.btnPublicCloud, 2);
            //
            // logoFlowPanel
            //
            this.logoFlowPanel.BackColor = System.Drawing.Color.Transparent;
            this.logoFlowPanel.Controls.Add(this.pbAzure);
            this.logoFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.logoFlowPanel.Margin = System.Windows.Forms.Padding.Empty;
            this.logoFlowPanel.Name = "logoFlowPanel";
            this.logoFlowPanel.Padding = System.Windows.Forms.Padding.Empty;
            this.logoFlowPanel.Size = new System.Drawing.Size(370, 22);
            this.logoFlowPanel.TabIndex = 0;
            this.logoFlowPanel.WrapContents = false;
            //
            // buttonFlowPanel
            //
            this.buttonFlowPanel.AutoSize = true;
            this.buttonFlowPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonFlowPanel.Controls.Add(this.btnCancel);
            this.buttonFlowPanel.Controls.Add(this.btnOk);
            this.buttonFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonFlowPanel.Margin = System.Windows.Forms.Padding.Empty;
            this.buttonFlowPanel.Name = "buttonFlowPanel";
            this.buttonFlowPanel.Padding = System.Windows.Forms.Padding.Empty;
            this.buttonFlowPanel.TabIndex = 2;
            this.buttonFlowPanel.WrapContents = false;
            //
            // layoutRootPanel
            //
            this.layoutRootPanel.ColumnCount = 1;
            this.layoutRootPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRootPanel.Controls.Add(this.logoFlowPanel, 0, 0);
            this.layoutRootPanel.Controls.Add(this.grouperEventGridNamespaceSettings, 0, 1);
            this.layoutRootPanel.Controls.Add(this.buttonFlowPanel, 0, 2);
            this.layoutRootPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutRootPanel.Margin = System.Windows.Forms.Padding.Empty;
            this.layoutRootPanel.Name = "layoutRootPanel";
            this.layoutRootPanel.Padding = new System.Windows.Forms.Padding(22, 3, 22, 12);
            this.layoutRootPanel.RowCount = 3;
            this.layoutRootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.layoutRootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutRootPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.layoutRootPanel.TabIndex = 0;
            this.layoutRootPanel.TabStop = false;
            // 
            // EventGridConnectForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(414, 442);
            this.Controls.Add(this.layoutRootPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventGridConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connect to an Event Grid Namespace";
            this.Load += new System.EventHandler(this.EventGridConnectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbAzure)).EndInit();
            this.cloudSettingsTable.ResumeLayout(false);
            this.contextFieldsTable.ResumeLayout(false);
            this.grouperEventGridNamespaceSettings.ResumeLayout(false);
            this.grouperEventGridNamespaceSettings.PerformLayout();
            this.cloudGroupBox.ResumeLayout(false);
            this.cloudGroupBox.PerformLayout();
            this.logoFlowPanel.ResumeLayout(false);
            this.buttonFlowPanel.ResumeLayout(false);
            this.buttonFlowPanel.PerformLayout();
            this.layoutRootPanel.ResumeLayout(false);
            this.layoutRootPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutRootPanel;
        private System.Windows.Forms.TableLayoutPanel contextFieldsTable;
        private System.Windows.Forms.TableLayoutPanel cloudSettingsTable;
        private System.Windows.Forms.FlowLayoutPanel logoFlowPanel;
        private System.Windows.Forms.FlowLayoutPanel buttonFlowPanel;
        private Controls.Grouper grouperEventGridNamespaceSettings;
        private System.Windows.Forms.Label lblNamespaceName;
        private System.Windows.Forms.Label lblResourceGroupName;
        private System.Windows.Forms.Label lblSubscriptionId;
        private System.Windows.Forms.Label lblApiVersion;
        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.Label lblCloud;
        private System.Windows.Forms.TextBox txtNamespaceName;
        private System.Windows.Forms.TextBox txtResourceGroupName;
        private System.Windows.Forms.TextBox txtSubscriptionId;
        private System.Windows.Forms.TextBox txtRetryTimeout;
        private System.Windows.Forms.GroupBox cloudGroupBox;
        private System.Windows.Forms.RadioButton btnPublicCloud;
        private System.Windows.Forms.RadioButton btnCustomCloud;
        private System.Windows.Forms.TextBox txtCustomId;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pbAzure;
        private System.Windows.Forms.ComboBox cboApiVersion;
    }
}
