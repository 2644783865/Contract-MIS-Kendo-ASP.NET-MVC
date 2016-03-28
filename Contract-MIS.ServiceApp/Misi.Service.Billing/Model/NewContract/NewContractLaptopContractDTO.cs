using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.NewContract
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(NewContractIpPhoneContractDTO))]
    public class NewContractLaptopContractDTO : ContractEquipDataDTO
    {
        [DataMember]
        public string QuotationNumber { get; set; }

        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string LineNumber { get; set; }

        [DataMember]
        public string HolderName { get; set; }

        [DataMember]
        public string SalaryNumber { get; set; }

        [DataMember]
        public string SoDeliveryNumber { get; set; }

        [DataMember]
        public string AssetNumber { get; set; }

        [DataMember]
        public string CipNumber { get; set; }

        [DataMember]
        public string DeliveryOrderToUser { get; set; }

        [DataMember]
        public string NotificationNumber { get; set; }
    }
}