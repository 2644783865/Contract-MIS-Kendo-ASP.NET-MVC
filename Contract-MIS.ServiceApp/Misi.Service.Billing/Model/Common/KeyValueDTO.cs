using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract]
    public class KeyValueDTO
    {
        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}