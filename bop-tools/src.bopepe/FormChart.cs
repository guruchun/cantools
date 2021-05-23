using log4net;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WeifenLuo.WinFormsUI.Docking;
namespace FcpTools
{
    public partial class FormChart : DockContent {
        // static members --------------------
        static readonly ILog log = LogManager.GetLogger("Console");

        // private members --------------------
        private Timer timer;
        List<string> _dataList = new List<string>();
        private ChartArea _ca;
        private DataGridView _dataCell = new DataGridView();
        int _LogMaxPoints = 1000;

        string logFileName = "";
        string logFileHeader = "Date,Time";
        string logFileContent;

        int chartAreaIndex;

        bool isRun = false;

        public FormChart()
        {
            try { 
                InitializeComponent();
                timer = new Timer();
                timer.Tick += new EventHandler(Timer_Tick);
                timer.Interval = 100;

                log.DebugFormat("initialized a form {0}", this.GetType().Name);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("failed to create a form {0}, ex={1}", this.GetType().Name, ex.Message);
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                // get char area list
                UpdateChartAreaList();

                // set property window of chart
                propertyChart.SelectedObject = chart;

                // create ColumnList
                CreateColumnList(SystemData.MemTable);

                // bind data source & set chart options
                SetDefaultChart();

                // set base log value 
                tooLogMaxValue.Text = _LogMaxPoints.ToString();

                // set base log, chart cycle
                SetDefaultCycle();

                log.DebugFormat("loaded a form {0}", this.GetType().Name);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("failed to load a form {0}, ex={1}", this.GetType().Name, ex.Message);
            }
        }

        private void UpdateChartAreaList()
        {
            try
            {
                // clear list
                cbAreas.Items.Clear();
                toolCbChartArea.Items.Clear();
                //toolCbChartArea.Text = "";

                // area list
                foreach (ChartArea area in chart.ChartAreas)
                {
                    cbAreas.Items.Add(area.Name);
                    toolCbChartArea.Items.Add(area.Name);
                }
                if (cbAreas.Items.Count > 0)
                {
                    cbAreas.SelectedIndex = 0;
                    toolCbChartArea.SelectedIndex = 0;
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        private void SetDefaultChart()
        {
            // bind data source & set chart options
            //_dataView = new DataView(_dataTable);
            //chart.DataBindTable(_dataView, "Time");
            chart.DataSource = SystemData.MemTable;

            // TODO load chart layout

            // set chart
            //Title title = chart.Titles.Add("chart title");
            //title.ForeColor = System.Drawing.Color.DarkBlue;
            //title.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);

            // set chart area
            foreach (ChartArea ca in chart.ChartAreas)
            {
                SetDefaultChartArea(ca);
            }

            // Add Chart Legend
            chart.Legends.Add("Legend");
            // Change Legend Position
            chart.Legends["Legend"].Docking = Docking.Bottom;
        }

        private void SetDefaultChartArea(ChartArea ca)
        {
            //ca.AxisY.Title = "titleY";
            //ca.AxisX.Title = "titleX";
            ca.AxisX.LabelStyle.Format = "HH:mm:ss";
            //ca.AxisX.IsLabelAutoFit = false;
            //ca.AxisX.LabelStyle = new LabelStyle() { IntervalType = DateTimeIntervalType.Minutes, Interval = 10, Format = "HH:mm:ss" };
            ca.AxisX.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            ca.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.DarkGray;
            ca.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
        }

        private void SetDefaultCycle()
        {
            tooLogCycle.Text = timer.Interval.ToString();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            try
            {
                // add series to chart area and legend
                foreach (string colName in listColumns.SelectedItems)
                {
                    string selected_Item = colName;
                    bool isDuplication = false;

                    // Series Name Duplicatie Check
                    var result = DuplicateSeriesNameCheck(selected_Item);
                    selected_Item = result.Item1;
                    isDuplication = result.Item2;

                    // add series
                    Series s = chart.Series.Add(selected_Item);

                    // Auto PalletColor Setting Method
                    chart.ApplyPaletteColors();

                    // set series
                    s.XValueType = ChartValueType.DateTime;
                    s.BorderWidth = 1;
                    s.ChartType = SeriesChartType.Line;
                    s.ChartArea = cbAreas.SelectedItem.ToString();

                    // DataGridView Rows Setting ( Color, Type )
                    int row = dgvSeries.Rows.Add(new object[] { selected_Item, "" });
                    dgvSeries.Rows[row].Cells[1].Style.BackColor = chart.Series[selected_Item].Color;
                    dgvSeries.Rows[row].Cells[2].Value = chart.Series[selected_Item].ChartType.ToString();
                }

                // refresh series of chart area
                chart.DataBind();
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }

        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            // set signal list
            foreach (DataGridViewCell cell in dgvSeries.SelectedCells)
            {
                string colName = (string)dgvSeries.Rows[cell.RowIndex].Cells[0].Value;
                dgvSeries.Rows.Remove(dgvSeries.Rows[cell.RowIndex]);

                // remove series from chart
                chart.Series.Remove(chart.Series[colName]);
            }
        }

        private void toolAreaAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ChartArea ca = (chart.ChartAreas.FindByName(toolCbChartArea.Text));
                if (ca == null)
                {
                    ca = chart.ChartAreas.Add(toolCbChartArea.Text);
                    SetDefaultChartArea(ca);

                    UpdateChartAreaList();
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        private void toolAreaRemove_Click(object sender, EventArgs e)
        {
            try
            {
                ChartArea ca = (chart.ChartAreas.FindByName(toolCbChartArea.Text));
                if (ca != null)
                {
                    // Delete With Series
                    SeriesDeleteFromChartArea(ca);
                    chart.ChartAreas.Remove(ca);

                    UpdateChartAreaList();
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        private void splitBody_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Console.WriteLine("width={0}, distance={1}", splitBody.Size.Width, splitBody.SplitterDistance);
        }

        private void dgvSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // set color
            if (e.ColumnIndex == 1)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = dgvSeries.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    dgvSeries.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = colorDialog.Color;
                    chart.Series[(string)dgvSeries.Rows[e.RowIndex].Cells[0].Value].Color = colorDialog.Color;

                    string seleted_ChartArea = cbAreas.SelectedItem.ToString();
                    dgvSeries.Rows.Clear();

                    foreach (Series s in chart.Series)
                    {
                        if (seleted_ChartArea == s.ChartArea)
                        {
                            int idx = dgvSeries.Rows.Add(new object[] { s.Name, "" });
                            var row = dgvSeries.Rows[idx];
                            chart.ApplyPaletteColors();

                            row.Cells[1].Style.BackColor = s.Color;
                            row.Cells[2].Value = s.ChartType.ToString();
                        }
                    }
                }
            }

            // DgvColumn Item DoubleClick
            if (e.ColumnIndex == 0)
            {
                string selectedValue = dgvSeries.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                dgvSeries.Rows.Remove(dgvSeries.Rows[e.RowIndex]);
                chart.Series.Remove(chart.Series[selectedValue]);
            }
        }

        private void FormChart_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Console.WriteLine("help requested... {0}", GetType().Name);
        }



        // ChartArea Delete with Series
        private void SeriesDeleteFromChartArea(ChartArea ca)
        {
            List<string> list = new List<string>();

            foreach (Series series in chart.Series)
            {
                if (series.ChartArea == ca.Name)
                {
                    list.Add(series.Name);
                }
            }

            foreach (string name in list)
            {
                chart.Series.Remove(chart.Series[name]);
            }
        }

        // dgvSeries Change ChartArea Right Click
        private void dgvSeries_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();

                foreach (ChartArea chartArea in chart.ChartAreas)
                {
                    if(chartArea.Name != cbAreas.SelectedItem.ToString())
                    {
                        menu.Items.Add(chartArea.Name);
                    }
                }

                int currentMouseOverRow = dgvSeries.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    try
                    {
                        menu.Show(dgvSeries, new Point(e.X, e.Y));
                        chartAreaIndex = currentMouseOverRow;
                        menu.ItemClicked += new ToolStripItemClickedEventHandler(dgvSeriesContextItemClick);
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine(e1.Message);
                    }
                }
            }
        }

        private void dgvSeriesContextItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            string chartArea = item.Text;

            string name = dgvSeries.Rows[chartAreaIndex].Cells[0].Value.ToString();
            chart.Series[name].ChartArea = chartArea;
            dgvSeries.Rows.Remove(dgvSeries.Rows[chartAreaIndex]);
        }

        // DataTable to ColumnList
        private void CreateColumnList(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                listColumns.Items.Add(row["Tag Name"].ToString());
                _dataList.Add(row["Tag Name"].ToString());

            }
        }

        // Timer Start BtnClick
        private void tooLogStart_Click(object sender, EventArgs e)
        {
            if (isRun)
            {
                MessageBox.Show("현재 로깅 중 입니다.");
                return;
            }

            // detect log directory
            string logDir = @"log-CAN";
            if (!System.IO.Directory.Exists(logDir))
            {
                System.IO.Directory.CreateDirectory(logDir);
            }

            // detect log file name
            if(tooLogFileName.Text.Length == 0)
            {
                if(File.Exists(@"./log-CAN/" + "log.csv"))
                {
                    int i = 1;
                    
                    while(File.Exists(@"./log-CAN/" + $"log{i}.csv"))
                    {
                        i++;
                    }

                    logFileName = $"log{i}.csv";
                }
                else
                {
                    logFileName = "log.csv";
                }
            } 
            else
            {
                logFileName = tooLogFileName.Text + ".csv";
            }

            StreamWriter writer = new StreamWriter(@"./log-CAN/" + logFileName);
            writer.WriteLine(CSVHeaderSetting());
            writer.WriteLine(CSVTypeSetting());
            writer.Close();

            timer.Start();
            isRun = true;
        }

        // Timer Stop BtnClick
        private void tooLogStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            isRun = false;
        }

        // Timer Tick
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime Xvalue = DateTime.Now;
                foreach (Series series in chart.Series)
                {
                    string signal = series.Name;
                    string signalOriginal = series.Name;

                    if (signal.IndexOf("(") != -1)
                    {
                        signal = signal.Substring(0, signal.IndexOf("("));
                    }

                    string result = SystemData.MemTable.Rows.Find(signal)["Value"].ToString();
                    double Yvalue;
                    bool val_tryParse = double.TryParse(result, out Yvalue);

                    if (!val_tryParse)
                    {
                        if (result == "True")
                            Yvalue = 1.0;
                        else
                            Yvalue = 0.0;
                        chart.Series[signalOriginal].Points.AddXY(Xvalue, Yvalue);
                        //chart.Series[signalOriginal].Points[chart.Series[signal].Points.Count - 1].IsValueShownAsLabel = true;
                    }
                    else
                    {
                        chart.Series[signalOriginal].Points.AddXY(Xvalue, Yvalue);
                        //chart.Series[signalOriginal].Points[chart.Series[signal].Points.Count - 1].IsValueShownAsLabel = true;
                        //chart.Series[signalOriginal].Points[chart.Series[signal].Points.Count - 2].IsValueShownAsLabel = false;
                    }
                }

                foreach (Series series in chart.Series)
                {
                    int pointCount = series.Points.Count;

                    if (pointCount >= _LogMaxPoints)
                    {
                        int num = pointCount - _LogMaxPoints;

                        for (int i = 0; i < num; i++)
                        {
                            series.Points.RemoveAt(i);
                        }

                        chart.ResetAutoValues();
                    }
                }

                CSVContentSetting();
                CSVSaveLog(logFileContent, logFileName);
            }
            catch (Exception e1)
            {
                log.Error($"Timer Tick Error : {e1.Message}");
            }
        }

        // Log Reset Btn Click
        private void tooLogRefresh_Click(object sender, EventArgs e)
        {
            foreach(Series s in chart.Series)
            {
                s.Points.Clear();
            }
        }


        // ListColumn Item DoubleClick
        private void listColumns_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string selected_Item = listColumns.SelectedItem.ToString();
                bool isDuplication = false;

                var result = DuplicateSeriesNameCheck(selected_Item);
                selected_Item = result.Item1;
                isDuplication = result.Item2;

                Series s = chart.Series.Add(selected_Item);

                chart.ApplyPaletteColors();
                s.XValueType = ChartValueType.DateTime;
                s.BorderWidth = 1;
                s.ChartType = SeriesChartType.Line;
                //s.Points.AddXY(DateTime.Now, 0);

                s.ChartArea = cbAreas.SelectedItem.ToString();

                int row = dgvSeries.Rows.Add(new object[] { selected_Item, "" });
                dgvSeries.Rows[row].Cells[1].Style.BackColor = chart.Series[selected_Item].Color;
                dgvSeries.Rows[row].Cells[2].Value = chart.Series[selected_Item].ChartType.ToString();
                
                chart.DataBind();
            }
            catch (Exception e1)
            {
                Console.WriteLine("---listColumns_DoubleClick()---");
                Console.WriteLine(e1.Message);
            }
        }

        // Series 추가시 중복일경우 넘버링을 하는 함수
        private Tuple<string, bool> DuplicateSeriesNameCheck(string _seriesName)
        {
            int count = 0;
            bool duplication = false;

            while (true)
            {
                if (chart.Series.IndexOf(_seriesName) != -1)
                {
                    if (_seriesName.IndexOf('(') != -1)
                    {
                        _seriesName = _seriesName.Substring(0, _seriesName.IndexOf('('));
                        count++;
                        _seriesName = _seriesName + $"({count})";
                    }
                    else
                    {
                        count++;
                        _seriesName = _seriesName + $"({count})";
                    }
                    duplication = true;
                }
                else
                {
                    break;
                }
            }

            return Tuple.Create(_seriesName, duplication);
        }

        // Chart Legend On OFF
        private void tooLegendbtn_Click(object sender, EventArgs e)
        {
            chart.Legends["Legend"].Enabled = !chart.Legends["Legend"].Enabled;
        }

        // Chart Zoom
        // ChartArea Right Mouse Click
        private void OnChartContext(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip prtMenuStrip = (ContextMenuStrip)sender;
            Chart chart = (Chart)prtMenuStrip.SourceControl;

            if (chart.ChartAreas.Count <= 0)
            {
                return;
            }

            ChartArea area = _ca;

            if(area == null)
            {
                return;
            }

            ToolStripMenuItem menuItem = (ToolStripMenuItem)e.ClickedItem;
            switch (e.ClickedItem.Text)
            {
                case "Zoom-X":
                    {
                        menuItem.Checked = !area.CursorX.IsUserSelectionEnabled;
                        area.CursorX.IsUserSelectionEnabled = menuItem.Checked;
                    }
                    break;
                case "Zoom-Y":
                    {
                        menuItem.Checked = !area.CursorY.IsUserSelectionEnabled;
                        area.CursorY.IsUserSelectionEnabled = menuItem.Checked;
                    }
                    break;
                case "Reset Zoom":
                    {
                        area.AxisX.ScaleView.ZoomReset(0);
                        area.AxisY.ScaleView.ZoomReset(0);
                    }
                    break;
            }
        }

        // ChartArea Click
        private void chart_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                // chart
                Chart chart = (Chart)sender;
                HitTestResult result = chart.HitTest(e.X, e.Y);

                if(_ca != null)
                {
                    _ca.BorderDashStyle = ChartDashStyle.NotSet;
                    _ca.BorderColor = Color.Empty;
                    _ca.BorderWidth = 0;
                }

                _ca = result.ChartArea;

                if (e.Button == MouseButtons.Left)
                {
                    if (_ca == null)
                    {
                        return;
                    }

                    toolCbChartArea.SelectedItem = _ca.Name;
                    cbAreas.SelectedItem = _ca.Name;

                    _ca.BorderDashStyle = ChartDashStyle.Dot;
                    _ca.BorderColor = Color.Black;
                    _ca.BorderWidth = 1;
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (_ca == null)
                    {
                        return;
                    }

                    // menu items
                    ToolStripMenuItem menuItem;
                    ContextMenuStrip contextMenu = new ContextMenuStrip();

                    //contextMenu.Items.Add(new ToolStripMenuItem("Zoom-X"));

                    menuItem = (ToolStripMenuItem)contextMenu.Items.Add("Zoom-X");
                    menuItem.Checked = _ca.CursorX.IsUserSelectionEnabled;
                    menuItem = (ToolStripMenuItem)contextMenu.Items.Add("Zoom-Y");
                    menuItem.Checked = _ca.CursorY.IsUserSelectionEnabled;

                    contextMenu.Items.Add(new ToolStripSeparator());

                    contextMenu.Items.Add("Reset Zoom");
                    chart.ContextMenuStrip = contextMenu;
                    chart.ContextMenuStrip.ItemClicked += OnChartContext;
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        // Log Save for Series
        private string CSVHeaderSetting()
        {
            string _header = logFileHeader;

            foreach(Series seriesName in chart.Series)
            {
                _header += "," + seriesName.Name;
            }
            return _header;
        }

        private string CSVTypeSetting()
        {
            string _type = "Date,Date";

            for(int i = 0; i < chart.Series.Count; i++)
            {
                _type += "," + "Double";
            }

            return _type;
        }

        private void CSVContentSetting()
        {
            logFileContent = DateTime.Now.ToString("yyyy-MM-dd,HH:mm:ss.fff");

            foreach(Series series in chart.Series)
            {
                if (chart.Series.FindByName(series.Name) != null)
                {
                    logFileContent += "," + series.Points[series.Points.Count - 1].YValues[0].ToString();
                }
                continue;   
            }
        }

        private void CSVSaveLog(string _content, string _fileName)
        {
                StreamWriter writer = new StreamWriter(@"./log-CAN/" + _fileName, true);
                writer.WriteLine(_content);
                writer.Close();
        }

        // Chart Type Change
        private void dgvSeries_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                ComboBox cb = e.Control as ComboBox;
                _dataCell = sender as DataGridView;

                if(cb != null)
                {
                    cb.SelectedIndexChanged -= new EventHandler(cb_SelectedIndexChanged);
                    cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
                }
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selected_Item = ((ComboBox)sender).SelectedItem.ToString();
                string selected_Series = dgvSeries.Rows[_dataCell.CurrentCell.RowIndex].Cells[0].Value.ToString();

                chart.Series[selected_Series].ChartType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), selected_Item);
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        // Log Max Value Changed
        private void toolLogMaxValueBtn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tooLogMaxValue.Text, out int maxVal))
            {
                _LogMaxPoints = maxVal;
            } 
            else
            {
                MessageBox.Show("숫자만 입력 할 수 있습니다.");
            }
        }

        // LogFolder Open
        private void tooLogFolderOpen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + "\\log-CAN");
        }

        // cbAreas ComboBox Changed
        private void cbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string seleted_ChartArea = cbAreas.SelectedItem.ToString();
                dgvSeries.Rows.Clear();

                foreach (Series s in chart.Series)
                {
                        if (seleted_ChartArea == s.ChartArea)
                    {
                        int idx = dgvSeries.Rows.Add(new object[] { s.Name, "" });
                        var row = dgvSeries.Rows[idx];
                        chart.ApplyPaletteColors();

                        row.Cells[1].Style.BackColor = s.Color;
                        row.Cells[2].Value = s.ChartType.ToString();
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("---cbAreas_SelectedIndexChanged---");
                Console.WriteLine(e1.Message);
            }
        }

        // Log Cycle Value Changed Btn Click Event
        private void toolLogCycleBtn_Click(object sender, EventArgs e)
        {
            string cycle = tooLogCycle.Text;

            if(int.TryParse(cycle, out int result))
            {
                timer.Interval = result;
            }
            else
            {
                MessageBox.Show("숫자로 입력해야 합니다.");
            }
                
        }

        private void tooLogMaxValue_Click(object sender, EventArgs e)
        {

        }
    }
}