using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DotnetDemo
{
    [Serializable]
    public class BaseClone<T>
    {
        public virtual T Clone()
        {
            using (var memoryStream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, this);
                memoryStream.Position = 0;
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
}
