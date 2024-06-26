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

using Microsoft.ServiceBus.Messaging;
using ServiceBusExplorer.Forms;
using ServiceBusExplorer.Helpers;
using ServiceBusExplorer.UIHelpers;
using ServiceBusExplorer.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace ServiceBusExplorer.Controls
{
    public partial class HandleConsumerGroupControl : UserControl
    {
        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";

        //***************************
        // Texts
        //***************************
        private const string DeleteText = "Delete";
        private const string CreateText = "Create";
        private const string UpdateText = "Update";
        private const string CancelText = "Cancel";

        //***************************
        // Messages
        //***************************
        private const string PathCannotBeNull = "The Path field cannot be null.";

        //***************************
        // Tooltips
        //***************************
        private const string NameTooltip = "Gets or sets the consumerGroup name.";
        private const string UserMetadataTooltip = "Gets or sets the user metadata.";

        //***************************
        // Property Labels
        //***************************
        private const string EventHubPath = "Event Hub Path";
        private const string CreatedAt = "Created At";
        private const string UpdatedAt = "Updated At";
        private const string IsReadOnly = "Is ReadOnly";

        ////***************************
        //// Event Hub Constants
        ////***************************
        private const string ConsumerGroupEntity = "Consumer Group";

        ////***************************
        //// Pages
        ////***************************
        private const string PartitionsTabPage = "tabPagePartitions";

        //***************************
        // Tooltips
        //***************************
        private const string DeleteTooltip = "Delete the row.";
        #endregion

        #region Private Fields
        private ConsumerGroupDescription consumerGroupDescription;
        private readonly ServiceBusHelper serviceBusHelper;
        private readonly WriteToLogDelegate writeToLog;
        private readonly string eventHubName;
        private readonly BindingSource dataPointBindingSource = new BindingSource();
        private readonly BindingSource partitionsBindingSource = new BindingSource();
        private SortableBindingList<PartitionDescription> partitionsBindingList;
        private readonly List<TabPage> hiddenPages = new List<TabPage>();
        #endregion

        #region Private Static Fields
        private static readonly List<string> operators = new List<string> { "ge", "gt", "le", "lt", "eq", "ne" };
        private static readonly List<string> timeGranularityList = new List<string> { "PT5M", "PT1H", "P1D", "P7D" };
        #endregion

        #region Public Constructors
        public HandleConsumerGroupControl(WriteToLogDelegate writeToLog, ServiceBusHelper serviceBusHelper, ConsumerGroupDescription consumerGroupDescription, string eventHubName)
        {
            this.writeToLog = writeToLog;
            this.serviceBusHelper = serviceBusHelper;
            this.consumerGroupDescription = consumerGroupDescription;
            this.eventHubName = eventHubName;

            InitializeComponent();
            InitializeControls();
        }
        #endregion

        #region Public Events
        public event Action OnCancel;
        public event Action OnRefresh;
        #endregion

        #region Public Methods
        public void RefreshData(ConsumerGroupDescription consumerGroup)
        {
            try
            {
                consumerGroupDescription = consumerGroup;
                InitializeData();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void GetPartitions()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    if (serviceBusHelper == null)
                    {
                        return;
                    }

                    // ConsumerGroup Node
                    if (consumerGroupDescription == null)
                    {
                        return;
                    }

                    var partitionEnumerable = serviceBusHelper.GetPartitions(consumerGroupDescription.EventHubPath, consumerGroupDescription.Name);
                    var partitionDescriptionList = partitionEnumerable as IList<PartitionDescription> ??
                                                   partitionEnumerable.ToList();
                    if (!partitionDescriptionList.Any())
                    {
                        return;
                    }
                    partitionsBindingList = new SortableBindingList<PartitionDescription>(partitionDescriptionList)
                    {
                        AllowEdit = false,
                        AllowNew = false,
                        AllowRemove = false
                    };
                    partitionsBindingSource.DataSource = partitionsBindingList;
                    partitionsDataGridView.DataSource = partitionsBindingSource;

                    var dataGridViewColumn = partitionsDataGridView.Columns["IsReadOnly"];
                    if (dataGridViewColumn != null)
                    {
                        dataGridViewColumn.Visible = false;
                    }

                    dataGridViewColumn = partitionsDataGridView.Columns["ExtensionData"];
                    if (dataGridViewColumn != null)
                    {
                        dataGridViewColumn.Visible = false;
                    }

                    dataGridViewColumn = partitionsDataGridView.Columns["EventHubPath"];
                    if (dataGridViewColumn != null)
                    {
                        dataGridViewColumn.Visible = false;
                    }

                    dataGridViewColumn = partitionsDataGridView.Columns["ConsumerGroupName"];
                    if (dataGridViewColumn != null)
                    {
                        dataGridViewColumn.Visible = false;
                    }

                    partitionsDataGridView.Refresh();

                    if (mainTabControl.TabPages[PartitionsTabPage] == null)
                    {
                        EnablePage(PartitionsTabPage);
                    }
                    if (mainTabControl.TabPages[PartitionsTabPage] != null)
                    {
                        mainTabControl.SelectTab(PartitionsTabPage);
                    }
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Private Methods
        private void InitializeControls()
        {
            // Set Grid style
            partitionsDataGridView.EnableHeadersVisualStyles = false;

            // Set the selection background color for all the cells.
            partitionsDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(92, 125, 150);
            partitionsDataGridView.DefaultCellStyle.SelectionForeColor = SystemColors.Window;

            // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
            // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
            partitionsDataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 180, 209);

            // Set the background color for all rows and for alternating rows.  
            // The value for alternating rows overrides the value for all rows. 
            partitionsDataGridView.RowsDefaultCellStyle.BackColor = SystemColors.Window;
            partitionsDataGridView.RowsDefaultCellStyle.ForeColor = SystemColors.ControlText;
            //filtersDataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            //filtersDataGridView.AlternatingRowsDefaultCellStyle.ForeColor = SystemColors.ControlText;

            // Set the row and column header styles.
            partitionsDataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
            partitionsDataGridView.RowHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
            partitionsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
            partitionsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;

            // Initialize the DataGridView.
            partitionsDataGridView.AutoGenerateColumns = true;
            partitionsDataGridView.AutoSize = true;
            partitionsDataGridView.ForeColor = SystemColors.WindowText;


            DisablePage(PartitionsTabPage);

            if (consumerGroupDescription != null)
            {
                // Initialize buttons
                btnCreateDelete.Text = DeleteText;
                btnCancelUpdate.Text = UpdateText;
                btnRefresh.Visible = true;
                btnGetPartitions.Visible = true;

                // Initialize textboxes
                txtName.ReadOnly = true;
                txtName.BackColor = SystemColors.Window;
                txtName.GotFocus += textBox_GotFocus;

                // Initialize Data
                InitializeData();

                toolTip.SetToolTip(txtName, NameTooltip);
                toolTip.SetToolTip(txtUserMetadata, UserMetadataTooltip);

                propertyListView.ContextMenuStrip = entityInformationContextMenuStrip;
            }
            else
            {
                // Initialize buttons
                btnCreateDelete.Text = CreateText;
                btnCancelUpdate.Text = CancelText;
                btnRefresh.Visible = false;
                btnGetPartitions.Visible = false;
            }
        }

        private void InitializeData()
        {
            // Initialize property grid
            var propertyList = new List<string[]>();

            propertyList.AddRange(new[]{new[]{EventHubPath, consumerGroupDescription.EventHubPath},
                                        new[]{IsReadOnly, consumerGroupDescription.IsReadOnly.ToString()},
                                        new[]{CreatedAt, consumerGroupDescription.CreatedAt.ToString(CultureInfo.CurrentCulture)},
                                        new[]{UpdatedAt, consumerGroupDescription.UpdatedAt.ToString(CultureInfo.CurrentCulture)}});

            propertyListView.Items.Clear();
            foreach (var array in propertyList)
            {
                propertyListView.Items.Add(new ListViewItem(array));
            }

            // Path
            if (!string.IsNullOrWhiteSpace(consumerGroupDescription.Name))
            {
                txtName.Text = consumerGroupDescription.Name;
            }

            // UserMetadata
            if (!string.IsNullOrWhiteSpace(consumerGroupDescription.UserMetadata))
            {
                txtUserMetadata.Text = consumerGroupDescription.UserMetadata;
            }
        }

        private void btnCreateDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceBusHelper == null)
                {
                    return;
                }
                if (btnCreateDelete.Text == DeleteText)
                {
                    using (var deleteForm = new DeleteForm(consumerGroupDescription.Name, ConsumerGroupEntity.ToLower()))
                    {
                        var configuration = TwoFilesConfiguration.Create(TwoFilesConfiguration.GetCurrentConfigFileUse(), writeToLog);

                        bool disableAccidentalDeletionPrevention = configuration.GetBoolValue(
                                                               ConfigurationParameters.DisableAccidentalDeletionPrevention,
                                                               defaultValue: false);

                        if (!disableAccidentalDeletionPrevention)
                        {
                            deleteForm.ShowAccidentalDeletionPreventionCheck(configuration, $"Delete {consumerGroupDescription.Name} {ConsumerGroupEntity.ToLower()}");
                        }

                        if (deleteForm.ShowDialog() == DialogResult.OK)
                        {
                            serviceBusHelper.DeleteConsumerGroup(consumerGroupDescription);
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        writeToLog(PathCannotBeNull);
                        return;
                    }
                    //var description = new ConsumerGroupDescription(eventHubName, txtName.Text)
                    //    {
                    //        UserMetadata = txtUserMetadata.Text,
                    //        EnableCheckpoint = checkBoxEnableCheckpoint.Enabled
                    //    };

                    var description = new ConsumerGroupDescription(eventHubName, txtName.Text)
                    {
                        UserMetadata = txtUserMetadata.Text
                    };

                    consumerGroupDescription = serviceBusHelper.CreateConsumerGroup(description);
                    InitializeControls();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
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

        private async void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            var ok = true;

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
                    consumerGroupDescription.UserMetadata = txtUserMetadata.Text;
                    //consumerGroupDescription.EnableCheckpoint = checkBoxEnableCheckpoint.Enabled;
                    serviceBusHelper.UpdateConsumerGroup(consumerGroupDescription);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                    ok = false;
                }
                finally
                {
                    InitializeControls();
                }
                if (ok)
                {
                    return;
                }
                try
                {
                    consumerGroupDescription = await serviceBusHelper.NamespaceManager.GetConsumerGroupAsync(eventHubName, consumerGroupDescription.Name);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
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

        private void copyPartitionInformationToClipboardMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                var builder = new StringBuilder();
                const string delimiter = ",";

                // Setup the columns
                for (var i = 0; i < propertyListView.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        builder.Append(delimiter);
                    }
                    builder.Append(propertyListView.Columns[i].Text);
                }
                builder.AppendLine();

                builder.Append(string.Format("Name, {0}", consumerGroupDescription.Name));
                builder.AppendLine();
                builder.Append(string.Format("EventHubPath, {0}", consumerGroupDescription.EventHubPath));
                builder.AppendLine();

                // Build the data row by row
                for (var i = 0; i < propertyListView.Items.Count; i++)
                {
                    if (i > 0)
                    {
                        builder.AppendLine();
                    }
                    for (var j = 0; j < propertyListView.Columns.Count; j++)
                    {
                        if (j > 0)
                        {
                            builder.Append(delimiter);
                        }
                        builder.Append(propertyListView.Items[i].SubItems[j].Text);
                    }
                }

                Clipboard.SetText(builder.ToString());
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void partitionsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void partitionsDataGridView_Resize(object sender, EventArgs e)
        {
            CalculateLastColumnWidth(sender);
        }

        private void partitionsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateLastColumnWidth(sender);
        }

        private void partitionsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateLastColumnWidth(sender);
        }

        private void CalculateLastColumnWidth(object sender)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView == null)
            {
                return;
            }
            try
            {
                if (dataGridView.ColumnCount == 0)
                {
                    return;
                }
                dataGridView.SuspendDrawing();
                dataGridView.SuspendLayout();
                var width = dataGridView.Width - dataGridView.RowHeadersWidth;
                var verticalScrollbar = dataGridView.Controls.OfType<VScrollBar>().First();
                if (verticalScrollbar != null && verticalScrollbar.Visible)
                {
                    width -= verticalScrollbar.Width;
                }
                var columnCount = partitionsDataGridView.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible);
                var columnWidth = width / columnCount;
                for (var i = 0; i < partitionsDataGridView.Columns.Count; i++)
                {
                    partitionsDataGridView.Columns[i].Width = columnWidth;
                }
            }
            finally
            {
                dataGridView.ResumeLayout();
                dataGridView.ResumeDrawing();
            }
        }

        private void grouperPartitionsList_CustomPaint(PaintEventArgs e)
        {
            partitionsDataGridView.Size = new Size(
                grouperPartitionsList.Size.Width - (partitionsDataGridView.Location.X * 2 + 2),
                grouperPartitionsList.Size.Height - partitionsDataGridView.Location.Y - partitionsDataGridView.Location.X - 2);
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                partitionsDataGridView.Location.X - 1,
                partitionsDataGridView.Location.Y - 1,
                partitionsDataGridView.Size.Width + 1,
                partitionsDataGridView.Size.Height + 1);
        }

        private void btnGetPartitions_Click(object sender, EventArgs e)
        {
            GetPartitions();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.ToLower();
            txtName.SelectionStart = txtName.Text.Length;
        }
        #endregion
    }
}
