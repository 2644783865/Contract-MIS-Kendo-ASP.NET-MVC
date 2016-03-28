using System.Runtime.Serialization;
using Misi.Service.Billing.Model.Common;

namespace Misi.Service.Billing.Model.TransferAsset
{
    [DataContract]
    public class TransferAssetByLocationRoutingInfoDTO : TransferAssetRoutingInfoDTO
    {
        private TransferAssetOldContractDTO _oldContract;
        private TransferAssetUpdatedContractDTO _updContract;

        [DataMember]
        public TransferAssetOldContractDTO OldContract
        {
            get { return _oldContract ?? (_oldContract = new TransferAssetOldContractDTO()); }
            set { _oldContract = value; }
        }

        [DataMember]
        public TransferAssetUpdatedContractDTO UpdContract
        {
            get { return _updContract ?? (_updContract = new TransferAssetUpdatedContractDTO()); }
            set { _updContract = value; }
        }
    }
}