using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TimeZero.Auction.Bot.Classes.Common
{
    public class Serializer<T> where T : class
    {
        public byte[] Serialize(T objectToSerialize)
        {
            try
            {
                using (MemoryStream objectStream = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(objectStream, objectToSerialize);
                    objectStream.Position = 0;
                    return objectStream.ToArray();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public T Deserialize(byte[] objectData)
        {
            try
            {
                if (objectData != null && objectData.Length > 0)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (MemoryStream objectStream = new MemoryStream(objectData))
                    {
                        return (T)formatter.Deserialize(objectStream);
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
