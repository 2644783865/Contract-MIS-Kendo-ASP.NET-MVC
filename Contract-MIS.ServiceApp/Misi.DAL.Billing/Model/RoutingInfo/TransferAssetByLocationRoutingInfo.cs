using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class TransferAssetByLocationRoutingInfo : TransferAssetRoutingInfo
    {
        private TransferAssetOldContract _oldContract;
        private TransferAssetUpdatedContract _updContract;

        public TransferAssetOldContract OldContract
        {
            get { return _oldContract ?? (_oldContract = new TransferAssetOldContract()); }
            set { _oldContract = value; }
        }

        public TransferAssetUpdatedContract UpdContract
        {
            get { return _updContract ?? (_updContract = new TransferAssetUpdatedContract()); }
            set { _updContract = value; }
        }
    }
}
