
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using log4net;

namespace FcpUtils {
    public class SockServerTCP {
        private static readonly ILog log = LogManager.GetLogger("Console");
        private TcpListener _acceptor;
        private List<TcpClient> _SessionList = new List<TcpClient>();

        // SockServerTCP에서 Event를 발생시키면 User Form에서 이 Event에 등록한 Handler가 호출된다.
        // Event 정의: EventHandler 타입의 delegate 변수를 정의하면서 event로 사용된다는 것을 알린다.
        // Event 발생: event는 C의 함수 포인터와 비슷한다. event가 raise되면 delegate 변수를 통해 method가 호출된다.
        // Event 등록: event를 받으려면 delegate를 구현한 method가 필요하다.
        //             이 method를 User handler라고 하자. event(delegate)에 user handler를 할당하는 것이 handler 등록이다.
        // Event 작업: event 발생시점에 호출한 delegate가 결국은 user handler를 호출하는 것이다.
        
        // Event 정의
        public event EventHandler Connected;
        public event EventHandler Disconnected;
        public event EventHandler NumberOfClientsChanged;
        public event EventHandler DataReceived;

        // Server properties
        public IPAddress BindAddress { get; set; }
        public int Port { get; set; }
        public int NumberOfConnections { get; private set; }

        public SockServerTCP()
        {
            BindAddress = IPAddress.Any;
            NumberOfConnections = 0;
        }
        
        public void Start()
        {
            try
            {
                _acceptor = new TcpListener(BindAddress, Port);
                _acceptor.Start();
            }
            catch (Exception e1)
            {
                log.Debug("fail to start the Tcp server, " + e1.Message);
                return;
            }

            try
            {
                // new connection request -> connected -> return new TcpClient
                // TcpClient tcpClient = _acceptor.AcceptTcpClient();
                _acceptor.BeginAcceptTcpClient(AcceptTcpClientCallback, null);

            }
            catch (Exception e1)
            {
                log.Debug("accept tcp connection error, " + e1.Message);
            }
        }

        public void Stop()
        {
            try
            {
                _acceptor.Stop();
                foreach (TcpClient client in _SessionList)
                {
                    client.Close();
                }
            }
            catch (Exception e1)
            {
                throw new Exception("error to stop TCP server, " + e1.Message);
            }

            NumberOfConnections = GetAndCleanNumberOfConnectedClients(null);
            NumberOfClientsChanged?.Invoke(this, null);

            log.Debug("stopped TCP server");
        }

        private int GetAndCleanNumberOfConnectedClients(TcpClient client)
        {
            _SessionList.RemoveAll(
                delegate (TcpClient c)
                {
                    //return ((DateTime.Now.Ticks - c.Ticks) > 40000000);
                    return !c.Connected;
                }
            );

            if (client == null || !client.Connected)
                return _SessionList.Count;

            bool objetExists = false;
            foreach (TcpClient tc in _SessionList)
            {
                if (client.Equals(tc))
                    objetExists = true;
            }
            
            if (!objetExists)
                _SessionList.Add(client);

            return _SessionList.Count;
        }

        private void TcpSocketReader(TcpClient tcpClient)
        {
            if (tcpClient == null)
                return;

            string sessionName = tcpClient.Client.RemoteEndPoint.ToString();
            NetworkStream netStream = tcpClient.GetStream();
            //SockEventArgs netRecvParams;
            int readable, readBytes;
            while (true)
            {
                try
                {
                    // FIXME Connected state is not valid
                    if (tcpClient.Connected == false)
                    {
                        break;
                    }

                    //readable = tcpClient.Available > 1024 ? 1024 : tcpClient.Available;
                    readable = tcpClient.Available;
                    if (readable > 0)
                    {
                        byte[] rxBuffer = new byte[readable];
                        readBytes = netStream.Read(rxBuffer, 0, readable);

                        if (readBytes > 0)
                        {
                            log.Debug(sessionName + " received, len=" + rxBuffer.Length);

                            // handle received data -> call delegator 
                            List<object> args = new List<object>
                            {
                                tcpClient,     // session
                                rxBuffer       // received message
                            };

                            DataReceived?.Invoke(this, new SockEventArgs(SockEventType.DataReceived, args));
                        }
                    }

                    Thread.Sleep(1);    // 1ms
                }
                catch (ThreadAbortException e1)
                {
                    log.Debug("TCP session aborted, " + e1.Message);
                    break;
                }
                catch (Exception e1)
                {
                    log.Debug("TCP session handler exception, " + e1.Message);
                    break;
                }
            }
            tcpClient.Close();
            NumberOfConnections = GetAndCleanNumberOfConnectedClients(tcpClient);
            NumberOfClientsChanged?.Invoke(this, null);

            // fire disconnected event
            Disconnected?.Invoke(this, 
                new SockEventArgs(SockEventType.Disconnected, new List<object> { tcpClient }));

            log.Debug(sessionName + " is disconnected -> thread exited");
        }

        public string[] GetClientList()
        {
            List<string> clients = new List<string>();
            foreach (var s in _SessionList)
            {
                try
                {
                    if (s.Connected)
                        clients.Add(s.Client.RemoteEndPoint.ToString());
                } catch(Exception ex)
                {
                    log.Error("get client list, error " + ex.Message);
                    continue;
                }
            }
            return clients.ToArray();
        }

        private void AcceptTcpClientCallback(IAsyncResult asyncResult)
        {
            TcpClient tcpSession;
            try
            {
                if (!_acceptor.Server.IsBound)
                {
                    log.Debug("AcceptTcpClientCallback is called. but server is not bound");
                    return;
                }

                tcpSession = _acceptor.EndAcceptTcpClient(asyncResult);
                _SessionList.Add(tcpSession);
                log.Debug("AcceptTcpClientCallback is called. connected from " + tcpSession.Client.RemoteEndPoint.ToString());

                // fire event --> call eventHandlers
                Connected?.Invoke(this, new SockEventArgs(SockEventType.Connected, new List<object> { tcpSession }));

                NumberOfConnections = GetAndCleanNumberOfConnectedClients(tcpSession);
                NumberOfClientsChanged?.Invoke(this, new SockEventArgs(SockEventType.NumberOfClientsChanged, null));

                // create client handler thread
                Thread clientThread = new Thread(() => TcpSocketReader(tcpSession));
                clientThread.Start();
                log.Debug("Accepted, " + tcpSession.Client.RemoteEndPoint.ToString());


                // listen to the next client connection
                _acceptor.BeginAcceptTcpClient(AcceptTcpClientCallback, null);
            }
            catch (Exception e1)
            {
                log.Debug("Connection request handle error, " + e1.Message);
            }
        }

        // server는 여러개의 session을 가지고 있으므로 
        // 전송을 server에 맡기려면 session id를 인자로 넘겨주어야 한다.
        // 현재는 사용하는 쪽에서 session을 event와 함께 전달받았으므로 직접 전송하면 된다.
        // TODO session 자체를 사용자측에 넘기지 않고 session id와 데이터만 넘기도록 한다. 
        // session에 읽고 쓰는 작업은 Server 클래스에서 담당하도록 한다.
        public void SendMessage(TcpClient tcpSession)
        {
            //tcpSession.Client.send
            throw new NotImplementedException();
        }
    }
}
