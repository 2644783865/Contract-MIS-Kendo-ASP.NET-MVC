using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(NewContractLaptopRoutingInfoDTO))]
    [KnownType(typeof(NewContractSoftwareRoutingInfoDTO))]
    [KnownType(typeof(NewContractIpPhoneRoutingInfoDTO))]
    [KnownType(typeof(NewContractExtLineRoutingInfoDTO))]
    public abstract class NewContractRoutingInfoBaseDTO : RoutingInfoBaseDTO
    {
        [DataMember]
        public string IdrWebNumber { get; set; }
    }
}