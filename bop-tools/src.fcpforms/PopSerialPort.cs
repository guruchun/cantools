using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FcpTools
{
    public partial class PopSerialPort : Form
    {
        public FcpUtils.PortInfo PortInfo;

        public PopSerialPort()
        {
            InitializeComponent();
        }

        private void PopSerialPort_Load(object sender, EventArgs e)
        {
            // Baud rate
            var baudRates = new KeyValuePair<string, int>[6];
            baudRates[0] = new KeyValuePair<string, int>("9600", 9600);
            baudRates[1] = new KeyValuePair<string, int>("19200", 19200);
            baudRates[2] = new KeyValuePair<string, int>("56000", 56000);
            baudRates[3] = new KeyValuePair<string, int>("115200", 115200);
            baudRates[4] = new KeyValuePair<string, int>("230400", 230400);
            baudRates[5] = new KeyValuePair<string, int>("460800", 460800);
            cbSpeed.DisplayMember = "Key";
            cbSpeed.ValueMember = "Value";
            cbSpeed.DataSource = baudRates;
            cbSpeed.SelectedValue = PortInfo.BaudRate;

            // Parity
            var parities = new KeyValuePair<string, Parity>[5];
            parities[0] = new KeyValuePair<string, Parity>("None", Parity.None);
            parities[1] = new KeyValuePair<string, Parity>("Odd", Parity.Odd);
            parities[2] = new KeyValuePair<string, Parity>("Even", Parity.Even);
            parities[3] = new KeyValuePair<string, Parity>("Mark", Parity.Mark);
            parities[4] = new KeyValuePair<string, Parity>("Space", Parity.Space);
            cbParity.DisplayMember = "Key";
            cbParity.ValueMember = "Value";
            cbParity.DataSource = parities;
            cbParity.SelectedValue = PortInfo.Parity;

            // DataBits
            var dataBits_ = new KeyValuePair<string, int>[2];
            dataBits_[0] = new KeyValuePair<string, int>("7bit", 7);
            dataBits_[1] = new KeyValuePair<string, int>("8bit", 8);
            cbDataBits.DisplayMember = "Key";
            cbDataBits.ValueMember = "Value";
            cbDataBits.DataSource = dataBits_;
            cbDataBits.SelectedValue = PortInfo.DataBits;

            // StopBits
            var stopBits_ = new KeyValuePair<string, StopBits>[4];
            stopBits_[0] = new KeyValuePair<string, StopBits>("None", StopBits.None);
            stopBits_[1] = new KeyValuePair<string, StopBits>("1", StopBits.One);
            stopBits_[2] = new KeyValuePair<string, StopBits>("1.5", StopBits.OnePointFive);
            stopBits_[3] = new KeyValuePair<string, StopBits>("2", StopBits.Two);
            cbStopBits.DisplayMember = "Key";
            cbStopBits.ValueMember = "Value";
            cbStopBits.DataSource = stopBits_;
            cbStopBits.SelectedValue = PortInfo.StopBits;

            // FlowControl
            var handShakes = new KeyValuePair<string, Handshake>[4];
            handShakes[0] = new KeyValuePair<string, Handshake>("None", Handshake.None);
            handShakes[1] = new KeyValuePair<string, Handshake>("HW RTS", Handshake.RequestToSend);
            handShakes[2] = new KeyValuePair<string, Handshake>("HW & SW", Handshake.RequestToSendXOnXOff);
            handShakes[3] = new KeyValuePair<string, Handshake>("SW XOnOff", Handshake.XOnXOff);
            cbFlowControl.DisplayMember = "Key";
            cbFlowControl.ValueMember = "Value";
            cbFlowControl.DataSource = handShakes;
            cbFlowControl.SelectedValue = PortInfo.Handshake;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            PortInfo.BaudRate = (int)cbSpeed.SelectedValue;
            PortInfo.Parity = (Parity)cbParity.SelectedValue;
            PortInfo.DataBits = (int)cbDataBits.SelectedValue;
            PortInfo.StopBits = (StopBits)cbStopBits.SelectedValue;
            PortInfo.Handshake = (Handshake)cbFlowControl.SelectedValue;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
