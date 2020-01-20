#region Using directives

using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

#endregion Using directives

namespace ProjectCeleste.GameFiles.XMLParser.Helpers
{
    public struct XmlTimeSpan : IXmlSerializable
    {
        private TimeSpan _value;

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            _value = TimeSpan.Parse(reader.ReadContentAsString());
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteValue(_value.ToString());
        }

        public static implicit operator XmlTimeSpan(TimeSpan value)
        {
            return new XmlTimeSpan { _value = value };
        }

        public static implicit operator TimeSpan(XmlTimeSpan value)
        {
            return value._value;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((XmlTimeSpan)obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public static bool operator ==(XmlTimeSpan left, XmlTimeSpan right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(XmlTimeSpan left, XmlTimeSpan right)
        {
            return !(left == right);
        }
    }
}