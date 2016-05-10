using System.Xml.Serialization;

namespace Hearthstone_Helper.Utility
{
    [XmlRoot]
    public class Version
    {
        public int Major;
        public int Minor;
        public int Build;
        public int Revision;

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Build}.{Revision}";
        }
    }
}
