using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractRequestInfoDTO : CommonRequestInfoDTO
    {
        [DataMember]
        public string RequestedBy { get; set; }

        [DataMember]
        public string Location { get; set; }
    }
}