using FcpUtils;
using log4net;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;

namespace FcpTools
{
    public class EpeEventArgs : EventArgs
    {
        public readonly EpeMessage.Command Cmd;
        public readonly object Value;

        public EpeEventArgs(EpeMessage.Command cmd, object value)
        {
            this.Cmd = cmd;
            this.Value = value;
        }
    }

    public class EpeAdapter
    {
        private static EpeAdapter _instance = null;

        private readonly ILog log = LogManager.GetLogger("Console");
        private readonly ILog com = LogManager.GetLogger("Device");

        internal event EventHandler Updated;

        private SerialPort serialPort = new SerialPort();
        private List<byte> _measuringItems = new List<byte> {0, 1};

        // for request message
        private EpeMessage _reqMessage;

        // for receiving response message
        private List<byte> _rxBuffer = new List<byte>();
        private bool _rxCompleted = false;
        private bool _rxTimeout = true;
        private int _rxWaitLength = 0;
        private System.Timers.Timer _respTimer;

        internal EpeAdapter()
        {
            serialPort.DataReceived += SerialPort_DataReceived;

            _respTimer = new System.Timers.Timer
            {
                Interval = 3000,
                AutoReset = false
            };
            _respTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Tick);
        }

        static public EpeAdapter GetInstance()
        {
            if (_instance == null) {
                _instance = new EpeAdapter();
            }

            return _instance;
        }

        internal void SetPort(PortInfo portInfo)
        {
            try {
                serialPort.PortName = portInfo.PortName;
                serialPort.BaudRate = portInfo.BaudRate;
                serialPort.StopBits = portInfo.StopBits;
                serialPort.Parity = portInfo.Parity;
                serialPort.Handshake = portInfo.Handshake;
            }
            catch (Exception e) {
                log.Error("Port config error, " + e.Message);
            }
        }

        internal void Start()
        {
            try
            {
                if (serialPort.IsOpen)
                    serialPort.Close();

                serialPort.Open();
            }
            catch(Exception ex)
            {
                log.Error("Port open error , : " + ex.Message);
                throw;
            }
        }

        internal void Stop()
        {
            if (serialPort.IsOpen)
                serialPort.Close();
        }

        internal void SetMeasuringItems(List<byte> list)
        {
            this._measuringItems = list;
        }

        internal void SendRequest(ushort addr, EpeMessage.Command cmd)
        {
            if (!serialPort.IsOpen)
            {
                log.Error("device port is not open");
                return;
            }

            // reset rx status
            _rxBuffer.Clear();
            _rxWaitLength = 0;
            _rxCompleted = false;
            _rxTimeout = false;

            // create & send request message
            try
            {
                _reqMessage = new EpeMessage(addr, cmd);
                if (cmd == EpeMessage.Command.GET_MEAVAL) {
                    _reqMessage.SetQueryItems(_measuringItems.ToArray());
                }
                byte[] rawMesg = _reqMessage.GetRawRequest();

                serialPort.Write(rawMesg, 0, rawMesg.Length);
                com.InfoFormat("TX: {0:000}, {1}", rawMesg.Length, BitConverter.ToString(rawMesg));
            }
            catch(Exception ex)
            {
                log.ErrorFormat("fail to send a message. addr={0}, cmd={1}, ex={2}", addr, cmd, ex.Message);
            }

            // set rx timeout
            _respTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_rxCompleted) {
                log.ErrorFormat("invalid response <-- request: addr={0}, cmd={1}", _reqMessage.Addr, _reqMessage.Cmd);
                log.ErrorFormat("drop rx message, count={0}, buffer={1}", _rxBuffer.Count, StrUtils.Bytes2Hex(_rxBuffer.ToArray()));

                _rxBuffer.Clear();
                _rxWaitLength = 0;
            }
            _rxTimeout = true;
        }

        internal void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort.BytesToRead == 0)
                    return;

                if (_rxTimeout) {
                    byte[] rxBuff = new byte[serialPort.BytesToRead];
                    serialPort.Read(rxBuff, 0, rxBuff.Length);

                    // timeout 되었으므로 나중에 들어온 메시지는 버린다.
                    log.InfoFormat("rx timeout, count={0}, drop={1}", rxBuff.Length, BitConverter.ToString(rxBuff));

                    return;
                }

                // read byte until message completed or timeout
                // state: ready --> receiving --> complete
                // format: addr(2), cmd(1), len(1), ack/nak(1), data(~), crc(1)
                int byteData = -1;
                while (!_rxCompleted)
                {
                    byteData = serialPort.ReadByte();
                    // check read error or no remaining readable data
                    if (byteData < 0)
                        break;

                    // check packet length
                    if (_rxBuffer.Count == 3) {
                        _rxWaitLength = (byte)byteData;
                        Console.WriteLine("wait length={0}", _rxWaitLength);
                    }

                    // check completed (last CRC byte is not added on buffer)
                    if (_rxWaitLength != 0 && _rxBuffer.Count == _rxWaitLength + 4)
                    {
                        _rxCompleted = true;
                    }

                    // add rx byte to rxBuffer
                    _rxBuffer.Add((byte)byteData);
                }

                // validate reqeust message
                if (!_rxCompleted)
                {
                    // 수신 중이므로 나중에 처리
                    log.InfoFormat("data receiving, rxCount={0}, buff={1}", 
                        _rxBuffer.Count, BitConverter.ToString(_rxBuffer.ToArray()));
                    return;
                }

                // handle received message
                com.InfoFormat("RX: {0:000}, {1}", _rxBuffer.Count, StrUtils.Bytes2Hex(_rxBuffer.ToArray()));

                // parse message
                EpeMessage codec = new EpeMessage(_rxBuffer.ToArray());
                codec.SetQueryItems(_measuringItems.ToArray());

                // raise event with value
                if (codec.Cmd == EpeMessage.Command.GET_MEAVAL)
                    Updated(this, new EpeEventArgs(codec.Cmd, codec.GetValues()));
                else
                    Updated(this, new EpeEventArgs(codec.Cmd, codec.GetStrValue()));

                _rxBuffer.Clear();
                _rxWaitLength = 0;
            }
            catch (Exception ex)
            {
                log.InfoFormat("can't handle message, rx={0}, ex={1}",
                    StrUtils.Bytes2Hex(_rxBuffer.ToArray()), ex.Message);
            }
        }
    }

}
