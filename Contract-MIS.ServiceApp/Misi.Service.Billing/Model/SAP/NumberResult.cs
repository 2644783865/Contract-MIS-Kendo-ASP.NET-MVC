using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.SAP
{
    [DataContract]
    public class NumberResult : SAPResponse
    {
        [DataMember]
        public int Value { get; set; }
    }
}