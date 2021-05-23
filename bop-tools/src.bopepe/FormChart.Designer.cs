
namespace FcpTools
{
    partial class FormChart
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChart));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutBase = new System.Windows.Forms.TableLayoutPanel();
            this.tableUpper = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolCbChartArea = new System.Windows.Forms.ToolStripComboBox();
            this.toolAreaAdd = new System.Windows.Forms.ToolStripButton();
            this.toolAreaRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tooLegendbtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tooLogStart = new System.Windows.Forms.ToolStripButton();
            this.tooLogStop = new System.Windows.Forms.ToolStripButton();
            this.tooLogRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tooLogMaxValue = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tooLogCycle = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.tooLogFileName = new System.Windows.Forms.ToolStripTextBox();
            this.tooLogFolderOpen = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitBody = new System.Windows.Forms.SplitContainer();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableRight = new System.Windows.Forms.TableLayoutPanel();
            this.panelData = new System.Windows.Forms.Panel();
            this.ChartTapControl = new System.Windows.Forms.TabControl();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutData = new System.Windows.Forms.TableLayoutPanel();
            this.listColumns = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAreas = new System.Windows.Forms.ComboBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.tabChartProperty = new System.Windows.Forms.TabPage();
            this.propertyChart = new System.Windows.Forms.PropertyGrid();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.sigName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sigColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tableLayoutBase.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).BeginInit();
            this.splitBody.Panel1.SuspendLayout();
            this.splitBody.Panel2.SuspendLayout();
            this.splitBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tableRight.SuspendLayout();
            this.panelData.SuspendLayout();
            this.ChartTapControl.SuspendLayout();
            this.tabChart.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutData.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            this.panel4.SuspendLayout();
            this.tabChartProperty.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutBase
            // 
            this.tableLayoutBase.ColumnCount = 1;
            this.tableLayoutBase.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBase.Controls.Add(this.tableUpper, 0, 0);
            this.tableLayoutBase.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutBase.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBase.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutBase.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutBase.Name = "tableLayoutBase";
            this.tableLayoutBase.RowCount = 4;
            this.tableLayoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tableLayoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutBase.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutBase.Size = new System.Drawing.Size(1166, 666);
            this.tableLayoutBase.TabIndex = 13;
            // 
            // tableUpper
            // 
            this.tableUpper.ColumnCount = 2;
            this.tableUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUpper.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableUpper.Location = new System.Drawing.Point(3, 3);
            this.tableUpper.Name = "tableUpper";
            this.tableUpper.RowCount = 2;
            this.tableUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableUpper.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableUpper.Size = new System.Drawing.Size(1160, 1);
            this.tableUpper.TabIndex = 80;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.toolStrip);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1160, 26);
            this.flowLayoutPanel1.TabIndex = 81;
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolCbChartArea,
            this.toolAreaAdd,
            this.toolAreaRemove,
            this.toolStripSeparator2,
            this.tooLegendbtn,
            this.toolStripLabel4,
            this.tooLogMaxValue,
            this.toolStripSeparator3,
            this.toolStripLabel3,
            this.tooLogStart,
            this.tooLogStop,
            this.tooLogRefresh,
            this.toolStripSeparator4,
            this.toolStripLabel1,
            this.tooLogCycle,
            this.toolStripSeparator5,
            this.toolStripLabel5,
            this.tooLogFileName,
            this.tooLogFolderOpen});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(981, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel2.Text = "ChartArea :";
            // 
            // toolCbChartArea
            // 
            this.toolCbChartArea.Name = "toolCbChartArea";
            this.toolCbChartArea.Size = new System.Drawing.Size(100, 25);
            // 
            // toolAreaAdd
            // 
            this.toolAreaAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAreaAdd.Image = global::FcpTools.Properties.Resources.chart_pie_add;
            this.toolAreaAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAreaAdd.Name = "toolAreaAdd";
            this.toolAreaAdd.Size = new System.Drawing.Size(23, 22);
            this.toolAreaAdd.Text = "ChartAreaAdd";
            this.toolAreaAdd.Click += new System.EventHandler(this.toolAreaAdd_Click);
            // 
            // toolAreaRemove
            // 
            this.toolAreaRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolAreaRemove.Image = global::FcpTools.Properties.Resources.chart_pie_delete;
            this.toolAreaRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAreaRemove.Name = "toolAreaRemove";
            this.toolAreaRemove.Size = new System.Drawing.Size(23, 22);
            this.toolAreaRemove.Text = "ChartAreaRemove";
            this.toolAreaRemove.Click += new System.EventHandler(this.toolAreaRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tooLegendbtn
            // 
            this.tooLegendbtn.Image = global::FcpTools.Properties.Resources.bullet_star;
            this.tooLegendbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooLegendbtn.Name = "tooLegendbtn";
            this.tooLegendbtn.Size = new System.Drawing.Size(66, 22);
            this.tooLegendbtn.Text = "Legend";
            this.tooLegendbtn.Click += new System.EventHandler(this.tooLegendbtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(62, 22);
            this.toolStripLabel3.Text = "Logging : ";
            // 
            // tooLogStart
            // 
            this.tooLogStart.Image = ((System.Drawing.Image)(resources.GetObject("tooLogStart.Image")));
            this.tooLogStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooLogStart.Name = "tooLogStart";
            this.tooLogStart.Size = new System.Drawing.Size(52, 22);
            this.tooLogStart.Text = "Start";
            this.tooLogStart.Click += new System.EventHandler(this.tooLogStart_Click);
            // 
            // tooLogStop
            // 
            this.tooLogStop.Image = ((System.Drawing.Image)(resources.GetObject("tooLogStop.Image")));
            this.tooLogStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooLogStop.Name = "tooLogStop";
            this.tooLogStop.Size = new System.Drawing.Size(52, 22);
            this.tooLogStop.Text = "Stop";
            this.tooLogStop.Click += new System.EventHandler(this.tooLogStop_Click);
            // 
            // tooLogRefresh
            // 
            this.tooLogRefresh.Image = global::FcpTools.Properties.Resources.dot_gray;
            this.tooLogRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooLogRefresh.Name = "tooLogRefresh";
            this.tooLogRefresh.Size = new System.Drawing.Size(55, 22);
            this.tooLogRefresh.Text = "Reset";
            this.tooLogRefresh.ToolTipText = "Refresh";
            this.tooLogRefresh.Click += new System.EventHandler(this.tooLogRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(78, 22);
            this.toolStripLabel4.Text = "Disp. Points :";
            // 
            // tooLogMaxValue
            // 
            this.tooLogMaxValue.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tooLogMaxValue.Name = "tooLogMaxValue";
            this.tooLogMaxValue.Size = new System.Drawing.Size(40, 25);
            this.tooLogMaxValue.Click += new System.EventHandler(this.tooLogMaxValue_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(63, 22);
            this.toolStripLabel1.Text = "Interval(s) ";
            // 
            // tooLogCycle
            // 
            this.tooLogCycle.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tooLogCycle.Name = "tooLogCycle";
            this.tooLogCycle.Size = new System.Drawing.Size(45, 25);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel5.Text = "Log File : ";
            // 
            // tooLogFileName
            // 
            this.tooLogFileName.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tooLogFileName.Name = "tooLogFileName";
            this.tooLogFileName.Size = new System.Drawing.Size(100, 25);
            // 
            // tooLogFolderOpen
            // 
            this.tooLogFolderOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tooLogFolderOpen.Image = global::FcpTools.Properties.Resources.folders;
            this.tooLogFolderOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tooLogFolderOpen.Name = "tooLogFolderOpen";
            this.tooLogFolderOpen.Size = new System.Drawing.Size(23, 22);
            this.tooLogFolderOpen.Text = "DirectoryOpen";
            this.tooLogFolderOpen.Click += new System.EventHandler(this.tooLogFolderOpen_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitBody);
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 616);
            this.panel1.TabIndex = 0;
            // 
            // splitBody
            // 
            this.splitBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBody.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitBody.Location = new System.Drawing.Point(0, 0);
            this.splitBody.Name = "splitBody";
            // 
            // splitBody.Panel1
            // 
            this.splitBody.Panel1.Controls.Add(this.chart);
            // 
            // splitBody.Panel2
            // 
            this.splitBody.Panel2.Controls.Add(this.tableRight);
            this.splitBody.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitBody.Panel2MinSize = 285;
            this.splitBody.Size = new System.Drawing.Size(1160, 616);
            this.splitBody.SplitterDistance = 869;
            this.splitBody.TabIndex = 0;
            this.splitBody.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitBody_SplitterMoved);
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Transparent;
            chartArea4.BorderColor = System.Drawing.Color.Gray;
            chartArea4.Name = "Default";
            this.chart.ChartAreas.Add(chartArea4);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(869, 616);
            this.chart.TabIndex = 3;
            this.chart.Text = "SOFC Data Trend";
            this.chart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.chart_MouseDown);
            // 
            // tableRight
            // 
            this.tableRight.ColumnCount = 1;
            this.tableRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.Controls.Add(this.panelData, 0, 0);
            this.tableRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRight.Location = new System.Drawing.Point(0, 0);
            this.tableRight.Name = "tableRight";
            this.tableRight.RowCount = 1;
            this.tableRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableRight.Size = new System.Drawing.Size(287, 616);
            this.tableRight.TabIndex = 0;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.ChartTapControl);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(3, 3);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(281, 610);
            this.panelData.TabIndex = 5;
            // 
            // ChartTapControl
            // 
            this.ChartTapControl.Controls.Add(this.tabChart);
            this.ChartTapControl.Controls.Add(this.tabChartProperty);
            this.ChartTapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartTapControl.Location = new System.Drawing.Point(0, 0);
            this.ChartTapControl.Name = "ChartTapControl";
            this.ChartTapControl.SelectedIndex = 0;
            this.ChartTapControl.Size = new System.Drawing.Size(281, 610);
            this.ChartTapControl.TabIndex = 129;
            // 
            // tabChart
            // 
            this.tabChart.AutoScroll = true;
            this.tabChart.Controls.Add(this.tableLayoutPanel1);
            this.tabChart.Location = new System.Drawing.Point(4, 22);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(3);
            this.tabChart.Size = new System.Drawing.Size(273, 584);
            this.tabChart.TabIndex = 0;
            this.tabChart.Text = "Setting";
            this.tabChart.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(267, 578);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 283);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutData
            // 
            this.tableLayoutData.ColumnCount = 1;
            this.tableLayoutData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutData.Controls.Add(this.listColumns, 0, 1);
            this.tableLayoutData.Controls.Add(this.label2, 0, 0);
            this.tableLayoutData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutData.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutData.Name = "tableLayoutData";
            this.tableLayoutData.RowCount = 2;
            this.tableLayoutData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutData.Size = new System.Drawing.Size(261, 283);
            this.tableLayoutData.TabIndex = 5;
            // 
            // listColumns
            // 
            this.listColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listColumns.FormattingEnabled = true;
            this.listColumns.ItemHeight = 12;
            this.listColumns.Location = new System.Drawing.Point(3, 23);
            this.listColumns.Name = "listColumns";
            this.listColumns.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listColumns.Size = new System.Drawing.Size(255, 257);
            this.listColumns.TabIndex = 3;
            this.listColumns.DoubleClick += new System.EventHandler(this.listColumns_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Data List:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 292);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(261, 283);
            this.panel3.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.dgvSeries, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(261, 283);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // dgvSeries
            // 
            this.dgvSeries.AllowUserToAddRows = false;
            this.dgvSeries.AllowUserToDeleteRows = false;
            this.dgvSeries.AllowUserToResizeRows = false;
            this.dgvSeries.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvSeries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSeries.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sigName,
            this.sigColor,
            this.chartType});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSeries.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSeries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSeries.Location = new System.Drawing.Point(3, 38);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.RowHeadersVisible = false;
            this.dgvSeries.RowTemplate.Height = 23;
            this.dgvSeries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSeries.Size = new System.Drawing.Size(255, 242);
            this.dgvSeries.TabIndex = 80;
            this.dgvSeries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeries_CellDoubleClick);
            this.dgvSeries.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSeries_EditingControlShowing);
            this.dgvSeries.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSeries_MouseClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnUp);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.cbAreas);
            this.panel4.Controls.Add(this.btnDown);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(255, 29);
            this.panel4.TabIndex = 129;
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = global::FcpTools.Properties.Resources.arrow_up;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUp.Location = new System.Drawing.Point(222, 3);
            this.btnUp.Margin = new System.Windows.Forms.Padding(1);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(26, 24);
            this.btnUp.TabIndex = 128;
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Area:";
            // 
            // cbAreas
            // 
            this.cbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAreas.FormattingEnabled = true;
            this.cbAreas.Location = new System.Drawing.Point(46, 5);
            this.cbAreas.Name = "cbAreas";
            this.cbAreas.Size = new System.Drawing.Size(145, 20);
            this.cbAreas.TabIndex = 1;
            this.cbAreas.SelectedIndexChanged += new System.EventHandler(this.cbAreas_SelectedIndexChanged);
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::FcpTools.Properties.Resources.arrow_down;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDown.Location = new System.Drawing.Point(194, 3);
            this.btnDown.Margin = new System.Windows.Forms.Padding(1);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(26, 24);
            this.btnDown.TabIndex = 127;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // tabChartProperty
            // 
            this.tabChartProperty.Controls.Add(this.propertyChart);
            this.tabChartProperty.Location = new System.Drawing.Point(4, 22);
            this.tabChartProperty.Name = "tabChartProperty";
            this.tabChartProperty.Padding = new System.Windows.Forms.Padding(3);
            this.tabChartProperty.Size = new System.Drawing.Size(273, 584);
            this.tabChartProperty.TabIndex = 1;
            this.tabChartProperty.Text = "Advanced";
            this.tabChartProperty.UseVisualStyleBackColor = true;
            // 
            // propertyChart
            // 
            this.propertyChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyChart.Location = new System.Drawing.Point(3, 3);
            this.propertyChart.Name = "propertyChart";
            this.propertyChart.Size = new System.Drawing.Size(267, 578);
            this.propertyChart.TabIndex = 0;
            // 
            // sigName
            // 
            this.sigName.HeaderText = "Name";
            this.sigName.Name = "sigName";
            this.sigName.ReadOnly = true;
            // 
            // sigColor
            // 
            this.sigColor.HeaderText = "Color";
            this.sigColor.Name = "sigColor";
            this.sigColor.Width = 50;
            // 
            // chartType
            // 
            this.chartType.HeaderText = "Type";
            this.chartType.Items.AddRange(new object[] {
            "Line",
            "Spline",
            "FastLine",
            "Column",
            "Point"});
            this.chartType.Name = "chartType";
            this.chartType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chartType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.chartType.Width = 95;
            // 
            // FormChart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1166, 666);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.tableLayoutBase);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormChart";
            this.Text = "Realtime Chart";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tableLayoutBase.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitBody.Panel1.ResumeLayout(false);
            this.splitBody.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitBody)).EndInit();
            this.splitBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tableRight.ResumeLayout(false);
            this.panelData.ResumeLayout(false);
            this.ChartTapControl.ResumeLayout(false);
            this.tabChart.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutData.ResumeLayout(false);
            this.tableLayoutData.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabChartProperty.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutBase;
        private System.Windows.Forms.TableLayoutPanel tableUpper;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton toolAreaAdd;
        private System.Windows.Forms.ToolStripButton toolAreaRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tooLegendbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitBody;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.DataGridView dgvSeries;
        private System.Windows.Forms.ListBox listColumns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbAreas;
        private System.Windows.Forms.ToolStripComboBox toolCbChartArea;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton tooLogStart;
        private System.Windows.Forms.ToolStripButton tooLogStop;
        private System.Windows.Forms.ToolStripButton tooLogRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabControl ChartTapControl;
        private System.Windows.Forms.TabPage tabChart;
        private System.Windows.Forms.TabPage tabChartProperty;
        private System.Windows.Forms.PropertyGrid propertyChart;
        private System.Windows.Forms.ToolStripTextBox tooLogMaxValue;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox tooLogFileName;
        private System.Windows.Forms.ToolStripButton tooLogFolderOpen;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutData;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tooLogCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigColor;
        private System.Windows.Forms.DataGridViewComboBoxColumn chartType;
    }
}