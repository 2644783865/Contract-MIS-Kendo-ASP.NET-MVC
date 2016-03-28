using Misi.DAL.Billing.Model.Contract;

namespace Misi.DAL.Billing.Model.RoutingInfo
{
    public class NewContractLaptopRoutingInfo : NewContractRoutingInfoBase
    {
        private NewContractLaptopContract _contract;

        public NewContractLaptopContract Contract
        {
            get { return _contract ?? (_contract = new NewContractLaptopContract()); }
            set { _contract = value; }
        }
    }
}
