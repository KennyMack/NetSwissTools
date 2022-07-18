using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NetSwissTools.Models
{
    class BinarySerializer
    {
        public byte[] SerializeToBinary<T>(T objectToSerialize)
        {
            var ms = new MemoryStream();
            var bf = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Persistence));
            bf.Serialize(ms, objectToSerialize);
            ms.Seek(0, SeekOrigin.Begin);
            var array = ms.ToArray();
            ms.Close();
            return array;
        }

        public T DeserializeFromBinary<T>(byte[] data)
        {
            T dataObject = default(T);
            if (data.Length > 0)
            {
                var ms = new MemoryStream(data);
                var bf = new BinaryFormatter();
                ms.Position = 0;
                dataObject = (T)bf.Deserialize(ms);
                ms.Close();
            }
            return dataObject;
        }
    }
}
