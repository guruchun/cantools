using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FcpUtils {

   // replace System.Collections.Generic.KeyValuePair for serializaing
   [Serializable]
    public struct KeyValueType<K, V> {
        public KeyValueType(K k, V v) : this() { Key = k; Value = v; }
        [XmlAttribute(AttributeName = "key")]
        public K Key { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public V Value { get; set; }
    }
    
    public enum SockEventType {
        Connected = 1, Disconnected, DataReceived, NumberOfClientsChanged
    }
    
    public class SockEventArgs : EventArgs {
        public readonly SockEventType EventType;
        public readonly List<object> Arguments;

        public SockEventArgs(SockEventType eventType, List<object> paramList)
        {
            this.EventType = eventType;
            this.Arguments = paramList;
        }
    }
}
