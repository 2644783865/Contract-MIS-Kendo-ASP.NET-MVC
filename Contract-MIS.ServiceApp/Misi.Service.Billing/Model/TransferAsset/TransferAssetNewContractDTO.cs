using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.TransferAsset
{
    [DataContract]
    public class TransferAssetNewContractDTO : ContractEquipDataDTO
    {
        [DataMember]
        public string NewNumber { get; set; }

        [DataMember]
        public string NewLineNumber { get; set; }

        [DataMember]
        public string NewHolderName { get; set; }

        [DataMember]
        public string NewSalaryNumber { get; set; }

        [DataMember]
        public string NewLocation { get; set; }

        [DataMember]
        public string ReturnDeliveryNumber { get; set; }

        [DataMember]
        public string SoDeliveryNumber { get; set; }

        [DataMember]
        public string DeliveryOrderToUser { get; set; }
    }
}