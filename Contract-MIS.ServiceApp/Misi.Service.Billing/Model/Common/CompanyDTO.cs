using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.Common
{
    [DataContract]
    public class CompanyDTO
    {
        [DataMember]
        public long No { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}