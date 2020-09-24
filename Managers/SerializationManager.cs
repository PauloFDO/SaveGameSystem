using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace SaveGameSystem
{
    public class SerializationManager : MonoBehaviour
    {
        public static bool Save<T>(T objectToSave, string key)
        {
            string path = Application.persistentDataPath + "/saves/";
            Directory.CreateDirectory(path);
            BinaryFormatter formatter = GetBinaryFormatter();

            using (FileStream fileStream = new FileStream(path + key + ".save", FileMode.Create))
            {
                formatter.Serialize(fileStream, objectToSave);
            }

            return true;
        }

        public static object Load<T>(string key)
        {
            string path = Application.persistentDataPath + "/saves/";
            BinaryFormatter formatter = GetBinaryFormatter();
 
            T returnValue = default(T);

            using (FileStream fileStream = new FileStream(path + key + ".save", FileMode.Open))
            {
                returnValue = (T)formatter.Deserialize(fileStream);
            }

            return returnValue;
        }

        public static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            SurrogateSelector selector = new SurrogateSelector();

            var vector3Surrogate = new Vector3SerializationSurrogate();
            var quaternionSurrogate = new QuaternionSerializationSurrogate();

            selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
            selector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quaternionSurrogate);

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}