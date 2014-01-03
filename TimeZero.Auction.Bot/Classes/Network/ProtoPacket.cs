using System.Collections.Generic;
using System.Xml;

namespace TimeZero.Auction.Bot.Network
{
    public sealed class ProtoPacket
    {

#region Constants

        private const string PROTO_XML_ROOT = "ROOT";

#endregion

#region Private fields

        private readonly XmlDocument _xml;

#endregion

#region Class methods

        public ProtoPacket(string data)
        {
            _xml = new XmlDocument();
            _xml.AppendChild(_xml.CreateElement(PROTO_XML_ROOT)).InnerXml = data;
        }

        public string this[string path]
        {
            get { return GetValue(path); }
        }

        public List<string> GetValues(string path)
        {
            path = string.Format("/{0}/{1}", PROTO_XML_ROOT, path);
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

        public string GetValue(string path)
        {
            List<string> values = GetValues(path);
            return values != null ? values[0] : null;
        }

#endregion

    }
}
