﻿#region Copyright
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

#region Using Directives

using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using ServiceBusExplorer.Forms;
using ServiceBusExplorer.Helpers;
using ServiceBusExplorer.UIHelpers;
using ServiceBusExplorer.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace ServiceBusExplorer.Controls
{
    public partial class HandleRelayControl : UserControl
    {
        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";

        //***************************
        // Indexes
        //***************************
        private const int RequiresClientAuthorizationIndex = 0;
        private const int RequiresTransportSecurityIndex = 1;
        private const int IsAnonymousAccessibleIndex = 6;

        //***************************
        // Texts
        //***************************
        private const string DeleteText = "Delete";
        private const string CreateText = "Create";
        private const string UpdateText = "Update";
        private const string CancelText = "Cancel";
        private const string UserMetadata = "User Metadata";

        //***************************
        // Pages
        //***************************
        private const string AuthorizationPage = "tabPageAuthorization";

        //***************************
        // Messages
        //***************************
        private const string PathCannotBeNull = "The Path field cannot be null.";
        private const string AuthorizationRuleDeleteMessage = "The Authorization Rule will be permanently deleted";
        private const string KeyNameCannotBeNull = "Authorization Rule [{0}]: the KeyName cannot be null";

        //***************************
        // Tooltips
        //***************************
        private const string PathTooltip = "Gets or sets the relay path.";
        private const string UserMetadataTooltip = "Gets or sets the user metadata.";

        //***************************
        // Property Labels
        //***************************
        private const string CreatedAt = "Created At";
        private const string UpdatedAt = "Updated At";
        private const string CollectionName = "Collection Name";
        private const string IsReadOnly = "Is ReadOnly";
        private const string IsDynamic = "Is Dynamic";
        private const string ListenerCount = "Listener Count";
        private const string RelayEntity = "Relay";
        #endregion

        #region Private Fields
        private RelayDescription relayDescription;
        private readonly ServiceBusHelper serviceBusHelper;
        private readonly WriteToLogDelegate writeToLog;
        private readonly string path;
        private readonly List<TabPage> hiddenPages = new List<TabPage>();
        #endregion

        #region Private Static Fields
        private static readonly List<string> operators = new List<string> { "ge", "gt", "le", "lt", "eq", "ne" };
        private static readonly List<string> timeGranularityList = new List<string> { "PT5M", "PT1H", "P1D", "P7D" };
        #endregion

        #region Public Constructors
        public HandleRelayControl(WriteToLogDelegate writeToLog, ServiceBusHelper serviceBusHelper, RelayDescription relayDescription, string path)
        {
            this.writeToLog = writeToLog;
            this.serviceBusHelper = serviceBusHelper;
            this.relayDescription = relayDescription;
            this.path = path;

            InitializeComponent();
            InitializeControls();
        }
        #endregion

        #region Public Events
        public event Action OnCancel;
        public event Action OnRefresh;
        #endregion

        #region Public Methods
        public void RefreshData(RelayDescription relayService)
        {
            try
            {
                relayDescription = relayService;
                InitializeData();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Private Methods
        // ReSharper disable once FunctionComplexityOverflow
        private void InitializeControls()
        {
            // RelayType
            if (cboRelayType.Items.Count == 0)
            {
                var values = Enum.GetNames(typeof(RelayType));
                // ReSharper disable once CoVariantArrayConversion
                cboRelayType.Items.AddRange(values);
            }
            if (cboRelayType.Items.Count > 0)
            {
                cboRelayType.SelectedIndex = 0;
            }

            // IsAnonymousAccessible
            if (serviceBusHelper.IsCloudNamespace)
            {
                if (checkedListBox.Items.Count > IsAnonymousAccessibleIndex)
                {
                    checkedListBox.Items.RemoveAt(IsAnonymousAccessibleIndex);
                }
            }

            AuthorizationRulesDataGridViewHelper.InitializeDataGridView(authorizationRulesDataGridView);
            AuthorizationRulesDataGridViewHelper.AddAuthorizationRulesColumns(authorizationRulesDataGridView, serviceBusHelper.IsCloudNamespace, LogicalToDeviceUnits);

            if (relayDescription != null)
            {
                // Initialize buttons
                btnCreateDelete.Text = DeleteText;
                btnCancelUpdate.Text = UpdateText;
                btnRefresh.Visible = true;

                // Initialize textboxes
                txtPath.ReadOnly = true;
                txtPath.BackColor = SystemColors.Window;
                txtPath.ForeColor = SystemColors.ControlText;
                txtPath.GotFocus += textBox_GotFocus;

                // Initialize comboboxes
                cboRelayType.BackColor = SystemColors.Window;
                cboRelayType.Enabled = false;

                // EnableBatchedOperations
                checkedListBox.SetItemChecked(RequiresClientAuthorizationIndex, relayDescription.RequiresClientAuthorization);
                checkedListBox.SetItemChecked(RequiresTransportSecurityIndex, relayDescription.RequiresTransportSecurity);

                // Initialize Data
                InitializeData();

                checkedListBox.ItemCheck += checkedListBox_ItemCheck;

                toolTip.SetToolTip(txtPath, PathTooltip);
                toolTip.SetToolTip(txtUserMetadata, UserMetadataTooltip);

                if (relayDescription.IsDynamic)
                {
                    DisablePage(AuthorizationPage);
                    txtUserMetadata.ReadOnly = true;
                    txtUserMetadata.BackColor = SystemColors.Window;
                    txtUserMetadata.GotFocus += textBox_GotFocus;

                    btnCreateDelete.Visible = false;
                    btnCancelUpdate.Visible = false;
                    //btnCloseTabs.Location = btnCreateDelete.Location;
                    btnRefresh.Location = btnCancelUpdate.Location;
                }
            }
            else
            {
                // Initialize buttons
                btnCreateDelete.Text = CreateText;
                btnCancelUpdate.Text = CancelText;
                btnRefresh.Visible = false;

                checkedListBox.SetItemChecked(RequiresClientAuthorizationIndex, true);
                checkedListBox.SetItemChecked(RequiresTransportSecurityIndex, true);

                // Create BindingList for Authorization Rules
                var bindingList = new BindingList<AuthorizationRuleWrapper>(new List<AuthorizationRuleWrapper>())
                {
                    AllowEdit = true,
                    AllowNew = true,
                    AllowRemove = true
                };
                bindingList.ListChanged += bindingList_ListChanged;
                authorizationRulesBindingSource.DataSource = bindingList;
                authorizationRulesDataGridView.DataSource = authorizationRulesBindingSource;

                if (!string.IsNullOrWhiteSpace(path))
                {
                    txtPath.Text = path;
                }
                txtPath.Focus();
            }

            checkedListBox.SetResizeEvent(LogicalToDeviceUnits);
        }

        private void EnablePage(string pageName)
        {
            var page =
                hiddenPages.FirstOrDefault(
                    p => string.Compare(p.Name, pageName, StringComparison.InvariantCultureIgnoreCase) == 0);
            if (page == null)
            {
                return;
            }
            mainTabControl.TabPages.Add(page);
            hiddenPages.Remove(page);
        }

        private void DisablePage(string pageName)
        {
            var page = mainTabControl.TabPages[pageName];
            if (page == null)
            {
                return;
            }
            mainTabControl.TabPages.Remove(page);
            hiddenPages.Add(page);
        }

        private void bindingList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                if (relayDescription != null &&
                    relayDescription.Authorization.Count > 0 &&
                    relayDescription.Authorization.Count > e.NewIndex)
                {
                    var rule = relayDescription.Authorization.ElementAt(e.NewIndex);
                    if (rule != null)
                    {
                        relayDescription.Authorization.Remove(rule);
                    }
                }
            }
        }

        private void InitializeData()
        {
            // Authorization Rules
            BindingList<AuthorizationRuleWrapper> bindingList;
            if (relayDescription.Authorization.Count > 0)
            {
                var enumerable = relayDescription.Authorization.Select(r => new AuthorizationRuleWrapper(r));
                bindingList = new BindingList<AuthorizationRuleWrapper>(enumerable.ToList())
                {
                    AllowEdit = true,
                    AllowNew = true,
                    AllowRemove = true
                };

            }
            else
            {
                bindingList = new BindingList<AuthorizationRuleWrapper>(new List<AuthorizationRuleWrapper>())
                {
                    AllowEdit = true,
                    AllowNew = true,
                    AllowRemove = true
                };
            }
            bindingList.ListChanged += bindingList_ListChanged;
            authorizationRulesBindingSource.DataSource = new BindingList<AuthorizationRuleWrapper>(bindingList);
            authorizationRulesDataGridView.DataSource = authorizationRulesBindingSource;
            cboRelayType.SelectedItem = relayDescription.RelayType.ToString();

            // Initialize property grid
            var propertyList = new List<string[]>();

            propertyList.AddRange(new[]{new[]{IsReadOnly, relayDescription.IsReadOnly.ToString()},
                                            new[]{IsDynamic, relayDescription.IsDynamic.ToString()},
                                            new[]{ListenerCount, relayDescription.ListenerCount.ToString()},
                                            new[]{CreatedAt, relayDescription.CreatedAt.ToString(CultureInfo.CurrentCulture)},
                                            new[]{UpdatedAt, relayDescription.UpdatedAt.ToString(CultureInfo.CurrentCulture)},
                                            new[]{CollectionName, relayDescription.CollectionName}
                                            });

            propertyListView.Items.Clear();
            foreach (var array in propertyList)
            {
                propertyListView.Items.Add(new ListViewItem(array));
            }

            // Path
            if (!string.IsNullOrWhiteSpace(relayDescription.Path))
            {
                txtPath.Text = relayDescription.Path;
            }

            // UserMetadata
            if (!string.IsNullOrWhiteSpace(relayDescription.UserMetadata))
            {
                txtUserMetadata.Text = relayDescription.UserMetadata;
            }
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (relayDescription == null)
            {
                return;
            }
            if (e.Index == RequiresClientAuthorizationIndex)
            {
                e.NewValue = relayDescription.RequiresClientAuthorization ? CheckState.Checked : CheckState.Unchecked;
            }
            if (e.Index == RequiresTransportSecurityIndex)
            {
                e.NewValue = relayDescription.RequiresTransportSecurity ? CheckState.Checked : CheckState.Unchecked;
            }
        }

        // ReSharper disable once FunctionComplexityOverflow
        private async void btnCreateDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceBusHelper == null)
                {
                    return;
                }
                if (btnCreateDelete.Text == DeleteText)
                {
                    using (var deleteForm = new DeleteForm(relayDescription.Path, RelayEntity.ToLower()))
                    {
                        var configuration = TwoFilesConfiguration.Create(TwoFilesConfiguration.GetCurrentConfigFileUse(), writeToLog);

                        bool disableAccidentalDeletionPrevention = configuration.GetBoolValue(
                                                               ConfigurationParameters.DisableAccidentalDeletionPrevention,
                                                               defaultValue: false);

                        if (!disableAccidentalDeletionPrevention)
                        {
                            deleteForm.ShowAccidentalDeletionPreventionCheck(configuration, $"Delete {relayDescription.Path} {RelayEntity.ToLower()}");
                        }

                        if (deleteForm.ShowDialog() == DialogResult.OK)
                        {
                            await serviceBusHelper.NamespaceManager.DeleteRelayAsync(relayDescription.Path);
                            //serviceBusHelper.DeleteRelay(relayDescription.Path);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtPath.Text))
                    {
                        writeToLog(PathCannotBeNull);
                        return;
                    }
                    var description = new RelayDescription(txtPath.Text, (RelayType)Enum.Parse(typeof(RelayType), cboRelayType.Text, true))
                    {
                        UserMetadata = txtUserMetadata.Text,
                        RequiresClientAuthorization = checkedListBox.GetItemChecked(RequiresClientAuthorizationIndex),
                        RequiresTransportSecurity = checkedListBox.GetItemChecked(RequiresTransportSecurityIndex)
                    };

                    var bindingList = authorizationRulesBindingSource.DataSource as BindingList<AuthorizationRuleWrapper>;
                    if (bindingList != null)
                    {
                        for (var i = 0; i < bindingList.Count; i++)
                        {
                            var rule = bindingList[i];
                            if (serviceBusHelper.IsCloudNamespace)
                            {
                                if (string.IsNullOrWhiteSpace(rule.KeyName))
                                {
                                    writeToLog(string.Format(KeyNameCannotBeNull, i));
                                    continue;
                                }
                            }
                            var rightList = new List<AccessRights>();
                            if (rule.Manage)
                            {
                                rightList.AddRange(new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen });
                            }
                            else
                            {
                                if (rule.Send)
                                {
                                    rightList.Add(AccessRights.Send);
                                }
                                if (rule.Listen)
                                {
                                    rightList.Add(AccessRights.Listen);
                                }
                            }
                            if (serviceBusHelper.IsCloudNamespace)
                            {
                                if (string.IsNullOrWhiteSpace(rule.SecondaryKey))
                                {
                                    description.Authorization.Add(new SharedAccessAuthorizationRule(rule.KeyName,
                                                                                                    rule.PrimaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                                                                                    rightList));
                                }
                                else
                                {
                                    description.Authorization.Add(new SharedAccessAuthorizationRule(rule.KeyName,
                                                                                                    rule.PrimaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                                                                                    rule.SecondaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                                                                                    rightList));
                                }
                            }
                            else
                            {
                                description.Authorization.Add(new AllowRule(rule.IssuerName,
                                                                            rule.ClaimType,
                                                                            rule.ClaimValue,
                                                                            rightList));
                            }
                        }
                    }
                    relayDescription = serviceBusHelper.CreateRelay(description);
                    InitializeControls();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            if (ex == null || string.IsNullOrWhiteSpace(ex.Message))
            {
                return;
            }
            writeToLog(string.Format(CultureInfo.CurrentCulture, ExceptionFormat, ex.Message));
            if (ex.InnerException != null && !string.IsNullOrWhiteSpace(ex.InnerException.Message))
            {
                writeToLog(string.Format(CultureInfo.CurrentCulture, InnerExceptionFormat, ex.InnerException.Message));
            }
        }

        // ReSharper disable once FunctionComplexityOverflow
        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            if (btnCancelUpdate.Text == CancelText)
            {
                if (OnCancel != null)
                {
                    OnCancel();
                }
            }
            else
            {
                try
                {
                    relayDescription.UserMetadata = txtUserMetadata.Text;

                    var bindingList = authorizationRulesBindingSource.DataSource as BindingList<AuthorizationRuleWrapper>;
                    if (bindingList != null)
                    {
                        for (var i = 0; i < bindingList.Count; i++)
                        {
                            var rule = bindingList[i];

                            if (serviceBusHelper.IsCloudNamespace)
                            {
                                if (string.IsNullOrWhiteSpace(rule.KeyName))
                                {
                                    writeToLog(string.Format(KeyNameCannotBeNull, i));
                                    continue;
                                }
                            }
                            var rightList = new List<AccessRights>();
                            if (rule.Manage)
                            {
                                rightList.AddRange(new[] { AccessRights.Manage, AccessRights.Send, AccessRights.Listen });
                            }
                            else
                            {
                                if (rule.Send)
                                {
                                    rightList.Add(AccessRights.Send);
                                }
                                if (rule.Listen)
                                {
                                    rightList.Add(AccessRights.Listen);
                                }
                            }
                            if (serviceBusHelper.IsCloudNamespace)
                            {
                                if (string.IsNullOrWhiteSpace(rule.PrimaryKey) && string.IsNullOrWhiteSpace(rule.SecondaryKey))
                                {
                                    relayDescription.Authorization.Add(new SharedAccessAuthorizationRule(rule.KeyName,
                                                                                                         rightList));
                                }
                                else if (string.IsNullOrWhiteSpace(rule.SecondaryKey))
                                {
                                    relayDescription.Authorization.Add(new SharedAccessAuthorizationRule(rule.KeyName,
                                                                                                         rule.PrimaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                                                                                         rightList));
                                }
                                else
                                {
                                    relayDescription.Authorization.Add(new SharedAccessAuthorizationRule(rule.KeyName,
                                                                                                         rule.PrimaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                                                                                         rule.SecondaryKey ?? SharedAccessAuthorizationRule.GenerateRandomKey(),
                                                                                                         rightList));
                                }
                            }
                            else
                            {
                                relayDescription.Authorization.Add(new AllowRule(rule.IssuerName,
                                                                                 rule.ClaimType,
                                                                                 rule.ClaimValue,
                                                                                 rightList));
                            }
                        }
                    }
                    relayDescription = serviceBusHelper.UpdateRelay(relayDescription);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    relayDescription = serviceBusHelper.GetRelay(relayDescription.Path);
                }
                finally
                {
                    InitializeControls();
                }
            }
        }

        private static void textBox_GotFocus(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                NativeMethods.HideCaret(textBox.Handle);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (OnRefresh != null)
            {
                OnRefresh();
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.ForeColor = Color.White;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                control.ForeColor = SystemColors.ControlText;
            }
        }

        private void btnOpenUserMetadataForm_Click(object sender, EventArgs e)
        {
            using (var form = new TextForm(UserMetadata, txtUserMetadata.Text))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    txtUserMetadata.Text = form.Content;
                }
            }
        }

        private void propertyListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) => ListViewHelper.DrawListViewHeaders(e, DeviceDpi);

        private void propertyListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void propertyListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawText();
        }

        private void propertyListView_Resize(object sender, EventArgs e)
        {
            try
            {
                propertyListView.SuspendDrawing();
                propertyListView.SuspendLayout();
                var width = propertyListView.Width - propertyListView.Columns[0].Width - 4;
                var scrollbars = ScrollBarHelper.GetVisibleScrollbars(propertyListView);
                if (scrollbars == ScrollBars.Vertical || scrollbars == ScrollBars.Both)
                {
                    width -= 17;
                }
                propertyListView.Columns[1].Width = width;
            }
            finally
            {
                propertyListView.ResumeLayout();
                propertyListView.ResumeDrawing();
            }
        }

        private void mainTabControl_DrawItem(object sender, DrawItemEventArgs e) => TabControlHelper.DrawTabControlTabs(mainTabControl, e, null);

        private void grouperAuthorizationRuleList_CustomPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                    authorizationRulesDataGridView.Location.X - 1,
                                    authorizationRulesDataGridView.Location.Y - 1,
                                    authorizationRulesDataGridView.Size.Width + 1,
                                    authorizationRulesDataGridView.Size.Height + 1);
        }

        private void authorizationRulesDataGridView_Resize(object sender, EventArgs e)
        {
            try
            {
                authorizationRulesDataGridView.SuspendDrawing();
                authorizationRulesDataGridView.SuspendLayout();
                if (authorizationRulesDataGridView.Columns["IssuerName"] == null ||
                authorizationRulesDataGridView.Columns["ClaimType"] == null ||
                authorizationRulesDataGridView.Columns["ClaimValue"] == null ||
                authorizationRulesDataGridView.Columns["Manage"] == null ||
                authorizationRulesDataGridView.Columns["Send"] == null ||
                authorizationRulesDataGridView.Columns["Listen"] == null ||
                authorizationRulesDataGridView.Columns["Revision"] == null ||
                authorizationRulesDataGridView.Columns["CreatedTime"] == null ||
                authorizationRulesDataGridView.Columns["ModifiedTime"] == null)
                {
                    return;
                }

                var width = authorizationRulesDataGridView.Width -
                            authorizationRulesDataGridView.Columns["Manage"].Width -
                            authorizationRulesDataGridView.Columns["Send"].Width -
                            authorizationRulesDataGridView.Columns["Listen"].Width -
                            authorizationRulesDataGridView.Columns["Revision"].Width -
                            authorizationRulesDataGridView.RowHeadersWidth;
                var verticalScrollbar = authorizationRulesDataGridView.Controls.OfType<VScrollBar>().First();
                if (verticalScrollbar.Visible)
                {
                    width -= verticalScrollbar.Width;
                }
                int columnWidth;
                if (serviceBusHelper.IsCloudNamespace)
                {
                    columnWidth = width / 8;
                    authorizationRulesDataGridView.Columns["IssuerName"].Width = width - (7 * columnWidth);
                    if (authorizationRulesDataGridView.Columns["KeyName"] != null &&
                        authorizationRulesDataGridView.Columns["PrimaryKey"] != null &&
                        authorizationRulesDataGridView.Columns["SecondaryKey"] != null)
                    {
                        authorizationRulesDataGridView.Columns["KeyName"].Width = columnWidth;
                        authorizationRulesDataGridView.Columns["PrimaryKey"].Width = columnWidth;
                        authorizationRulesDataGridView.Columns["SecondaryKey"].Width = columnWidth;
                    }
                }
                else
                {
                    columnWidth = width / 5;
                    authorizationRulesDataGridView.Columns["IssuerName"].Width = width - (4 * columnWidth);
                }
                authorizationRulesDataGridView.Columns["ClaimType"].Width = columnWidth;
                authorizationRulesDataGridView.Columns["ClaimValue"].Width = columnWidth;
                authorizationRulesDataGridView.Columns["CreatedTime"].Width = columnWidth;
                authorizationRulesDataGridView.Columns["ModifiedTime"].Width = columnWidth;
            }
            finally
            {
                authorizationRulesDataGridView.ResumeLayout();
                authorizationRulesDataGridView.ResumeDrawing();
            }
        }

        private void authorizationRulesDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            authorizationRulesDataGridView_Resize(sender, null);
        }

        private void authorizationRulesDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            authorizationRulesDataGridView_Resize(sender, null);
        }

        private void authorizationRulesDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (var deleteForm = new DeleteForm(AuthorizationRuleDeleteMessage))
            {
                e.Cancel = deleteForm.ShowDialog() == DialogResult.Cancel;
            }
        }

        private void authorizationRulesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (authorizationRulesDataGridView.Columns[e.ColumnIndex].Name == "Manage")
            {
                if (!(bool)authorizationRulesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
                {
                    authorizationRulesDataGridView.Rows[e.RowIndex].Cells["Manage"].Value = true;
                    authorizationRulesDataGridView.Rows[e.RowIndex].Cells["Send"].Value = true;
                    authorizationRulesDataGridView.Rows[e.RowIndex].Cells["Listen"].Value = true;
                }
                return;
            }
            if ((authorizationRulesDataGridView.Columns[e.ColumnIndex].Name == "Send" ||
                 authorizationRulesDataGridView.Columns[e.ColumnIndex].Name == "Listen"))
            {
                if ((bool)authorizationRulesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value &&
                    (bool)authorizationRulesDataGridView.Rows[e.RowIndex].Cells["Manage"].Value)
                {
                    authorizationRulesDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    authorizationRulesDataGridView.Rows[e.RowIndex].Cells["Manage"].Value = false;
                }
            }
        }

        private void authorizationRulesDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!serviceBusHelper.IsCloudNamespace &&
                e.RowIndex == authorizationRulesDataGridView.Rows.Count - 1 &&
                string.IsNullOrWhiteSpace(authorizationRulesDataGridView.Rows[e.RowIndex].Cells["IssuerName"].Value as string))
            {
                authorizationRulesDataGridView.Rows[e.RowIndex].Cells["IssuerName"].Value = serviceBusHelper.Namespace;
            }
        }

        private void authorizationRulesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }

                for (var i = 0; i < Controls.Count; i++)
                {
                    Controls[i].Dispose();
                }

                base.Dispose(disposing);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }
        }

        private void grouperRelayProperties_CustomPaint(PaintEventArgs e)
        {
            if (relayDescription != null)
            {
                return;
            }
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                   cboRelayType.Location.X - 1,
                                   cboRelayType.Location.Y - 1,
                                   cboRelayType.Size.Width + 1,
                                   cboRelayType.Size.Height + 1);
        }


        #endregion
    }
}
