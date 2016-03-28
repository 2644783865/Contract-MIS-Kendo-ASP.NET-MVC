
namespace Misi.Common.Lib.Util
{
    public class SAPDataField : System.Attribute
    {
        private readonly string _sapDataField;

        public SAPDataField(string name)
        {
            _sapDataField = name;
        }

        public string Field {
            get { return _sapDataField; }
        }
    }
}