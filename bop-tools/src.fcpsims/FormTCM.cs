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
    public partial class FormTCM : DockContent
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

        public FormTCM()
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

                // data source
                DgvSysData.DataSource = SystemData.MemTable;
                DgvSysData.Columns["Value"].DefaultCellStyle.Format = "0.00##";
                DgvSysData.Columns["Updated"].DefaultCellStyle.Format = "HH:mm:ss";
                DgvSysData.Columns["Counter"].Visible = false; // counter

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
            CbPortList.Items.Clear();
            foreach (string s in SerialPort.GetPortNames())
            {
                CbPortList.Items.Add(s);
            }

            // find index
            CbPortList.SelectedIndex = -1;
            for (int i = 0; i < CbPortList.Items.Count; i++)
            {
                if (CbPortList.Items[i].ToString() == _portInfo.PortName)
                {
                    CbPortList.SelectedIndex = i;
                    break;
                }
            }
            if (CbPortList.Items.Count > 0 && CbPortList.SelectedIndex == -1)
                CbPortList.SelectedIndex = 0;
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

            foreach (KeyValuePair<string, ModbusMap.AddressInfo> kv in dic)
            {
                modbusClient.ClearRxBuffer();

                string[] _a = kv.Key.Split(':');
                string type = _a[0];
                string addr = _a[1];
                int quantity = 1;
                ModbusFunc func;

                if (type == "COIL")
                    func = ModbusFunc.READ_COIL;
                else if (type == "DISC")
                    func = ModbusFunc.READ_DISC;
                else if (type == "REG")
                    func = ModbusFunc.READ_HOREG;
                else if (type == "INREG")
                    func = ModbusFunc.READ_INREG;
                else
                    func = ModbusFunc.READ_COIL;

                readModbus(func, int.Parse(addr), quantity);
            }
        }

        private void readModbus(ModbusFunc func, int startAddr, int quantity)
        {
            try
            {
                byte[] sendByte = modbusClient.MakeReadMessage(1, (byte)func, startAddr, quantity);
                byte[] recvByte = modbusClient.SendRequest(sendByte);

                if (recvByte == null || recvByte.Length < 6)
                {
                    Console.WriteLine("recv data is invalid");
                    return;
                }

                if (func == ModbusFunc.READ_COIL || func == ModbusFunc.READ_DISC)
                {
                    bool[] serverResponse = ModbusClient.ParseBitMessage(recvByte, quantity);

                    ModbusMap.AddressInfo info = new ModbusMap.AddressInfo();
                    for (int i = 0; i < serverResponse.Length; i++)
                    {
                        string tag = "";
                        string desc = "";
                        string key = (func == ModbusFunc.READ_COIL ? "COIL:" : "DISC:") + (startAddr + i).ToString();

                        if (dicModbusReg.ContainsKey("Modbus"))
                        {
                            bool found = dicModbusReg["Modbus"].TryGetValue(key, out info);
                            if (found)
                            {
                                tag = info.tag;
                                desc = info.description;
                            }
                        }

                        DataRow row = SystemData.MemTable.Rows.Find(desc);
                        if (row != null)
                        {
                            row["Value"] = serverResponse[i];
                            row["Updated"] = DateTime.Now.ToString("HH:mm:ss");
                        }
                    }
                }
                else if (func == ModbusFunc.READ_HOREG || func == ModbusFunc.READ_INREG)
                {
                    ushort[] serverResponse = ModbusClient.ParseRegMessage(recvByte, quantity);

                    ModbusMap.AddressInfo info = new ModbusMap.AddressInfo();

                    for (int i = 0; i < serverResponse.Length; i++)
                    {
                        int scale = 1;
                        string tag = "", type = "", format = "", desc = "";
                        double value = serverResponse[i];
                        string key = (func == ModbusFunc.READ_INREG ? "INREG:" : "REG:") + (startAddr + i).ToString();

                        if (!dicModbusReg.ContainsKey("Modbus"))
                        {
                            Console.WriteLine("Check Map Binding");
                            continue;
                        }

                        bool found = dicModbusReg["Modbus"].TryGetValue(key, out info);
                        if (!found)
                        {
                            return;
                        }

                        type = info.dataType;
                        tag = info.tag;
                        format = info.format;
                        scale = info.scale;
                        desc = info.description;

                        if (info.dataType == "FLOAT" || info.dataType == "DOUBLE")
                        {
                            if (info.dataType == "FLOAT")
                            {
                                UInt16[] modvalues = new UInt16[2];
                                Array.Copy(serverResponse, i, modvalues, 0, 2);
                                value = ModbusClient.ConvertRegistersToFloat(modvalues, ModbusType.RegisterOrderFormat(format));
                            }
                            else
                            {
                                UInt16[] modValues = new UInt16[4];
                                Array.Copy(serverResponse, i, modValues, 0, 4);
                                value = ModbusClient.ConvertRegistersToDouble(modValues, ModbusType.RegisterOrderFormat(format));
                            }
                        }
                        else if (info.dataType == "BITFLD")
                        {
                            DataRow row = SystemData.MemTable.Rows.Find(desc);

                            if (row != null)
                            {
                                row["Value"] = value;
                                row["Updated"] = DateTime.Now.ToString("HH:mm:ss");

                                int count = 0;
                                foreach (DataRow rw in SystemData.MemTable.Rows)
                                {
                                    if (rw["Tag Name"].ToString().IndexOf(desc) != -1)
                                        count++;
                                }

                                if (count >= 2)
                                {
                                    int mask = 1;
                                    for (int pos = 0; pos < 16; pos++)
                                    {
                                        DataRow drow = SystemData.MemTable.Rows.Find(desc + " : " + pos);

                                        drow["Value"] = (serverResponse[i] & (mask << pos)) > 0 ? true : false;
                                        drow["Updated"] = DateTime.Now.ToString("HH:mm:ss");
                                    }
                                }
                                else if (count < 2)
                                {
                                    int index = SystemData.MemTable.Rows.IndexOf(row);
                                    int mask = 1;
                                    for (int pos = 0; pos < 16; pos++)
                                    {
                                        bool flag = (serverResponse[i] & (mask << pos)) > 0 ? true : false;
                                        DataRow dr = SystemData.MemTable.NewRow();

                                        object[] obj = new object[] { desc + " : " + pos, flag, "", DateTime.Now.ToString("HH:mm:ss") };
                                        dr.ItemArray = obj;

                                        SystemData.MemTable.Rows.InsertAt(dr, index + pos + 1);
                                    }
                                }
                            }
                        }
                        //else if(info.dataType == "BSTR")
                        //{
                        // TODO BSTR 수식
                        //}
                        else
                        {
                            if (info.dataType == "SHORT")
                            {
                                value = (short)serverResponse[i];
                            }

                            if (info.scale != 1)
                            {
                                value /= info.scale;
                            }

                            DataRow row = SystemData.MemTable.Rows.Find(desc);
                            if (row != null)
                            {
                                row["Value"] = value;
                                row["Updated"] = DateTime.Now.ToString("HH:mm:ss");
                            }
                        }
                    }
                }
            }
            catch (Exception e1)
            {
                Console.WriteLine("ReadModbus Error ex = {0}", e1.Message);
            }
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

        private void DgvVisibleFilter(object senrder, EventArgs e)
        {
            try
            {
                CurrencyManager manager = (CurrencyManager)BindingContext[DgvSysData.DataSource];
                manager.SuspendBinding();

                foreach (DataGridViewRow row in DgvSysData.Rows)
                    row.Visible = false;

                foreach (DataGridViewRow row in DgvSysData.Rows)
                {
                    foreach (var data in dic)
                    {
                        if (row.Cells["Tag Name"].Value.ToString() == data.Value.description)
                        {
                            DgvSysData.Rows[row.Index].Visible = true;
                        }
                    }
                }

                manager.ResumeBinding();
            }
            catch (Exception ex)
            {
                log.Error($"Filtering MemTable in Data Error : {ex.Message}");
            }

            DgvSysData.SelectionChanged += new System.EventHandler(this.DgvSysData_CellClick);
            Application.Idle -= DgvVisibleFilter;
        }

        private void DgvSysData_CellClick(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            DataGridViewCell cell = dgv.CurrentCell;

            if (!DictionaryFindtoString(dgv.Rows[cell.RowIndex].Cells[0].Value.ToString(), dic))
            {
                CurrencyManager mgr = (CurrencyManager)BindingContext[dgv.DataSource];
                mgr.SuspendBinding();

                dgv.Rows[cell.RowIndex].Visible = false;

                mgr.ResumeBinding();
            }
        }

        private bool DictionaryFindtoString(string q, Dictionary<string, ModbusMap.AddressInfo> dic)
        {
            bool result = false;

            foreach (KeyValuePair<string, ModbusMap.AddressInfo> data in dic)
            {
                if (data.Value.description == q)
                    result = true;
            }

            return result;
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
