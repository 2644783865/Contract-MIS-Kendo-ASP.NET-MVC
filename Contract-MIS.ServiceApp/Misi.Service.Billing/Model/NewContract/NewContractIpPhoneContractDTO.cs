using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract]
    public class NewContractIpPhoneContractDTO : NewContractLaptopContractDTO
    {
        [DataMember]
        public string ExtensionLineNumber { get; set; }
    }
}