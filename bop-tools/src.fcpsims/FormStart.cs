using FcpUtils;
using log4net;
using System;
using System.IO.Ports;
using WeifenLuo.WinFormsUI.Docking;
using WinModbus;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using FcpTools;

namespace FcpSims
{
    public partial class FormStart : DockContent
    {
        // static members --------------------
        static readonly ILog log = LogManager.GetLogger("Console");

        // instance members
        private ModRtuServer _modbusSvr = new ModRtuServer();
        private PortInfo _portInfo = new PortInfo();

        // 2020.11.16 sungjun
        private Dictionary<string, ModbusMap.AddressInfo> dic = new Dictionary<string, ModbusMap.AddressInfo>();
        private Dictionary<string, Dictionary<string, ModbusMap.AddressInfo>> dicModbusReg = new Dictionary<string, Dictionary<string, ModbusMap.AddressInfo>>();
        ModbusClient modbusClient = new ModbusClient();

        public FormStart()
        {
            InitializeComponent();
            Application.Idle += DgvVisibleFilter;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            try
            {
                // port configuration
                RefreshPorts();

                // 2020.11.16 sungjun
                //ModbusConnection();
                LoadModbusMap();
                CreateMemTable();

                log.DebugFormat("loaded a form {0}", this.GetType().Name);
            }
            catch (Exception e1)
            {
                log.ErrorFormat("failed to load a form {0}, ex={1}", this.GetType().Name, e1.Message);
            }
        }

        private void portRefresh_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void RefreshPorts()
        {
            //show list of valid com ports
            InvPort.Items.Clear();
            TcmPort.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                InvPort.Items.Add(s);
                TcmPort.Items.Add(s);
            }

            // find index
            InvPort.SelectedIndex = -1;
            for (int i = 0; i < InvPort.Items.Count; i++)
            {
                if (InvPort.Items[i].ToString() == _portInfo.PortName)
                {
                    InvPort.SelectedIndex = i;
                    break;
                }
            }
            if (InvPort.Items.Count > 0 && InvPort.SelectedIndex == -1)
                InvPort.SelectedIndex = 0;

            // TODO TCM port
        }

        private void portConfig_Click(object sender, EventArgs e)
        {
            FcpTools.PopSerialPort config = new FcpTools.PopSerialPort
            {
                PortInfo = this._portInfo
            };
            config.ShowDialog();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {

            if (BtnOpen.Text == "Open")
            {
                if (CbPortList.Items.Count < 1)
                {
                    log.Error("serial port is not found");
                    return;
                }
                try
                {
                    _portInfo.PortName = (string)CbPortList.SelectedItem;
                    _modbusSvr.Port = _portInfo.PortName;
                    _modbusSvr.Config(_portInfo.BaudRate, _portInfo.DataBits, _portInfo.Parity, _portInfo.StopBits);
                    bool isOk = _modbusSvr.Start();
                    if (isOk)
                    {
                        BtnOpen.Text = "Close";
                        CbPortList.Enabled = false;
                        log.Debug(_portInfo.PortName + " is opened ... ");
                    }
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
                    _modbusSvr.Stop();
                    BtnOpen.Text = "Open";
                    CbPortList.Enabled = true;
                    log.Debug(_portInfo.PortName + " is closed ... ");
                }
                catch (Exception ex)
                {
                    log.Error(_portInfo.PortName + " close Error, " + ex.Message);
                    return;
                }
            }
        }

        // 2020.11.16 sungjun ModbusMap
        private void ModbusConnection()
        {
            modbusClient.IPAddress = ConfigInfo.GetSettings().DeviceProperties["Tcm.ip"];
            modbusClient.Port = int.Parse(ConfigInfo.GetSettings().DeviceProperties["Tcm.portNum"].ToString());
            modbusClient.ReplyTimeout = 3000;
            modbusClient.Connect();
        }


        private void LoadModbusMap()
        {
            string tcm_mapFilePath = ConfigInfo.GetSettings().DeviceProperties["Tcm.mapFile"];
            string type = "Modbus";

            XmlSerializer serializer = new XmlSerializer(typeof(ModbusMap));
            TextReader reader = new StreamReader(Application.StartupPath + "/maps/" + tcm_mapFilePath);
            ModbusMap map = (ModbusMap)serializer.Deserialize(reader);

            foreach (var group in map.registers)
            {
                foreach (var register in group.register)
                {
                    try
                    {
                        dic.Add(group.type + ":" + (group.baseAddress + register.address), register);
                    }
                    catch (Exception ex)
                    {
                        log.Error($"Load ModbusMap Error : {ex.Message}");
                    }
                }
            }

            dicModbusReg.Add(type, dic);
        }

        // start reequest
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!modbusClient.Connected)
                ModbusConnection();
        }

        // MemTable
        private void CreateMemTable()
        {
            try
            {
                foreach (KeyValuePair<string, ModbusMap.AddressInfo> kv in dic)
                {
                    DataRow row = SystemData.MemTable.Rows.Find(kv.Value.tag);

                    if (row != null)
                    {
                        log.Error($"duplicate {kv.Value.tag}");
                    }
                    else
                    {
                        SystemData.MemTable.Rows.Add(new object[] { kv.Value.description, 0, kv.Value.tag });
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error($"Insert MemTable in Data Error : {ex.Message}");
            }
        }

        private void BtnConfigPort_Click(object sender, EventArgs e)
        {
            PopSerialPort config = new PopSerialPort
            {
                PortInfo = this._portInfo
            };
            config.ShowDialog();
        }

        private void BtnRefreshPort_Click(object sender, EventArgs e)
        {
            RefreshPorts();
        }

        private void BtnOpen_Click_1(object sender, EventArgs e)
        {

        }
    }
}
