using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace TimeZero.Auction.Bot.Classes.Network.ProtoPacket
{
    public sealed partial class Packet
    {

#region Static private fields

        private static readonly Regex _regexPacketType = new Regex("(?<=^\\<).*?(?=\\W)|(?<=^\\<).*?(?=\\>)", 
            RegexOptions.ExplicitCapture);

        private static readonly Regex _regexXmlEncode = new Regex("(?s)(?<==\".?)&(?!amp;)",
            RegexOptions.ExplicitCapture);

        private static readonly Dictionary<string, string> _xmlEncodeReplacements = new Dictionary<string, string>
            {
                { "&", "&amp;" }
            };

#endregion

#region Constants

        private const string PROTO_XML_ROOT = "ROOT";

#endregion

#region Private fields

        private readonly XmlDocument _xml;
        private readonly XmlNode _dataNode;

#endregion

#region Properties

        public string Type { get; private set; }
        public bool IsEncoded { get; private set; }
        public DateTime ReceiveTime { get; private set; }

        public string Data
        {
            get
            {
                if (IsEncoded)
                {
                    string data = _dataNode.InnerText;
                    byte[] decodedData = Convert.FromBase64String(data);
                    return Encoding.UTF8.GetString(decodedData);
                }
                return _dataNode.InnerXml;
            }
        }

        public string this[string path]
        {
            get { return GetValue(path); }
        }

#endregion

#region Class methods

        public Packet(string data)
        {
            _xml = new XmlDocument();
            Type = _regexPacketType.Match(data).Value;
            _dataNode = _xml.AppendChild(_xml.CreateElement(PROTO_XML_ROOT));
            try
            {
                _dataNode.InnerXml = NormalizeXmlData(data);
            }
            catch
            {
                byte[] pData = Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(pData);
                _dataNode.InnerXml = string.Format("<{0}>{1}</{0}>", Type, encodedData);
                IsEncoded = true;
            }
            ReceiveTime = DateTime.Now;
        }

        private string NormalizeXmlData(string data)
        {
            Match match;
            while ((match = _regexXmlEncode.Match(data)).Success)
            {
                data = data.Remove(match.Index, match.Length).Insert(match.Index,
                    _xmlEncodeReplacements[match.Value]);
            }
            return data;
        }

        public List<string> GetValues(string path)
        {
            path = string.Format("/{0}/{1}/{2}", PROTO_XML_ROOT, Type, path);
            XmlNodeList nodes = _xml.SelectNodes(path);
            if (nodes != null && nodes.Count > 0)
            {
                List<string> values = new List<string>(nodes.Count);
                foreach (XmlNode node in nodes)
                {
                    values.Add(node.InnerText);
                }
                return values;
            }
            return null;
        }

        public XmlNodeList GetNodes(string path)
        {
            path = string.Format("/{0}/{1}/{2}", PROTO_XML_ROOT, Type, path);
            return _xml.SelectNodes(path);
        }

        public string GetValue(string path)
        {
            List<string> values = GetValues(path);
            return values != null ? values[0] : null;
        }

        public override string ToString()
        {
            return Type;
        }

#endregion

    }
}
