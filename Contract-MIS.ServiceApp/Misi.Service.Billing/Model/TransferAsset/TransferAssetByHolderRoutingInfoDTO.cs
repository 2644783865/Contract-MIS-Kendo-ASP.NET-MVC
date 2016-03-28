using System.Runtime.Serialization;

namespace Misi.Service.Billing.Model.TransferAsset
{
    [DataContract]
    public class TransferAssetByHolderRoutingInfoDTO : TransferAssetRoutingInfoDTO
    {
        private TransferAssetOldContractDTO _oldContract;
        private TransferAssetNewContractDTO _newContract;

        [DataMember]
        public TransferAssetOldContractDTO OldContract
        {
            get { return _oldContract ?? (_oldContract = new TransferAssetOldContractDTO()); }
            set { _oldContract = value; }
        }

        [DataMember]
        public TransferAssetNewContractDTO NewContract
        {
            get { return _newContract ?? (_newContract = new TransferAssetNewContractDTO()); }
            set { _newContract = value; }
        }
    }

}