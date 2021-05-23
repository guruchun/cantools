using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading;

namespace FcpUtils {
    public class SockClientTCP {
        public string IPAddress { get; set; }
        public UInt16 Port { get; set; }
        public Int32 ConnTimeout { get; set; }
        public Int32 ReadTimeout { get; set; }

        internal TcpClient tcpClient;
        internal NetworkStream NetStream;
        Thread sockThread;
        internal bool Running;

        // event handler용 delegate type 선언 (prototype)
        public delegate void ConnectedEvent(object sender);
        // delegate를 event로 생성
        public event ConnectedEvent Connected;

        public delegate void DisconnectedEvent(object sender);
        public event DisconnectedEvent Disconnected;

        public delegate void DataReceivedEvent(object sender, byte[] receivedData);
        public event DataReceivedEvent DataReceived;

        public SockClientTCP()
        {
            this.ConnTimeout = 500;
            this.ReadTimeout = 0;   // for no timeout (Timeout.Infinite)
        }

        //public SockClientTCP(string ipAddress, UInt16 port)
        //{
        //    this.ConnTimeout = 500;
        //    this.ReadTimeout = 0; 
        //    this.IPAddress = ipAddress;
        //    this.Port = port;
        //}

        public void Connect(string ipAddress, UInt16 port)
        {
            this.IPAddress = ipAddress;
            this.Port = port;

            Connect();
        }

        public void Connect()
        {
            tcpClient = new TcpClient();
            IAsyncResult result = tcpClient.BeginConnect(this.IPAddress, this.Port, null, null);
            if (result.AsyncWaitHandle.WaitOne(TimeSpan.FromMilliseconds(this.ConnTimeout)))
            {
                tcpClient.EndConnect(result);
                NetStream = tcpClient.GetStream();
                if (this.ReadTimeout > 0)
                    NetStream.ReadTimeout = this.ReadTimeout;    // ms

                // fire event
                if (this.Connected != null)
                    Connected(this);
            }
            else
                throw new Exception("Failed to connect, timeout(ms):" + this.ConnTimeout);

            // create thread with parameter
            sockThread = new Thread(() => ReadThreadProc(this));
            sockThread.Start();
        }

        public void Close()
        {
            // stop thread
            Running = false;

            try
            {
                if (tcpClient != null)
                    tcpClient.Close();

                // stop thread forcely
                if (sockThread != null)
                    sockThread.Abort();

                // raise event
                if (this.Disconnected != null)
                    Disconnected(this);

                Console.WriteLine("TCP client socket is closed... ");
            } catch (Exception e)
            {
                Console.WriteLine("error on socket, disconnecting... " + e.Message);
            }

            // reset all
            NetStream = null;
            tcpClient = null;
            sockThread = null;
        }

        public void Send(byte[] data)
        {
            if (NetStream != null && tcpClient.Connected)
                NetStream.Write(data, 0, data.Length);
        }

        public static void ReadThreadProc(SockClientTCP sockClient)
        {
            sockClient.Running = true;
            int count = 0;
            byte[] recvBuffer = new byte[1024];
            while (sockClient != null && sockClient.Running && sockClient.IsConnected())
            {
                try
                {
                    if (sockClient.NetStream == null)
                        break;
                    if (sockClient.NetStream.DataAvailable)
                    {
                        count = sockClient.NetStream.Read(recvBuffer, 0, recvBuffer.Length);
                        byte[] rxBuff = new byte[count];
                        Array.Copy(recvBuffer, 0, rxBuff, 0, count);
                        Console.WriteLine(StrUtils.Bytes2Hex(rxBuff));

                        // raise event
                        sockClient.DataReceived(sockClient, rxBuff);
                    }
                }
                catch (Exception e) {
                    Console.WriteLine("TCP Receiving Thread is aborted... " + e.Message);
                    break ;
                }
            }
            sockClient.Running = false;

            // raise event
            //if (sockClient.Disconnected != null)
            //    sockClient.Disconnected(null);
            sockClient.Disconnected?.Invoke(null);
        }

        public bool IsConnected()
        {
            if (tcpClient != null)
                return tcpClient.Connected;

            return false;
        }
    }
}
