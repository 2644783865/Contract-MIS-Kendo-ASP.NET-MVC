using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract]
    public class DivisionDTO
    {
        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}