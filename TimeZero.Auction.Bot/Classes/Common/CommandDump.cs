using System;
using System.IO;
using System.Runtime.Serialization;

namespace TimeZero.Auction.Bot.Classes.Common
{
    [Serializable]
    public sealed class CommandDump : SerializableDictionary<string, string>   
    {
        public CommandDump() { }

        public CommandDump(SerializationInfo info, StreamingContext ctx) 
            : base(info, ctx) { }

        public int Duplicates { get; private set; }

        public void Serialize(string fileName)
        {
            Serializer<CommandDump> serializer = new Serializer<CommandDump>();
            byte[] data = serializer.Serialize(this);
            File.WriteAllBytes(fileName, data);
        }

        public static CommandDump Deserialize(string fileName)
        {
            byte[] data = File.ReadAllBytes(fileName);
            return new Serializer<CommandDump>().Deserialize(data);
        }

        public new void Add(string key, string value)
        {
            if (!ContainsKey(key))
            {
                base.Add(key, value);
            }
            else
            {
                Duplicates++;
            }
        }

        public new void Clear()
        {
            base.Clear();
            Duplicates = 0;
        }
    }
}
