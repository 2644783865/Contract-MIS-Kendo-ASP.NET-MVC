using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class NewContractIpPhoneRoutingInfo : NewContractRoutingInfoBase
    {
        private NewContractIpPhoneContract _contract;

        public NewContractIpPhoneContract Contract
        {
            get { return _contract ?? (_contract = new NewContractIpPhoneContract()); }
            set { _contract = value; }
        }
    }
}
