using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class TransferAssetByHolderRoutingInfo : TransferAssetRoutingInfo
    {
        private TransferAssetOldContract _oldContract;
        private TransferAssetNewContract _newContract;

        public TransferAssetOldContract OldContract
        {
            get { return _oldContract ?? (_oldContract = new TransferAssetOldContract()); }
            set { _oldContract = value; }
        }

        public TransferAssetNewContract NewContract
        {
            get { return _newContract ?? (_newContract = new TransferAssetNewContract()); }
            set { _newContract = value; }
        }
    }
}
