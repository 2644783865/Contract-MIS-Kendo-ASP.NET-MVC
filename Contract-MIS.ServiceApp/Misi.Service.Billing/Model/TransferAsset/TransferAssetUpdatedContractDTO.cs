using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.TransferAsset
{
    [DataContract]
    public class TransferAssetUpdatedContractDTO : TransferAssetOldContractDTO
    {
        [DataMember]
        public string UpdLocation { get; set; }
    }
}