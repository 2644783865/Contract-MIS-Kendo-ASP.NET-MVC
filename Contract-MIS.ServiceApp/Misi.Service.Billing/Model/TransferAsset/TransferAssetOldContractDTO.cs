using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.TransferAsset
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(TransferAssetUpdatedContractDTO))]
    public class TransferAssetOldContractDTO : ContractEquipDataDTO
    {
        [DataMember]
        public string OldNumber { get; set; }

        [DataMember]
        public string OldLineNumber { get; set; }

        [DataMember]
        public string OldHolderName { get; set; }

        [DataMember]
        public string OldSalaryNumber { get; set; }

        [DataMember]
        public string OldLocation { get; set; }
    }
}