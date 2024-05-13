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

using FastColoredTextBoxNS;
using Microsoft.ServiceBus.Messaging;
using ServiceBusExplorer.Enums;
using ServiceBusExplorer.Forms;
using ServiceBusExplorer.Helpers;
using ServiceBusExplorer.UIHelpers;
using ServiceBusExplorer.Utilities.Helpers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static ServiceBusExplorer.ServiceBusHelper;
using Cursor = System.Windows.Forms.Cursor;
#endregion

namespace ServiceBusExplorer.Controls
{
    public partial class TestTopicControl : UserControl
    {
        #region Private Constants
        //***************************
        // Properties & Types
        //***************************
        private const string PropertyKey = "Key";
        private const string PropertyType = "Type";
        private const string PropertyValue = "Value";
        private const string DefaultMessageCount = "1";
        private const string DefaulSendBatchSize = "10";
        private const string DefaulReceiveBatchSize = "10";
        private const string DefaultSenderTaskCount = "1";
        private const string DefaultReceiverTaskCount = "1";
        private const string PeekLock = "PeekLock";
        private const string StartCaption = "Start";
        private const string StopCaption = "Stop";
        private const string DefaultFilterExpression = "1=1";

        //***************************
        // Messages
        //***************************
        private const string ReceiveTimeoutCannotBeNull = "The receive timeout field cannot be null and must a non negative integer number.";
        private const string SessionTimeoutCannotBeNull = "The session timeout field cannot be null and must be a non negative integer number.";
        private const string PrefetchCountCannotBeNull = "The prefetch count field cannot be null and must be an integer number.";
        private const string MessageCountMustBeANumber = "The Message Count field must be an integer number greater or equal to zero.";
        private const string SendTaskCountMustBeANumber = "The Sender Task Count field must be an integer number greater than zero.";
        private const string ReceiveTaskCountMustBeANumber = "The Receiver Task Count field must be an integer number greater than zero.";
        private const string SenderBatchSizeMustBeANumber = "The Sender Batch Size field must be an integer number greater than zero.";
        private const string ReceiverBatchSizeMustBeANumber = "The Receiver Batch Size field must be an integer number greater than zero.";
        private const string SenderThinkTimeMustBeANumber = "The Sender Think Time field must be an integer number greater than zero.";
        private const string ReceiverThinkTimeMustBeANumber = "The Receiver Think Time field must be an integer number greater than zero.";
        private const string TransactionCommitted = " - Transaction committed.";
        private const string TransactionAborted = " - Transaction aborted.";
        private const string NoMoreSessionsToAccept = "Receiver[{0}]: No more sessions to accept.";
        private const string FilterExpressionIsNotValid = "The filter expression is not valid.";
        private const string NoSubscriptionSelected = "No subscription has been selected.";
        private const string NoMessageSelected = "No file to send has been selected under the Files tab.";
        private const string SelectBrokeredMessageGenerator = "Select a BrokeredMessage generator...";
        private const string InvalidJsonTemplate = "{0} is an invalid JSON template. The file will be used as text message rather than a template.";
        private const string InvalidXmlTemplate = "{0} is an invalid XML template. The file will be used as text message rather than a template.";
        private const string SelectBrokeredMessageInspector = "Select a BrokeredMessage inspector...";
        private const string SelectBrokeredMessageGeneratorWarning = "You have to select a BrokeredMessage generator under the Generator tab before sending messages to {0}.";

        //***************************
        // Tooltips
        //***************************
        private const string ContentTypeTooltip = "Gets or sets the type of the content.";
        private const string ToTooltip = "Gets or sends the send to address.";
        private const string ScheduledEnqueueTimeUtcTooltip = "Gets or sets the timeout in seconds after which the message will be enqueued.";
        private const string ReceiveModeTooltip = "Gets or sets the receive mode of message receivers.";
        private const string MessageTextTooltip = "Gets or sets the message text.";
        private const string SenderEnabledToolTip = "Enable or disable message senders.";
        private const string ReceiverEnabledToolTip = "Enable or disable message receivers.";
        private const string LabelTooltip = "Gets or sets the message label.";
        private const string MessageIdTooltip = "Gets or sets the message id.";
        private const string SessionIdTooltip = "Gets or sets the session id.";
        private const string CorrelationIdTooltip = "Gets or sets the correlation id.";
        private const string ReplyToTooltip = "Gets or sets the replyTo field.";
        private const string ReplyToSessionIdTooltip = "Gets or sets the replyToSessionId field.";
        private const string MessagePropertiesTooltip = "Gets or sets the properties of the message.";
        private const string MessageCountTooltip = "Gets or sets the number of messages to send.";
        private const string SendTaskCountTooltip = "Gets or sets the count of message senders.";
        private const string ReceiverTaskCountTooltip = "Gets or sets the count of message receivers.";
        private const string UpdateMessageIdTooltip = "Gets or sets a boolean value indicating whether the id of the message must be updated when sending multiple messages.";
        private const string ReceiveTimeoutTooltip = "Gets or sets the receive timeout.";
        private const string SessionTimeoutTooltip = "Gets or sets the session timeout.";
        private const string FilterExpressionTooltip = "Gets or sets the filter expression used to select messages to move to the dead-letter queue or to defer.";
        private const string SubscriptionTooltip = "Select the subscription used to receive messages.";
        private const string EnableSenderLoggingTooltip = "Enable logging of message content and properties for message senders.";
        private const string EnableReceiverLoggingTooltip = "Enable logging of message content and properties for message receivers.";
        private const string EnableSenderVerboseLoggingTooltip = "Enable verbose logging for message senders.";
        private const string EnableReceiverVerboseLoggingTooltip = "Enable verbose logging for message receivers.";
        private const string EnableSenderTransactionTooltip = "Enable transactional behavior for message senders.";
        private const string EnableReceiverTransactionTooltip = "Enable transactional behavior for message receivers.";
        private const string EnableSenderCommitTooltip = "Enable transaction commit for message senders.";
        private const string EnableReceiverCommitTooltip = "Enable transaction commit for message receivers.";
        private const string EnableMessageIdUpdateTooltip = "Enable automatic message id update.";
        private const string OneSessionPerSenderTaskTooltip = "Use one session per sender task.";
        private const string EnableMoveToDeadLetterTooltip = "When this option is enabled, all received messages are moved to the Dead-letter queue.";
        private const string EnableReadFromDeadLetterTooltip = "When this option is enabled, the receivers attempts to read messages from the Dead-letter queue.";
        private const string EnableCreateNewMessagingFactoryForSender = "Creating a new messaging factory for each sender task";
        private const string EnableCreateNewMessagingFactoryForReceiver = "Creating a new messaging factory for each receiver task";

        //***************************
        // Tab Pages
        //***************************
        private const int MessageTabPage = 0;
        private const int FilesTabPage = 1;
        private const int GeneratorTabPage = 2;

        //***************************
        // ListView Column Indexes
        //***************************
        private const int NameListViewColumnIndex = 0;
        private const int SizeListViewColumnIndex = 1;
        #endregion

        #region Private Instance Fields
        private readonly TopicDescription topic;
        private readonly List<SubscriptionDescription> subscriptionList;
        private readonly BindingSource bindingSource = new BindingSource();
        private int receiveTimeout = 60;
        private int sessionTimeout = 60;
        private int prefetchCount;
        private List<MessageSender> messageSenderCollection;
        private CancellationTokenSource senderCancellationTokenSource;
        private CancellationTokenSource receiverCancellationTokenSource;
        private CancellationTokenSource managerCancellationTokenSource;
        private CancellationTokenSource graphCancellationTokenSource;
        private ManualResetEventSlim managerResetEvent;
        private long messageCount = 1;
        private int senderBatchSize = 1;
        private int receiverBatchSize = 1;
        private int senderThinkTime;
        private int receiverThinkTime;
        private long senderMessageNumber;
        private double senderMessagesPerSecond;
        private double senderMinimumTime;
        private double senderMaximumTime;
        private double senderAverageTime;
        private double senderTotalTime;
        private long receiverMessageNumber;
        private double receiverMessagesPerSecond;
        private double receiverMinimumTime;
        private double receiverMaximumTime;
        private double receiverAverageTime;
        private double receiverTotalTime;
        private int actionCount;
        private long currentIndex;
        private int senderTaskCount = 1;
        private int receiverTaskCount = 1;
        private bool isSenderFaulted;
        private Filter filter;
        TestControlHelper controlHelper;
        private BlockingCollection<Tuple<long, long, DirectionType>> blockingCollection;
        private IBrokeredMessageGenerator brokeredMessageGenerator;
        private IBrokeredMessageInspector senderBrokeredMessageInspector;
        private IBrokeredMessageInspector receiverBrokeredMessageInspector;
        private readonly List<MessagingFactory> senderFactories = new List<MessagingFactory>();
        private readonly List<MessagingFactory> receiverFactories = new List<MessagingFactory>();
        #endregion

        #region Private Static Fields

        static readonly List<string> Types = new List<string>
        {
            "Boolean",
            "Byte",
            "Int16",
            "Int32",
            "Int64",
            "Single",
            "Double",
            "Decimal",
            "Guid",
            "DateTime",
            "String",
            "Char",
            "UInt64",
            "UInt32",
            "UInt16",
            "SByte"
        };
        #endregion

        #region Public Constructors
        public TestTopicControl(MainForm mainForm,
                                WriteToLogDelegate writeToLog,
                                Func<Task> stopLog,
                                Action startLog,
                                ServiceBusHelper serviceBusHelper,
                                TopicDescription topic,
                                List<SubscriptionDescription> subscriptionList)
        {
            controlHelper = new TestControlHelper(mainForm, writeToLog, stopLog, startLog, serviceBusHelper);
            this.topic = topic;
            this.subscriptionList = subscriptionList;
            InitializeComponent();
            InitializeControls();
        }
        #endregion

        #region Public Events
        public event Action OnCancel;
        #endregion

        #region Private Methods
        private void InitializeControls()
        {

            try
            {
                // Get Brokered Message Generator and Inspector classes
                cboSenderInspector.Items.Add(SelectBrokeredMessageInspector);
                cboSenderInspector.SelectedIndex = 0;
                cboReceiverInspector.Items.Add(SelectBrokeredMessageInspector);
                cboReceiverInspector.SelectedIndex = 0;
                cboBrokeredMessageGeneratorType.Items.Add(SelectBrokeredMessageGenerator);
                cboBrokeredMessageGeneratorType.SelectedIndex = 0;
                cboMessageFormat.Items.AddRange(new[] { "Text", "JSON", "XML" });
                cboMessageFormat.SelectedIndex = 0;

                if (controlHelper.ServiceBusHelper != null)
                {
                    if (controlHelper.ServiceBusHelper.BrokeredMessageInspectors != null)
                    {
                        foreach (var key in controlHelper.ServiceBusHelper.BrokeredMessageInspectors.Keys)
                        {
                            cboSenderInspector.Items.Add(key);
                            cboReceiverInspector.Items.Add(key);
                        }
                    }

                    if (controlHelper.ServiceBusHelper.BrokeredMessageGenerators != null)
                    {
                        foreach (var key in controlHelper.ServiceBusHelper.BrokeredMessageGenerators.Keys)
                        {
                            cboBrokeredMessageGeneratorType.Items.Add(key);
                        }
                    }
                }

                // Populate filenames listview control
                if (controlHelper.MainForm.FileNames.Any())
                {
                    foreach (var tuple in controlHelper.MainForm.FileNames)
                    {
                        messageFileListView.Items.Add(new ListViewItem(new[]
                                                        {
                                                            tuple.Item1,
                                                            tuple.Item2
                                                        }));
                    }
                    btnClearFiles.Enabled = messageFileListView.Items.Count > 0;
                }

                // Set Think Time
                txtSenderThinkTime.Text = controlHelper.MainForm.SenderThinkTime.ToString(CultureInfo.InvariantCulture);
                txtReceiverThinkTime.Text = controlHelper.MainForm.ReceiverThinkTime.ToString(CultureInfo.InvariantCulture);
                senderThinkTime = controlHelper.MainForm.SenderThinkTime;
                receiverThinkTime = controlHelper.MainForm.ReceiverThinkTime;

                // Set Binding Source
                bindingSource.DataSource = MessagePropertyInfo.Properties;

                // Initialize body type combo
                cboBodyType.SelectedIndex = (int)MainForm.SingletonMainForm.MessageBodyType;

                // Initialize the DataGridView.
                propertiesDataGridView.AutoGenerateColumns = false;
                propertiesDataGridView.AutoSize = true;
                propertiesDataGridView.DataSource = bindingSource;
                propertiesDataGridView.ForeColor = SystemColors.WindowText;

                // Create the Name column
                var textBoxColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = PropertyKey,
                    Name = PropertyKey,
                    Width = 138
                };
                propertiesDataGridView.Columns.Add(textBoxColumn);

                // Create the Type column
                var comboBoxColumn = new DataGridViewComboBoxColumn
                {
                    DataSource = Types,
                    DataPropertyName = PropertyType,
                    Name = PropertyType,
                    Width = 90,
                    FlatStyle = FlatStyle.Flat
                };
                propertiesDataGridView.Columns.Add(comboBoxColumn);

                // Create the Value column
                textBoxColumn = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = PropertyValue,
                    Name = PropertyValue,
                    Width = 138
                };
                propertiesDataGridView.Columns.Add(textBoxColumn);

                // Set Grid style
                propertiesDataGridView.EnableHeadersVisualStyles = false;

                // Set the selection background color for all the cells.
                propertiesDataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(92, 125, 150);
                propertiesDataGridView.DefaultCellStyle.SelectionForeColor = SystemColors.Window;

                // Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default 
                // value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
                propertiesDataGridView.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(153, 180, 209);

                // Set the background color for all rows and for alternating rows.  
                // The value for alternating rows overrides the value for all rows. 
                propertiesDataGridView.RowsDefaultCellStyle.BackColor = SystemColors.Window;
                propertiesDataGridView.RowsDefaultCellStyle.ForeColor = SystemColors.ControlText;

                // Set the row and column header styles.
                propertiesDataGridView.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
                propertiesDataGridView.RowHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;
                propertiesDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(215, 228, 242);
                propertiesDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlText;

                controlHelper.IsReadyToStoreMessageText = true;

                LanguageDetector.SetFormattedMessage(controlHelper.ServiceBusHelper,
                                                     controlHelper.MainForm.MessageText ?? string.Empty,
                                                     txtMessageText);

                txtLabel.Text = controlHelper.MainForm.Label ?? string.Empty;
                txtMessageId.Text = Guid.NewGuid().ToString();
                checkBoxOneSessionPerTask.Checked = false;
                txtMessageCount.Text = DefaultMessageCount;
                txtSendBatchSize.Text = DefaulSendBatchSize;
                txtReceiveBatchSize.Text = DefaulReceiveBatchSize;
                txtSendTaskCount.Text = DefaultSenderTaskCount;
                txtReceiveTaskCount.Text = DefaultReceiverTaskCount;
                txtContentType.Text = controlHelper.MainForm.MessageContentType;
                txtReceiveTimeout.Text = controlHelper.MainForm?.ReceiveTimeout.ToString(CultureInfo.InvariantCulture);
                txtServerTimeout.Text = controlHelper.MainForm?.ServerTimeout.ToString(CultureInfo.InvariantCulture);
                txtPrefetchCount.Text = controlHelper.MainForm?.PrefetchCount.ToString(CultureInfo.InvariantCulture);
                if (subscriptionList != null &&
                    subscriptionList.Count > 0)
                {
                    // ReSharper disable CoVariantArrayConversion
                    cboSubscriptions.Items.AddRange(subscriptionList.Select(s => s.Name).ToArray());
                    // ReSharper restore CoVariantArrayConversion
                    if (cboSubscriptions.Items.Count > 0)
                    {
                        cboSubscriptions.SelectedIndex = 0;
                    }
                }
                cboReceivedMode.SelectedIndex = 1;
                txtSendBatchSize.Enabled = false;
                txtReceiveBatchSize.Enabled = false;

                // Create Tooltips for controls
                toolTip.SetToolTip(senderEnabledCheckBox, SenderEnabledToolTip);
                toolTip.SetToolTip(receiverEnabledCheckBox, ReceiverEnabledToolTip);
                toolTip.SetToolTip(txtMessageText, MessageTextTooltip);
                toolTip.SetToolTip(propertiesDataGridView, MessagePropertiesTooltip);
                toolTip.SetToolTip(txtLabel, LabelTooltip);
                toolTip.SetToolTip(txtMessageId, MessageIdTooltip);
                toolTip.SetToolTip(txtSessionId, SessionIdTooltip);
                toolTip.SetToolTip(txtCorrelationId, CorrelationIdTooltip);
                toolTip.SetToolTip(txtReplyTo, ReplyToTooltip);
                toolTip.SetToolTip(txtReplyToSessionId, ReplyToSessionIdTooltip);
                toolTip.SetToolTip(txtMessageCount, MessageCountTooltip);
                toolTip.SetToolTip(txtSendTaskCount, SendTaskCountTooltip);
                toolTip.SetToolTip(txtReceiveTaskCount, ReceiverTaskCountTooltip);
                toolTip.SetToolTip(checkBoxUpdateMessageId, UpdateMessageIdTooltip);
                toolTip.SetToolTip(txtReceiveTimeout, ReceiveTimeoutTooltip);
                toolTip.SetToolTip(txtServerTimeout, SessionTimeoutTooltip);
                toolTip.SetToolTip(txtFilterExpression, FilterExpressionTooltip);
                toolTip.SetToolTip(txtTo, ToTooltip);
                toolTip.SetToolTip(txtContentType, ContentTypeTooltip);
                toolTip.SetToolTip(txtScheduledEnqueueTimeUtc, ScheduledEnqueueTimeUtcTooltip);
                toolTip.SetToolTip(cboSubscriptions, SubscriptionTooltip);
                toolTip.SetToolTip(checkBoxEnableSenderLogging, EnableSenderLoggingTooltip);
                toolTip.SetToolTip(checkBoxEnableReceiverLogging, EnableReceiverLoggingTooltip);
                toolTip.SetToolTip(checkBoxSenderVerboseLogging, EnableSenderVerboseLoggingTooltip);
                toolTip.SetToolTip(checkBoxReceiverVerboseLogging, EnableReceiverVerboseLoggingTooltip);
                toolTip.SetToolTip(checkBoxOneSessionPerTask, OneSessionPerSenderTaskTooltip);
                toolTip.SetToolTip(checkBoxSenderUseTransaction, EnableSenderTransactionTooltip);
                toolTip.SetToolTip(checkBoxReceiverUseTransaction, EnableReceiverTransactionTooltip);
                toolTip.SetToolTip(checkBoxSenderCommitTransaction, EnableSenderCommitTooltip);
                toolTip.SetToolTip(checkBoxReceiverCommitTransaction, EnableReceiverCommitTooltip);
                toolTip.SetToolTip(checkBoxUpdateMessageId, EnableMessageIdUpdateTooltip);
                toolTip.SetToolTip(checkBoxMoveToDeadLetter, EnableMoveToDeadLetterTooltip);
                toolTip.SetToolTip(checkBoxReadFromDeadLetter, EnableReadFromDeadLetterTooltip);
                toolTip.SetToolTip(cboReceivedMode, ReceiveModeTooltip);
                toolTip.SetToolTip(checkBoxSendNewFactory, EnableCreateNewMessagingFactoryForSender);
                toolTip.SetToolTip(checkBoxReceiveNewFactory, EnableCreateNewMessagingFactoryForReceiver);

                splitContainer.SplitterWidth = 16;
                splitContainer.SplitterDistance = (splitContainer.Size.Width - splitContainer.SplitterWidth) / 2;
                propertiesDataGridView.Size = txtMessageText.Size;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private bool ValidateParameters()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtReceiveTimeout.Text) ||
                    !int.TryParse(txtReceiveTimeout.Text, out var temp) ||
                    temp < 0)
                {
                    controlHelper.WriteToLog(ReceiveTimeoutCannotBeNull);
                    return false;
                }
                receiveTimeout = temp;
                if (string.IsNullOrWhiteSpace(txtServerTimeout.Text) ||
                    !int.TryParse(txtServerTimeout.Text, out temp) ||
                    temp < 0)
                {
                    controlHelper.WriteToLog(SessionTimeoutCannotBeNull);
                    return false;
                }
                sessionTimeout = temp;
                if (string.IsNullOrWhiteSpace(txtPrefetchCount.Text) ||
                    !int.TryParse(txtPrefetchCount.Text, out temp))
                {
                    controlHelper.WriteToLog(PrefetchCountCannotBeNull);
                    return false;
                }
                prefetchCount = temp;
                if (!int.TryParse(txtMessageCount.Text, out temp) || temp < 0)
                {
                    controlHelper.WriteToLog(MessageCountMustBeANumber);
                    return false;
                }
                messageCount = temp;
                if (!int.TryParse(txtSendBatchSize.Text, out temp) || temp <= 0)
                {
                    controlHelper.WriteToLog(SenderBatchSizeMustBeANumber);
                    return false;
                }
                senderBatchSize = temp;
                if (!int.TryParse(txtReceiveBatchSize.Text, out temp) || temp <= 0)
                {
                    controlHelper.WriteToLog(ReceiverBatchSizeMustBeANumber);
                    return false;
                }
                receiverBatchSize = temp;
                if (!int.TryParse(txtSenderThinkTime.Text, out temp) || temp <= 0)
                {
                    controlHelper.WriteToLog(SenderThinkTimeMustBeANumber);
                    return false;
                }
                senderThinkTime = temp;
                if (!int.TryParse(txtReceiverThinkTime.Text, out temp) || temp <= 0)
                {
                    controlHelper.WriteToLog(ReceiverThinkTimeMustBeANumber);
                    return false;
                }
                receiverThinkTime = temp;
                if (!int.TryParse(txtSendTaskCount.Text, out temp) || temp <= 0)
                {
                    controlHelper.WriteToLog(SendTaskCountMustBeANumber);
                    return false;
                }
                senderTaskCount = temp;
                if (!int.TryParse(txtReceiveTaskCount.Text, out temp) || temp <= 0)
                {
                    controlHelper.WriteToLog(ReceiveTaskCountMustBeANumber);
                    return false;
                }
                receiverTaskCount = temp;
                var sqlFilter = new SqlFilter(!string.IsNullOrWhiteSpace(txtFilterExpression.Text)
                                                                  ? txtFilterExpression.Text
                                                                  : DefaultFilterExpression);
                sqlFilter.Validate();
                filter = sqlFilter.Preprocess();
                if (filter == null)
                {
                    controlHelper.WriteToLog(FilterExpressionIsNotValid);
                }
                if (messageTabControl.SelectedIndex == FilesTabPage)
                {
                    var fileList = messageFileListView.Items.Cast<ListViewItem>()
                                .Where(i => i.Checked)
                                .Select(i => i.Text)
                                .ToList();
                    if (fileList.Count == 0)
                    {
                        controlHelper.WriteToLog(NoMessageSelected);
                        return false;
                    }
                }
                if (messageTabControl.SelectedIndex == GeneratorTabPage && cboBrokeredMessageGeneratorType.SelectedIndex < 1)
                {
                    controlHelper.WriteToLog(string.Format(SelectBrokeredMessageGeneratorWarning, topic.Path));
                    return false;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
                return false;
            }
            return true;
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnStart.Text == StopCaption)
                {
                    await CancelActions();
                    btnStart.Text = StartCaption;
                    return;
                }

                if (controlHelper.ServiceBusHelper == null || !ValidateParameters())
                {
                    return;
                }

                controlHelper.StartLog?.Invoke();
                btnStart.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;

                //*****************************************************************************************************
                //                                   Initialize Statistics and Manager Action
                //*****************************************************************************************************
                actionCount = 0;
                senderMessageNumber = 0;
                senderMessagesPerSecond = 0;
                senderMinimumTime = long.MaxValue;
                senderMaximumTime = 0;
                senderAverageTime = 0;
                senderTotalTime = 0;
                receiverMessageNumber = 0;
                receiverMessagesPerSecond = 0;
                receiverMinimumTime = long.MaxValue;
                receiverMaximumTime = 0;
                receiverAverageTime = 0;
                receiverTotalTime = 0;
                if (checkBoxSenderEnableGraph.Checked ||
                    checkBoxReceiverEnableGraph.Checked)
                {
                    chart.Series.ToList().ForEach(s => s.Points.Clear());
                }
                managerResetEvent = new ManualResetEventSlim(false);
                Action<CancellationTokenSource> managerAction = cts =>
                {
                    if (cts == null)
                    {
                        return;
                    }
                    try
                    {
                        managerResetEvent.Wait(cts.Token);
                    }
                    catch (OperationCanceledException)
                    {
                    }
                    if (!cts.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)async delegate
                        {
                            btnStart.Text = StartCaption;
                            await MainForm.SingletonMainForm.RefreshSelectedEntity();
                        });
                    }
                };

                Action updateGraphAction = () =>
                {
                    var ok = true;
                    long max = 10;
                    while (!graphCancellationTokenSource.IsCancellationRequested && (actionCount > 1 || ok))
                    {
                        ok = true;
                        long sendMessageNumber = 0;
                        long receiveMessageNumber = 0;
                        long sendTotalTime = 0;
                        long receiveTotalTime = 0;
                        while (ok && sendMessageNumber < max && receiveMessageNumber < max)
                        {
                            ok = blockingCollection.TryTake(out var tuple, 10);
                            if (ok)
                            {
                                if (tuple.Item3 == DirectionType.Send)
                                {
                                    sendMessageNumber += tuple.Item1;
                                    sendTotalTime += tuple.Item2;
                                    if (sendMessageNumber > max)
                                    {
                                        max = sendMessageNumber;
                                    }
                                    continue;
                                }
                                receiveMessageNumber += tuple.Item1;
                                receiveTotalTime += tuple.Item2;
                                if (receiveMessageNumber > max)
                                {
                                    max = receiveMessageNumber;
                                }
                            }
                        }
                        if (sendMessageNumber > 0)
                        {
                            var sendTuple = new Tuple<long, long, DirectionType>(sendMessageNumber, sendTotalTime, DirectionType.Send);
                            if (InvokeRequired)
                            {
                                Invoke(new UpdateStatisticsDelegate(InternalUpdateStatistics), sendTuple.Item1, sendTuple.Item2, sendTuple.Item3);
                            }
                            else
                            {
                                InternalUpdateStatistics(sendTuple.Item1,
                                    sendTuple.Item2,
                                    sendTuple.Item3);
                            }
                        }
                        if (receiveMessageNumber > 0)
                        {
                            var receiveTuple = new Tuple<long, long, DirectionType>(receiveMessageNumber, receiveTotalTime, DirectionType.Receive);
                            if (InvokeRequired)
                            {
                                Invoke(new UpdateStatisticsDelegate(InternalUpdateStatistics), receiveTuple.Item1, receiveTuple.Item2, receiveTuple.Item3);
                            }
                            else
                            {
                                InternalUpdateStatistics(receiveTuple.Item1,
                                    receiveTuple.Item2,
                                    receiveTuple.Item3);
                            }
                        }
                    }
                    if (Interlocked.Decrement(ref actionCount) == 0)
                    {
                        managerResetEvent.Set();
                    }
                };

                AsyncCallback updateGraphCallback = a =>
                {
                    var action = a.AsyncState as Action;
                    if (action != null)
                    {
                        action.EndInvoke(a);
                        if (Interlocked.Decrement(ref actionCount) == 0)
                        {
                            managerResetEvent.Set();
                        }
                    }
                };

                blockingCollection = new BlockingCollection<Tuple<long, long, DirectionType>>();
                //*****************************************************************************************************
                //                                   Sending messages to a Topic
                //*****************************************************************************************************

                if (senderEnabledCheckBox.Checked && messageCount > 0)
                {
                    // Create message senders. They are cached for later usage to improve performance.
                    if (isSenderFaulted ||
                        messageSenderCollection == null ||
                        messageSenderCollection.Count == 0 ||
                        messageSenderCollection.Count < senderTaskCount ||
                        checkBoxSendNewFactory.Checked)
                    {
                        messageSenderCollection = new List<MessageSender>(senderTaskCount);
                        for (var i = 0; i < senderTaskCount; i++)
                        {
                            if (checkBoxSendNewFactory.Checked)
                            {
                                var factory = controlHelper.ServiceBusHelper.CreateMessagingFactory();
                                senderFactories.Add(factory);
                                messageSenderCollection.Add(factory.CreateMessageSender(topic.Path));
                            }
                            else
                            {
                                messageSenderCollection.Add(controlHelper.ServiceBusHelper.MessagingFactory.CreateMessageSender(topic.Path));
                            }
                        }
                        isSenderFaulted = false;
                    }

                    // Get Body Type
                    if (!Enum.TryParse(cboBodyType.Text, true, out BodyType bodyType))
                    {
                        bodyType = BodyType.Stream;
                    }
                    var isBinary = false;
                    // Create outbound message template list
                    var messageTemplateList = new List<BrokeredMessage>();
                    var messageTextList = new List<string>();
                    var partitionKey = checkBoxSenderUseTransaction.Checked ? Guid.NewGuid().ToString() : null;
                    if (messageTabControl.SelectedIndex == MessageTabPage)
                    {
                        messageTemplateList.Add(controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(txtMessageText.Text,
                            txtLabel.Text,
                            txtContentType.Text,
                            GetMessageId(),
                            txtSessionId.Text,
                            txtCorrelationId.Text,
                            partitionKey,
                            txtTo.Text,
                            txtReplyTo.Text,
                            txtReplyToSessionId.Text,
                            txtTimeToLive.Text,
                            txtScheduledEnqueueTimeUtc.Text,
                            checkBoxForcePersistence.Checked,
                            bindingSource.Cast<MessagePropertyInfo>()));
                        messageTextList.Add(txtMessageText.Text);
                    }
                    else if (messageTabControl.SelectedIndex == FilesTabPage)
                    {
                        var fileList = messageFileListView.Items.Cast<ListViewItem>()
                            .Where(i => i.Checked)
                            .Select(i => i.Text)
                            .ToList();
                        if (fileList.Count == 0)
                        {
                            controlHelper.WriteToLog(NoMessageSelected);
                            return;
                        }
                        foreach (var fileName in fileList)
                        {
                            try
                            {
                                BrokeredMessage template;
                                if (radioButtonBinaryFile.Checked)
                                {
                                    using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                                    {
                                        using (var binaryReader = new BinaryReader(fileStream))
                                        {
                                            var bytes = binaryReader.ReadBytes((int)fileStream.Length);
                                            template = controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(new MemoryStream(bytes),
                                                txtLabel.Text,
                                                txtContentType.Text,
                                                GetMessageId(),
                                                txtSessionId.Text,
                                                txtCorrelationId.Text,
                                                partitionKey,
                                                txtTo.Text,
                                                txtReplyTo.Text,
                                                txtReplyToSessionId.Text,
                                                txtTimeToLive.Text,
                                                txtScheduledEnqueueTimeUtc.Text,
                                                bindingSource.Cast<MessagePropertyInfo>());
                                            messageTextList.Add(BitConverter.ToString(bytes).Replace('-', ' '));
                                            bodyType = BodyType.Stream;
                                            isBinary = true;
                                        }
                                    }
                                }
                                else
                                {
                                    using (var streamReader = new StreamReader(fileName))
                                    {
                                        var text = await streamReader.ReadToEndAsync();
                                        if (radioButtonTextFile.Checked)
                                        {
                                            template = controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(text,
                                                txtLabel.Text,
                                                txtContentType.Text,
                                                GetMessageId(),
                                                txtSessionId.Text,
                                                txtCorrelationId.Text,
                                                partitionKey,
                                                txtTo.Text,
                                                txtReplyTo.Text,
                                                txtReplyToSessionId.Text,
                                                txtTimeToLive.Text,
                                                txtScheduledEnqueueTimeUtc.Text,
                                                checkBoxForcePersistence.Checked,
                                                bindingSource.Cast<MessagePropertyInfo>());
                                            messageTextList.Add(text);
                                        }
                                        else if (radioButtonJsonTemplate.Checked)
                                        {
                                            try
                                            {
                                                // Multiple messages
                                                if (text.StartsWith("[", StringComparison.OrdinalIgnoreCase))
                                                {
                                                    var brokeredMessageTemplates = JsonSerializerHelper.Deserialize<List<BrokeredMessageTemplate>>(text);
                                                    foreach (var item in brokeredMessageTemplates)
                                                    {
                                                        template = controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(item);
                                                        messageTemplateList.Add(template);
                                                        messageTextList.Add(item.Message);
                                                    }

                                                    messageCount = messageTemplateList.Count; // change the default of 1 message

                                                    template = null; // clear template to avoid adding it again at the end of the method
                                                }
                                                else // single message
                                                {
                                                    var brokeredMessageTemplate = JsonSerializerHelper.Deserialize<BrokeredMessageTemplate>(text);
                                                    template = controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(brokeredMessageTemplate);
                                                    messageTextList.Add(brokeredMessageTemplate.Message);
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                controlHelper.WriteToLog(string.Format(InvalidJsonTemplate, fileName));
                                                template = controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(text,
                                                    txtLabel.Text,
                                                    txtContentType.Text,
                                                    GetMessageId(),
                                                    txtSessionId.Text,
                                                    txtCorrelationId.Text,
                                                    partitionKey,
                                                    txtTo.Text,
                                                    txtReplyTo.Text,
                                                    txtReplyToSessionId.Text,
                                                    txtTimeToLive.Text,
                                                    txtScheduledEnqueueTimeUtc.Text,
                                                    checkBoxForcePersistence.Checked,
                                                    bindingSource.Cast<MessagePropertyInfo>());
                                                messageTextList.Add(text);
                                            }
                                        }
                                        else // XML Template
                                        {
                                            try
                                            {
                                                var brokeredMessageTemplate = XmlSerializerHelper.Deserialize<BrokeredMessageTemplate>(text);
                                                template = controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(brokeredMessageTemplate);
                                                messageTextList.Add(brokeredMessageTemplate.Message);
                                            }
                                            catch (Exception)
                                            {
                                                controlHelper.WriteToLog(string.Format(InvalidXmlTemplate, fileName));
                                                template = controlHelper.ServiceBusHelper.CreateBrokeredMessageTemplate(text,
                                                    txtLabel.Text,
                                                    txtContentType.Text,
                                                    GetMessageId(),
                                                    txtSessionId.Text,
                                                    txtCorrelationId.Text,
                                                    partitionKey,
                                                    txtTo.Text,
                                                    txtReplyTo.Text,
                                                    txtReplyToSessionId.Text,
                                                    txtTimeToLive.Text,
                                                    txtScheduledEnqueueTimeUtc.Text,
                                                    checkBoxForcePersistence.Checked,
                                                    bindingSource.Cast<MessagePropertyInfo>());
                                                messageTextList.Add(text);
                                            }
                                        }
                                    }
                                }
                                if (template != null)
                                {
                                    messageTemplateList.Add(template);
                                }
                            }
                            catch (Exception ex)
                            {
                                HandleException(ex);
                            }
                        }
                    }
                    else // Brokered Message Generator Tab
                    {
                        try
                        {
                            brokeredMessageGenerator = brokeredMessageGeneratorPropertyGrid.SelectedObject as IBrokeredMessageGenerator;
                            if (brokeredMessageGenerator != null)
                            {
                                messageTemplateList = new List<BrokeredMessage>(brokeredMessageGenerator.GenerateBrokeredMessageCollection(txtMessageCount.IntegerValue, controlHelper.WriteToLog));
                            }
                        }
                        catch (Exception ex)
                        {
                            HandleException(ex);
                        }
                    }
                    try
                    {
                        senderCancellationTokenSource = new CancellationTokenSource();
                        currentIndex = 0;
                        senderBrokeredMessageInspector = cboSenderInspector.SelectedIndex > 0
                            ? Activator.CreateInstance(controlHelper.ServiceBusHelper.BrokeredMessageInspectors[cboSenderInspector.Text]) as IBrokeredMessageInspector
                            : null;

                        Func<long> getMessageNumber = () =>
                        {
                            lock (this)
                            {
                                return currentIndex++;
                            }
                        };
                        Action<int, IEnumerable<BrokeredMessage>, IEnumerable<String>> senderAction = (taskId, messageTemplateEnumerable, messageTextEnumerable) =>
                        {
                            try
                            {
                                string traceMessage;
                                bool ok;

                                if (checkBoxSenderUseTransaction.Checked)
                                {
                                    using (var scope = new TransactionScope())
                                    {
                                        ok = controlHelper.ServiceBusHelper.SendMessages(messageSenderCollection[taskId],
                                            messageTemplateEnumerable,
                                            getMessageNumber,
                                            messageCount,
                                            taskId,
                                            checkBoxUpdateMessageId.Checked,
                                            checkBoxAddMessageNumber.Checked,
                                            checkBoxOneSessionPerTask.Checked,
                                            checkBoxEnableSenderLogging.Checked,
                                            checkBoxSenderVerboseLogging.Checked,
                                            checkBoxSenderEnableStatistics.Checked,
                                            checkBoxSendBatch.Checked,
                                            isBinary,
                                            senderBatchSize,
                                            checkBoxSenderThinkTime.Checked,
                                            senderThinkTime,
                                            bodyType,
                                            senderBrokeredMessageInspector,
                                            UpdateStatistics,
                                            senderCancellationTokenSource,
                                            out traceMessage);
                                        var builder = new StringBuilder(traceMessage);
                                        if (checkBoxSenderCommitTransaction.Checked)
                                        {
                                            scope.Complete();
                                            builder.AppendLine(TransactionCommitted);
                                        }
                                        else
                                        {
                                            builder.AppendLine(TransactionAborted);
                                        }
                                        traceMessage = builder.ToString();
                                    }
                                }
                                else
                                {
                                    ok = controlHelper.ServiceBusHelper.SendMessages(messageSenderCollection[taskId],
                                        messageTemplateEnumerable,
                                        getMessageNumber,
                                        messageCount,
                                        taskId,
                                        checkBoxUpdateMessageId.Checked,
                                        checkBoxAddMessageNumber.Checked,
                                        checkBoxOneSessionPerTask.Checked,
                                        checkBoxEnableSenderLogging.Checked,
                                        checkBoxSenderVerboseLogging.Checked,
                                        checkBoxSenderEnableStatistics.Checked,
                                        checkBoxSendBatch.Checked,
                                        isBinary,
                                        senderBatchSize,
                                        checkBoxSenderThinkTime.Checked,
                                        senderThinkTime,
                                        bodyType,
                                        senderBrokeredMessageInspector,
                                        UpdateStatistics,
                                        senderCancellationTokenSource,
                                        out traceMessage);
                                }
                                if (!string.IsNullOrWhiteSpace(traceMessage))
                                {
                                    controlHelper.WriteToLog(traceMessage.Substring(0,
                                        traceMessage.
                                            Length - 1));
                                }
                                isSenderFaulted = !ok;
                            }
                            catch (Exception ex)
                            {
                                isSenderFaulted = true;
                                HandleException(ex);
                            }
                        };

                        // Define Sender AsyncCallback
                        AsyncCallback senderCallback = a =>
                        {
                            var action = a.AsyncState as Action<int, IEnumerable<BrokeredMessage>, IEnumerable<String>>;
                            if (action != null)
                            {
                                action.EndInvoke(a);
                                if (Interlocked.Decrement(ref actionCount) == 0)
                                {
                                    managerResetEvent.Set();
                                }
                            }
                        };

                        // Start Sender Actions
                        for (var i = 0; i < Math.Min(messageCount, senderTaskCount); i++)
                        {
                            senderAction.BeginInvoke(i, messageTemplateList, messageTextList, senderCallback, senderAction);
                            Interlocked.Increment(ref actionCount);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }

                //*****************************************************************************************************
                //                                   Receiving messages from a Subscription
                //*****************************************************************************************************
                if (receiverEnabledCheckBox.Checked)
                {
                    var currentSubscription = subscriptionList.SingleOrDefault(s => s.Name == cboSubscriptions.Text);
                    if (currentSubscription == null)
                    {
                        throw new ArgumentException(NoSubscriptionSelected);
                    }
                    var currentReceiveMode = cboReceivedMode.Text == PeekLock ?
                        ReceiveMode.PeekLock :
                        ReceiveMode.ReceiveAndDelete;
                    var currentMoveToDeadLetterQueue = checkBoxMoveToDeadLetter.Checked;
                    var currentReadFromDeadLetterQueue = checkBoxReadFromDeadLetter.Checked;

                    try
                    {
                        receiverCancellationTokenSource = new CancellationTokenSource();
                        receiverBrokeredMessageInspector = cboReceiverInspector.SelectedIndex > 0
                            ? Activator.CreateInstance(controlHelper.ServiceBusHelper.BrokeredMessageInspectors[cboReceiverInspector.Text]) as IBrokeredMessageInspector
                            : null;

                        Action<int, MessagingFactory> receiverAction = (taskId, messagingFactory) =>
                        {
                            var allSessionsAccepted = false;

                            while (!allSessionsAccepted)
                            {
                                try
                                {
                                    MessageReceiver messageReceiver;
                                    if (currentReadFromDeadLetterQueue)
                                    {
                                        messageReceiver =
                                            messagingFactory.CreateMessageReceiver(SubscriptionClient.FormatDeadLetterPath(currentSubscription.TopicPath,
                                                    currentSubscription.Name),
                                                currentReceiveMode);
                                    }
                                    else
                                    {
                                        if (currentSubscription.RequiresSession)
                                        {
                                            var subscriptionClient = messagingFactory.CreateSubscriptionClient(currentSubscription.TopicPath,
                                                currentSubscription.Name,
                                                currentReceiveMode);
                                            messageReceiver = subscriptionClient.AcceptMessageSession(TimeSpan.FromSeconds(sessionTimeout));
                                        }
                                        else
                                        {
                                            messageReceiver = messagingFactory.CreateMessageReceiver(SubscriptionClient.FormatSubscriptionPath(currentSubscription.TopicPath,
                                                    currentSubscription.Name),
                                                currentReceiveMode);
                                        }
                                    }
                                    messageReceiver.PrefetchCount = prefetchCount;
                                    string traceMessage;
                                    if (checkBoxReceiverUseTransaction.Checked)
                                    {
                                        using (var scope = new TransactionScope())
                                        {
                                            controlHelper.ServiceBusHelper.ReceiveMessages(messageReceiver,
                                                taskId,
                                                receiveTimeout,
                                                filter,
                                                currentMoveToDeadLetterQueue,
                                                checkBoxCompleteReceive.Checked,
                                                checkBoxDeferMessage.Checked,
                                                checkBoxEnableReceiverLogging.Checked,
                                                checkBoxReceiverVerboseLogging.Checked,
                                                checkBoxReceiverEnableStatistics.Checked,
                                                checkBoxReceiveBatch.Checked,
                                                receiverBatchSize,
                                                checkBoxReceiverThinkTime.Checked,
                                                receiverThinkTime,
                                                receiverBrokeredMessageInspector,
                                                UpdateStatistics,
                                                receiverCancellationTokenSource,
                                                out traceMessage);
                                            var builder = new StringBuilder(traceMessage);
                                            if (checkBoxReceiverCommitTransaction.Checked)
                                            {
                                                scope.Complete();
                                                builder.AppendLine(TransactionCommitted);
                                            }
                                            else
                                            {
                                                builder.AppendLine(TransactionAborted);
                                            }
                                            traceMessage = builder.ToString();
                                        }
                                    }
                                    else
                                    {
                                        controlHelper.ServiceBusHelper.ReceiveMessages(messageReceiver,
                                            taskId,
                                            receiveTimeout,
                                            filter,
                                            currentMoveToDeadLetterQueue,
                                            checkBoxCompleteReceive.Checked,
                                            checkBoxDeferMessage.Checked,
                                            checkBoxEnableReceiverLogging.Checked,
                                            checkBoxReceiverVerboseLogging.Checked,
                                            checkBoxReceiverEnableStatistics.Checked,
                                            checkBoxReceiveBatch.Checked,
                                            receiverBatchSize,
                                            checkBoxReceiverThinkTime.Checked,
                                            receiverThinkTime,
                                            receiverBrokeredMessageInspector,
                                            UpdateStatistics,
                                            receiverCancellationTokenSource,
                                            out traceMessage);
                                    }
                                    if (!string.IsNullOrWhiteSpace(traceMessage))
                                    {
                                        controlHelper.WriteToLog(traceMessage.Substring(0, traceMessage.Length - 1));
                                    }
                                    allSessionsAccepted = !currentSubscription.RequiresSession;
                                }
                                catch (TimeoutException ex)
                                {
                                    if (currentSubscription.RequiresSession)
                                    {
                                        controlHelper.WriteToLog(string.Format(NoMoreSessionsToAccept, taskId));
                                        allSessionsAccepted = true;
                                    }
                                    else
                                    {
                                        HandleException(ex);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    HandleException(ex);
                                }
                            }
                        };

                        // Define Receiver AsyncCallback
                        AsyncCallback receiverCallback = a =>
                        {
                            var action = a.AsyncState as Action<int, MessagingFactory>;
                            if (action != null)
                            {
                                action.EndInvoke(a);
                                if (Interlocked.Decrement(ref actionCount) == 0)
                                {
                                    managerResetEvent.Set();
                                }
                            }
                        };

                        // Start Receiver Actions
                        for (var i = 0; i < receiverTaskCount; i++)
                        {
                            MessagingFactory factory;
                            if (checkBoxReceiveNewFactory.Checked)
                            {
                                factory = controlHelper.ServiceBusHelper.CreateMessagingFactory();
                                receiverFactories.Add(factory);
                            }
                            else
                            {
                                factory = controlHelper.ServiceBusHelper.MessagingFactory;
                            }

                            receiverAction.BeginInvoke(i, factory, receiverCallback, receiverAction);
                            Interlocked.Increment(ref actionCount);
                        }
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
                if (actionCount > 0)
                {
                    managerCancellationTokenSource = new CancellationTokenSource();
                    managerAction.BeginInvoke(managerCancellationTokenSource, null, null);
                    graphCancellationTokenSource = new CancellationTokenSource();
                    updateGraphAction.BeginInvoke(updateGraphCallback, updateGraphAction);
                    Interlocked.Increment(ref actionCount);
                    btnStart.Text = StopCaption;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            finally
            {
                btnStart.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }

        private void HandleException(Exception ex)
        {
            if (string.IsNullOrWhiteSpace(ex?.Message))
            {
                return;
            }
            controlHelper.WriteToLog(string.Format(CultureInfo.CurrentCulture, TestControlHelper.ExceptionFormat, ex.Message));
            if (!string.IsNullOrWhiteSpace(ex.InnerException?.Message))
            {
                controlHelper.WriteToLog(string.Format(CultureInfo.CurrentCulture, TestControlHelper.InnerExceptionFormat, ex.InnerException.Message));
            }
        }

        private string GetMessageId()
        {
            if (checkBoxUpdateMessageId.Checked)
            {
                return Guid.NewGuid().ToString();
            }
            if (!string.IsNullOrWhiteSpace(txtMessageId.Text))
            {
                return txtMessageId.Text;
            }
            return Guid.NewGuid().ToString();
        }

        internal async Task CancelActions()
        {
            if (controlHelper.StopLog != null)
            {
                await controlHelper.StopLog();
            }
            managerCancellationTokenSource?.Cancel();
            graphCancellationTokenSource?.Cancel();
            senderCancellationTokenSource?.Cancel();
            receiverCancellationTokenSource?.Cancel();

            // always cleans up the factories
            // clean up factories if the checkbox is checked.
            if (senderFactories != null && senderFactories.Count > 0)
            {
                foreach (var messagingFactory in senderFactories)
                {
                    try
                    {
                        await messagingFactory.CloseAsync();
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }

                senderFactories.Clear();
            }

            if (receiverFactories != null && receiverFactories.Count > 0)
            {
                foreach (var messagingFactory in receiverFactories)
                {
                    try
                    {
                        await messagingFactory.CloseAsync();
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }

                receiverFactories.Clear();
            }
        }

        internal async void btnCancel_Click(object sender, EventArgs e)
        {
            await CancelActions();
            OnCancel?.Invoke();
        }

        private void mainTabControl_DrawItem(object sender, DrawItemEventArgs e) => TabControlHelper.DrawTabControlTabs(mainTabControl, e, null);

        private void senderEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            grouperMessage.Enabled = senderEnabledCheckBox.Checked;
            grouperSender.Enabled = senderEnabledCheckBox.Checked;
            SetGraphLayout();
        }

        private void receiverEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            grouperReceiver.Enabled = receiverEnabledCheckBox.Checked;
            SetGraphLayout();
        }

        private void checkBoxEnableSenderLogging_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSenderVerboseLogging.Enabled = checkBoxEnableSenderLogging.Checked;
        }

        private void checkBoxEnableReceiverLogging_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxReceiverVerboseLogging.Enabled = checkBoxEnableReceiverLogging.Checked;
        }

        private void checkBoxSenderUseTransaction_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSenderCommitTransaction.Enabled = checkBoxSenderUseTransaction.Checked;
        }

        private void checkBoxReceiverUseTransaction_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxReceiverCommitTransaction.Enabled = checkBoxReceiverUseTransaction.Checked;
        }

        private void checkBoxMoveToDeadLetter_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxReadFromDeadLetter.Enabled = !checkBoxMoveToDeadLetter.Checked;
            checkBoxReadFromDeadLetter.Checked = false;
            checkBoxDeferMessage.Enabled = !checkBoxMoveToDeadLetter.Checked;
            checkBoxDeferMessage.Checked = false;
            if (checkBoxMoveToDeadLetter.Enabled)
            {
                cboReceivedMode.Text = PeekLock;
            }
        }

        private void checkBoxReadFromDeadLetter_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxMoveToDeadLetter.Enabled = !checkBoxReadFromDeadLetter.Checked;
            checkBoxMoveToDeadLetter.Checked = false;
            checkBoxDeferMessage.Enabled = !checkBoxReadFromDeadLetter.Checked;
            checkBoxDeferMessage.Checked = false;
        }

        private void checkBoxDeferMessage_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxMoveToDeadLetter.Enabled = !checkBoxDeferMessage.Checked;
            checkBoxMoveToDeadLetter.Checked = false;
            checkBoxReadFromDeadLetter.Enabled = !checkBoxDeferMessage.Checked;
            checkBoxReadFromDeadLetter.Checked = false;
        }

        private void cboReceivedMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBoxCompleteReceive.Enabled = cboReceivedMode.Text == PeekLock;
        }

        private void checkBoxSenderEnableStatistics_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxSenderEnableGraph.Enabled = checkBoxSenderEnableStatistics.Checked;
        }

        private void checkBoxReceiverEnableStatistics_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxReceiverEnableGraph.Enabled = checkBoxReceiverEnableStatistics.Checked;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.FileName = string.Empty;
                if (openFileDialog.ShowDialog() != DialogResult.OK ||
                    string.IsNullOrWhiteSpace(openFileDialog.FileName) ||
                    !File.Exists(openFileDialog.FileName))
                {
                    return;
                }
                using (var reader = new StreamReader(openFileDialog.FileName))
                {
                    var text = reader.ReadToEnd();
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        return;
                    }
                    LanguageDetector.SetFormattedMessage(controlHelper.ServiceBusHelper, text, txtMessageText);
                    if (controlHelper.MainForm != null)
                    {
                        controlHelper.MainForm.MessageText = text;
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void txtLabel_TextChanged(object sender, EventArgs e)
        {
            if (controlHelper.MainForm != null)
            {
                controlHelper.MainForm.Label = txtLabel.Text;
            }
        }

        /// <summary>
        /// Updates the statistics and graph on the control.
        /// </summary>
        /// <param name="messageNumber">Elapsed time.</param>
        /// <param name="elapsedMilliseconds">Elapsed time.</param>
        /// <param name="direction">The direction of the I/O operation: Send or Receive.</param>
        private void UpdateStatistics(long messageNumber, long elapsedMilliseconds, DirectionType direction)
        {
            blockingCollection.Add(new Tuple<long, long, DirectionType>(messageNumber, elapsedMilliseconds, direction));
        }

        /// <summary>
        /// Updates the statistics and graph on the control.
        /// </summary>
        /// <param name="messageNumber">Elapsed time.</param>
        /// <param name="elapsedMilliseconds">Elapsed time.</param>
        /// <param name="direction">The direction of the I/O operation: Send or Receive.</param>
        private void InternalUpdateStatistics(long messageNumber, long elapsedMilliseconds, DirectionType direction)
        {
            lock (this)
            {
                var elapsedSeconds = (double)elapsedMilliseconds / 1000;

                if (direction == DirectionType.Send)
                {
                    if (elapsedSeconds > senderMaximumTime)
                    {
                        senderMaximumTime = elapsedSeconds;
                    }
                    if (elapsedSeconds < senderMinimumTime)
                    {
                        senderMinimumTime = elapsedSeconds;
                    }
                    senderTotalTime += elapsedSeconds;
                    senderMessageNumber += messageNumber;
                    senderAverageTime = senderMessageNumber > 0 ? senderTotalTime / senderMessageNumber : 0;
                    senderMessagesPerSecond = senderTotalTime > 0 ? senderMessageNumber * senderTaskCount / senderTotalTime : 0;

                    lblSenderLastTime.Text = string.Format(TestControlHelper.LabelFormat, elapsedSeconds);
                    lblSenderLastTime.Refresh();
                    lblSenderAverageTime.Text = string.Format(TestControlHelper.LabelFormat, senderAverageTime);
                    lblSenderAverageTime.Refresh();
                    lblSenderMaximumTime.Text = string.Format(TestControlHelper.LabelFormat, senderMaximumTime);
                    lblSenderMaximumTime.Refresh();
                    lblSenderMinimumTime.Text = string.Format(TestControlHelper.LabelFormat, senderMinimumTime);
                    lblSenderMinimumTime.Refresh();
                    lblSenderMessagesPerSecond.Text = string.Format(TestControlHelper.LabelFormat, senderMessagesPerSecond);
                    lblSenderMessagesPerSecond.Refresh();
                    lblSenderMessageNumber.Text = senderMessageNumber.ToString(CultureInfo.InvariantCulture);
                    lblSenderMessageNumber.Refresh();

                    if (checkBoxSenderEnableGraph.Checked)
                    {
                        chart.Series["SenderLatency"].Points.AddXY(senderMessageNumber, elapsedSeconds);
                        chart.Series["SenderThroughput"].Points.AddXY(senderMessageNumber, senderMessagesPerSecond);
                    }
                }
                else
                {
                    if (elapsedSeconds > receiverMaximumTime)
                    {
                        receiverMaximumTime = elapsedSeconds;
                    }
                    if (elapsedSeconds < receiverMinimumTime)
                    {
                        receiverMinimumTime = elapsedSeconds;
                    }
                    receiverTotalTime += elapsedSeconds;
                    receiverMessageNumber += messageNumber;
                    receiverAverageTime = receiverMessageNumber > 0 ? receiverTotalTime / receiverMessageNumber : 0;
                    receiverMessagesPerSecond = receiverTotalTime > 0 ? receiverMessageNumber * receiverTaskCount / receiverTotalTime : 0;

                    lblReceiverLastTime.Text = string.Format(TestControlHelper.LabelFormat, elapsedSeconds);
                    lblReceiverLastTime.Refresh();
                    lblReceiverAverageTime.Text = string.Format(TestControlHelper.LabelFormat, receiverAverageTime);
                    lblReceiverAverageTime.Refresh();
                    lblReceiverMaximumTime.Text = string.Format(TestControlHelper.LabelFormat, receiverMaximumTime);
                    lblReceiverMaximumTime.Refresh();
                    lblReceiverMinimumTime.Text = string.Format(TestControlHelper.LabelFormat, receiverMinimumTime);
                    lblReceiverMinimumTime.Refresh();
                    lblReceiverMessagesPerSecond.Text = string.Format(TestControlHelper.LabelFormat, receiverMessagesPerSecond);
                    lblReceiverMessagesPerSecond.Refresh();
                    lblReceiverMessageNumber.Text = receiverMessageNumber.ToString(CultureInfo.InvariantCulture);
                    lblReceiverMessageNumber.Refresh();

                    if (checkBoxReceiverEnableGraph.Checked)
                    {
                        chart.Series["ReceiverLatency"].Points.AddXY(receiverMessageNumber, elapsedSeconds);
                        chart.Series["ReceiverThroughput"].Points.AddXY(receiverMessageNumber, receiverMessagesPerSecond);
                    }
                }
            }
        }

        private void SetGraphLayout()
        {
            var text = string.Empty;
            chart.Series.Clear();
            if (!senderEnabledCheckBox.Checked &&
                !receiverEnabledCheckBox.Checked)
            {
                grouperSenderStatistics.Visible = false;
                grouperReceiverStatistics.Visible = false;
                chart.Visible = false;
                return;
            }

            if (senderEnabledCheckBox.Checked)
            {
                var series1 = new Series();
                var series3 = new Series();

                series1.BorderColor = Color.FromArgb(180, 26, 59, 105);
                series1.BorderWidth = 2;
                series1.ChartArea = "Default";
                series1.ChartType = SeriesChartType.FastLine;
                series1.Legend = "Default";
                series1.LegendText = "Sender Latency";
                series1.Name = "SenderLatency";

                series3.BorderWidth = 2;
                series3.ChartArea = "Default";
                series3.ChartType = SeriesChartType.FastLine;
                series3.Legend = "Default";
                series3.LegendText = "Sender Throughput";
                series3.Name = "SenderThroughput";

                chart.Series.Add(series1);
                chart.Series.Add(series3);
                chart.Visible = true;
                text = "Sender Performance Counters";
                grouperSenderStatistics.Visible = true;
            }
            else
            {
                grouperSenderStatistics.Visible = false;
                chart.Visible = true;
                chart.Size = new Size(tabPageGraph.Width - LogicalToDeviceUnits(160),
                                      tabPageGraph.Height - LogicalToDeviceUnits(22));
            }

            if (receiverEnabledCheckBox.Checked)
            {
                var series2 = new Series();
                var series4 = new Series();

                series2.BorderColor = Color.Red;
                series2.BorderWidth = 2;
                series2.ChartArea = "Default";
                series2.ChartType = SeriesChartType.FastLine;
                series2.Legend = "Default";
                series2.LegendText = "Receiver Latency";
                series2.Name = "ReceiverLatency";

                series4.BorderWidth = 2;
                series4.ChartArea = "Default";
                series4.ChartType = SeriesChartType.FastLine;
                series4.Legend = "Default";
                series4.LegendText = "Receiver Throughput";
                series4.Name = "ReceiverThroughput";

                chart.Series.Add(series2);
                chart.Series.Add(series4);
                chart.Visible = true;
                text = "Receiver Performance Counters";
                if (senderEnabledCheckBox.Checked)
                {
                    chart.Size = new Size(tabPageGraph.Width - LogicalToDeviceUnits(304),
                                          tabPageGraph.Height - LogicalToDeviceUnits(22));
                }
                grouperReceiverStatistics.Location = senderEnabledCheckBox.Checked ?
                                                   new Point(grouperSenderStatistics.Width + chart.Width + LogicalToDeviceUnits(32), 8) :
                                                   new Point(16, 8);
                grouperReceiverStatistics.Anchor = senderEnabledCheckBox.Checked
                                                     ? AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right
                                                     : AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left;
                grouperReceiverStatistics.Visible = true;
            }
            else
            {
                grouperReceiverStatistics.Visible = false;
                chart.Visible = true;
                chart.Size = new Size(tabPageGraph.Width - LogicalToDeviceUnits(160),
                                      tabPageGraph.Height - LogicalToDeviceUnits(22));
            }

            if (senderEnabledCheckBox.Checked && receiverEnabledCheckBox.Checked)
            {
                text = "Sender & Receiver Performance Counters";
            }

            var title = new Title
            {
                Font = new Font("Microsoft Sans Serif", 8.25F,
                                FontStyle.Regular,
                                GraphicsUnit.Point,
                                0),
                Name = "Title",
                ShadowColor = Color.Transparent,
                ShadowOffset = 1,
                Text = text
            };

            chart.Titles.Clear();
            chart.Titles.Add(title);
            tabPageGraph.Refresh();
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

        private void propertiesDataGridView_Resize(object sender, EventArgs e)
        {
            CalculateLastColumnWidth();
        }

        private void propertiesDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalculateLastColumnWidth();
        }

        private void propertiesDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            CalculateLastColumnWidth();
        }

        private void checkBoxSendBatch_CheckedChanged(object sender, EventArgs e)
        {
            txtSendBatchSize.Enabled = checkBoxSendBatch.Checked;
        }

        private void checkBoxReceiveBatch_CheckedChanged(object sender, EventArgs e)
        {
            txtReceiveBatchSize.Enabled = checkBoxReceiveBatch.Checked;
            checkBoxMoveToDeadLetter.Enabled = !checkBoxReceiveBatch.Checked;
            checkBoxMoveToDeadLetter.Checked = false;
            checkBoxReadFromDeadLetter.Enabled = !checkBoxReceiveBatch.Checked;
            checkBoxReadFromDeadLetter.Checked = false;
            checkBoxDeferMessage.Enabled = !checkBoxReceiveBatch.Checked;
            checkBoxDeferMessage.Checked = false;
        }

        private void CalculateLastColumnWidth()
        {
            try
            {
                propertiesDataGridView.SuspendDrawing();
                propertiesDataGridView.SuspendLayout();
                if (propertiesDataGridView.Columns.Count != 3)
                {
                    return;
                }
                var width = propertiesDataGridView.Width - propertiesDataGridView.Columns[0].Width -
                            propertiesDataGridView.Columns[1].Width - propertiesDataGridView.RowHeadersWidth;
                var verticalScrollbar = propertiesDataGridView.Controls.OfType<VScrollBar>().First();
                if (verticalScrollbar != null && verticalScrollbar.Visible)
                {
                    width -= verticalScrollbar.Width;
                }
                propertiesDataGridView.Columns[2].Width = width;
            }
            finally
            {
                propertiesDataGridView.ResumeLayout();
                propertiesDataGridView.ResumeDrawing();
            }
        }

        private void TestTopicControl_Resize(object sender, EventArgs e)
        {
            grouperMessage.SuspendDrawing();
            grouperMessage.SuspendLayout();
            try
            {
                var textBoxWidth = (grouperMessage.Width - 240) / 2;
                lblSessionId.Location = new Point(120 + textBoxWidth, lblSessionId.Location.Y);
                lblCorrelationId.Location = new Point(lblSessionId.Location.X, lblCorrelationId.Location.Y);
                lblContentType.Location = new Point(lblSessionId.Location.X, lblContentType.Location.Y);
                lblReplyToSessionId.Location = new Point(lblSessionId.Location.X, lblReplyToSessionId.Location.Y);
                lblTimeToLive.Location = new Point(lblSessionId.Location.X, lblTimeToLive.Location.Y);
                txtMessageId.Size = new Size(textBoxWidth, txtMessageId.Size.Height);
                txtSessionId.Size = new Size(textBoxWidth, txtSessionId.Size.Height);
                txtTo.Size = new Size(textBoxWidth, txtTo.Size.Height);
                txtCorrelationId.Size = new Size(textBoxWidth, txtCorrelationId.Size.Height);
                txtReplyTo.Size = new Size(textBoxWidth, txtReplyTo.Size.Height);
                txtContentType.Size = new Size(textBoxWidth, txtContentType.Size.Height);
                txtLabel.Size = new Size(textBoxWidth, txtLabel.Size.Height);
                txtReplyToSessionId.Size = new Size(textBoxWidth, txtReplyToSessionId.Size.Height);
                txtScheduledEnqueueTimeUtc.Size = new Size(textBoxWidth, txtScheduledEnqueueTimeUtc.Size.Height);
                txtTimeToLive.Size = new Size(textBoxWidth, txtTimeToLive.Size.Height);
                txtSessionId.Location = new Point(textBoxWidth + 216, txtSessionId.Location.Y);
                txtCorrelationId.Location = new Point(txtSessionId.Location.X, txtCorrelationId.Location.Y);
                txtContentType.Location = new Point(txtSessionId.Location.X, txtContentType.Location.Y);
                txtReplyToSessionId.Location = new Point(txtSessionId.Location.X, txtReplyToSessionId.Location.Y);
                txtTimeToLive.Location = new Point(txtSessionId.Location.X, txtTimeToLive.Location.Y);
            }
            finally
            {
                grouperMessage.ResumeLayout();
                grouperMessage.ResumeDrawing();
            }
        }

        private void grouperSender_CustomPaint(PaintEventArgs e)
        {
            // The combo boxes are now inside the tableLayoutPanel3, so their location is relative to tableLayoutPanel3
            // rather than the grouperSender control. We need to transform their location to the grouperSender control.
            var cboBodyTypeLocation = tableLayoutPanel3.PointToScreen(cboBodyType.Location);
            cboBodyTypeLocation = grouperSender.PointToClient(cboBodyTypeLocation);

            var cboSenderInspectorLocation = tableLayoutPanel3.PointToScreen(cboSenderInspector.Location);
            cboSenderInspectorLocation = grouperSender.PointToClient(cboSenderInspectorLocation);

            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                    cboBodyTypeLocation.X - 1,
                                    cboBodyTypeLocation.Y - 1,
                                    cboBodyType.Size.Width + 1,
                                    cboBodyType.Size.Height + 1);
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                    cboSenderInspectorLocation.X - 1,
                                    cboSenderInspectorLocation.Y - 1,
                                    cboSenderInspector.Size.Width + 1,
                                    cboSenderInspector.Size.Height + 1);
        }

        private void grouperReceiver_CustomPaint(PaintEventArgs e)
        {
            // The combo boxes are now inside the tableLayoutPanel9, so their location is relative to tableLayoutPanel9
            // rather than the grouperReceiver control. We need to transform their location to the grouperReceiver control.
            var cboReceivedModeLocation = tableLayoutPanel9.PointToScreen(cboReceivedMode.Location);
            cboReceivedModeLocation = grouperReceiver.PointToClient(cboReceivedModeLocation);

            var cboSubscriptionsLocation = tableLayoutPanel9.PointToScreen(cboSubscriptions.Location);
            cboSubscriptionsLocation = grouperReceiver.PointToClient(cboSubscriptionsLocation);

            // The cboReceiverInspector is inside the flowLayoutPanel1 instead of the tableLayoutPanel9
            var cboReceiverInspectorLocation = flowLayoutPanel1.PointToScreen(cboReceiverInspector.Location);
            cboReceiverInspectorLocation = grouperReceiver.PointToClient(cboReceiverInspectorLocation);

            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                    cboReceivedModeLocation.X - 1,
                                    cboReceivedModeLocation.Y - 1,
                                    cboReceivedMode.Size.Width + 1,
                                    cboReceivedMode.Size.Height + 1);

            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                    cboSubscriptionsLocation.X - 1,
                                    cboSubscriptionsLocation.Y - 1,
                                    cboSubscriptions.Size.Width + 1,
                                    cboSubscriptions.Size.Height + 1);
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                    cboReceiverInspectorLocation.X - 1,
                                    cboReceiverInspectorLocation.Y - 1,
                                    cboReceiverInspector.Size.Width + 1,
                                    cboReceiverInspector.Size.Height + 1);
        }

        private void grouperMessageProperties_CustomPaint(PaintEventArgs e)
        {
            propertiesDataGridView.Size = new Size(grouperMessageProperties.Size.Width - LogicalToDeviceUnits(32),
                                                   grouperMessageProperties.Size.Height - LogicalToDeviceUnits(48));
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                   propertiesDataGridView.Location.X - 1,
                                   propertiesDataGridView.Location.Y - 1,
                                   propertiesDataGridView.Size.Width + 1,
                                   propertiesDataGridView.Size.Height + 1);
        }
        private void checkBoxSenderThinkTime_CheckedChanged(object sender, EventArgs e)
        {
            txtSenderThinkTime.Enabled = checkBoxSenderThinkTime.Checked;
        }

        private void checkBoxReceiverThinkTime_CheckedChanged(object sender, EventArgs e)
        {
            txtReceiverThinkTime.Enabled = checkBoxReceiverThinkTime.Checked;
        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPress(e);

            var numberFormatInfo = CultureInfo.CurrentCulture.NumberFormat;
            var decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            var groupSeparator = numberFormatInfo.NumberGroupSeparator;
            var negativeSign = numberFormatInfo.NegativeSign;

            var keyInput = e.KeyChar.ToString(CultureInfo.InvariantCulture);

            if (char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
                     keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            else if (e.KeyChar == ' ')
            {

            }
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
            }
        }

        private void messageTabControl_DrawItem(object sender, DrawItemEventArgs e) => TabControlHelper.DrawTabControlTabs(messageTabControl, e, null);

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;
            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog() != DialogResult.OK ||
               !openFileDialog.FileNames.Any())
            {
                return;
            }
            foreach (var fileInfo in openFileDialog.FileNames.Select(fileName => new FileInfo(fileName)))
            {
                var size = $"{(fileInfo.Length % 1024 == 0 ? fileInfo.Length / 1024 : fileInfo.Length / 1024 + 1)} KB";
                messageFileListView.Items.Add(new ListViewItem(new[]
                {
                    fileInfo.FullName,
                    size
                })
                { Checked = true });
                controlHelper.MainForm.FileNames.Add(new Tuple<string, string>(fileInfo.FullName, size));
            }
            checkBoxFileName.Checked = messageFileListView.Items.Cast<ListViewItem>().All(i => i.Checked);
            var fileList = messageFileListView.Items.Cast<ListViewItem>()
                                    .Select(i => i.Text)
                                    .ToList();
            if (fileList.All(f => Path.GetExtension(f) == ".txt"))
            {
                radioButtonTextFile.Checked = true;
            }
            else if (fileList.All(f => Path.GetExtension(f) == ".json"))
            {
                radioButtonJsonTemplate.Checked = true;
            }
            else if (fileList.All(f => Path.GetExtension(f) == ".xml"))
            {
                radioButtonXmlTemplate.Checked = true;
            }
            btnClearFiles.Enabled = messageFileListView.Items.Count > 0;
            messageFileListView.Columns[SizeListViewColumnIndex].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void messageFileListView_Resize(object sender, EventArgs e)
        {
            try
            {
                messageFileListView.SuspendDrawing();
                messageFileListView.SuspendLayout();
                var listView = sender as ListView;
                if (listView == null)
                {
                    return;
                }
                var width = listView.Width - listView.Columns[SizeListViewColumnIndex].Width;
                listView.Columns[NameListViewColumnIndex].Width = width - LogicalToDeviceUnits(4);
            }
            finally
            {
                messageFileListView.ResumeLayout();
                messageFileListView.ResumeDrawing();
            }
        }

        private void messageFileListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) => ListViewHelper.DrawListViewHeaders(e, DeviceDpi);

        private void messageFileListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //e.DrawDefault = true;
            //e.DrawBackground();
            //e.DrawText();
        }

        private void messageFileListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void btnClearFiles_Click(object sender, EventArgs e)
        {
            checkBoxFileName.Checked = false;
            messageFileListView.Items.Clear();
            controlHelper.MainForm.FileNames.Clear();
            btnClearFiles.Enabled = false;
        }

        private void checkBoxFileName_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < messageFileListView.Items.Count; i++)
            {
                messageFileListView.Items[i].Checked = checkBoxFileName.Checked;
            }
        }

        private void grouperMessageFiles_CustomPaint(PaintEventArgs obj)
        {
            var x = DeviceDpi <= 96 ? 8 : 6;
            var y = DeviceDpi <= 96 ? 4 : 3;

            nameColumnHeader.Text = string.Empty;
            checkBoxFileName.Location = new Point(messageFileListView.Location.X + x,
                                                  messageFileListView.Location.Y + y);
            var width = (grouperMessageFiles.Size.Width - 32) / 4;
            radioButtonBinaryFile.Location = new Point(width + 16, radioButtonJsonTemplate.Location.Y);
            radioButtonJsonTemplate.Location = new Point(2 * width + 16, radioButtonJsonTemplate.Location.Y);
            radioButtonXmlTemplate.Location = new Point(grouperMessageFiles.Size.Width - 16 - radioButtonXmlTemplate.Size.Width, radioButtonXmlTemplate.Location.Y);
        }

        private void checkBoxOneSessionPerTask_CheckedChanged(object sender, EventArgs e)
        {
            txtSessionId.Enabled = !checkBoxOneSessionPerTask.Checked;
        }

        private void grouperBrokeredMessageGenerator_CustomPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                     cboBrokeredMessageGeneratorType.Location.X - 1,
                                     cboBrokeredMessageGeneratorType.Location.Y - 1,
                                     cboBrokeredMessageGeneratorType.Size.Width + 1,
                                     cboBrokeredMessageGeneratorType.Size.Height + 1);
            brokeredMessageGeneratorPropertyGrid.HelpVisible = brokeredMessageGeneratorPropertyGrid.Height > 250;
        }

        private void cboBrokeredMessageGeneratorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboBrokeredMessageGeneratorType.SelectedIndex == 0)
                {
                    return;
                }
                if (!controlHelper.ServiceBusHelper.BrokeredMessageGenerators.ContainsKey(cboBrokeredMessageGeneratorType.Text))
                {
                    return;
                }
                var type = controlHelper.ServiceBusHelper.BrokeredMessageGenerators[cboBrokeredMessageGeneratorType.Text];
                if (type == null)
                {
                    return;
                }
                brokeredMessageGeneratorPropertyGrid.SelectedObject = Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void propertiesDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
                if (disposing)
                {
                    components?.Dispose();
                }

                senderCancellationTokenSource?.Dispose();

                receiverCancellationTokenSource?.Dispose();

                managerCancellationTokenSource?.Dispose();

                graphCancellationTokenSource?.Dispose();

                managerResetEvent?.Dispose();

                blockingCollection?.Dispose();

                if (brokeredMessageGenerator != null)
                {
                    var disposable = brokeredMessageGenerator as IDisposable;
                    disposable?.Dispose();
                }

                if (senderBrokeredMessageInspector != null)
                {
                    var disposable = senderBrokeredMessageInspector as IDisposable;
                    disposable?.Dispose();
                }

                if (receiverBrokeredMessageInspector != null)
                {
                    var disposable = receiverBrokeredMessageInspector as IDisposable;
                    disposable?.Dispose();
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

        private void txtMessageText_TextChanged(object sender, TextChangedEventArgs e)
        {
            controlHelper.OnMessageTextChanged(txtMessageText.Text);
        }

        private void txtContentType_TextChanged(object sender, EventArgs e)
        {
            controlHelper.MainForm.MessageContentType = txtContentType.Text;
        }

        private void grouperMessageFormat_CustomPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1),
                                   cboMessageFormat.Location.X - 1,
                                   cboMessageFormat.Location.Y - 1,
                                   cboMessageFormat.Size.Width + 1,
                                   cboMessageFormat.Size.Height + 1);
        }

        private void cboMessageFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            LanguageDetector.SetFormattedMessage(cboMessageFormat.Text, txtMessageText);
        }

        #endregion
    }
}
