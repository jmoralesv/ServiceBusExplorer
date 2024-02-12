namespace ServiceBusExplorer.Controls
{
    partial class TestTopicControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestTopicControl));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.mainTabMessagePage = new System.Windows.Forms.TabPage();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.messageTabControl = new System.Windows.Forms.TabControl();
            this.tabMessagePage = new System.Windows.Forms.TabPage();
            this.tabFilesPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabGeneratorPage = new System.Windows.Forms.TabPage();
            this.mainTabSenderPage = new System.Windows.Forms.TabPage();
            this.senderEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.mainTabReceiverPage = new System.Windows.Forms.TabPage();
            this.receiverEnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.tabPageGraph = new System.Windows.Forms.TabPage();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnClearFiles = new System.Windows.Forms.Button();
            this.btnSelectFiles = new System.Windows.Forms.Button();
            this.grouperMessageFormat = new ServiceBusExplorer.Controls.Grouper();
            this.cboMessageFormat = new System.Windows.Forms.ComboBox();
            this.grouperMessageText = new ServiceBusExplorer.Controls.Grouper();
            this.txtMessageText = new FastColoredTextBoxNS.FastColoredTextBox();
            this.grouperMessageFiles = new ServiceBusExplorer.Controls.Grouper();
            this.radioButtonBinaryFile = new System.Windows.Forms.RadioButton();
            this.radioButtonJsonTemplate = new System.Windows.Forms.RadioButton();
            this.radioButtonXmlTemplate = new System.Windows.Forms.RadioButton();
            this.radioButtonTextFile = new System.Windows.Forms.RadioButton();
            this.checkBoxFileName = new System.Windows.Forms.CheckBox();
            this.messageFileListView = new System.Windows.Forms.ListView();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grouperBrokeredMessageGenerator = new ServiceBusExplorer.Controls.Grouper();
            this.lblRegistration = new System.Windows.Forms.Label();
            this.brokeredMessageGeneratorPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.cboBrokeredMessageGeneratorType = new System.Windows.Forms.ComboBox();
            this.lblRegistrationType = new System.Windows.Forms.Label();
            this.grouperMessageProperties = new ServiceBusExplorer.Controls.Grouper();
            this.propertiesDataGridView = new System.Windows.Forms.DataGridView();
            this.grouperSender = new ServiceBusExplorer.Controls.Grouper();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxSenderUseTransaction = new System.Windows.Forms.CheckBox();
            this.cboSenderInspector = new System.Windows.Forms.ComboBox();
            this.checkBoxSendNewFactory = new System.Windows.Forms.CheckBox();
            this.lblSenderInspector = new System.Windows.Forms.Label();
            this.checkBoxSenderCommitTransaction = new System.Windows.Forms.CheckBox();
            this.txtSendBatchSize = new System.Windows.Forms.TextBox();
            this.lblSendBatchSize = new System.Windows.Forms.Label();
            this.txtSendTaskCount = new System.Windows.Forms.TextBox();
            this.txtMessageCount = new ServiceBusExplorer.Controls.NumericTextBox();
            this.cboBodyType = new System.Windows.Forms.ComboBox();
            this.lblBody = new System.Windows.Forms.Label();
            this.checkBoxEnableSenderLogging = new System.Windows.Forms.CheckBox();
            this.checkBoxSenderVerboseLogging = new System.Windows.Forms.CheckBox();
            this.checkBoxSenderEnableStatistics = new System.Windows.Forms.CheckBox();
            this.txtSenderThinkTime = new System.Windows.Forms.TextBox();
            this.lblSendTaskCount = new System.Windows.Forms.Label();
            this.checkBoxSenderEnableGraph = new System.Windows.Forms.CheckBox();
            this.lblSenderThinkTime = new System.Windows.Forms.Label();
            this.checkBoxOneSessionPerTask = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.checkBoxSenderThinkTime = new System.Windows.Forms.CheckBox();
            this.checkBoxUpdateMessageId = new System.Windows.Forms.CheckBox();
            this.checkBoxAddMessageNumber = new System.Windows.Forms.CheckBox();
            this.checkBoxSendBatch = new System.Windows.Forms.CheckBox();
            this.grouperMessage = new ServiceBusExplorer.Controls.Grouper();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxForcePersistence = new System.Windows.Forms.CheckBox();
            this.lblForcePersistence = new System.Windows.Forms.Label();
            this.txtTimeToLive = new System.Windows.Forms.TextBox();
            this.txtContentType = new System.Windows.Forms.TextBox();
            this.txtReplyToSessionId = new System.Windows.Forms.TextBox();
            this.lblContentType = new System.Windows.Forms.Label();
            this.lblMessageId = new System.Windows.Forms.Label();
            this.lblTimeToLive = new System.Windows.Forms.Label();
            this.txtCorrelationId = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtSessionId = new System.Windows.Forms.TextBox();
            this.lblReplyToSessionId = new System.Windows.Forms.Label();
            this.txtScheduledEnqueueTimeUtc = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblReplyTo = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblScheduledEnqueueTimeUtc = new System.Windows.Forms.Label();
            this.lblCorrelationId = new System.Windows.Forms.Label();
            this.txtReplyTo = new System.Windows.Forms.TextBox();
            this.lblSessionId = new System.Windows.Forms.Label();
            this.txtMessageId = new System.Windows.Forms.TextBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.grouperReceiver = new ServiceBusExplorer.Controls.Grouper();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBoxReceiveNewFactory = new System.Windows.Forms.CheckBox();
            this.txtFilterExpression = new System.Windows.Forms.TextBox();
            this.cboSubscriptions = new System.Windows.Forms.ComboBox();
            this.checkBoxReadFromDeadLetter = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxReceiverThinkTime = new System.Windows.Forms.CheckBox();
            this.lblReceiverThinkTime = new System.Windows.Forms.Label();
            this.txtReceiverThinkTime = new System.Windows.Forms.TextBox();
            this.lblReceiveTaskCount = new System.Windows.Forms.Label();
            this.txtReceiveTaskCount = new System.Windows.Forms.TextBox();
            this.checkBoxDeferMessage = new System.Windows.Forms.CheckBox();
            this.lblServerWaitTime = new System.Windows.Forms.Label();
            this.checkBoxCompleteReceive = new System.Windows.Forms.CheckBox();
            this.checkBoxReceiverEnableGraph = new System.Windows.Forms.CheckBox();
            this.txtReceiveTimeout = new System.Windows.Forms.TextBox();
            this.lblPrefetchCount = new System.Windows.Forms.Label();
            this.checkBoxReceiverVerboseLogging = new System.Windows.Forms.CheckBox();
            this.txtPrefetchCount = new System.Windows.Forms.TextBox();
            this.checkBoxReceiverCommitTransaction = new System.Windows.Forms.CheckBox();
            this.lblReceiveBatchSize = new System.Windows.Forms.Label();
            this.checkBoxReceiveBatch = new System.Windows.Forms.CheckBox();
            this.checkBoxReceiverUseTransaction = new System.Windows.Forms.CheckBox();
            this.checkBoxMoveToDeadLetter = new System.Windows.Forms.CheckBox();
            this.lblSubscription = new System.Windows.Forms.Label();
            this.checkBoxReceiverEnableStatistics = new System.Windows.Forms.CheckBox();
            this.txtServerTimeout = new System.Windows.Forms.TextBox();
            this.lblFilterExpr = new System.Windows.Forms.Label();
            this.txtReceiveBatchSize = new System.Windows.Forms.TextBox();
            this.cboReceivedMode = new System.Windows.Forms.ComboBox();
            this.lblServerTimeout = new System.Windows.Forms.Label();
            this.checkBoxEnableReceiverLogging = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblReceiverInspector = new System.Windows.Forms.Label();
            this.cboReceiverInspector = new System.Windows.Forms.ComboBox();
            this.grouperReceiverStatistics = new ServiceBusExplorer.Controls.Grouper();
            this.receiverLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReceiverLastTime = new System.Windows.Forms.Label();
            this.lblReceiverLastCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReceiverAverageTime = new System.Windows.Forms.Label();
            this.lblReceiverAverageCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReceiverMinimumTime = new System.Windows.Forms.Label();
            this.lblReceiverMinimumCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReceiverMaximumTime = new System.Windows.Forms.Label();
            this.lblReceiverMaximumCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReceiverMessagesPerSecond = new System.Windows.Forms.Label();
            this.lblReceiverMessagesPerSecondCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lblReceiverMessageNumber = new System.Windows.Forms.Label();
            this.lblReceiverCallsSuccessedCaption = new System.Windows.Forms.Label();
            this.grouperSenderStatistics = new ServiceBusExplorer.Controls.Grouper();
            this.senderLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSenderAverageTime = new System.Windows.Forms.Label();
            this.lblSenderAverageCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSenderLastTime = new System.Windows.Forms.Label();
            this.lblSenderLastCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSenderMinimumTime = new System.Windows.Forms.Label();
            this.lblSenderMinimumCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSenderMaximumTime = new System.Windows.Forms.Label();
            this.lblSenderMaximumCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSenderMessagesPerSecond = new System.Windows.Forms.Label();
            this.lblSenderMessagesPerSecondCaption = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.lblSenderMessageNumber = new System.Windows.Forms.Label();
            this.lblSenderCallsSuccessedCaption = new System.Windows.Forms.Label();
            this.mainTabControl.SuspendLayout();
            this.mainTabMessagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.messageTabControl.SuspendLayout();
            this.tabMessagePage.SuspendLayout();
            this.tabFilesPage.SuspendLayout();
            this.tabGeneratorPage.SuspendLayout();
            this.mainTabSenderPage.SuspendLayout();
            this.mainTabReceiverPage.SuspendLayout();
            this.tabPageGraph.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.grouperMessageFormat.SuspendLayout();
            this.grouperMessageText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText)).BeginInit();
            this.grouperMessageFiles.SuspendLayout();
            this.grouperBrokeredMessageGenerator.SuspendLayout();
            this.grouperMessageProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).BeginInit();
            this.grouperSender.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grouperMessage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grouperReceiver.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.grouperReceiverStatistics.SuspendLayout();
            this.receiverLayoutPanel.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.grouperSenderStatistics.SuspendLayout();
            this.senderLayoutPanel.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStart.Location = new System.Drawing.Point(840, 438);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(72, 24);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnStart.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(920, 438);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.mainTabMessagePage);
            this.mainTabControl.Controls.Add(this.mainTabSenderPage);
            this.mainTabControl.Controls.Add(this.mainTabReceiverPage);
            this.mainTabControl.Controls.Add(this.tabPageGraph);
            this.mainTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.mainTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabControl.Location = new System.Drawing.Point(16, 16);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(976, 414);
            this.mainTabControl.TabIndex = 0;
            this.mainTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.mainTabControl_DrawItem);
            // 
            // mainTabMessagePage
            // 
            this.mainTabMessagePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mainTabMessagePage.Controls.Add(this.splitContainer);
            this.mainTabMessagePage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mainTabMessagePage.Location = new System.Drawing.Point(4, 24);
            this.mainTabMessagePage.Name = "mainTabMessagePage";
            this.mainTabMessagePage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTabMessagePage.Size = new System.Drawing.Size(968, 386);
            this.mainTabMessagePage.TabIndex = 0;
            this.mainTabMessagePage.Text = "Message";
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(16, 8);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.messageTabControl);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.grouperMessageProperties);
            this.splitContainer.Size = new System.Drawing.Size(936, 366);
            this.splitContainer.SplitterDistance = 459;
            this.splitContainer.SplitterWidth = 16;
            this.splitContainer.TabIndex = 2;
            // 
            // messageTabControl
            // 
            this.messageTabControl.Controls.Add(this.tabMessagePage);
            this.messageTabControl.Controls.Add(this.tabFilesPage);
            this.messageTabControl.Controls.Add(this.tabGeneratorPage);
            this.messageTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.messageTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageTabControl.Location = new System.Drawing.Point(0, 0);
            this.messageTabControl.Name = "messageTabControl";
            this.messageTabControl.SelectedIndex = 0;
            this.messageTabControl.Size = new System.Drawing.Size(459, 366);
            this.messageTabControl.TabIndex = 0;
            this.messageTabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.messageTabControl_DrawItem);
            // 
            // tabMessagePage
            // 
            this.tabMessagePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.tabMessagePage.Controls.Add(this.grouperMessageFormat);
            this.tabMessagePage.Controls.Add(this.grouperMessageText);
            this.tabMessagePage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabMessagePage.Location = new System.Drawing.Point(4, 24);
            this.tabMessagePage.Name = "tabMessagePage";
            this.tabMessagePage.Size = new System.Drawing.Size(451, 338);
            this.tabMessagePage.TabIndex = 2;
            this.tabMessagePage.Text = "Message";
            // 
            // tabFilesPage
            // 
            this.tabFilesPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.tabFilesPage.Controls.Add(this.label2);
            this.tabFilesPage.Controls.Add(this.grouperMessageFiles);
            this.tabFilesPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabFilesPage.Location = new System.Drawing.Point(4, 24);
            this.tabFilesPage.Name = "tabFilesPage";
            this.tabFilesPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilesPage.Size = new System.Drawing.Size(451, 338);
            this.tabFilesPage.TabIndex = 5;
            this.tabFilesPage.Text = "Files";
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(16, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 56);
            this.label2.TabIndex = 0;
            this.label2.Text = "The default is to just send one message so if you have selected multiple files an" +
    "d want to send all of them you have to change the Message Count on the Sender ta" +
    "b.";
            // 
            // tabGeneratorPage
            // 
            this.tabGeneratorPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.tabGeneratorPage.Controls.Add(this.grouperBrokeredMessageGenerator);
            this.tabGeneratorPage.Location = new System.Drawing.Point(4, 24);
            this.tabGeneratorPage.Name = "tabGeneratorPage";
            this.tabGeneratorPage.Size = new System.Drawing.Size(451, 338);
            this.tabGeneratorPage.TabIndex = 6;
            this.tabGeneratorPage.Text = "Generator";
            // 
            // mainTabSenderPage
            // 
            this.mainTabSenderPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mainTabSenderPage.Controls.Add(this.senderEnabledCheckBox);
            this.mainTabSenderPage.Controls.Add(this.grouperSender);
            this.mainTabSenderPage.Controls.Add(this.grouperMessage);
            this.mainTabSenderPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mainTabSenderPage.Location = new System.Drawing.Point(4, 24);
            this.mainTabSenderPage.Name = "mainTabSenderPage";
            this.mainTabSenderPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTabSenderPage.Size = new System.Drawing.Size(968, 386);
            this.mainTabSenderPage.TabIndex = 1;
            this.mainTabSenderPage.Text = "Sender";
            // 
            // senderEnabledCheckBox
            // 
            this.senderEnabledCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.senderEnabledCheckBox.AutoSize = true;
            this.senderEnabledCheckBox.Checked = true;
            this.senderEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.senderEnabledCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.senderEnabledCheckBox.Location = new System.Drawing.Point(880, 12);
            this.senderEnabledCheckBox.Name = "senderEnabledCheckBox";
            this.senderEnabledCheckBox.Size = new System.Drawing.Size(75, 19);
            this.senderEnabledCheckBox.TabIndex = 2;
            this.senderEnabledCheckBox.Text = "Enabled:";
            this.senderEnabledCheckBox.UseVisualStyleBackColor = true;
            this.senderEnabledCheckBox.CheckedChanged += new System.EventHandler(this.senderEnabledCheckBox_CheckedChanged);
            // 
            // mainTabReceiverPage
            // 
            this.mainTabReceiverPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.mainTabReceiverPage.Controls.Add(this.receiverEnabledCheckBox);
            this.mainTabReceiverPage.Controls.Add(this.grouperReceiver);
            this.mainTabReceiverPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.mainTabReceiverPage.Location = new System.Drawing.Point(4, 24);
            this.mainTabReceiverPage.Name = "mainTabReceiverPage";
            this.mainTabReceiverPage.Size = new System.Drawing.Size(968, 386);
            this.mainTabReceiverPage.TabIndex = 2;
            this.mainTabReceiverPage.Text = "Receiver";
            // 
            // receiverEnabledCheckBox
            // 
            this.receiverEnabledCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receiverEnabledCheckBox.AutoSize = true;
            this.receiverEnabledCheckBox.Checked = true;
            this.receiverEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.receiverEnabledCheckBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.receiverEnabledCheckBox.Location = new System.Drawing.Point(881, 12);
            this.receiverEnabledCheckBox.Name = "receiverEnabledCheckBox";
            this.receiverEnabledCheckBox.Size = new System.Drawing.Size(75, 19);
            this.receiverEnabledCheckBox.TabIndex = 14;
            this.receiverEnabledCheckBox.Text = "Enabled:";
            this.receiverEnabledCheckBox.UseVisualStyleBackColor = true;
            this.receiverEnabledCheckBox.CheckedChanged += new System.EventHandler(this.receiverEnabledCheckBox_CheckedChanged);
            // 
            // tabPageGraph
            // 
            this.tabPageGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.tabPageGraph.Controls.Add(this.grouperReceiverStatistics);
            this.tabPageGraph.Controls.Add(this.grouperSenderStatistics);
            this.tabPageGraph.Controls.Add(this.chart);
            this.tabPageGraph.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPageGraph.Location = new System.Drawing.Point(4, 24);
            this.tabPageGraph.Name = "tabPageGraph";
            this.tabPageGraph.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGraph.Size = new System.Drawing.Size(968, 386);
            this.tabPageGraph.TabIndex = 3;
            this.tabPageGraph.Text = "Graph";
            // 
            // chart
            // 
            this.chart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.chart.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.chart.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.chart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            this.chart.BorderSkin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.chart.BorderSkin.BorderWidth = 0;
            this.chart.BorderSkin.PageColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.chart.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameTitle1;
            chartArea4.Area3DStyle.Inclination = 15;
            chartArea4.Area3DStyle.IsClustered = true;
            chartArea4.Area3DStyle.IsRightAngleAxes = false;
            chartArea4.Area3DStyle.Perspective = 10;
            chartArea4.Area3DStyle.Rotation = 10;
            chartArea4.Area3DStyle.WallWidth = 0;
            chartArea4.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea4.AxisX.ScrollBar.Size = 10D;
            chartArea4.AxisX.Title = "Messages";
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea4.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea4.AxisY.ScrollBar.Size = 10D;
            chartArea4.AxisY.Title = "Time - Msg/Sec";
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY2.Title = "Messages/Sec";
            chartArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            chartArea4.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea4.BackSecondaryColor = System.Drawing.Color.White;
            chartArea4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea4.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea4.CursorX.IsUserEnabled = true;
            chartArea4.CursorX.IsUserSelectionEnabled = true;
            chartArea4.CursorY.IsUserEnabled = true;
            chartArea4.CursorY.IsUserSelectionEnabled = true;
            chartArea4.Name = "Default";
            chartArea4.ShadowColor = System.Drawing.Color.White;
            this.chart.ChartAreas.Add(chartArea4);
            legend4.Alignment = System.Drawing.StringAlignment.Far;
            legend4.BackColor = System.Drawing.Color.Transparent;
            legend4.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend4.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            legend4.IsTextAutoFit = false;
            legend4.MaximumAutoSize = 5F;
            legend4.Name = "Default";
            this.chart.Legends.Add(legend4);
            this.chart.Location = new System.Drawing.Point(152, 16);
            this.chart.Name = "chart";
            series13.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            series13.BorderWidth = 2;
            series13.ChartArea = "Default";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series13.Legend = "Default";
            series13.LegendText = "Sender Latency";
            series13.Name = "SenderLatency";
            series14.BorderColor = System.Drawing.Color.Red;
            series14.BorderWidth = 2;
            series14.ChartArea = "Default";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series14.Legend = "Default";
            series14.LegendText = "Receiver Latency";
            series14.Name = "ReceiverLatency";
            series15.BorderWidth = 2;
            series15.ChartArea = "Default";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series15.Legend = "Default";
            series15.LegendText = "Sender Throughput";
            series15.Name = "SenderThroughput";
            series16.BorderWidth = 2;
            series16.ChartArea = "Default";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series16.Legend = "Default";
            series16.LegendText = "Receiver Throughput";
            series16.Name = "ReceiverThroughput";
            this.chart.Series.Add(series13);
            this.chart.Series.Add(series14);
            this.chart.Series.Add(series15);
            this.chart.Series.Add(series16);
            this.chart.Size = new System.Drawing.Size(668, 352);
            this.chart.TabIndex = 1;
            title4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.Name = "Title";
            title4.ShadowColor = System.Drawing.Color.Transparent;
            title4.ShadowOffset = 1;
            title4.Text = "Sender & Receiver Performance Counters";
            this.chart.Titles.Add(title4);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnOpenFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenFile.Location = new System.Drawing.Point(760, 438);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(72, 24);
            this.btnOpenFile.TabIndex = 3;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            this.btnOpenFile.MouseEnter += new System.EventHandler(this.button_MouseEnter);
            this.btnOpenFile.MouseLeave += new System.EventHandler(this.button_MouseLeave);
            // 
            // btnClearFiles
            // 
            this.btnClearFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnClearFiles.Enabled = false;
            this.btnClearFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClearFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClearFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnClearFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearFiles.Location = new System.Drawing.Point(680, 438);
            this.btnClearFiles.Name = "btnClearFiles";
            this.btnClearFiles.Size = new System.Drawing.Size(72, 24);
            this.btnClearFiles.TabIndex = 2;
            this.btnClearFiles.Text = "Clear Files";
            this.btnClearFiles.UseVisualStyleBackColor = false;
            this.btnClearFiles.Click += new System.EventHandler(this.btnClearFiles_Click);
            // 
            // btnSelectFiles
            // 
            this.btnSelectFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.btnSelectFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnSelectFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnSelectFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnSelectFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFiles.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelectFiles.Location = new System.Drawing.Point(601, 438);
            this.btnSelectFiles.Name = "btnSelectFiles";
            this.btnSelectFiles.Size = new System.Drawing.Size(72, 24);
            this.btnSelectFiles.TabIndex = 1;
            this.btnSelectFiles.Text = "Select Files";
            this.btnSelectFiles.UseVisualStyleBackColor = false;
            this.btnSelectFiles.Click += new System.EventHandler(this.btnSelectFiles_Click);
            // 
            // grouperMessageFormat
            // 
            this.grouperMessageFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperMessageFormat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperMessageFormat.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperMessageFormat.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperMessageFormat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageFormat.BorderThickness = 1F;
            this.grouperMessageFormat.Controls.Add(this.cboMessageFormat);
            this.grouperMessageFormat.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperMessageFormat.ForeColor = System.Drawing.Color.White;
            this.grouperMessageFormat.GroupImage = null;
            this.grouperMessageFormat.GroupTitle = "Message Format";
            this.grouperMessageFormat.Location = new System.Drawing.Point(17, 258);
            this.grouperMessageFormat.Name = "grouperMessageFormat";
            this.grouperMessageFormat.Padding = new System.Windows.Forms.Padding(20);
            this.grouperMessageFormat.PaintGroupBox = true;
            this.grouperMessageFormat.RoundCorners = 4;
            this.grouperMessageFormat.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperMessageFormat.ShadowControl = false;
            this.grouperMessageFormat.ShadowThickness = 1;
            this.grouperMessageFormat.Size = new System.Drawing.Size(416, 70);
            this.grouperMessageFormat.TabIndex = 1;
            this.grouperMessageFormat.CustomPaint += new System.Action<System.Windows.Forms.PaintEventArgs>(this.grouperMessageFormat_CustomPaint);
            // 
            // cboMessageFormat
            // 
            this.cboMessageFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMessageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMessageFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMessageFormat.FormattingEnabled = true;
            this.cboMessageFormat.Location = new System.Drawing.Point(16, 32);
            this.cboMessageFormat.Name = "cboMessageFormat";
            this.cboMessageFormat.Size = new System.Drawing.Size(384, 21);
            this.cboMessageFormat.TabIndex = 0;
            this.cboMessageFormat.SelectedIndexChanged += new System.EventHandler(this.cboMessageFormat_SelectedIndexChanged);
            // 
            // grouperMessageText
            // 
            this.grouperMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperMessageText.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperMessageText.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperMessageText.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperMessageText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageText.BorderThickness = 1F;
            this.grouperMessageText.Controls.Add(this.txtMessageText);
            this.grouperMessageText.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperMessageText.ForeColor = System.Drawing.Color.White;
            this.grouperMessageText.GroupImage = null;
            this.grouperMessageText.GroupTitle = "Message Text";
            this.grouperMessageText.Location = new System.Drawing.Point(17, 10);
            this.grouperMessageText.Name = "grouperMessageText";
            this.grouperMessageText.Padding = new System.Windows.Forms.Padding(20);
            this.grouperMessageText.PaintGroupBox = true;
            this.grouperMessageText.RoundCorners = 4;
            this.grouperMessageText.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperMessageText.ShadowControl = false;
            this.grouperMessageText.ShadowThickness = 1;
            this.grouperMessageText.Size = new System.Drawing.Size(416, 240);
            this.grouperMessageText.TabIndex = 0;
            // 
            // txtMessageText
            // 
            this.txtMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageText.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.txtMessageText.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.txtMessageText.BackBrush = null;
            this.txtMessageText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageText.CharHeight = 14;
            this.txtMessageText.CharWidth = 8;
            this.txtMessageText.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessageText.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtMessageText.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.txtMessageText.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMessageText.IsReplaceMode = false;
            this.txtMessageText.Location = new System.Drawing.Point(16, 32);
            this.txtMessageText.Name = "txtMessageText";
            this.txtMessageText.Paddings = new System.Windows.Forms.Padding(0);
            this.txtMessageText.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.txtMessageText.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("txtMessageText.ServiceColors")));
            this.txtMessageText.Size = new System.Drawing.Size(384, 192);
            this.txtMessageText.TabIndex = 0;
            this.txtMessageText.Zoom = 100;
            this.txtMessageText.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtMessageText_TextChanged);
            // 
            // grouperMessageFiles
            // 
            this.grouperMessageFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperMessageFiles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperMessageFiles.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperMessageFiles.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperMessageFiles.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageFiles.BorderThickness = 1F;
            this.grouperMessageFiles.Controls.Add(this.radioButtonBinaryFile);
            this.grouperMessageFiles.Controls.Add(this.radioButtonJsonTemplate);
            this.grouperMessageFiles.Controls.Add(this.radioButtonXmlTemplate);
            this.grouperMessageFiles.Controls.Add(this.radioButtonTextFile);
            this.grouperMessageFiles.Controls.Add(this.checkBoxFileName);
            this.grouperMessageFiles.Controls.Add(this.messageFileListView);
            this.grouperMessageFiles.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperMessageFiles.ForeColor = System.Drawing.Color.White;
            this.grouperMessageFiles.GroupImage = null;
            this.grouperMessageFiles.GroupTitle = "Message Files";
            this.grouperMessageFiles.Location = new System.Drawing.Point(16, 78);
            this.grouperMessageFiles.Name = "grouperMessageFiles";
            this.grouperMessageFiles.Padding = new System.Windows.Forms.Padding(20);
            this.grouperMessageFiles.PaintGroupBox = true;
            this.grouperMessageFiles.RoundCorners = 4;
            this.grouperMessageFiles.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperMessageFiles.ShadowControl = false;
            this.grouperMessageFiles.ShadowThickness = 1;
            this.grouperMessageFiles.Size = new System.Drawing.Size(416, 247);
            this.grouperMessageFiles.TabIndex = 1;
            this.grouperMessageFiles.CustomPaint += new System.Action<System.Windows.Forms.PaintEventArgs>(this.grouperMessageFiles_CustomPaint);
            // 
            // radioButtonBinaryFile
            // 
            this.radioButtonBinaryFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonBinaryFile.AutoSize = true;
            this.radioButtonBinaryFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonBinaryFile.Location = new System.Drawing.Point(104, 216);
            this.radioButtonBinaryFile.Name = "radioButtonBinaryFile";
            this.radioButtonBinaryFile.Size = new System.Drawing.Size(73, 17);
            this.radioButtonBinaryFile.TabIndex = 3;
            this.radioButtonBinaryFile.Text = "Binary File";
            this.radioButtonBinaryFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonJsonTemplate
            // 
            this.radioButtonJsonTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonJsonTemplate.AutoSize = true;
            this.radioButtonJsonTemplate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonJsonTemplate.Location = new System.Drawing.Point(192, 216);
            this.radioButtonJsonTemplate.Name = "radioButtonJsonTemplate";
            this.radioButtonJsonTemplate.Size = new System.Drawing.Size(100, 17);
            this.radioButtonJsonTemplate.TabIndex = 4;
            this.radioButtonJsonTemplate.TabStop = true;
            this.radioButtonJsonTemplate.Text = "JSON Template";
            this.radioButtonJsonTemplate.UseVisualStyleBackColor = true;
            // 
            // radioButtonXmlTemplate
            // 
            this.radioButtonXmlTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButtonXmlTemplate.AutoSize = true;
            this.radioButtonXmlTemplate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonXmlTemplate.Location = new System.Drawing.Point(305, 216);
            this.radioButtonXmlTemplate.Name = "radioButtonXmlTemplate";
            this.radioButtonXmlTemplate.Size = new System.Drawing.Size(94, 17);
            this.radioButtonXmlTemplate.TabIndex = 5;
            this.radioButtonXmlTemplate.TabStop = true;
            this.radioButtonXmlTemplate.Text = "XML Template";
            this.radioButtonXmlTemplate.UseVisualStyleBackColor = true;
            // 
            // radioButtonTextFile
            // 
            this.radioButtonTextFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.radioButtonTextFile.AutoSize = true;
            this.radioButtonTextFile.Checked = true;
            this.radioButtonTextFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radioButtonTextFile.Location = new System.Drawing.Point(16, 216);
            this.radioButtonTextFile.Name = "radioButtonTextFile";
            this.radioButtonTextFile.Size = new System.Drawing.Size(65, 17);
            this.radioButtonTextFile.TabIndex = 2;
            this.radioButtonTextFile.TabStop = true;
            this.radioButtonTextFile.Text = "Text File";
            this.radioButtonTextFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxFileName
            // 
            this.checkBoxFileName.AutoSize = true;
            this.checkBoxFileName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxFileName.Location = new System.Drawing.Point(22, 35);
            this.checkBoxFileName.Name = "checkBoxFileName";
            this.checkBoxFileName.Size = new System.Drawing.Size(54, 17);
            this.checkBoxFileName.TabIndex = 1;
            this.checkBoxFileName.Text = "Name";
            this.checkBoxFileName.UseVisualStyleBackColor = true;
            this.checkBoxFileName.CheckedChanged += new System.EventHandler(this.checkBoxFileName_CheckedChanged);
            // 
            // messageFileListView
            // 
            this.messageFileListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageFileListView.CheckBoxes = true;
            this.messageFileListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.sizeColumnHeader});
            this.messageFileListView.FullRowSelect = true;
            this.messageFileListView.HideSelection = false;
            this.messageFileListView.Location = new System.Drawing.Point(16, 32);
            this.messageFileListView.Name = "messageFileListView";
            this.messageFileListView.OwnerDraw = true;
            this.messageFileListView.Size = new System.Drawing.Size(384, 176);
            this.messageFileListView.TabIndex = 0;
            this.messageFileListView.UseCompatibleStateImageBehavior = false;
            this.messageFileListView.View = System.Windows.Forms.View.Details;
            this.messageFileListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.messageFileListView_DrawColumnHeader);
            this.messageFileListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.messageFileListView_DrawItem);
            this.messageFileListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.messageFileListView_DrawSubItem);
            this.messageFileListView.Resize += new System.EventHandler(this.messageFileListView_Resize);
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 200;
            // 
            // sizeColumnHeader
            // 
            this.sizeColumnHeader.Text = "Size";
            this.sizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.sizeColumnHeader.Width = 70;
            // 
            // grouperBrokeredMessageGenerator
            // 
            this.grouperBrokeredMessageGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperBrokeredMessageGenerator.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperBrokeredMessageGenerator.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperBrokeredMessageGenerator.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperBrokeredMessageGenerator.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperBrokeredMessageGenerator.BorderThickness = 1F;
            this.grouperBrokeredMessageGenerator.Controls.Add(this.lblRegistration);
            this.grouperBrokeredMessageGenerator.Controls.Add(this.brokeredMessageGeneratorPropertyGrid);
            this.grouperBrokeredMessageGenerator.Controls.Add(this.cboBrokeredMessageGeneratorType);
            this.grouperBrokeredMessageGenerator.Controls.Add(this.lblRegistrationType);
            this.grouperBrokeredMessageGenerator.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperBrokeredMessageGenerator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperBrokeredMessageGenerator.ForeColor = System.Drawing.Color.White;
            this.grouperBrokeredMessageGenerator.GroupImage = null;
            this.grouperBrokeredMessageGenerator.GroupTitle = "Message Generator";
            this.grouperBrokeredMessageGenerator.Location = new System.Drawing.Point(17, 14);
            this.grouperBrokeredMessageGenerator.Name = "grouperBrokeredMessageGenerator";
            this.grouperBrokeredMessageGenerator.Padding = new System.Windows.Forms.Padding(20);
            this.grouperBrokeredMessageGenerator.PaintGroupBox = true;
            this.grouperBrokeredMessageGenerator.RoundCorners = 4;
            this.grouperBrokeredMessageGenerator.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperBrokeredMessageGenerator.ShadowControl = false;
            this.grouperBrokeredMessageGenerator.ShadowThickness = 1;
            this.grouperBrokeredMessageGenerator.Size = new System.Drawing.Size(416, 310);
            this.grouperBrokeredMessageGenerator.TabIndex = 0;
            this.grouperBrokeredMessageGenerator.CustomPaint += new System.Action<System.Windows.Forms.PaintEventArgs>(this.grouperBrokeredMessageGenerator_CustomPaint);
            // 
            // lblRegistration
            // 
            this.lblRegistration.AutoSize = true;
            this.lblRegistration.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRegistration.Location = new System.Drawing.Point(16, 80);
            this.lblRegistration.Name = "lblRegistration";
            this.lblRegistration.Size = new System.Drawing.Size(57, 13);
            this.lblRegistration.TabIndex = 2;
            this.lblRegistration.Text = "Properties:";
            // 
            // brokeredMessageGeneratorPropertyGrid
            // 
            this.brokeredMessageGeneratorPropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.brokeredMessageGeneratorPropertyGrid.BackColor = System.Drawing.SystemColors.Window;
            this.brokeredMessageGeneratorPropertyGrid.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.brokeredMessageGeneratorPropertyGrid.HelpVisible = false;
            this.brokeredMessageGeneratorPropertyGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.brokeredMessageGeneratorPropertyGrid.Location = new System.Drawing.Point(16, 96);
            this.brokeredMessageGeneratorPropertyGrid.Name = "brokeredMessageGeneratorPropertyGrid";
            this.brokeredMessageGeneratorPropertyGrid.Size = new System.Drawing.Size(384, 198);
            this.brokeredMessageGeneratorPropertyGrid.TabIndex = 3;
            this.brokeredMessageGeneratorPropertyGrid.ToolbarVisible = false;
            // 
            // cboBrokeredMessageGeneratorType
            // 
            this.cboBrokeredMessageGeneratorType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBrokeredMessageGeneratorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBrokeredMessageGeneratorType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBrokeredMessageGeneratorType.FormattingEnabled = true;
            this.cboBrokeredMessageGeneratorType.Location = new System.Drawing.Point(16, 48);
            this.cboBrokeredMessageGeneratorType.Name = "cboBrokeredMessageGeneratorType";
            this.cboBrokeredMessageGeneratorType.Size = new System.Drawing.Size(384, 21);
            this.cboBrokeredMessageGeneratorType.TabIndex = 1;
            this.cboBrokeredMessageGeneratorType.SelectedIndexChanged += new System.EventHandler(this.cboBrokeredMessageGeneratorType_SelectedIndexChanged);
            // 
            // lblRegistrationType
            // 
            this.lblRegistrationType.AutoSize = true;
            this.lblRegistrationType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRegistrationType.Location = new System.Drawing.Point(16, 32);
            this.lblRegistrationType.Name = "lblRegistrationType";
            this.lblRegistrationType.Size = new System.Drawing.Size(130, 13);
            this.lblRegistrationType.TabIndex = 0;
            this.lblRegistrationType.Text = "Message Generator Type:";
            // 
            // grouperMessageProperties
            // 
            this.grouperMessageProperties.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperMessageProperties.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperMessageProperties.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperMessageProperties.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageProperties.BorderThickness = 1F;
            this.grouperMessageProperties.Controls.Add(this.propertiesDataGridView);
            this.grouperMessageProperties.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessageProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grouperMessageProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperMessageProperties.ForeColor = System.Drawing.Color.White;
            this.grouperMessageProperties.GroupImage = null;
            this.grouperMessageProperties.GroupTitle = "Message Properties";
            this.grouperMessageProperties.Location = new System.Drawing.Point(0, 0);
            this.grouperMessageProperties.Name = "grouperMessageProperties";
            this.grouperMessageProperties.Padding = new System.Windows.Forms.Padding(20);
            this.grouperMessageProperties.PaintGroupBox = true;
            this.grouperMessageProperties.RoundCorners = 4;
            this.grouperMessageProperties.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperMessageProperties.ShadowControl = false;
            this.grouperMessageProperties.ShadowThickness = 1;
            this.grouperMessageProperties.Size = new System.Drawing.Size(461, 366);
            this.grouperMessageProperties.TabIndex = 0;
            this.grouperMessageProperties.CustomPaint += new System.Action<System.Windows.Forms.PaintEventArgs>(this.grouperMessageProperties_CustomPaint);
            // 
            // propertiesDataGridView
            // 
            this.propertiesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertiesDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.propertiesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.propertiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.propertiesDataGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.propertiesDataGridView.Location = new System.Drawing.Point(16, 32);
            this.propertiesDataGridView.Name = "propertiesDataGridView";
            this.propertiesDataGridView.RowHeadersWidth = 20;
            this.propertiesDataGridView.Size = new System.Drawing.Size(429, 318);
            this.propertiesDataGridView.TabIndex = 0;
            this.propertiesDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.propertiesDataGridView_DataError);
            this.propertiesDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.propertiesDataGridView_RowsAdded);
            this.propertiesDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.propertiesDataGridView_RowsRemoved);
            this.propertiesDataGridView.Resize += new System.EventHandler(this.propertiesDataGridView_Resize);
            // 
            // grouperSender
            // 
            this.grouperSender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperSender.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperSender.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperSender.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperSender.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSender.BorderThickness = 1F;
            this.grouperSender.Controls.Add(this.tableLayoutPanel3);
            this.grouperSender.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperSender.ForeColor = System.Drawing.Color.White;
            this.grouperSender.GroupImage = null;
            this.grouperSender.GroupTitle = "Configuration";
            this.grouperSender.Location = new System.Drawing.Point(624, 24);
            this.grouperSender.Name = "grouperSender";
            this.grouperSender.Padding = new System.Windows.Forms.Padding(20);
            this.grouperSender.PaintGroupBox = true;
            this.grouperSender.RoundCorners = 4;
            this.grouperSender.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperSender.ShadowControl = false;
            this.grouperSender.ShadowThickness = 1;
            this.grouperSender.Size = new System.Drawing.Size(328, 350);
            this.grouperSender.TabIndex = 1;
            this.grouperSender.CustomPaint += new System.Action<System.Windows.Forms.PaintEventArgs>(this.grouperSender_CustomPaint);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSenderUseTransaction, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cboSenderInspector, 1, 9);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSendNewFactory, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.lblSenderInspector, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSenderCommitTransaction, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtSendBatchSize, 3, 8);
            this.tableLayoutPanel3.Controls.Add(this.lblSendBatchSize, 2, 8);
            this.tableLayoutPanel3.Controls.Add(this.txtSendTaskCount, 3, 7);
            this.tableLayoutPanel3.Controls.Add(this.txtMessageCount, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.cboBodyType, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.lblBody, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxEnableSenderLogging, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSenderVerboseLogging, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSenderEnableStatistics, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtSenderThinkTime, 3, 5);
            this.tableLayoutPanel3.Controls.Add(this.lblSendTaskCount, 2, 7);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSenderEnableGraph, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblSenderThinkTime, 2, 5);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxOneSessionPerTask, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblCount, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSenderThinkTime, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxUpdateMessageId, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxAddMessageNumber, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxSendBatch, 2, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(9, 35);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 10;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(310, 310);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // checkBoxSenderUseTransaction
            // 
            this.checkBoxSenderUseTransaction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSenderUseTransaction.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSenderUseTransaction, 2);
            this.checkBoxSenderUseTransaction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSenderUseTransaction.Location = new System.Drawing.Point(3, 7);
            this.checkBoxSenderUseTransaction.Name = "checkBoxSenderUseTransaction";
            this.checkBoxSenderUseTransaction.Size = new System.Drawing.Size(104, 17);
            this.checkBoxSenderUseTransaction.TabIndex = 0;
            this.checkBoxSenderUseTransaction.Text = "Use Transaction";
            this.checkBoxSenderUseTransaction.UseVisualStyleBackColor = true;
            this.checkBoxSenderUseTransaction.CheckedChanged += new System.EventHandler(this.checkBoxSenderUseTransaction_CheckedChanged);
            // 
            // cboSenderInspector
            // 
            this.cboSenderInspector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.SetColumnSpan(this.cboSenderInspector, 3);
            this.cboSenderInspector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSenderInspector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSenderInspector.FormattingEnabled = true;
            this.cboSenderInspector.Location = new System.Drawing.Point(80, 284);
            this.cboSenderInspector.Name = "cboSenderInspector";
            this.cboSenderInspector.Size = new System.Drawing.Size(227, 21);
            this.cboSenderInspector.TabIndex = 23;
            // 
            // checkBoxSendNewFactory
            // 
            this.checkBoxSendNewFactory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSendNewFactory.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSendNewFactory, 4);
            this.checkBoxSendNewFactory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSendNewFactory.Location = new System.Drawing.Point(3, 193);
            this.checkBoxSendNewFactory.Name = "checkBoxSendNewFactory";
            this.checkBoxSendNewFactory.Size = new System.Drawing.Size(254, 17);
            this.checkBoxSendNewFactory.TabIndex = 13;
            this.checkBoxSendNewFactory.Text = "Create New Messaging Factory for Each Sender";
            this.checkBoxSendNewFactory.UseVisualStyleBackColor = true;
            // 
            // lblSenderInspector
            // 
            this.lblSenderInspector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSenderInspector.AutoSize = true;
            this.lblSenderInspector.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSenderInspector.Location = new System.Drawing.Point(3, 281);
            this.lblSenderInspector.Name = "lblSenderInspector";
            this.lblSenderInspector.Size = new System.Drawing.Size(71, 26);
            this.lblSenderInspector.TabIndex = 22;
            this.lblSenderInspector.Text = "Msg Inspector:";
            // 
            // checkBoxSenderCommitTransaction
            // 
            this.checkBoxSenderCommitTransaction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSenderCommitTransaction.AutoSize = true;
            this.checkBoxSenderCommitTransaction.Checked = true;
            this.checkBoxSenderCommitTransaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSenderCommitTransaction, 2);
            this.checkBoxSenderCommitTransaction.Enabled = false;
            this.checkBoxSenderCommitTransaction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSenderCommitTransaction.Location = new System.Drawing.Point(157, 7);
            this.checkBoxSenderCommitTransaction.Name = "checkBoxSenderCommitTransaction";
            this.checkBoxSenderCommitTransaction.Size = new System.Drawing.Size(119, 17);
            this.checkBoxSenderCommitTransaction.TabIndex = 1;
            this.checkBoxSenderCommitTransaction.Text = "Commit Transaction";
            this.checkBoxSenderCommitTransaction.UseVisualStyleBackColor = true;
            // 
            // txtSendBatchSize
            // 
            this.txtSendBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendBatchSize.Location = new System.Drawing.Point(234, 253);
            this.txtSendBatchSize.Name = "txtSendBatchSize";
            this.txtSendBatchSize.Size = new System.Drawing.Size(73, 20);
            this.txtSendBatchSize.TabIndex = 21;
            this.txtSendBatchSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblSendBatchSize
            // 
            this.lblSendBatchSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSendBatchSize.AutoSize = true;
            this.lblSendBatchSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSendBatchSize.Location = new System.Drawing.Point(157, 257);
            this.lblSendBatchSize.Name = "lblSendBatchSize";
            this.lblSendBatchSize.Size = new System.Drawing.Size(61, 13);
            this.lblSendBatchSize.TabIndex = 20;
            this.lblSendBatchSize.Text = "Batch Size:";
            // 
            // txtSendTaskCount
            // 
            this.txtSendTaskCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSendTaskCount.Location = new System.Drawing.Point(234, 222);
            this.txtSendTaskCount.Name = "txtSendTaskCount";
            this.txtSendTaskCount.Size = new System.Drawing.Size(73, 20);
            this.txtSendTaskCount.TabIndex = 17;
            this.txtSendTaskCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // txtMessageCount
            // 
            this.txtMessageCount.AllowDecimal = false;
            this.txtMessageCount.AllowNegative = false;
            this.txtMessageCount.AllowSpace = false;
            this.txtMessageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageCount.IsZeroWhenEmpty = false;
            this.txtMessageCount.Location = new System.Drawing.Point(80, 222);
            this.txtMessageCount.Name = "txtMessageCount";
            this.txtMessageCount.Size = new System.Drawing.Size(71, 20);
            this.txtMessageCount.TabIndex = 15;
            // 
            // cboBodyType
            // 
            this.cboBodyType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboBodyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBodyType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBodyType.FormattingEnabled = true;
            this.cboBodyType.Items.AddRange(new object[] {
            "Stream",
            "String",
            "WCF"});
            this.cboBodyType.Location = new System.Drawing.Point(80, 253);
            this.cboBodyType.Name = "cboBodyType";
            this.cboBodyType.Size = new System.Drawing.Size(71, 21);
            this.cboBodyType.TabIndex = 19;
            // 
            // lblBody
            // 
            this.lblBody.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBody.AutoSize = true;
            this.lblBody.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBody.Location = new System.Drawing.Point(3, 257);
            this.lblBody.Name = "lblBody";
            this.lblBody.Size = new System.Drawing.Size(61, 13);
            this.lblBody.TabIndex = 18;
            this.lblBody.Text = "Body Type:";
            // 
            // checkBoxEnableSenderLogging
            // 
            this.checkBoxEnableSenderLogging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxEnableSenderLogging.AutoSize = true;
            this.checkBoxEnableSenderLogging.Checked = true;
            this.checkBoxEnableSenderLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxEnableSenderLogging, 2);
            this.checkBoxEnableSenderLogging.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxEnableSenderLogging.Location = new System.Drawing.Point(3, 38);
            this.checkBoxEnableSenderLogging.Name = "checkBoxEnableSenderLogging";
            this.checkBoxEnableSenderLogging.Size = new System.Drawing.Size(100, 17);
            this.checkBoxEnableSenderLogging.TabIndex = 2;
            this.checkBoxEnableSenderLogging.Text = "Enable Logging";
            this.checkBoxEnableSenderLogging.UseVisualStyleBackColor = true;
            this.checkBoxEnableSenderLogging.CheckedChanged += new System.EventHandler(this.checkBoxEnableSenderLogging_CheckedChanged);
            // 
            // checkBoxSenderVerboseLogging
            // 
            this.checkBoxSenderVerboseLogging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSenderVerboseLogging.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSenderVerboseLogging, 2);
            this.checkBoxSenderVerboseLogging.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSenderVerboseLogging.Location = new System.Drawing.Point(157, 38);
            this.checkBoxSenderVerboseLogging.Name = "checkBoxSenderVerboseLogging";
            this.checkBoxSenderVerboseLogging.Size = new System.Drawing.Size(101, 17);
            this.checkBoxSenderVerboseLogging.TabIndex = 3;
            this.checkBoxSenderVerboseLogging.Text = "Enable Verbose";
            this.checkBoxSenderVerboseLogging.UseVisualStyleBackColor = true;
            // 
            // checkBoxSenderEnableStatistics
            // 
            this.checkBoxSenderEnableStatistics.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSenderEnableStatistics.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSenderEnableStatistics, 2);
            this.checkBoxSenderEnableStatistics.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSenderEnableStatistics.Location = new System.Drawing.Point(3, 69);
            this.checkBoxSenderEnableStatistics.Name = "checkBoxSenderEnableStatistics";
            this.checkBoxSenderEnableStatistics.Size = new System.Drawing.Size(104, 17);
            this.checkBoxSenderEnableStatistics.TabIndex = 4;
            this.checkBoxSenderEnableStatistics.Text = "Enable Statistics";
            this.checkBoxSenderEnableStatistics.UseVisualStyleBackColor = true;
            this.checkBoxSenderEnableStatistics.CheckedChanged += new System.EventHandler(this.checkBoxSenderEnableStatistics_CheckedChanged);
            // 
            // txtSenderThinkTime
            // 
            this.txtSenderThinkTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSenderThinkTime.Enabled = false;
            this.txtSenderThinkTime.Location = new System.Drawing.Point(234, 160);
            this.txtSenderThinkTime.Name = "txtSenderThinkTime";
            this.txtSenderThinkTime.Size = new System.Drawing.Size(73, 20);
            this.txtSenderThinkTime.TabIndex = 12;
            this.txtSenderThinkTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblSendTaskCount
            // 
            this.lblSendTaskCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSendTaskCount.AutoSize = true;
            this.lblSendTaskCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSendTaskCount.Location = new System.Drawing.Point(157, 226);
            this.lblSendTaskCount.Name = "lblSendTaskCount";
            this.lblSendTaskCount.Size = new System.Drawing.Size(65, 13);
            this.lblSendTaskCount.TabIndex = 16;
            this.lblSendTaskCount.Text = "Task Count:";
            // 
            // checkBoxSenderEnableGraph
            // 
            this.checkBoxSenderEnableGraph.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSenderEnableGraph.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSenderEnableGraph, 2);
            this.checkBoxSenderEnableGraph.Enabled = false;
            this.checkBoxSenderEnableGraph.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSenderEnableGraph.Location = new System.Drawing.Point(157, 69);
            this.checkBoxSenderEnableGraph.Name = "checkBoxSenderEnableGraph";
            this.checkBoxSenderEnableGraph.Size = new System.Drawing.Size(91, 17);
            this.checkBoxSenderEnableGraph.TabIndex = 5;
            this.checkBoxSenderEnableGraph.Text = "Enable Graph";
            this.checkBoxSenderEnableGraph.UseVisualStyleBackColor = true;
            // 
            // lblSenderThinkTime
            // 
            this.lblSenderThinkTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSenderThinkTime.AutoSize = true;
            this.lblSenderThinkTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSenderThinkTime.Location = new System.Drawing.Point(157, 164);
            this.lblSenderThinkTime.Name = "lblSenderThinkTime";
            this.lblSenderThinkTime.Size = new System.Drawing.Size(67, 13);
            this.lblSenderThinkTime.TabIndex = 11;
            this.lblSenderThinkTime.Text = "Interval (ms):";
            // 
            // checkBoxOneSessionPerTask
            // 
            this.checkBoxOneSessionPerTask.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxOneSessionPerTask.AutoSize = true;
            this.checkBoxOneSessionPerTask.Checked = true;
            this.checkBoxOneSessionPerTask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxOneSessionPerTask, 2);
            this.checkBoxOneSessionPerTask.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxOneSessionPerTask.Location = new System.Drawing.Point(3, 100);
            this.checkBoxOneSessionPerTask.Name = "checkBoxOneSessionPerTask";
            this.checkBoxOneSessionPerTask.Size = new System.Drawing.Size(115, 17);
            this.checkBoxOneSessionPerTask.TabIndex = 6;
            this.checkBoxOneSessionPerTask.Text = "One Session/Task";
            this.checkBoxOneSessionPerTask.UseVisualStyleBackColor = true;
            this.checkBoxOneSessionPerTask.CheckedChanged += new System.EventHandler(this.checkBoxOneSessionPerTask_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCount.Location = new System.Drawing.Point(3, 219);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(71, 26);
            this.lblCount.TabIndex = 14;
            this.lblCount.Text = "Message Count:";
            // 
            // checkBoxSenderThinkTime
            // 
            this.checkBoxSenderThinkTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSenderThinkTime.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSenderThinkTime, 2);
            this.checkBoxSenderThinkTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSenderThinkTime.Location = new System.Drawing.Point(3, 162);
            this.checkBoxSenderThinkTime.Name = "checkBoxSenderThinkTime";
            this.checkBoxSenderThinkTime.Size = new System.Drawing.Size(101, 17);
            this.checkBoxSenderThinkTime.TabIndex = 10;
            this.checkBoxSenderThinkTime.Text = "Use Think Time";
            this.checkBoxSenderThinkTime.UseVisualStyleBackColor = true;
            this.checkBoxSenderThinkTime.CheckedChanged += new System.EventHandler(this.checkBoxSenderThinkTime_CheckedChanged);
            // 
            // checkBoxUpdateMessageId
            // 
            this.checkBoxUpdateMessageId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxUpdateMessageId.AutoSize = true;
            this.checkBoxUpdateMessageId.Checked = true;
            this.checkBoxUpdateMessageId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxUpdateMessageId, 2);
            this.checkBoxUpdateMessageId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxUpdateMessageId.Location = new System.Drawing.Point(157, 100);
            this.checkBoxUpdateMessageId.Name = "checkBoxUpdateMessageId";
            this.checkBoxUpdateMessageId.Size = new System.Drawing.Size(116, 17);
            this.checkBoxUpdateMessageId.TabIndex = 7;
            this.checkBoxUpdateMessageId.Text = "Update MessageId";
            this.checkBoxUpdateMessageId.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddMessageNumber
            // 
            this.checkBoxAddMessageNumber.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxAddMessageNumber.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxAddMessageNumber, 2);
            this.checkBoxAddMessageNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxAddMessageNumber.Location = new System.Drawing.Point(3, 131);
            this.checkBoxAddMessageNumber.Name = "checkBoxAddMessageNumber";
            this.checkBoxAddMessageNumber.Size = new System.Drawing.Size(85, 17);
            this.checkBoxAddMessageNumber.TabIndex = 8;
            this.checkBoxAddMessageNumber.Text = "Add Number";
            this.checkBoxAddMessageNumber.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendBatch
            // 
            this.checkBoxSendBatch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxSendBatch.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxSendBatch, 2);
            this.checkBoxSendBatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxSendBatch.Location = new System.Drawing.Point(157, 131);
            this.checkBoxSendBatch.Name = "checkBoxSendBatch";
            this.checkBoxSendBatch.Size = new System.Drawing.Size(82, 17);
            this.checkBoxSendBatch.TabIndex = 9;
            this.checkBoxSendBatch.Text = "Send Batch";
            this.checkBoxSendBatch.UseVisualStyleBackColor = true;
            this.checkBoxSendBatch.CheckedChanged += new System.EventHandler(this.checkBoxSendBatch_CheckedChanged);
            // 
            // grouperMessage
            // 
            this.grouperMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperMessage.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperMessage.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperMessage.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperMessage.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessage.BorderThickness = 1F;
            this.grouperMessage.Controls.Add(this.tableLayoutPanel1);
            this.grouperMessage.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperMessage.ForeColor = System.Drawing.Color.White;
            this.grouperMessage.GroupImage = null;
            this.grouperMessage.GroupTitle = "Message";
            this.grouperMessage.Location = new System.Drawing.Point(16, 24);
            this.grouperMessage.Name = "grouperMessage";
            this.grouperMessage.Padding = new System.Windows.Forms.Padding(20);
            this.grouperMessage.PaintGroupBox = true;
            this.grouperMessage.RoundCorners = 4;
            this.grouperMessage.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperMessage.ShadowControl = false;
            this.grouperMessage.ShadowThickness = 1;
            this.grouperMessage.Size = new System.Drawing.Size(592, 350);
            this.grouperMessage.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxForcePersistence, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblForcePersistence, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtTimeToLive, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtContentType, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtReplyToSessionId, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblContentType, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblMessageId, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeToLive, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCorrelationId, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSessionId, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblReplyToSessionId, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtScheduledEnqueueTimeUtc, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtTo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblReplyTo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblScheduledEnqueueTimeUtc, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblCorrelationId, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtReplyTo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSessionId, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMessageId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtLabel, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(18, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 188);
            this.tableLayoutPanel1.TabIndex = 22;
            // 
            // checkBoxForcePersistence
            // 
            this.checkBoxForcePersistence.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxForcePersistence.AutoSize = true;
            this.checkBoxForcePersistence.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxForcePersistence.Location = new System.Drawing.Point(114, 164);
            this.checkBoxForcePersistence.Name = "checkBoxForcePersistence";
            this.checkBoxForcePersistence.Size = new System.Drawing.Size(15, 14);
            this.checkBoxForcePersistence.TabIndex = 11;
            this.checkBoxForcePersistence.UseVisualStyleBackColor = true;
            // 
            // lblForcePersistence
            // 
            this.lblForcePersistence.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblForcePersistence.AutoSize = true;
            this.lblForcePersistence.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblForcePersistence.Location = new System.Drawing.Point(3, 165);
            this.lblForcePersistence.Name = "lblForcePersistence";
            this.lblForcePersistence.Size = new System.Drawing.Size(95, 13);
            this.lblForcePersistence.TabIndex = 10;
            this.lblForcePersistence.Text = "Force Persistence:";
            // 
            // txtTimeToLive
            // 
            this.txtTimeToLive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTimeToLive.Location = new System.Drawing.Point(392, 129);
            this.txtTimeToLive.Name = "txtTimeToLive";
            this.txtTimeToLive.Size = new System.Drawing.Size(162, 20);
            this.txtTimeToLive.TabIndex = 21;
            this.txtTimeToLive.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // txtContentType
            // 
            this.txtContentType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtContentType.Location = new System.Drawing.Point(392, 67);
            this.txtContentType.Name = "txtContentType";
            this.txtContentType.Size = new System.Drawing.Size(162, 20);
            this.txtContentType.TabIndex = 17;
            this.txtContentType.TextChanged += new System.EventHandler(this.txtContentType_TextChanged);
            // 
            // txtReplyToSessionId
            // 
            this.txtReplyToSessionId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtReplyToSessionId.Location = new System.Drawing.Point(392, 98);
            this.txtReplyToSessionId.Name = "txtReplyToSessionId";
            this.txtReplyToSessionId.Size = new System.Drawing.Size(162, 20);
            this.txtReplyToSessionId.TabIndex = 19;
            // 
            // lblContentType
            // 
            this.lblContentType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblContentType.AutoSize = true;
            this.lblContentType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblContentType.Location = new System.Drawing.Point(281, 71);
            this.lblContentType.Name = "lblContentType";
            this.lblContentType.Size = new System.Drawing.Size(71, 13);
            this.lblContentType.TabIndex = 16;
            this.lblContentType.Text = "ContentType:";
            // 
            // lblMessageId
            // 
            this.lblMessageId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMessageId.AutoSize = true;
            this.lblMessageId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMessageId.Location = new System.Drawing.Point(3, 9);
            this.lblMessageId.Name = "lblMessageId";
            this.lblMessageId.Size = new System.Drawing.Size(62, 13);
            this.lblMessageId.TabIndex = 1;
            this.lblMessageId.Text = "MessageId:";
            // 
            // lblTimeToLive
            // 
            this.lblTimeToLive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTimeToLive.AutoSize = true;
            this.lblTimeToLive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTimeToLive.Location = new System.Drawing.Point(281, 133);
            this.lblTimeToLive.Name = "lblTimeToLive";
            this.lblTimeToLive.Size = new System.Drawing.Size(80, 13);
            this.lblTimeToLive.TabIndex = 20;
            this.lblTimeToLive.Text = "TimeToLive (s):";
            // 
            // txtCorrelationId
            // 
            this.txtCorrelationId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtCorrelationId.Location = new System.Drawing.Point(392, 36);
            this.txtCorrelationId.Name = "txtCorrelationId";
            this.txtCorrelationId.Size = new System.Drawing.Size(162, 20);
            this.txtCorrelationId.TabIndex = 15;
            // 
            // lblTo
            // 
            this.lblTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTo.AutoSize = true;
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTo.Location = new System.Drawing.Point(3, 40);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To:";
            // 
            // txtSessionId
            // 
            this.txtSessionId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSessionId.Enabled = false;
            this.txtSessionId.Location = new System.Drawing.Point(392, 5);
            this.txtSessionId.Name = "txtSessionId";
            this.txtSessionId.Size = new System.Drawing.Size(162, 20);
            this.txtSessionId.TabIndex = 13;
            // 
            // lblReplyToSessionId
            // 
            this.lblReplyToSessionId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReplyToSessionId.AutoSize = true;
            this.lblReplyToSessionId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReplyToSessionId.Location = new System.Drawing.Point(281, 102);
            this.lblReplyToSessionId.Name = "lblReplyToSessionId";
            this.lblReplyToSessionId.Size = new System.Drawing.Size(96, 13);
            this.lblReplyToSessionId.TabIndex = 18;
            this.lblReplyToSessionId.Text = "ReplyToSessionId:";
            // 
            // txtScheduledEnqueueTimeUtc
            // 
            this.txtScheduledEnqueueTimeUtc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtScheduledEnqueueTimeUtc.Location = new System.Drawing.Point(114, 129);
            this.txtScheduledEnqueueTimeUtc.Name = "txtScheduledEnqueueTimeUtc";
            this.txtScheduledEnqueueTimeUtc.Size = new System.Drawing.Size(161, 20);
            this.txtScheduledEnqueueTimeUtc.TabIndex = 9;
            this.txtScheduledEnqueueTimeUtc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // txtTo
            // 
            this.txtTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTo.Location = new System.Drawing.Point(114, 36);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(161, 20);
            this.txtTo.TabIndex = 3;
            // 
            // lblReplyTo
            // 
            this.lblReplyTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReplyTo.AutoSize = true;
            this.lblReplyTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReplyTo.Location = new System.Drawing.Point(3, 71);
            this.lblReplyTo.Name = "lblReplyTo";
            this.lblReplyTo.Size = new System.Drawing.Size(50, 13);
            this.lblReplyTo.TabIndex = 4;
            this.lblReplyTo.Text = "ReplyTo:";
            // 
            // lblLabel
            // 
            this.lblLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLabel.AutoSize = true;
            this.lblLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLabel.Location = new System.Drawing.Point(3, 102);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(36, 13);
            this.lblLabel.TabIndex = 6;
            this.lblLabel.Text = "Label:";
            // 
            // lblScheduledEnqueueTimeUtc
            // 
            this.lblScheduledEnqueueTimeUtc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblScheduledEnqueueTimeUtc.AutoSize = true;
            this.lblScheduledEnqueueTimeUtc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblScheduledEnqueueTimeUtc.Location = new System.Drawing.Point(3, 133);
            this.lblScheduledEnqueueTimeUtc.Name = "lblScheduledEnqueueTimeUtc";
            this.lblScheduledEnqueueTimeUtc.Size = new System.Drawing.Size(81, 13);
            this.lblScheduledEnqueueTimeUtc.TabIndex = 8;
            this.lblScheduledEnqueueTimeUtc.Text = "Schedule (sec):";
            // 
            // lblCorrelationId
            // 
            this.lblCorrelationId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCorrelationId.AutoSize = true;
            this.lblCorrelationId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCorrelationId.Location = new System.Drawing.Point(281, 40);
            this.lblCorrelationId.Name = "lblCorrelationId";
            this.lblCorrelationId.Size = new System.Drawing.Size(69, 13);
            this.lblCorrelationId.TabIndex = 14;
            this.lblCorrelationId.Text = "CorrelationId:";
            // 
            // txtReplyTo
            // 
            this.txtReplyTo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtReplyTo.Location = new System.Drawing.Point(114, 67);
            this.txtReplyTo.Name = "txtReplyTo";
            this.txtReplyTo.Size = new System.Drawing.Size(161, 20);
            this.txtReplyTo.TabIndex = 5;
            // 
            // lblSessionId
            // 
            this.lblSessionId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSessionId.AutoSize = true;
            this.lblSessionId.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSessionId.Location = new System.Drawing.Point(281, 9);
            this.lblSessionId.Name = "lblSessionId";
            this.lblSessionId.Size = new System.Drawing.Size(56, 13);
            this.lblSessionId.TabIndex = 12;
            this.lblSessionId.Text = "SessionId:";
            // 
            // txtMessageId
            // 
            this.txtMessageId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtMessageId.Location = new System.Drawing.Point(114, 5);
            this.txtMessageId.Name = "txtMessageId";
            this.txtMessageId.Size = new System.Drawing.Size(161, 20);
            this.txtMessageId.TabIndex = 1;
            // 
            // txtLabel
            // 
            this.txtLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtLabel.Location = new System.Drawing.Point(114, 98);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(161, 20);
            this.txtLabel.TabIndex = 7;
            this.txtLabel.TextChanged += new System.EventHandler(this.txtLabel_TextChanged);
            // 
            // grouperReceiver
            // 
            this.grouperReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperReceiver.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperReceiver.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperReceiver.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperReceiver.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperReceiver.BorderThickness = 1F;
            this.grouperReceiver.Controls.Add(this.tableLayoutPanel9);
            this.grouperReceiver.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperReceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperReceiver.ForeColor = System.Drawing.Color.White;
            this.grouperReceiver.GroupImage = null;
            this.grouperReceiver.GroupTitle = "Configuration";
            this.grouperReceiver.Location = new System.Drawing.Point(16, 24);
            this.grouperReceiver.Name = "grouperReceiver";
            this.grouperReceiver.Padding = new System.Windows.Forms.Padding(20);
            this.grouperReceiver.PaintGroupBox = true;
            this.grouperReceiver.RoundCorners = 4;
            this.grouperReceiver.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperReceiver.ShadowControl = false;
            this.grouperReceiver.ShadowThickness = 1;
            this.grouperReceiver.Size = new System.Drawing.Size(936, 350);
            this.grouperReceiver.TabIndex = 15;
            this.grouperReceiver.CustomPaint += new System.Action<System.Windows.Forms.PaintEventArgs>(this.grouperReceiver_CustomPaint);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 8;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.686077F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.31605F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.86257F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.31605F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.18319F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.31605F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.7F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.62F));
            this.tableLayoutPanel9.Controls.Add(this.flowLayoutPanel2, 6, 6);
            this.tableLayoutPanel9.Controls.Add(this.lblReceiveTaskCount, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReceiveNewFactory, 6, 7);
            this.tableLayoutPanel9.Controls.Add(this.txtReceiveTaskCount, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxDeferMessage, 7, 4);
            this.tableLayoutPanel9.Controls.Add(this.lblServerWaitTime, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxCompleteReceive, 7, 3);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReceiverEnableGraph, 7, 2);
            this.tableLayoutPanel9.Controls.Add(this.txtReceiveTimeout, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblPrefetchCount, 4, 0);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReceiverVerboseLogging, 7, 1);
            this.tableLayoutPanel9.Controls.Add(this.txtPrefetchCount, 5, 0);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReceiverCommitTransaction, 7, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblReceiveBatchSize, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReceiveBatch, 6, 3);
            this.tableLayoutPanel9.Controls.Add(this.cboSubscriptions, 1, 9);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReceiverUseTransaction, 6, 0);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReadFromDeadLetter, 6, 5);
            this.tableLayoutPanel9.Controls.Add(this.txtFilterExpression, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxMoveToDeadLetter, 6, 4);
            this.tableLayoutPanel9.Controls.Add(this.lblSubscription, 0, 9);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxReceiverEnableStatistics, 6, 2);
            this.tableLayoutPanel9.Controls.Add(this.txtServerTimeout, 3, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblFilterExpr, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.txtReceiveBatchSize, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.cboReceivedMode, 5, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblServerTimeout, 2, 1);
            this.tableLayoutPanel9.Controls.Add(this.checkBoxEnableReceiverLogging, 6, 1);
            this.tableLayoutPanel9.Controls.Add(this.label1, 4, 1);
            this.tableLayoutPanel9.Controls.Add(this.flowLayoutPanel1, 6, 8);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(18, 35);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 10;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(901, 313);
            this.tableLayoutPanel9.TabIndex = 150;
            // 
            // checkBoxReceiveNewFactory
            // 
            this.checkBoxReceiveNewFactory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiveNewFactory.AutoSize = true;
            this.tableLayoutPanel9.SetColumnSpan(this.checkBoxReceiveNewFactory, 2);
            this.checkBoxReceiveNewFactory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiveNewFactory.Location = new System.Drawing.Point(599, 224);
            this.checkBoxReceiveNewFactory.Name = "checkBoxReceiveNewFactory";
            this.checkBoxReceiveNewFactory.Size = new System.Drawing.Size(263, 17);
            this.checkBoxReceiveNewFactory.TabIndex = 149;
            this.checkBoxReceiveNewFactory.Text = "Create New Messaging Factory for Each Receiver";
            this.checkBoxReceiveNewFactory.UseVisualStyleBackColor = true;
            // 
            // txtFilterExpression
            // 
            this.txtFilterExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.SetColumnSpan(this.txtFilterExpression, 5);
            this.txtFilterExpression.Location = new System.Drawing.Point(81, 65);
            this.txtFilterExpression.Multiline = true;
            this.txtFilterExpression.Name = "txtFilterExpression";
            this.tableLayoutPanel9.SetRowSpan(this.txtFilterExpression, 7);
            this.txtFilterExpression.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFilterExpression.Size = new System.Drawing.Size(512, 211);
            this.txtFilterExpression.TabIndex = 131;
            this.txtFilterExpression.Text = "1=1";
            // 
            // cboSubscriptions
            // 
            this.cboSubscriptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.SetColumnSpan(this.cboSubscriptions, 5);
            this.cboSubscriptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubscriptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSubscriptions.FormattingEnabled = true;
            this.cboSubscriptions.Location = new System.Drawing.Point(81, 285);
            this.cboSubscriptions.Name = "cboSubscriptions";
            this.cboSubscriptions.Size = new System.Drawing.Size(512, 21);
            this.cboSubscriptions.TabIndex = 132;
            // 
            // checkBoxReadFromDeadLetter
            // 
            this.checkBoxReadFromDeadLetter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReadFromDeadLetter.AutoSize = true;
            this.tableLayoutPanel9.SetColumnSpan(this.checkBoxReadFromDeadLetter, 2);
            this.checkBoxReadFromDeadLetter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReadFromDeadLetter.Location = new System.Drawing.Point(599, 162);
            this.checkBoxReadFromDeadLetter.Name = "checkBoxReadFromDeadLetter";
            this.checkBoxReadFromDeadLetter.Size = new System.Drawing.Size(169, 17);
            this.checkBoxReadFromDeadLetter.TabIndex = 18;
            this.checkBoxReadFromDeadLetter.Text = "Read From DeadLetter Queue";
            this.checkBoxReadFromDeadLetter.UseVisualStyleBackColor = true;
            this.checkBoxReadFromDeadLetter.CheckedChanged += new System.EventHandler(this.checkBoxReadFromDeadLetter_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel9.SetColumnSpan(this.flowLayoutPanel2, 2);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxReceiverThinkTime);
            this.flowLayoutPanel2.Controls.Add(this.lblReceiverThinkTime);
            this.flowLayoutPanel2.Controls.Add(this.txtReceiverThinkTime);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(596, 189);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(296, 25);
            this.flowLayoutPanel2.TabIndex = 152;
            // 
            // checkBoxReceiverThinkTime
            // 
            this.checkBoxReceiverThinkTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiverThinkTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiverThinkTime.Location = new System.Drawing.Point(3, 3);
            this.checkBoxReceiverThinkTime.Name = "checkBoxReceiverThinkTime";
            this.checkBoxReceiverThinkTime.Size = new System.Drawing.Size(151, 19);
            this.checkBoxReceiverThinkTime.TabIndex = 144;
            this.checkBoxReceiverThinkTime.Text = "Use Think Time";
            this.checkBoxReceiverThinkTime.UseVisualStyleBackColor = true;
            this.checkBoxReceiverThinkTime.CheckedChanged += new System.EventHandler(this.checkBoxReceiverThinkTime_CheckedChanged);
            // 
            // lblReceiverThinkTime
            // 
            this.lblReceiverThinkTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReceiverThinkTime.AutoSize = true;
            this.lblReceiverThinkTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReceiverThinkTime.Location = new System.Drawing.Point(160, 6);
            this.lblReceiverThinkTime.Name = "lblReceiverThinkTime";
            this.lblReceiverThinkTime.Size = new System.Drawing.Size(67, 13);
            this.lblReceiverThinkTime.TabIndex = 146;
            this.lblReceiverThinkTime.Text = "Interval (ms):";
            // 
            // txtReceiverThinkTime
            // 
            this.txtReceiverThinkTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtReceiverThinkTime.Enabled = false;
            this.txtReceiverThinkTime.Location = new System.Drawing.Point(233, 3);
            this.txtReceiverThinkTime.Name = "txtReceiverThinkTime";
            this.txtReceiverThinkTime.Size = new System.Drawing.Size(55, 20);
            this.txtReceiverThinkTime.TabIndex = 145;
            // 
            // lblReceiveTaskCount
            // 
            this.lblReceiveTaskCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReceiveTaskCount.AutoSize = true;
            this.lblReceiveTaskCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReceiveTaskCount.Location = new System.Drawing.Point(3, 9);
            this.lblReceiveTaskCount.Name = "lblReceiveTaskCount";
            this.lblReceiveTaskCount.Size = new System.Drawing.Size(65, 13);
            this.lblReceiveTaskCount.TabIndex = 135;
            this.lblReceiveTaskCount.Text = "Task Count:";
            // 
            // txtReceiveTaskCount
            // 
            this.txtReceiveTaskCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtReceiveTaskCount.Location = new System.Drawing.Point(81, 5);
            this.txtReceiveTaskCount.Name = "txtReceiveTaskCount";
            this.txtReceiveTaskCount.Size = new System.Drawing.Size(95, 20);
            this.txtReceiveTaskCount.TabIndex = 125;
            this.txtReceiveTaskCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBoxDeferMessage
            // 
            this.checkBoxDeferMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxDeferMessage.AutoSize = true;
            this.checkBoxDeferMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxDeferMessage.Location = new System.Drawing.Point(767, 131);
            this.checkBoxDeferMessage.Name = "checkBoxDeferMessage";
            this.checkBoxDeferMessage.Size = new System.Drawing.Size(98, 17);
            this.checkBoxDeferMessage.TabIndex = 17;
            this.checkBoxDeferMessage.Text = "Defer Message";
            this.checkBoxDeferMessage.UseVisualStyleBackColor = true;
            this.checkBoxDeferMessage.CheckedChanged += new System.EventHandler(this.checkBoxDeferMessage_CheckedChanged);
            // 
            // lblServerWaitTime
            // 
            this.lblServerWaitTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServerWaitTime.AutoSize = true;
            this.lblServerWaitTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblServerWaitTime.Location = new System.Drawing.Point(182, 9);
            this.lblServerWaitTime.Name = "lblServerWaitTime";
            this.lblServerWaitTime.Size = new System.Drawing.Size(105, 13);
            this.lblServerWaitTime.TabIndex = 134;
            this.lblServerWaitTime.Text = "Receive Timeout (s):";
            // 
            // checkBoxCompleteReceive
            // 
            this.checkBoxCompleteReceive.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxCompleteReceive.AutoSize = true;
            this.checkBoxCompleteReceive.Checked = true;
            this.checkBoxCompleteReceive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompleteReceive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxCompleteReceive.Location = new System.Drawing.Point(767, 100);
            this.checkBoxCompleteReceive.Name = "checkBoxCompleteReceive";
            this.checkBoxCompleteReceive.Size = new System.Drawing.Size(113, 17);
            this.checkBoxCompleteReceive.TabIndex = 15;
            this.checkBoxCompleteReceive.Text = "Complete Receive";
            this.checkBoxCompleteReceive.UseVisualStyleBackColor = true;
            // 
            // checkBoxReceiverEnableGraph
            // 
            this.checkBoxReceiverEnableGraph.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiverEnableGraph.AutoSize = true;
            this.checkBoxReceiverEnableGraph.Enabled = false;
            this.checkBoxReceiverEnableGraph.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiverEnableGraph.Location = new System.Drawing.Point(767, 69);
            this.checkBoxReceiverEnableGraph.Name = "checkBoxReceiverEnableGraph";
            this.checkBoxReceiverEnableGraph.Size = new System.Drawing.Size(91, 17);
            this.checkBoxReceiverEnableGraph.TabIndex = 13;
            this.checkBoxReceiverEnableGraph.Text = "Enable Graph";
            this.checkBoxReceiverEnableGraph.UseVisualStyleBackColor = true;
            // 
            // txtReceiveTimeout
            // 
            this.txtReceiveTimeout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtReceiveTimeout.Location = new System.Drawing.Point(297, 5);
            this.txtReceiveTimeout.Name = "txtReceiveTimeout";
            this.txtReceiveTimeout.Size = new System.Drawing.Size(95, 20);
            this.txtReceiveTimeout.TabIndex = 126;
            this.txtReceiveTimeout.Text = "1";
            this.txtReceiveTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblPrefetchCount
            // 
            this.lblPrefetchCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPrefetchCount.AutoSize = true;
            this.lblPrefetchCount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPrefetchCount.Location = new System.Drawing.Point(398, 9);
            this.lblPrefetchCount.Name = "lblPrefetchCount";
            this.lblPrefetchCount.Size = new System.Drawing.Size(81, 13);
            this.lblPrefetchCount.TabIndex = 139;
            this.lblPrefetchCount.Text = "Prefetch Count:";
            // 
            // checkBoxReceiverVerboseLogging
            // 
            this.checkBoxReceiverVerboseLogging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiverVerboseLogging.AutoSize = true;
            this.checkBoxReceiverVerboseLogging.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiverVerboseLogging.Location = new System.Drawing.Point(767, 38);
            this.checkBoxReceiverVerboseLogging.Name = "checkBoxReceiverVerboseLogging";
            this.checkBoxReceiverVerboseLogging.Size = new System.Drawing.Size(101, 17);
            this.checkBoxReceiverVerboseLogging.TabIndex = 11;
            this.checkBoxReceiverVerboseLogging.Text = "Enable Verbose";
            this.checkBoxReceiverVerboseLogging.UseVisualStyleBackColor = true;
            // 
            // txtPrefetchCount
            // 
            this.txtPrefetchCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPrefetchCount.Location = new System.Drawing.Point(498, 5);
            this.txtPrefetchCount.Name = "txtPrefetchCount";
            this.txtPrefetchCount.Size = new System.Drawing.Size(95, 20);
            this.txtPrefetchCount.TabIndex = 127;
            this.txtPrefetchCount.Text = "0";
            this.txtPrefetchCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // checkBoxReceiverCommitTransaction
            // 
            this.checkBoxReceiverCommitTransaction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiverCommitTransaction.AutoSize = true;
            this.checkBoxReceiverCommitTransaction.Checked = true;
            this.checkBoxReceiverCommitTransaction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxReceiverCommitTransaction.Enabled = false;
            this.checkBoxReceiverCommitTransaction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiverCommitTransaction.Location = new System.Drawing.Point(767, 7);
            this.checkBoxReceiverCommitTransaction.Name = "checkBoxReceiverCommitTransaction";
            this.checkBoxReceiverCommitTransaction.Size = new System.Drawing.Size(119, 17);
            this.checkBoxReceiverCommitTransaction.TabIndex = 9;
            this.checkBoxReceiverCommitTransaction.Text = "Commit Transaction";
            this.checkBoxReceiverCommitTransaction.UseVisualStyleBackColor = true;
            // 
            // lblReceiveBatchSize
            // 
            this.lblReceiveBatchSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReceiveBatchSize.AutoSize = true;
            this.lblReceiveBatchSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReceiveBatchSize.Location = new System.Drawing.Point(3, 40);
            this.lblReceiveBatchSize.Name = "lblReceiveBatchSize";
            this.lblReceiveBatchSize.Size = new System.Drawing.Size(61, 13);
            this.lblReceiveBatchSize.TabIndex = 140;
            this.lblReceiveBatchSize.Text = "Batch Size:";
            // 
            // checkBoxReceiveBatch
            // 
            this.checkBoxReceiveBatch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiveBatch.AutoSize = true;
            this.checkBoxReceiveBatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiveBatch.Location = new System.Drawing.Point(599, 100);
            this.checkBoxReceiveBatch.Name = "checkBoxReceiveBatch";
            this.checkBoxReceiveBatch.Size = new System.Drawing.Size(97, 17);
            this.checkBoxReceiveBatch.TabIndex = 14;
            this.checkBoxReceiveBatch.Text = "Receive Batch";
            this.checkBoxReceiveBatch.UseVisualStyleBackColor = true;
            this.checkBoxReceiveBatch.CheckedChanged += new System.EventHandler(this.checkBoxReceiveBatch_CheckedChanged);
            // 
            // checkBoxReceiverUseTransaction
            // 
            this.checkBoxReceiverUseTransaction.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiverUseTransaction.AutoSize = true;
            this.checkBoxReceiverUseTransaction.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiverUseTransaction.Location = new System.Drawing.Point(599, 7);
            this.checkBoxReceiverUseTransaction.Name = "checkBoxReceiverUseTransaction";
            this.checkBoxReceiverUseTransaction.Size = new System.Drawing.Size(104, 17);
            this.checkBoxReceiverUseTransaction.TabIndex = 8;
            this.checkBoxReceiverUseTransaction.Text = "Use Transaction";
            this.checkBoxReceiverUseTransaction.UseVisualStyleBackColor = true;
            this.checkBoxReceiverUseTransaction.CheckedChanged += new System.EventHandler(this.checkBoxReceiverUseTransaction_CheckedChanged);
            // 
            // checkBoxMoveToDeadLetter
            // 
            this.checkBoxMoveToDeadLetter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxMoveToDeadLetter.AutoSize = true;
            this.checkBoxMoveToDeadLetter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxMoveToDeadLetter.Location = new System.Drawing.Point(599, 131);
            this.checkBoxMoveToDeadLetter.Name = "checkBoxMoveToDeadLetter";
            this.checkBoxMoveToDeadLetter.Size = new System.Drawing.Size(160, 17);
            this.checkBoxMoveToDeadLetter.TabIndex = 16;
            this.checkBoxMoveToDeadLetter.Text = "Move To DeadLetter Queue";
            this.checkBoxMoveToDeadLetter.UseVisualStyleBackColor = true;
            this.checkBoxMoveToDeadLetter.CheckedChanged += new System.EventHandler(this.checkBoxMoveToDeadLetter_CheckedChanged);
            // 
            // lblSubscription
            // 
            this.lblSubscription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSubscription.AutoSize = true;
            this.lblSubscription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSubscription.Location = new System.Drawing.Point(3, 289);
            this.lblSubscription.Name = "lblSubscription";
            this.lblSubscription.Size = new System.Drawing.Size(68, 13);
            this.lblSubscription.TabIndex = 133;
            this.lblSubscription.Text = "Subscription:";
            // 
            // checkBoxReceiverEnableStatistics
            // 
            this.checkBoxReceiverEnableStatistics.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxReceiverEnableStatistics.AutoSize = true;
            this.checkBoxReceiverEnableStatistics.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxReceiverEnableStatistics.Location = new System.Drawing.Point(599, 69);
            this.checkBoxReceiverEnableStatistics.Name = "checkBoxReceiverEnableStatistics";
            this.checkBoxReceiverEnableStatistics.Size = new System.Drawing.Size(104, 17);
            this.checkBoxReceiverEnableStatistics.TabIndex = 12;
            this.checkBoxReceiverEnableStatistics.Text = "Enable Statistics";
            this.checkBoxReceiverEnableStatistics.UseVisualStyleBackColor = true;
            this.checkBoxReceiverEnableStatistics.CheckedChanged += new System.EventHandler(this.checkBoxReceiverEnableStatistics_CheckedChanged);
            // 
            // txtServerTimeout
            // 
            this.txtServerTimeout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtServerTimeout.Location = new System.Drawing.Point(297, 36);
            this.txtServerTimeout.Name = "txtServerTimeout";
            this.txtServerTimeout.Size = new System.Drawing.Size(95, 20);
            this.txtServerTimeout.TabIndex = 129;
            this.txtServerTimeout.Text = "5";
            this.txtServerTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // lblFilterExpr
            // 
            this.lblFilterExpr.AutoSize = true;
            this.lblFilterExpr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFilterExpr.Location = new System.Drawing.Point(3, 62);
            this.lblFilterExpr.Name = "lblFilterExpr";
            this.lblFilterExpr.Size = new System.Drawing.Size(32, 13);
            this.lblFilterExpr.TabIndex = 137;
            this.lblFilterExpr.Text = "Filter:";
            // 
            // txtReceiveBatchSize
            // 
            this.txtReceiveBatchSize.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtReceiveBatchSize.Location = new System.Drawing.Point(81, 36);
            this.txtReceiveBatchSize.Name = "txtReceiveBatchSize";
            this.txtReceiveBatchSize.Size = new System.Drawing.Size(95, 20);
            this.txtReceiveBatchSize.TabIndex = 128;
            this.txtReceiveBatchSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // cboReceivedMode
            // 
            this.cboReceivedMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReceivedMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceivedMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboReceivedMode.FormattingEnabled = true;
            this.cboReceivedMode.Items.AddRange(new object[] {
            "PeekLock",
            "ReceiveDelete"});
            this.cboReceivedMode.Location = new System.Drawing.Point(498, 36);
            this.cboReceivedMode.Name = "cboReceivedMode";
            this.cboReceivedMode.Size = new System.Drawing.Size(95, 21);
            this.cboReceivedMode.TabIndex = 130;
            this.cboReceivedMode.SelectedIndexChanged += new System.EventHandler(this.cboReceivedMode_SelectedIndexChanged);
            // 
            // lblServerTimeout
            // 
            this.lblServerTimeout.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblServerTimeout.AutoSize = true;
            this.lblServerTimeout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblServerTimeout.Location = new System.Drawing.Point(182, 40);
            this.lblServerTimeout.Name = "lblServerTimeout";
            this.lblServerTimeout.Size = new System.Drawing.Size(96, 13);
            this.lblServerTimeout.TabIndex = 138;
            this.lblServerTimeout.Text = "Server Timeout (s):";
            // 
            // checkBoxEnableReceiverLogging
            // 
            this.checkBoxEnableReceiverLogging.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxEnableReceiverLogging.AutoSize = true;
            this.checkBoxEnableReceiverLogging.Checked = true;
            this.checkBoxEnableReceiverLogging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnableReceiverLogging.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxEnableReceiverLogging.Location = new System.Drawing.Point(599, 38);
            this.checkBoxEnableReceiverLogging.Name = "checkBoxEnableReceiverLogging";
            this.checkBoxEnableReceiverLogging.Size = new System.Drawing.Size(100, 17);
            this.checkBoxEnableReceiverLogging.TabIndex = 10;
            this.checkBoxEnableReceiverLogging.Text = "Enable Logging";
            this.checkBoxEnableReceiverLogging.UseVisualStyleBackColor = true;
            this.checkBoxEnableReceiverLogging.CheckedChanged += new System.EventHandler(this.checkBoxEnableReceiverLogging_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(398, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 136;
            this.label1.Text = "Receive Mode:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel9.SetColumnSpan(this.flowLayoutPanel1, 2);
            this.flowLayoutPanel1.Controls.Add(this.lblReceiverInspector);
            this.flowLayoutPanel1.Controls.Add(this.cboReceiverInspector);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(596, 251);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(299, 25);
            this.flowLayoutPanel1.TabIndex = 150;
            // 
            // lblReceiverInspector
            // 
            this.lblReceiverInspector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblReceiverInspector.AutoSize = true;
            this.lblReceiverInspector.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblReceiverInspector.Location = new System.Drawing.Point(3, 7);
            this.lblReceiverInspector.Name = "lblReceiverInspector";
            this.lblReceiverInspector.Size = new System.Drawing.Size(77, 13);
            this.lblReceiverInspector.TabIndex = 147;
            this.lblReceiverInspector.Text = "Msg Inspector:";
            // 
            // cboReceiverInspector
            // 
            this.cboReceiverInspector.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cboReceiverInspector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiverInspector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboReceiverInspector.FormattingEnabled = true;
            this.cboReceiverInspector.Location = new System.Drawing.Point(86, 3);
            this.cboReceiverInspector.Name = "cboReceiverInspector";
            this.cboReceiverInspector.Size = new System.Drawing.Size(205, 21);
            this.cboReceiverInspector.TabIndex = 148;
            // 
            // grouperReceiverStatistics
            // 
            this.grouperReceiverStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grouperReceiverStatistics.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperReceiverStatistics.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperReceiverStatistics.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperReceiverStatistics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperReceiverStatistics.BorderThickness = 1F;
            this.grouperReceiverStatistics.Controls.Add(this.receiverLayoutPanel);
            this.grouperReceiverStatistics.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperReceiverStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperReceiverStatistics.ForeColor = System.Drawing.Color.White;
            this.grouperReceiverStatistics.GroupImage = null;
            this.grouperReceiverStatistics.GroupTitle = "Receiver";
            this.grouperReceiverStatistics.Location = new System.Drawing.Point(824, 8);
            this.grouperReceiverStatistics.Name = "grouperReceiverStatistics";
            this.grouperReceiverStatistics.Padding = new System.Windows.Forms.Padding(20);
            this.grouperReceiverStatistics.PaintGroupBox = true;
            this.grouperReceiverStatistics.RoundCorners = 4;
            this.grouperReceiverStatistics.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperReceiverStatistics.ShadowControl = false;
            this.grouperReceiverStatistics.ShadowThickness = 1;
            this.grouperReceiverStatistics.Size = new System.Drawing.Size(128, 352);
            this.grouperReceiverStatistics.TabIndex = 2;
            // 
            // receiverLayoutPanel
            // 
            this.receiverLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.receiverLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.receiverLayoutPanel.ColumnCount = 1;
            this.receiverLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.receiverLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.receiverLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.receiverLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.receiverLayoutPanel.Controls.Add(this.tableLayoutPanel17, 0, 0);
            this.receiverLayoutPanel.Controls.Add(this.tableLayoutPanel16, 0, 1);
            this.receiverLayoutPanel.Controls.Add(this.tableLayoutPanel15, 0, 2);
            this.receiverLayoutPanel.Controls.Add(this.tableLayoutPanel14, 0, 3);
            this.receiverLayoutPanel.Controls.Add(this.tableLayoutPanel12, 0, 4);
            this.receiverLayoutPanel.Controls.Add(this.tableLayoutPanel6, 0, 5);
            this.receiverLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.receiverLayoutPanel.Location = new System.Drawing.Point(16, 32);
            this.receiverLayoutPanel.Name = "receiverLayoutPanel";
            this.receiverLayoutPanel.RowCount = 6;
            this.receiverLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.receiverLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.receiverLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.receiverLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.receiverLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.receiverLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.receiverLayoutPanel.Size = new System.Drawing.Size(96, 272);
            this.receiverLayoutPanel.TabIndex = 122;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel17.ColumnCount = 1;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel17.Controls.Add(this.lblReceiverLastTime, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.lblReceiverLastCaption, 0, 0);
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel17.TabIndex = 0;
            // 
            // lblReceiverLastTime
            // 
            this.lblReceiverLastTime.BackColor = System.Drawing.Color.White;
            this.lblReceiverLastTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiverLastTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiverLastTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverLastTime.Location = new System.Drawing.Point(3, 19);
            this.lblReceiverLastTime.Name = "lblReceiverLastTime";
            this.lblReceiverLastTime.Size = new System.Drawing.Size(84, 13);
            this.lblReceiverLastTime.TabIndex = 1;
            this.lblReceiverLastTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiverLastCaption
            // 
            this.lblReceiverLastCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverLastCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverLastCaption.Location = new System.Drawing.Point(3, 0);
            this.lblReceiverLastCaption.Name = "lblReceiverLastCaption";
            this.lblReceiverLastCaption.Size = new System.Drawing.Size(84, 19);
            this.lblReceiverLastCaption.TabIndex = 0;
            this.lblReceiverLastCaption.Text = "Last Time";
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel16.ColumnCount = 1;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel16.Controls.Add(this.lblReceiverAverageTime, 0, 1);
            this.tableLayoutPanel16.Controls.Add(this.lblReceiverAverageCaption, 0, 0);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 2;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel16.TabIndex = 1;
            // 
            // lblReceiverAverageTime
            // 
            this.lblReceiverAverageTime.BackColor = System.Drawing.Color.White;
            this.lblReceiverAverageTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiverAverageTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiverAverageTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverAverageTime.Location = new System.Drawing.Point(3, 19);
            this.lblReceiverAverageTime.Name = "lblReceiverAverageTime";
            this.lblReceiverAverageTime.Size = new System.Drawing.Size(84, 13);
            this.lblReceiverAverageTime.TabIndex = 1;
            this.lblReceiverAverageTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiverAverageCaption
            // 
            this.lblReceiverAverageCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverAverageCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverAverageCaption.Location = new System.Drawing.Point(3, 0);
            this.lblReceiverAverageCaption.Name = "lblReceiverAverageCaption";
            this.lblReceiverAverageCaption.Size = new System.Drawing.Size(84, 19);
            this.lblReceiverAverageCaption.TabIndex = 0;
            this.lblReceiverAverageCaption.Text = "Average Time";
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel15.ColumnCount = 1;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel15.Controls.Add(this.lblReceiverMinimumTime, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.lblReceiverMinimumCaption, 0, 0);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 2;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel15.TabIndex = 2;
            // 
            // lblReceiverMinimumTime
            // 
            this.lblReceiverMinimumTime.BackColor = System.Drawing.Color.White;
            this.lblReceiverMinimumTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiverMinimumTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiverMinimumTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverMinimumTime.Location = new System.Drawing.Point(3, 19);
            this.lblReceiverMinimumTime.Name = "lblReceiverMinimumTime";
            this.lblReceiverMinimumTime.Size = new System.Drawing.Size(84, 13);
            this.lblReceiverMinimumTime.TabIndex = 1;
            this.lblReceiverMinimumTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiverMinimumCaption
            // 
            this.lblReceiverMinimumCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverMinimumCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverMinimumCaption.Location = new System.Drawing.Point(3, 0);
            this.lblReceiverMinimumCaption.Name = "lblReceiverMinimumCaption";
            this.lblReceiverMinimumCaption.Size = new System.Drawing.Size(84, 19);
            this.lblReceiverMinimumCaption.TabIndex = 0;
            this.lblReceiverMinimumCaption.Text = "Minimum Time";
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel14.Controls.Add(this.lblReceiverMaximumTime, 0, 1);
            this.tableLayoutPanel14.Controls.Add(this.lblReceiverMaximumCaption, 0, 0);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 138);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel14.TabIndex = 3;
            // 
            // lblReceiverMaximumTime
            // 
            this.lblReceiverMaximumTime.BackColor = System.Drawing.Color.White;
            this.lblReceiverMaximumTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiverMaximumTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiverMaximumTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverMaximumTime.Location = new System.Drawing.Point(3, 19);
            this.lblReceiverMaximumTime.Name = "lblReceiverMaximumTime";
            this.lblReceiverMaximumTime.Size = new System.Drawing.Size(84, 13);
            this.lblReceiverMaximumTime.TabIndex = 1;
            this.lblReceiverMaximumTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiverMaximumCaption
            // 
            this.lblReceiverMaximumCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverMaximumCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverMaximumCaption.Location = new System.Drawing.Point(3, 0);
            this.lblReceiverMaximumCaption.Name = "lblReceiverMaximumCaption";
            this.lblReceiverMaximumCaption.Size = new System.Drawing.Size(84, 19);
            this.lblReceiverMaximumCaption.TabIndex = 0;
            this.lblReceiverMaximumCaption.Text = "Maximum Time";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel12.Controls.Add(this.lblReceiverMessagesPerSecond, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.lblReceiverMessagesPerSecondCaption, 0, 0);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel12.TabIndex = 6;
            // 
            // lblReceiverMessagesPerSecond
            // 
            this.lblReceiverMessagesPerSecond.BackColor = System.Drawing.Color.White;
            this.lblReceiverMessagesPerSecond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiverMessagesPerSecond.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiverMessagesPerSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverMessagesPerSecond.Location = new System.Drawing.Point(3, 19);
            this.lblReceiverMessagesPerSecond.Name = "lblReceiverMessagesPerSecond";
            this.lblReceiverMessagesPerSecond.Size = new System.Drawing.Size(84, 13);
            this.lblReceiverMessagesPerSecond.TabIndex = 1;
            this.lblReceiverMessagesPerSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiverMessagesPerSecondCaption
            // 
            this.lblReceiverMessagesPerSecondCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverMessagesPerSecondCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverMessagesPerSecondCaption.Location = new System.Drawing.Point(3, 0);
            this.lblReceiverMessagesPerSecondCaption.Name = "lblReceiverMessagesPerSecondCaption";
            this.lblReceiverMessagesPerSecondCaption.Size = new System.Drawing.Size(84, 19);
            this.lblReceiverMessagesPerSecondCaption.TabIndex = 0;
            this.lblReceiverMessagesPerSecondCaption.Text = "Messages/Sec";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Controls.Add(this.lblReceiverMessageNumber, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.lblReceiverCallsSuccessedCaption, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 228);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(90, 41);
            this.tableLayoutPanel6.TabIndex = 8;
            // 
            // lblReceiverMessageNumber
            // 
            this.lblReceiverMessageNumber.BackColor = System.Drawing.Color.White;
            this.lblReceiverMessageNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceiverMessageNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReceiverMessageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverMessageNumber.Location = new System.Drawing.Point(3, 20);
            this.lblReceiverMessageNumber.Name = "lblReceiverMessageNumber";
            this.lblReceiverMessageNumber.Size = new System.Drawing.Size(84, 13);
            this.lblReceiverMessageNumber.TabIndex = 1;
            this.lblReceiverMessageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblReceiverCallsSuccessedCaption
            // 
            this.lblReceiverCallsSuccessedCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReceiverCallsSuccessedCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiverCallsSuccessedCaption.Location = new System.Drawing.Point(3, 0);
            this.lblReceiverCallsSuccessedCaption.Name = "lblReceiverCallsSuccessedCaption";
            this.lblReceiverCallsSuccessedCaption.Size = new System.Drawing.Size(84, 20);
            this.lblReceiverCallsSuccessedCaption.TabIndex = 0;
            this.lblReceiverCallsSuccessedCaption.Text = "Messages Total";
            // 
            // grouperSenderStatistics
            // 
            this.grouperSenderStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grouperSenderStatistics.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.grouperSenderStatistics.BackgroundGradientColor = System.Drawing.Color.White;
            this.grouperSenderStatistics.BackgroundGradientMode = ServiceBusExplorer.Controls.Grouper.GroupBoxGradientMode.None;
            this.grouperSenderStatistics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSenderStatistics.BorderThickness = 1F;
            this.grouperSenderStatistics.Controls.Add(this.senderLayoutPanel);
            this.grouperSenderStatistics.CustomGroupBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.grouperSenderStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grouperSenderStatistics.ForeColor = System.Drawing.Color.White;
            this.grouperSenderStatistics.GroupImage = null;
            this.grouperSenderStatistics.GroupTitle = "Sender";
            this.grouperSenderStatistics.Location = new System.Drawing.Point(16, 8);
            this.grouperSenderStatistics.Name = "grouperSenderStatistics";
            this.grouperSenderStatistics.Padding = new System.Windows.Forms.Padding(20);
            this.grouperSenderStatistics.PaintGroupBox = true;
            this.grouperSenderStatistics.RoundCorners = 4;
            this.grouperSenderStatistics.ShadowColor = System.Drawing.Color.DarkGray;
            this.grouperSenderStatistics.ShadowControl = false;
            this.grouperSenderStatistics.ShadowThickness = 1;
            this.grouperSenderStatistics.Size = new System.Drawing.Size(128, 360);
            this.grouperSenderStatistics.TabIndex = 0;
            // 
            // senderLayoutPanel
            // 
            this.senderLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.senderLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.senderLayoutPanel.ColumnCount = 1;
            this.senderLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.senderLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.senderLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.senderLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.senderLayoutPanel.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.senderLayoutPanel.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.senderLayoutPanel.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.senderLayoutPanel.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.senderLayoutPanel.Controls.Add(this.tableLayoutPanel8, 0, 4);
            this.senderLayoutPanel.Controls.Add(this.tableLayoutPanel10, 0, 5);
            this.senderLayoutPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.senderLayoutPanel.Location = new System.Drawing.Point(16, 32);
            this.senderLayoutPanel.Name = "senderLayoutPanel";
            this.senderLayoutPanel.RowCount = 6;
            this.senderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.senderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.senderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.senderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.senderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.senderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.senderLayoutPanel.Size = new System.Drawing.Size(96, 272);
            this.senderLayoutPanel.TabIndex = 121;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.lblSenderAverageTime, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblSenderAverageCaption, 0, 0);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 48);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel7.TabIndex = 5;
            // 
            // lblSenderAverageTime
            // 
            this.lblSenderAverageTime.BackColor = System.Drawing.Color.White;
            this.lblSenderAverageTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSenderAverageTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSenderAverageTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderAverageTime.Location = new System.Drawing.Point(3, 19);
            this.lblSenderAverageTime.Name = "lblSenderAverageTime";
            this.lblSenderAverageTime.Size = new System.Drawing.Size(84, 13);
            this.lblSenderAverageTime.TabIndex = 1;
            this.lblSenderAverageTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderAverageCaption
            // 
            this.lblSenderAverageCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderAverageCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderAverageCaption.Location = new System.Drawing.Point(3, 0);
            this.lblSenderAverageCaption.Name = "lblSenderAverageCaption";
            this.lblSenderAverageCaption.Size = new System.Drawing.Size(84, 19);
            this.lblSenderAverageCaption.TabIndex = 0;
            this.lblSenderAverageCaption.Text = "Average Time";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.lblSenderLastTime, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSenderLastCaption, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblSenderLastTime
            // 
            this.lblSenderLastTime.BackColor = System.Drawing.Color.White;
            this.lblSenderLastTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSenderLastTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSenderLastTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderLastTime.Location = new System.Drawing.Point(3, 19);
            this.lblSenderLastTime.Name = "lblSenderLastTime";
            this.lblSenderLastTime.Size = new System.Drawing.Size(84, 13);
            this.lblSenderLastTime.TabIndex = 1;
            this.lblSenderLastTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderLastCaption
            // 
            this.lblSenderLastCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderLastCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderLastCaption.Location = new System.Drawing.Point(3, 0);
            this.lblSenderLastCaption.Name = "lblSenderLastCaption";
            this.lblSenderLastCaption.Size = new System.Drawing.Size(84, 19);
            this.lblSenderLastCaption.TabIndex = 0;
            this.lblSenderLastCaption.Text = "Last Time";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.lblSenderMinimumTime, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblSenderMinimumCaption, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 93);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // lblSenderMinimumTime
            // 
            this.lblSenderMinimumTime.BackColor = System.Drawing.Color.White;
            this.lblSenderMinimumTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSenderMinimumTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSenderMinimumTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMinimumTime.Location = new System.Drawing.Point(3, 19);
            this.lblSenderMinimumTime.Name = "lblSenderMinimumTime";
            this.lblSenderMinimumTime.Size = new System.Drawing.Size(84, 13);
            this.lblSenderMinimumTime.TabIndex = 1;
            this.lblSenderMinimumTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderMinimumCaption
            // 
            this.lblSenderMinimumCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderMinimumCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMinimumCaption.Location = new System.Drawing.Point(3, 0);
            this.lblSenderMinimumCaption.Name = "lblSenderMinimumCaption";
            this.lblSenderMinimumCaption.Size = new System.Drawing.Size(84, 19);
            this.lblSenderMinimumCaption.TabIndex = 0;
            this.lblSenderMinimumCaption.Text = "Minimum Time";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel5.Controls.Add(this.lblSenderMaximumTime, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblSenderMaximumCaption, 0, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 138);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // lblSenderMaximumTime
            // 
            this.lblSenderMaximumTime.BackColor = System.Drawing.Color.White;
            this.lblSenderMaximumTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSenderMaximumTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSenderMaximumTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMaximumTime.Location = new System.Drawing.Point(3, 19);
            this.lblSenderMaximumTime.Name = "lblSenderMaximumTime";
            this.lblSenderMaximumTime.Size = new System.Drawing.Size(84, 13);
            this.lblSenderMaximumTime.TabIndex = 1;
            this.lblSenderMaximumTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderMaximumCaption
            // 
            this.lblSenderMaximumCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderMaximumCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMaximumCaption.Location = new System.Drawing.Point(3, 0);
            this.lblSenderMaximumCaption.Name = "lblSenderMaximumCaption";
            this.lblSenderMaximumCaption.Size = new System.Drawing.Size(84, 19);
            this.lblSenderMaximumCaption.TabIndex = 0;
            this.lblSenderMaximumCaption.Text = "Maximum Time";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.lblSenderMessagesPerSecond, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.lblSenderMessagesPerSecondCaption, 0, 0);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(90, 39);
            this.tableLayoutPanel8.TabIndex = 11;
            // 
            // lblSenderMessagesPerSecond
            // 
            this.lblSenderMessagesPerSecond.BackColor = System.Drawing.Color.White;
            this.lblSenderMessagesPerSecond.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSenderMessagesPerSecond.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSenderMessagesPerSecond.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMessagesPerSecond.Location = new System.Drawing.Point(3, 19);
            this.lblSenderMessagesPerSecond.Name = "lblSenderMessagesPerSecond";
            this.lblSenderMessagesPerSecond.Size = new System.Drawing.Size(84, 13);
            this.lblSenderMessagesPerSecond.TabIndex = 1;
            this.lblSenderMessagesPerSecond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderMessagesPerSecondCaption
            // 
            this.lblSenderMessagesPerSecondCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderMessagesPerSecondCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMessagesPerSecondCaption.Location = new System.Drawing.Point(3, 0);
            this.lblSenderMessagesPerSecondCaption.Name = "lblSenderMessagesPerSecondCaption";
            this.lblSenderMessagesPerSecondCaption.Size = new System.Drawing.Size(84, 19);
            this.lblSenderMessagesPerSecondCaption.TabIndex = 0;
            this.lblSenderMessagesPerSecondCaption.Text = "Messages/Sec";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Controls.Add(this.lblSenderMessageNumber, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.lblSenderCallsSuccessedCaption, 0, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 228);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(90, 41);
            this.tableLayoutPanel10.TabIndex = 8;
            // 
            // lblSenderMessageNumber
            // 
            this.lblSenderMessageNumber.BackColor = System.Drawing.Color.White;
            this.lblSenderMessageNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSenderMessageNumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSenderMessageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderMessageNumber.Location = new System.Drawing.Point(3, 20);
            this.lblSenderMessageNumber.Name = "lblSenderMessageNumber";
            this.lblSenderMessageNumber.Size = new System.Drawing.Size(84, 13);
            this.lblSenderMessageNumber.TabIndex = 1;
            this.lblSenderMessageNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSenderCallsSuccessedCaption
            // 
            this.lblSenderCallsSuccessedCaption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSenderCallsSuccessedCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderCallsSuccessedCaption.Location = new System.Drawing.Point(3, 0);
            this.lblSenderCallsSuccessedCaption.Name = "lblSenderCallsSuccessedCaption";
            this.lblSenderCallsSuccessedCaption.Size = new System.Drawing.Size(84, 20);
            this.lblSenderCallsSuccessedCaption.TabIndex = 0;
            this.lblSenderCallsSuccessedCaption.Text = "Messages Total";
            // 
            // TestTopicControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.Controls.Add(this.btnClearFiles);
            this.Controls.Add(this.btnSelectFiles);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.Name = "TestTopicControl";
            this.Size = new System.Drawing.Size(1008, 478);
            this.Resize += new System.EventHandler(this.TestTopicControl_Resize);
            this.mainTabControl.ResumeLayout(false);
            this.mainTabMessagePage.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.messageTabControl.ResumeLayout(false);
            this.tabMessagePage.ResumeLayout(false);
            this.tabFilesPage.ResumeLayout(false);
            this.tabGeneratorPage.ResumeLayout(false);
            this.mainTabSenderPage.ResumeLayout(false);
            this.mainTabSenderPage.PerformLayout();
            this.mainTabReceiverPage.ResumeLayout(false);
            this.mainTabReceiverPage.PerformLayout();
            this.tabPageGraph.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.grouperMessageFormat.ResumeLayout(false);
            this.grouperMessageText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText)).EndInit();
            this.grouperMessageFiles.ResumeLayout(false);
            this.grouperMessageFiles.PerformLayout();
            this.grouperBrokeredMessageGenerator.ResumeLayout(false);
            this.grouperBrokeredMessageGenerator.PerformLayout();
            this.grouperMessageProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertiesDataGridView)).EndInit();
            this.grouperSender.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.grouperMessage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grouperReceiver.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.grouperReceiverStatistics.ResumeLayout(false);
            this.receiverLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.grouperSenderStatistics.ResumeLayout(false);
            this.senderLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabPage mainTabMessagePage;
        private System.Windows.Forms.TabPage mainTabSenderPage;
        private System.Windows.Forms.TabPage mainTabReceiverPage;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TabControl mainTabControl;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart;
        internal System.Windows.Forms.TabPage tabPageGraph;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Grouper grouperMessageProperties;
        internal System.Windows.Forms.CheckBox receiverEnabledCheckBox;
        private Grouper grouperReceiverStatistics;
        private System.Windows.Forms.TableLayoutPanel receiverLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.Label lblReceiverLastTime;
        private System.Windows.Forms.Label lblReceiverLastCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label lblReceiverAverageTime;
        private System.Windows.Forms.Label lblReceiverAverageCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label lblReceiverMinimumTime;
        private System.Windows.Forms.Label lblReceiverMinimumCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.Label lblReceiverMaximumTime;
        private System.Windows.Forms.Label lblReceiverMaximumCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Label lblReceiverMessagesPerSecond;
        private System.Windows.Forms.Label lblReceiverMessagesPerSecondCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label lblReceiverMessageNumber;
        private System.Windows.Forms.Label lblReceiverCallsSuccessedCaption;
        private Grouper grouperSenderStatistics;
        private System.Windows.Forms.TableLayoutPanel senderLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label lblSenderAverageTime;
        private System.Windows.Forms.Label lblSenderAverageCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblSenderLastTime;
        private System.Windows.Forms.Label lblSenderLastCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblSenderMinimumTime;
        private System.Windows.Forms.Label lblSenderMinimumCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblSenderMaximumTime;
        private System.Windows.Forms.Label lblSenderMaximumCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label lblSenderMessagesPerSecond;
        private System.Windows.Forms.Label lblSenderMessagesPerSecondCaption;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label lblSenderMessageNumber;
        private System.Windows.Forms.Label lblSenderCallsSuccessedCaption;
        private System.Windows.Forms.DataGridView propertiesDataGridView;
        private System.Windows.Forms.TextBox txtSendTaskCount;
        private System.Windows.Forms.CheckBox checkBoxSendBatch;
        private System.Windows.Forms.CheckBox checkBoxAddMessageNumber;
        private System.Windows.Forms.CheckBox checkBoxSenderEnableGraph;
        private System.Windows.Forms.CheckBox checkBoxSenderEnableStatistics;
        private System.Windows.Forms.CheckBox checkBoxOneSessionPerTask;
        private System.Windows.Forms.CheckBox checkBoxUpdateMessageId;
        private System.Windows.Forms.CheckBox checkBoxEnableSenderLogging;
        private System.Windows.Forms.CheckBox checkBoxSenderVerboseLogging;
        private System.Windows.Forms.CheckBox checkBoxSenderCommitTransaction;
        private System.Windows.Forms.CheckBox checkBoxSenderUseTransaction;
        private System.Windows.Forms.Label lblSendBatchSize;
        private System.Windows.Forms.TextBox txtSendBatchSize;
        private System.Windows.Forms.Label lblBody;
        private System.Windows.Forms.ComboBox cboBodyType;
        private System.Windows.Forms.Label lblSendTaskCount;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblContentType;
        private System.Windows.Forms.TextBox txtContentType;
        private System.Windows.Forms.TextBox txtScheduledEnqueueTimeUtc;
        private System.Windows.Forms.Label lblScheduledEnqueueTimeUtc;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtTimeToLive;
        private System.Windows.Forms.Label lblTimeToLive;
        private System.Windows.Forms.Label lblReplyToSessionId;
        private System.Windows.Forms.TextBox txtReplyToSessionId;
        private System.Windows.Forms.Label lblReplyTo;
        private System.Windows.Forms.TextBox txtReplyTo;
        private System.Windows.Forms.TextBox txtCorrelationId;
        private System.Windows.Forms.Label lblCorrelationId;
        private System.Windows.Forms.Label lblSessionId;
        private System.Windows.Forms.TextBox txtSessionId;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label lblMessageId;
        private System.Windows.Forms.TextBox txtMessageId;
        private Grouper grouperReceiver;
        private System.Windows.Forms.CheckBox checkBoxReceiveBatch;
        private System.Windows.Forms.CheckBox checkBoxReceiverUseTransaction;
        private System.Windows.Forms.CheckBox checkBoxDeferMessage;
        private System.Windows.Forms.CheckBox checkBoxReceiverEnableGraph;
        private System.Windows.Forms.CheckBox checkBoxCompleteReceive;
        private System.Windows.Forms.CheckBox checkBoxReceiverEnableStatistics;
        private System.Windows.Forms.CheckBox checkBoxReadFromDeadLetter;
        private System.Windows.Forms.CheckBox checkBoxMoveToDeadLetter;
        private System.Windows.Forms.CheckBox checkBoxReceiverVerboseLogging;
        private System.Windows.Forms.CheckBox checkBoxReceiverCommitTransaction;
        private System.Windows.Forms.CheckBox checkBoxEnableReceiverLogging;
        private System.Windows.Forms.TextBox txtReceiveTaskCount;
        private System.Windows.Forms.Label lblReceiveBatchSize;
        private System.Windows.Forms.TextBox txtReceiveBatchSize;
        private System.Windows.Forms.TextBox txtPrefetchCount;
        private System.Windows.Forms.Label lblPrefetchCount;
        private System.Windows.Forms.TextBox txtReceiveTimeout;
        private System.Windows.Forms.TextBox txtServerTimeout;
        private System.Windows.Forms.Label lblServerTimeout;
        private System.Windows.Forms.TextBox txtFilterExpression;
        private System.Windows.Forms.Label lblFilterExpr;
        private System.Windows.Forms.ComboBox cboReceivedMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReceiveTaskCount;
        private System.Windows.Forms.Label lblServerWaitTime;
        private System.Windows.Forms.ComboBox cboSubscriptions;
        private System.Windows.Forms.Label lblSubscription;
        private System.Windows.Forms.TextBox txtSenderThinkTime;
        private System.Windows.Forms.Label lblSenderThinkTime;
        private System.Windows.Forms.CheckBox checkBoxSenderThinkTime;
        private System.Windows.Forms.CheckBox checkBoxReceiverThinkTime;
        internal System.Windows.Forms.TabControl messageTabControl;
        private System.Windows.Forms.TabPage tabMessagePage;
        private System.Windows.Forms.TabPage tabFilesPage;
        private Grouper grouperMessageFiles;
        private System.Windows.Forms.ListView messageFileListView;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader sizeColumnHeader;
        private System.Windows.Forms.Button btnClearFiles;
        private System.Windows.Forms.Button btnSelectFiles;
        private System.Windows.Forms.CheckBox checkBoxFileName;
        internal Grouper grouperSender;
        internal Grouper grouperMessage;
        internal System.Windows.Forms.CheckBox senderEnabledCheckBox;
        private System.Windows.Forms.TabPage tabGeneratorPage;
        private Grouper grouperBrokeredMessageGenerator;
        private System.Windows.Forms.Label lblRegistration;
        private System.Windows.Forms.PropertyGrid brokeredMessageGeneratorPropertyGrid;
        private System.Windows.Forms.ComboBox cboBrokeredMessageGeneratorType;
        private System.Windows.Forms.Label lblRegistrationType;
        private System.Windows.Forms.RadioButton radioButtonXmlTemplate;
        private System.Windows.Forms.RadioButton radioButtonTextFile;
        private NumericTextBox txtMessageCount;
        private System.Windows.Forms.CheckBox checkBoxForcePersistence;
        private System.Windows.Forms.Label lblForcePersistence;
        private System.Windows.Forms.RadioButton radioButtonBinaryFile;
        private System.Windows.Forms.RadioButton radioButtonJsonTemplate;
        private System.Windows.Forms.ComboBox cboSenderInspector;
        private System.Windows.Forms.Label lblSenderInspector;
        private System.Windows.Forms.ComboBox cboReceiverInspector;
        private System.Windows.Forms.Label lblReceiverInspector;
        private System.Windows.Forms.CheckBox checkBoxSendNewFactory;
        private System.Windows.Forms.CheckBox checkBoxReceiveNewFactory;
        private Grouper grouperMessageFormat;
        private System.Windows.Forms.ComboBox cboMessageFormat;
        private Grouper grouperMessageText;
        private FastColoredTextBoxNS.FastColoredTextBox txtMessageText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label lblReceiverThinkTime;
        private System.Windows.Forms.TextBox txtReceiverThinkTime;
    }
}
