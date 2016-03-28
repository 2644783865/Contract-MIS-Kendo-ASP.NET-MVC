using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class NewContractExtLineRoutingInfo : NewContractRoutingInfoBase
    {
        private NewContractExtLineContract _contract;

        public NewContractExtLineContract Contract
        {
            get { return _contract ?? (_contract = new NewContractExtLineContract()); }
            set { _contract = value; }
        }
    }
}
