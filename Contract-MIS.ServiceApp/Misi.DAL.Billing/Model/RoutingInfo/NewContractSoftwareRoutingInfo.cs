using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class NewContractSoftwareRoutingInfo : NewContractRoutingInfoBase
    {
        private NewContractSoftwareContract _contract;

        public NewContractSoftwareContract Contract
        {
            get { return _contract ?? (_contract = new NewContractSoftwareContract()); }
            set { _contract = value; }
        }
    }
}
