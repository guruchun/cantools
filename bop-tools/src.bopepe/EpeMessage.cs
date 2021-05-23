using System;
using System.Collections.Generic;
using System.Text;

namespace FcpTools {
    public class EpeMessage {

        public enum Command
        {
            GET_SN = 0x61,
            GET_SWVER = 0x64,
            GET_MEAVAL = 0x67
        };

        public enum ErrCodes
        {
            NO_CAL_DATA = 0xEC,
            EEPROM_ERR = 0xED,
            HUMI_LOW_ERR = 0xEE,
            HUMI_HIGH_ERR = 0xEF,
            COMM_BUSY = 0xF9,
            TEMP_LOW_ERR = 0xFA,
            TEMP_HIGH_ERR = 0xFB,
            PARAM_INVALID = 0xFC,
            CMD_LOCKED = 0xFD,
            CMD_INVALID = 0xFE,
            CRC_ERR = 0xFF
        };

        public static Dictionary<ErrCodes, string> ErrDescs = new Dictionary<ErrCodes, string>()
        {
            [ErrCodes.NO_CAL_DATA] = "No calibrartion data",
            [ErrCodes.EEPROM_ERR] = "EEPROM defect",
            [ErrCodes.HUMI_LOW_ERR] = "Humidity sensor/probe failure (C < 100pF)",
            [ErrCodes.HUMI_HIGH_ERR] = "Humidity sensor/probe failure (C > 600pF)",
            [ErrCodes.COMM_BUSY] = "Communication temporarily not possible",
            [ErrCodes.TEMP_LOW_ERR] = "Temperature sensor/probe failure (R < 500 Ohm)",
            [ErrCodes.TEMP_HIGH_ERR] = "Temperature sensor/probe failure (R > 1800 Ohm)",
            [ErrCodes.PARAM_INVALID] = "Parameter wrong/not valid",
            [ErrCodes.CMD_LOCKED] = "Command is locked (permanantly or has to be activated specifically)",
            [ErrCodes.CMD_INVALID] = "Command is unsupported",
            [ErrCodes.CRC_ERR] = "CRC error"
        };

        //public static List<KeyValuePair<int, string>> MeasureList = new List<KeyValuePair<int, string>>() {
        //    new KeyValuePair<int, string>(0, "T, Temperature"),
        //    new KeyValuePair<int, string>(1, "F, Humidity"),
        //    new KeyValuePair<int, string>(2, "e, Water vapour partial pressure"),
        //    new KeyValuePair<int, string>(3, "Td, Dew point temperature"),
        //    new KeyValuePair<int, string>(4, "Tw, Wet bulb temperature"),
        //    new KeyValuePair<int, string>(5, "dv, Absolute humidity"),
        //    new KeyValuePair<int, string>(6, "r, Mixture raio"),
        //    new KeyValuePair<int, string>(7, "h, Enthalpy"),
        //    new KeyValuePair<int, string>(8, "Td/Tf, Deu point temperature, Frost point temperature"),
        //    new KeyValuePair<int, string>(13, "aw, Water activity"),
        //    new KeyValuePair<int, string>(14, "x, Water content")
        //};

        // {index, tagName}
        public static Dictionary<byte, string> MeasureTags = new Dictionary<byte, string>()
        {
            [0] = "T",
            [1] = "F",
            [2] = "e",
            [3] = "Td",
            [4] = "Tw",
            [5] = "dv",
            [6] = "r",
            [7] = "h",
            [8] = "Td/Tf",
            [13] = "aw",
            [14] = "x"
        };
        // {index, description}
        public static Dictionary<byte, string> MeasureDesc = new Dictionary<byte, string>()
        {
            [0] = "Temperature",
            [1] = "Humidity",
            [2] = "Water vapour partial pressure",
            [3] = "Dew point temperature",
            [4] = "Wet bulb temperature",
            [5] = "Absolute humidity",
            [6] = "Mixture raio",
            [7] = "Enthalpy",
            [8] = "Dew point temperature, Frost point temperature",
            [13] = "Water activity",
            [14] = "Water content"
        };

        // packet fields
        public ushort Addr = 0;
        public Command Cmd;
        private byte Length = 0;
        private byte[] QryItems = null;

        // packet value
        private string StrValue;
        private Dictionary<string, float> Values = new Dictionary<string, float>();

        // response status
        public static readonly byte ACK = 0x06;
        public static readonly byte NAK = 0x15;     // refer to ErrCodes, ErrDescs
        // response value unit for measuring command
        private static readonly byte UNIT_METRIC = 0x00;
        private static readonly byte UNIT_NOCMETRIC = 0x01;

        // create request message
        public EpeMessage()
        {
        }

        public EpeMessage(ushort addr, Command cmd)
        {
            Addr = addr;
            Cmd = cmd;
        }

        public void SetQueryItems(byte[] list)
        {
            this.QryItems = list;
        }

        // create response message
        public EpeMessage(byte[] packet)
        {
            // initial value

            // address
            Addr = BitConverter.ToUInt16(packet, 0);
            // command
            Cmd = (Command)packet[2];
            // length
            Length = packet[3];
            Console.WriteLine("LenField={0}, PacketLen={1}", Length, packet.Length);
            if (Length != packet.Length - 5) {
                Console.Error.WriteLine("length is invalid, expected={0} but packet={1}", Length, packet.Length - 5);
                return;
            }
            // check CRC
            byte crc = CalcCRC(packet);
            if (crc != packet[packet.Length-1]) {
                Console.Error.WriteLine("length is invalid, expected={0} but packet={1}", Length, packet.Length - 5);
                return;
            }

            // status
            if (packet[4] == ACK) {
                ParsePacketACK(Cmd, packet);
            } else {
                ParsePacketNAK(Cmd, packet);
            }
        }

        private void ParsePacketACK(Command Cmd, byte[] packet)
        {
            if (Cmd == Command.GET_SN) {
                if (packet.Length == 22) {
                    byte[] txtData = new byte[16];
                    Array.Copy(packet, 5, txtData, 0, 16);
                    this.StrValue = Encoding.ASCII.GetString(txtData);
                } else {
                    this.StrValue = "invalid s/n";
                }
            } else if (Cmd == Command.GET_SWVER) {
                if (packet.Length == 9) {
                    this.StrValue = string.Format("{0}.{1}.{2}", packet[5], packet[6], packet[7]);
                } else {
                    this.StrValue = "invalid ver.";
                }
            } else if (Cmd == Command.GET_MEAVAL) {

            } else {
                Console.Error.WriteLine("invalid command");
            }
        }

        private void ParsePacketNAK(Command Cmd, byte[] packet)
        {
            switch (Cmd) {
                case EpeMessage.Command.GET_SN:
                    break;
                case EpeMessage.Command.GET_SWVER:
                    break;
                case EpeMessage.Command.GET_MEAVAL:
                    break;
            }
        }

        public string GetStrValue()
        {
            return this.StrValue;
        }

        public Dictionary<string, float> GetValues()
        {
            return this.Values;
        }

        private byte CalcCRC(byte[] packet)
        {
            int crc = 0;
            for (int i=0; i < packet.Length - 1; i++) {
                crc = (crc + packet[i]) % 0x100;
            }
            return (byte)crc;
        }


        public byte[] GetRawRequest()
        {
            List<byte> packet = new List<byte>();

            packet.AddRange(BitConverter.GetBytes((ushort)this.Addr));
            packet.Add((byte)this.Cmd);
            packet.Add(0);
            int crc = 0;
            foreach (byte b in packet) {
                crc = (crc + b) % 0x100;
            }
            packet.Add((byte)crc);

            return packet.ToArray();
        }
    }
}
