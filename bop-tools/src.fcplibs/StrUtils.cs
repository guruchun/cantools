using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FcpUtils {
    public static class StrUtils {
        // hexadecimal string to byte array
        public static byte[] Hexstr2Bytes(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        // hexadecimal string with delimeters to byte array
        public static byte[] Hexdel2Bytes(string hexStr)
        {
            char[] delimiterChars = { ' ', ',', ':' };
            string mesg = hexStr.Trim();
            string[] hexMesgs = mesg.Split(delimiterChars);

            byte[] rawBytes = new byte[hexMesgs.Length];
            for (int i = 0; i < hexMesgs.Length; i++)
            {
                try
                {
                    rawBytes[i] = Convert.ToByte(hexMesgs[i], 16);
                }
                catch (Exception e)
                {
                    Console.WriteLine("invalid hex string " + hexMesgs[i] + ", " + e.Message);
                    rawBytes[i] = 0x00;
                }
            }
            return rawBytes;
        }

        public static string Bytes2Hex(byte[] bytes, string delimeter="-")
        {
            string temp = BitConverter.ToString(bytes);
            if (delimeter != "-")
            {
                temp.Replace("-", delimeter);
            }
            return temp;
        }


        /// <summary>
        /// Converts a string of bytes to an array of bytes.
        /// </summary>
        /// <param name="data">The string to convert.</param>
        /// <returns>An array of bytes half the length of the string.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        public static byte[] StringToBytes(string data)
        {
            if (data == null)
                throw new ArgumentNullException();

            // remove indicators and spaces
            data = data.Replace("h", "").Replace(" ", "").Replace("0x", "");

            if (data.Length % 2 != 0)
                data = "0" + data;

            byte[] arr = new byte[data.Length >> 1];

            for (int i = 0; i < (data.Length >> 1); ++i)
            {
                arr[i] = (byte)((GetHexVal(data[i << 1]) << 4) + (GetHexVal(data[(i << 1) + 1])));
            }

            return arr;
        }

        /// <summary>
        /// Converts a byte array to a string.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string BytesToString(byte[] data)
        {
            if (data == null || data.Length == 0) return "";

            string res = "0x";
            res += BitConverter.ToString(data).Replace("-", "");
            return res;
        }

        /// <summary>
        /// Obtains the hex value of a valid hex character.
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        private static int GetHexVal(char hex)
        {
            int val = hex;
            //For uppercase A-F letters:
            //return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }
    }
}
