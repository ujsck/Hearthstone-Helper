using System.IO;
using System.Xml.Serialization;

namespace Hearthstone_Helper.Utility
{
    public class XmlHelper<T>
    {
        public static T LoadFile(string path)
        {
            T instance;
            using (TextReader r = new StreamReader(path))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                instance = (T)xml.Deserialize(r);
            }
            return instance;
        }

        public static T LoadString(string xmlString)
        {
            T instance;
            using (TextReader r = new StringReader(xmlString))
            {
                XmlSerializer xml = new XmlSerializer(typeof(T));
                instance = (T)xml.Deserialize(r);
            }
            return instance;
        }
    }
}
