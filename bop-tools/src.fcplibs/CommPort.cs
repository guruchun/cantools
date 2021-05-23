namespace FcpUtils
{
    public class PortInfo {
        public string PortName = "COM1";
        public int BaudRate = 115200;
        public int DataBits = 8;
        public System.IO.Ports.Parity Parity = System.IO.Ports.Parity.None;
        public System.IO.Ports.StopBits StopBits = System.IO.Ports.StopBits.One;
        public System.IO.Ports.Handshake Handshake = System.IO.Ports.Handshake.None;
    }
}