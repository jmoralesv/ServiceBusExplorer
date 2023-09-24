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

#region Using Directives

using Microsoft.ServiceBus.Messaging;
using ServiceBusExplorer.UIHelpers;
using ServiceBusExplorer.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

#endregion

namespace ServiceBusExplorer.Controls
{
    public partial class HandlePartitionControl : UserControl
    {
        #region Private Constants
        //***************************
        // Formats
        //***************************
        private const string ExceptionFormat = "Exception: {0}";
        private const string InnerExceptionFormat = "InnerException: {0}";

        //***************************
        // Property Labels
        //***************************
        private const string PartitionId = "PartitionId";
        private const string EventHubPath = "Event Hub Path";
        private const string SizeInBytes = "Size in Bytes";
        private const string BeginSequenceNumber = "Begin Sequence Number";
        private const string EndSequenceNumber = "End Sequence Number";
        private const string IncomingBytesPerSecond = "IncomingBytesPerSecond";
        private const string OutgoingBytesPerSecond = "OutgoingBytesPerSecond";
        private const string LastEnqueuedOffset = "LastEnqueuedOffset";
        private const string LastEnqueuedTimeUtc = "LastEnqueuedTimeUtc";
        #endregion

        #region Private Fields
        private PartitionDescription partitionDescription;
        // ReSharper disable once NotAccessedField.Local
        private readonly ServiceBusHelper serviceBusHelper;
        private readonly WriteToLogDelegate writeToLog;
        #endregion

        #region Public Constructors
        public HandlePartitionControl(WriteToLogDelegate writeToLog, ServiceBusHelper serviceBusHelper, PartitionDescription partitionDescription)
        {
            this.writeToLog = writeToLog;
            this.serviceBusHelper = serviceBusHelper;
            this.partitionDescription = partitionDescription;
            InitializeComponent();
            InitializeData();
        }
        #endregion

        #region Public Events
        public event Action OnRefresh;
        #endregion

        #region Public Methods
        public void RefreshData(PartitionDescription partition)
        {
            try
            {
                partitionDescription = partition;
                InitializeData();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Private Methods
        private void InitializeData()
        {
            try
            {
                // Initialize property grid
                var propertyList = new List<string[]>();

                propertyList.AddRange(new[]{new[]{PartitionId, partitionDescription.PartitionId},
                                            new[]{EventHubPath, partitionDescription.EventHubPath},
                                            new[]{SizeInBytes, partitionDescription.SizeInBytes.ToString("N0")},
                                            new[]{LastEnqueuedOffset, partitionDescription.LastEnqueuedOffset ?? "Null"},
                                            new[]{LastEnqueuedTimeUtc, partitionDescription.LastEnqueuedTimeUtc.ToString(CultureInfo.InvariantCulture)},
                                            new[]{IncomingBytesPerSecond, partitionDescription.IncomingBytesPerSecond.ToString("N0")},
                                            new[]{OutgoingBytesPerSecond, partitionDescription.OutgoingBytesPerSecond.ToString("N0")},
                                            new[]{BeginSequenceNumber, partitionDescription.BeginSequenceNumber.ToString("N0")},
                                            new[]{EndSequenceNumber, partitionDescription.EndSequenceNumber.ToString("N0")}});

                propertyListView.Items.Clear();
                foreach (var array in propertyList)
                {
                    propertyListView.Items.Add(new ListViewItem(array));
                }

                propertyListView.ContextMenuStrip = partitionInformationContextMenuStrip;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (OnRefresh != null)
            {
                OnRefresh();
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
            {
                control.ForeColor = Color.White;
            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null)
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
        #endregion
    }
}
