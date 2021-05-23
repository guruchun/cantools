using FcpUtils;
using log4net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace FcpTools
{
    public partial class FormDevice : DockContent {
        // static members --------------------
        static readonly ILog log = LogManager.GetLogger("Console");

        private EpeAdapter _epeAdapter = new EpeAdapter();
        private PortInfo _portInfo = new PortInfo();

        // private members --------------------
        //private System.Windows.Forms.Timer timer;
        private System.Timers.Timer threadTimer;
        private int intervalTime = 1000;

        public FormDevice()
        {
            try {
                InitializeComponent();
                _epeAdapter.Updated += new EventHandler(epeUpdated);

                threadTimer = new System.Timers.Timer();
                threadTimer.Interval = intervalTime;
                threadTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Tick);

                log.DebugFormat("initialized a form {0}", this.GetType().Name);
            }
            catch (Exception ex) {
                log.ErrorFormat("failed to create a form {0}, ex={1}", this.GetType().Name, ex.Message);
            }
        }

        // 디바이스로부터 메시지를 받아 처리하고 상태가 변경되면 이벤트가 발생한다.
        // 메시지의 최신 내용으로 Data Table을 업데이트한다.
        void epeUpdated(object sender, EventArgs e)
        {
            if (e is EpeEventArgs) {
                EpeEventArgs args = (EpeEventArgs)e;

                // get tag values
                EpeMessage.Command cmd = args.Cmd;
                if (cmd == EpeMessage.Command.GET_MEAVAL) {
                    // update MemTable
                    SystemData.UpdateTagData((Dictionary<string, float>)args.Value);

                    // update display

                } else if (cmd == EpeMessage.Command.GET_SN) {
                    UpdateTextBox(txtSerialNum, (string)args.Value);
                } else if (cmd == EpeMessage.Command.GET_SWVER) {
                    UpdateTextBox(txtVersion, (string)args.Value);
                }
            }
        }

        delegate void updateControl(object o, string value);
        public void UpdateTextBox(object o, string value)
        {
            if (o.GetType().Name == "TextBox") {
                TextBox tb = o as TextBox;
                if (tb.InvokeRequired) {
                    updateControl d = new updateControl(UpdateTextBox);
                    this.Invoke(d, o, value);
                    return;
                } else {
                    tb.Text = value;
                }
            }
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                // port configuration
                RefreshPorts();
                // 9600, no parity, 8 databits, 1 stopbit
                _portInfo.BaudRate = 9600;
                // display it
                labelPortInfo.Text = string.Format("{0}-{1}-{2}-{3}",
                    _portInfo.BaudRate, _portInfo.DataBits, _portInfo.Parity.ToString(), _portInfo.StopBits.ToString());

                txtAddress.Text = "0";
                // set periodic query interval
                txtInterval.Text = intervalTime.ToString();

                //tableLayoutPanel1.AutoScroll = true;
                // columnAutoResize
                dgvMeasureItems.Columns[dgvMeasureItems.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                RefreshValues();


                // data source
                //dgvSigValues.DataSource = SystemData.MemTable;

                log.DebugFormat("loaded a form {0}", this.GetType().Name);
            }
            catch (Exception e1)
            {
                log.ErrorFormat("failed to load a form {0}, ex={1}", this.GetType().Name, e1.Message);
            }
        }

        private void RefreshValues()
        {
            dgvMeasureItems.Rows.Clear();

            // TODO update values
        }

        private void portRefresh_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void RefreshPorts()
        {
            // show list of valid com ports
            cbPortList.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                cbPortList.Items.Add(s);
            }

            // find index
            cbPortList.SelectedIndex = -1;
            for (int i=0; i < cbPortList.Items.Count; i++)
            {
                if (cbPortList.Items[i].ToString() == _portInfo.PortName)
                {
                    cbPortList.SelectedIndex = i;
                    break;
                }
            }
            if (cbPortList.Items.Count > 0 && cbPortList.SelectedIndex == -1)
                cbPortList.SelectedIndex = 0;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //dgvSigValuesFilter();

            if (btnOpen.Text == "Open")
            {
                if (cbPortList.Items.Count < 1)
                {
                    log.Error("serial port is not found");
                    return;
                }
                try
                {
                    _portInfo.PortName = (string)cbPortList.SelectedItem;
                    _epeAdapter.SetPort(_portInfo);
                    _epeAdapter.Start();
                    btnOpen.Text = "Close";
                    cbPortList.Enabled = false;
                    log.Debug(_portInfo.PortName + " is opened ... ");
                }
                catch (Exception ex)
                {
                    log.Error(_portInfo.PortName + " open Error, " + ex.Message);
                    return;
                }
            }
            else
            {
                try
                {
                    _epeAdapter.Stop();
                    btnOpen.Text = "Open";
                    cbPortList.Enabled = true;
                    log.Debug(_portInfo.PortName + " is closed ... ");
                }
                catch (Exception ex)
                {
                    log.Error(_portInfo.PortName + " close Error, " + ex.Message);
                    return;
                }
            }
        }

        // TODO initialize grid view 

        // TODO refresh grid view by sensor data

        private List<byte> UpdateCheckedItems()
        {
            List<byte> checkedIndex = new List<byte>();
            foreach (DataGridViewRow row in dgvMeasureItems.Rows) {
                if ((bool)row.Cells[0].Value == true)
                    checkedIndex.Add((byte)row.Cells[1].Value);
            }

            return checkedIndex;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (chkPeriodic.Checked) {
                    _epeAdapter.SendRequest(byte.Parse(txtAddress.Text), EpeMessage.Command.GET_MEAVAL);
                }
            }
            catch (Exception ex)
            {
                log.Debug($"Timer Tick Error, ex={ex.Message}");
            }
        } 

        private void chkPeriodic_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!(sender is CheckBox cbox))
                    return;

                if (cbox.Checked)
                    threadTimer.Start();
                else
                    threadTimer.Stop();
            }
            catch (Exception ex)
            {
                log.Error($"chkPeriodic_CheckedChanged Error : {ex.Message}");
            }
        }

        private void txtInterval_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            try {
                if (!(sender is TextBox textbox))
                    return;

                intervalTime = int.Parse(textbox.Text);
            }
            catch (Exception ex) {
                log.ErrorFormat("txtInterval Error : {0}", ex.Message);
                ((TextBox)sender).Text = "";
            }
        }

        private void btnReadSN_Click(object sender, EventArgs e)
        {
            try {
                _epeAdapter.SendRequest(byte.Parse(txtAddress.Text), EpeMessage.Command.GET_SN);
            }
            catch (Exception ex) {
                log.ErrorFormat("address is invalid, ex={0}", ex.Message);
            }
        }

        private void btnReadVer_Click(object sender, EventArgs e)
        {
            try {
                _epeAdapter.SendRequest(byte.Parse(txtAddress.Text), EpeMessage.Command.GET_SWVER);
            }
            catch (Exception ex) {
                log.ErrorFormat("address is invalid, ex={0}", ex.Message);
            }
        }

        private void btnReadMeasure_Click(object sender, EventArgs e)
        {
            try {
                List<byte> list = UpdateCheckedItems();
                _epeAdapter.SetMeasuringItems(list);
                _epeAdapter.SendRequest(byte.Parse(txtAddress.Text), EpeMessage.Command.GET_MEAVAL);
            }
            catch (Exception ex) {
                log.ErrorFormat("address is invalid, ex={0}", ex.Message);
            }
        }
    }
}